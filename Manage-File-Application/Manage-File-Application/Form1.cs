using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Manage_File_Application.ElasticCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_File_Application
{
    public partial class Form1 : Form
    {
        private ElasticDAO elasticDAO;
        private List<Model.File> elasticFiles;
        private CancellationTokenSource tokenSource;
        private bool cancelTasks;
        private List<Task> currTasks;
        private string currDirPath;

        // Stack chứa đường dẫn
        private Stack<string> pathStack = new Stack<string>();

        // Stack chứa đường dẫn bị xóa tạm htời
        private Stack<string> tmpPathPop = new Stack<string>();

        private ToolTip toolTip = new ToolTip();

        // List chứ copy, cut để paste
        ArrayList arrCopy = new ArrayList();
        ArrayList arrCut = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Manager Files";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tránh khi load Form auto focus vào các textbox
            this.ActiveControl = numItems;

            // Khởi tạo cây thư mục
            InitTreeFolder();

            // Khởi tạo Elastic
            elasticDAO = new ElasticDAO();

            currTasks = new List<Task>();
            cancelTasks = false;
            tokenSource = new CancellationTokenSource();

            // Disable nút back, forward
            btnBack.Enabled = false;
            btnForward.Enabled = false;

            // Title for element in form
            toolTip.SetToolTip(numItemsSelected, "Total item selected");
            toolTip.SetToolTip(numItems, "Total item count");
            toolTip.SetToolTip(btnBack, "Back");
            toolTip.SetToolTip(btnForward, "Forward");
            toolTip.SetToolTip(btnLargeIcon, "Display items with large icon view");
            toolTip.SetToolTip(btnSmallIcon, "Display items with small icon view");
            toolTip.SetToolTip(btnDetail, "Display items with detail view");
            toolTip.SetToolTip(btnList, "Display items with list view");
            toolTip.SetToolTip(btnTile, "Display items with title view");
            toolTip.SetToolTip(btnDelete, "Delete selected item");
            toolTip.SetToolTip(btnRename, "Rename selected item name");
            toolTip.SetToolTip(btnGo, "Open with path");
            toolTip.SetToolTip(btnSearch, "Search");
            toolTip.SetToolTip(btnShorcutKey, "Shorcut Key");
            toolTip.SetToolTip(btnCopy, "Copy (Ctrl + C)");
            toolTip.SetToolTip(btnCut, "Cut (Ctrl + X)");
            toolTip.SetToolTip(btnPaste, "Paste (Ctrl + V)");
            toolTip.SetToolTip(btnDelete, "Delete (Ctrl + D | Delete)");
            toolTip.SetToolTip(btnRename, "Rename (F2)");
            toolTip.SetToolTip(btnNewFile, "New File");
            toolTip.SetToolTip(btnNewFolder, "New Folder (Ctrl + Shift + N)");
            toolTip.SetToolTip(btnOpen, "Open file");

            // Set default cho cbChooseSearch
            cbChooseSearch.SelectedIndex = 0;
            txtSearch.Text = "Enter some text here";
            txtSearch.ForeColor = Color.Gray;

            // btn disable
            btnCopy.Enabled = false;
            btnPaste.Enabled = false;
            btnCut.Enabled = false;
            btnDelete.Enabled = false;
            btnRename.Enabled = false;
            btnOpen.Enabled = false;
        }

        private void InitTreeFolder()
        {
            // lấy danh sách các ổ đĩa
            string[] drives = Directory.GetLogicalDrives();

            TreeNode node = null;

            // duyệt từng phần tử (tên ổ đĩa), thêm vào TreeView
            foreach (string drive in drives)
            {
                // tạo node mới với tên ổ đĩa
                node = new TreeNode(drive);

                // add vào tree view
                treeFolder.Nodes.Add(node);

                // add một node tạm
                node.Nodes.Add("Temp");
            }
        }

        private void treeFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // node được chọn
            TreeNode node = e.Node;

            // xóa các node con (node Temp)
            node.Nodes.Clear();

            // chuyển sang icon folder mở
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            // load danh sách các thư mục con
            try
            {
                // duyệt qua các thư mục con
                foreach (string dir in Directory.GetDirectories(node.FullPath))
                {
                    // thêm các thư mục con vào tập nodes của node hiện tại
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);

                    // Bỏ qua folder ẩn, hệ thống
                    if ((dirInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
                        (dirInfo.Attributes & FileAttributes.System) == FileAttributes.System)
                    {
                        continue;
                    }

                    TreeNode n = node.Nodes.Add(System.IO.Path.GetFileName(dir));
                    n.Nodes.Add("Temp");
                }
            }
            catch { }
        }

        // Đổi icon khi đóng node
        private void treeFolder_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        // Chọn node trên cây
        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            openFolder(new DirectoryInfo(e.Node.FullPath).FullName);
        }

        private void openFolder(string fullPath)
        {
            // Scan file trong folder được chọn trong cây thư mục
            scanFileAsync(fullPath);

            // Push đường dẫn folder vào stack để navigation
            pathStack.Push(fullPath);

            // Xóa sạch tất cả đường dẫn folder xóa tạm thời
            // Disable nút forward
            if (tmpPathPop.Count > 0)
            {
                tmpPathPop.Clear();
                btnForward.Enabled = false;
            }

            // Enable nút back khi trong đường dẫn folder >= 2
            if (pathStack.Count > 1)
            {
                btnBack.Enabled = true;
            }
        }

        // Add file in ListView
        private void addFileToListView(string file)
        {
            // Check mode view để hiển thị icon phù hợp
            var modeView = listView.View.ToString();

            ImageList imgList = new ImageList();

            if (modeView == "Details" || modeView == "List" || modeView == "SmallIcon")
            {
                imgList = imageSmall;
            }
            else if (modeView == "Tile" || modeView == "LargeIcon")
            {
                imgList = imageLarge;
            }

            // Thao tác với file
            FileInfo fileInfo = new FileInfo(file);

            // Hiển thị ảnh phù hợp với file
            imgList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName));

            // Đưa các thành phần của 1 file vào col tương ứng trong listview
            // Col Name
            ListViewItem itemList = listView.Items.Add(fileInfo.Name, imgList.Images.Count - 1);

            // Tag
            itemList.Tag = fileInfo;

            // Col Path
            itemList.SubItems.Add(fileInfo.FullName);

            // Col Extension
            itemList.SubItems.Add(fileInfo.Extension);

            // Col Created
            //itemList.SubItems.Add(fileInfo.CreationTime.ToString("dd/MM/yyyy"));
            itemList.SubItems.Add(fileInfo.CreationTime.ToString());

            // Col Modified
            itemList.SubItems.Add(fileInfo.LastWriteTime.ToString());

            // Col size
            // Tính size file
            itemList.SubItems.Add(calFileSize(fileInfo.Length));

        }

        private string calFileSize(float fileSize)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB" };

            int tmp = 0;

            while (fileSize >= 1024 && tmp < units.Length - 1)
            {
                tmp++;
                fileSize = fileSize / 1024;
            }

            return String.Format("{0:0.##} {1}", fileSize, units[tmp]);
        }

        private void addFolderToListView(string folder)
        {
            // Thao tác với folder
            DirectoryInfo dirInfo = new DirectoryInfo(folder);

            // Ẩn file, folder hệ thống
            if ((dirInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
                (dirInfo.Attributes & FileAttributes.System) == FileAttributes.System)
            {
                return;
            }

            ListViewItem itemList = listView.Items.Add(dirInfo.Name);

            // img
            itemList.ImageIndex = 0;

            // Tag
            itemList.Tag = dirInfo;

            // path
            itemList.SubItems.Add(dirInfo.FullName);

            // extension
            itemList.SubItems.Add("Folder");

            // Create
            itemList.SubItems.Add(dirInfo.CreationTime.ToString());

            // Modified
            itemList.SubItems.Add(dirInfo.LastWriteTime.ToString());
        }

        // Scan file trong thư mục hiện tại theo đường dẫn để add vào listview
        private async Task scanFileAsync(string path)
        {
            try
            {
                elasticHttpSearchProgress.Value = 0;
                txtProcess.Text = 0 + "/" + 0;

                listView.ListViewItemSorter = null;
                this.Cursor = Cursors.WaitCursor;
                numItems.Text = "Items: 0";
                txtPath.Text = path;
                currDirPath = path;
                listView.Items.Clear();

                // lấy danh sách các file trong thư mục path
                string[] arrFiles = Directory.GetFiles(path);

                //// dừng task trước khi xoá index
                if (cancelTasks)
                {
                    tokenSource.Cancel();
                    cancelTasks = false;
                    tokenSource = new CancellationTokenSource();
                }

                // xoá index trên elastic
                bool response = await elasticDAO.DeleteAll();

                // List Files
                elasticFiles = new List<Model.File>();

                // Khởi tạo sort col trong listView
                foreach (string file in arrFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    // duyệt qua các file có nội dung là text

                    elasticFiles.Add(new Model.File()
                    {
                        Id = fileInfo.FullName,
                        Name = fileInfo.Name,
                        Path = file,
                        isFolder = false,
                        Extension = fileInfo.Extension,
                        DateCreate = fileInfo.CreationTime
                    });
                    addFileToListView(file);
                }

                // lấy danh sách các folder trong thư mục path
                string[] arrFolders = Directory.GetDirectories(path);

                foreach (string folder in arrFolders)
                {
                    FileInfo fileInfo = new FileInfo(folder);
                    elasticFiles.Add(new Model.File()
                    {
                        Id = fileInfo.FullName,
                        Name = fileInfo.Name,
                        Path = folder,
                        isFolder = true,
                        Extension = "",
                        DateCreate = fileInfo.CreationTime
                    });
                    addFolderToListView(folder);
                }

                DoTheElasticThings();

                // Đếm số file trong folder hiện tại
                numItems.Text = "Items: " + (new DirectoryInfo(path).GetDirectories().Length + new DirectoryInfo(path).GetFiles().Length);

                numItemsSelected.Text = listView.SelectedIndices.Count.ToString() + " items selected";

                // btn disable
                btnCopy.Enabled = false;
                btnCut.Enabled = false;
                btnDelete.Enabled = false;
                btnRename.Enabled = false;
                btnOpen.Enabled = false;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex) // Có một số folder không cấp quyền truy cập sẽ lỗi
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void scanFiles(string path)
        {
            try
            {
                listView.ListViewItemSorter = null;
                this.Cursor = Cursors.WaitCursor;
                numItems.Text = "Items: 0";
                txtPath.Text = path;
                currDirPath = path;
                listView.Items.Clear();

                // lấy danh sách các file trong thư mục path
                string[] arrFiles = Directory.GetFiles(path);

                // Khởi tạo sort col trong listView
                foreach (string file in arrFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    // duyệt qua các file có nội dung là text

                    addFileToListView(file);
                }

                // lấy danh sách các folder trong thư mục path
                string[] arrFolders = Directory.GetDirectories(path);

                foreach (string folder in arrFolders)
                {
                    addFolderToListView(folder);
                }

                // Đếm số file trong folder hiện tại
                numItems.Text = "Items: " + (new DirectoryInfo(path).GetDirectories().Length + new DirectoryInfo(path).GetFiles().Length);

                numItemsSelected.Text = listView.SelectedIndices.Count.ToString() + " items selected";

                // btn disable
                btnCopy.Enabled = false;
                btnCut.Enabled = false;
                btnDelete.Enabled = false;
                btnRename.Enabled = false;
                btnOpen.Enabled = false;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex) // Có một số folder không cấp quyền truy cập sẽ lỗi
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void DoTheElasticThings()
        {
            currTasks = new List<Task>();
            int currentIndex = 0;
            double taskFinished = 0;
            object lockObject = new object();
            foreach (Model.File f in elasticFiles)
            {
                cancelTasks = true;
                lock (lockObject)
                {
                    Task task = Task.Run(() => ReadFileAndAddElastic(f), tokenSource.Token).ContinueWith(t =>
                    {
                        if (f.Path.Contains(currDirPath))
                        {
                            taskFinished += 1;
                            txtProcess.Invoke((Action)(() =>
                            {
                                txtProcess.Text = taskFinished + "/" + elasticFiles.Count;
                            }));
                            currentIndex = (int)Math.Floor((taskFinished / elasticFiles.Count) * 100);
                            if (currentIndex <= 100)
                            {
                                elasticHttpSearchProgress.Invoke((Action)(() => elasticHttpSearchProgress.Value = currentIndex));
                            }
                            if (currentIndex == 100)
                            {
                                txtProcess.Invoke((Action)(() =>
                                {
                                    txtProcess.Text = "Ready to search";
                                }));
                            }
                        }
                    });
                    currTasks.Add(task);
                }
            }
        }

        private void ReadFileAndAddElastic(Model.File f)
        {
            if (f.Extension.Equals(".docx") || f.Extension.Equals(".doc") ||
                f.Extension.Equals(".pdf") || f.Extension.Equals(".txt"))
                f.Content = ReadContent(f.Extension, f.Path);
            elasticDAO.Create(f);
        }

        // Scan file in folder in txtPath
        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                scanFileAsync(txtPath.Text);
            }
        }

        // Scan file in folder in txtPath
        private void btnGo_Click(object sender, EventArgs e)
        {
            scanFileAsync(txtPath.Text);
        }

        // Mở file theo định dạng tương ứng
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            openFileOrFolder();
        }

        private void openFileOrFolder()
        {
            try
            {
                // Folder
                if (listView.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
                {
                    var curDir = (DirectoryInfo)listView.SelectedItems[0].Tag;
                    txtPath.Text = curDir.FullName;
                    openFolder(txtPath.Text);
                }
                else // File
                {
                    Process.Start(listView.FocusedItem.SubItems[1].Text);
                }
            }
            catch
            {
                MessageBox.Show("Can't open");
                return;
            }
        }

        // item selected
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            numItemsSelected.Text = listView.SelectedIndices.Count.ToString() + " items selected";
            if (listView.SelectedItems.Count == 0)
            {
                btnCopy.Enabled = false;
                btnCut.Enabled = false;
                btnDelete.Enabled = false;
                btnRename.Enabled = false;
                btnOpen.Enabled = false;
            }
            else
            {
                btnCopy.Enabled = true;
                btnCut.Enabled = true;
                btnDelete.Enabled = true;
                btnRename.Enabled = true;
                btnOpen.Enabled = true;
            }

        }

        // Key Shorcut
        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                if (e.KeyCode == Keys.F2)
                {
                    listView.SelectedItems[0].BeginEdit();
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    copyFileOrFolder();
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    cutFileOrFolder();
                }
                else if (e.KeyCode == Keys.Delete || e.Control && e.KeyCode == Keys.D)
                {
                    deleteFileOrFolderAsync();
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    checkPaste();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    refresh();
                }
                else if (e.Control && e.Shift && e.KeyCode == Keys.N)
                {
                    newFolder();
                }
            }
            else 
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    checkPaste();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    refresh();
                }
                else if (e.Control &&  e.Shift && e.KeyCode == Keys.N)
                {
                    newFolder();
                }
            }
        }

        // Đổi tên file or folder trong hệ thống sau khi sửa trên listView
        private void listView_AfterLabelEditAsync(object sender, LabelEditEventArgs e)
        {
            string path = listView.FocusedItem.SubItems[1].Text;

            var currentDir = System.IO.Path.GetDirectoryName(path);

            ListViewItem item = listView.SelectedItems[0];

            // Nếu không thay đổi tên
            if (string.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }
            else if (!checkFileName(e.Label)) // Kiểm tra kí tự đặc biệt
            {
                MessageBox.Show(@"A file/folder name can't contain any of the following characters: \ / : * ? '' < > |", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
            else
            {
                // folder
                if (item.Tag.GetType() == typeof(DirectoryInfo))
                {
                    string newFolderName = System.IO.Path.Combine(currentDir, e.Label);
                    // Bắt trùng tên folder
                    if (Directory.Exists(newFolderName))
                    {
                        MessageBox.Show("There is already a folder with the same name in this location", "Rename Folder");

                        e.CancelEdit = true;
                    }
                    else
                    {
                        Directory.Move(path, newFolderName);
                        DirectoryInfo dirInfo = new DirectoryInfo(newFolderName);
                        Task task = Task.Run((Action)(() => {
                            elasticDAO.Delete(path);
                            elasticDAO.Create(new Model.File()
                            {
                                Id = dirInfo.FullName,
                                Name = dirInfo.Name,
                                Path = dirInfo.FullName,
                                isFolder = true,
                                Extension = "",
                                DateCreate = dirInfo.CreationTime
                            });
                        }));
                    }
                }
                else  // file
                {
                    // Nối path với tên file sửa
                    string newFileName = System.IO.Path.Combine(currentDir, e.Label);

                    // Kiểm tra tên file sửa có trùng với tên file nào hiện có trong thư mục
                    if (File.Exists(newFileName))
                    {
                        MessageBox.Show("There is already a file with the same name in this location", "Rename File");
                        e.CancelEdit = true;
                    }
                    else
                    {
                        // Đổi tên file
                        File.Move(path, newFileName);
                        FileInfo fileInfo = new FileInfo(newFileName);
                        Task task = Task.Run((Action)(() => {
                            elasticDAO.Delete(path);
                            elasticDAO.Create(new Model.File()
                            {
                                Id = fileInfo.FullName,
                                Name = fileInfo.Name,
                                Path = fileInfo.FullName,
                                isFolder = false,
                                Content = ReadContent(fileInfo.Extension, fileInfo.FullName),
                                Extension = fileInfo.Extension,
                                DateCreate = fileInfo.CreationTime
                            });
                        }));
                    }
                }
            }
            listView.BeginInvoke(new MethodInvoker(() => refresh()));
        }

        // Kiểm tra kí tự đặc biệt
        public static bool checkFileName(string fileName)
        {
            const string errChar = "\\/:*?\"<>|";

            foreach (char ch in errChar)
            {
                if (fileName.Contains(ch.ToString()))
                    return false;
            }
            return true;
        }

        // Nút quay lại folder trước đó
        // Nếu trong stack path trên 2 thì thực hiện back
        // Pop đường dẫn hiện tại và lưu vào stack tmp
        // Quay lại folder trước đó
        // Enable nút forward
        // Nếu trong stack path còn 1 thì disable nút back
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (pathStack.Count > 1)
            {
                tmpPathPop.Push(pathStack.Pop());

                scanFileAsync(pathStack.Peek());
                txtPath.Text = pathStack.Peek();

                btnForward.Enabled = true;

                if (pathStack.Count == 1)
                {
                    btnBack.Enabled = false;
                }
            }
        }

        // Nút forward folder sau khi back
        // Nếu trong stack tmp > 0 thì thực hiện forward
        // Pop đường dẫn trong stack tmp và lưu vào stack path
        // Forward folder
        // Enable nút back
        // Nếu trong stack tmp còn 0 thì disable nút forward
        private void btnForward_Click(object sender, EventArgs e)
        {
            if (tmpPathPop.Count > 0)
            {
                pathStack.Push(tmpPathPop.Pop());

                scanFileAsync(pathStack.Peek());
                txtPath.Text = pathStack.Peek();

                btnBack.Enabled = true;

                if (tmpPathPop.Count == 0)
                {
                    btnForward.Enabled = false;
                }
            }
        }

        // Nút xóa file or folder
        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteFileOrFolderAsync();
        }

        private async Task deleteFileOrFolderAsync()
        {
            // Chọn file or folder cần xóa
            if (listView.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to delete " + listView.SelectedItems.Count + " item(s) ?",
                    "Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation
                );

                // Yes
                if (result.Equals(DialogResult.Yes))
                {
                    try
                    {
                        // Lấy item chọn
                        foreach (ListViewItem item in listView.SelectedItems)
                        {
                            // Folder
                            if (item.Tag.GetType() == typeof(DirectoryInfo))
                            {
                                DirectoryInfo folderdelete = (DirectoryInfo)item.Tag;
                                Directory.Delete(folderdelete.FullName, true);
                                refresh();
                            }
                            else // File
                            {
                                FileInfo file = (FileInfo)item.Tag;
                                File.Delete(file.FullName);
                                refresh();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(ex.StackTrace);
                    }
                }
                else { } // No
            }
        }

        // Nút Rename file or folder
        // Sau khi rename xong bấm enter
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                listView.SelectedItems[0].BeginEdit();
            }
        }

        // View LargeIcon
        private void btnLargeIcon_Click(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;
            refresh();
        }

        // View SmallIcon
        private void btnSmallIcon_Click(object sender, EventArgs e)
        {
            listView.View = View.SmallIcon;
            refresh();
        }

        // View Details
        private void btnDetail_Click(object sender, EventArgs e)
        {
            listView.View = View.Details;
            refresh();
        }

        // View List
        private void btnList_Click(object sender, EventArgs e)
        {
            listView.View = View.List;
            refresh();
        }

        // View Tile
        private void btnTile_Click(object sender, EventArgs e)
        {
            listView.View = View.Tile;
            refresh();
        }

        private void refreshWithElastic()
        {
            string path = txtPath.Text;
            if (path != String.Empty)
                scanFileAsync(path);
        }

        private void refresh()
        {
            string path = txtPath.Text;
            if (path != String.Empty)
                scanFiles(path);
        }

        // Context Menu
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            Point curPoint = listView.PointToClient(Cursor.Position);

            ListViewItem item = listView.GetItemAt(curPoint.X, curPoint.Y);

            if (item == null)
            {
                tsOpen.Visible = false;
                tsDelete.Visible = false;
                tsRename.Visible = false;
                tsRefresh.Visible = true;
                tsRefreshElastic.Visible = true;
                tsCopy.Visible = false;
                tsCut.Visible = false;
                tsPaste.Visible = true;
                tsLine1.Visible = false;
                tsNewFile.Visible = true;
                tsNewFolder.Visible = true;

                if (arrCopy.Count > 0 || arrCut.Count > 0)
                {
                    tsPaste.Enabled = true;
                }
                else
                {
                    tsPaste.Enabled = false;
                }
            }
            else
            {
                tsOpen.Visible = true;
                tsDelete.Visible = true;
                tsRename.Visible = true;
                tsRefresh.Visible = false;
                tsRefreshElastic.Visible = false;
                tsCopy.Visible = true;
                tsCut.Visible = true;
                tsPaste.Visible = false;
                tsNewFile.Visible = false;
                tsNewFolder.Visible = false;
                tsLine1.Visible = true;
                tsLine3.Visible = false;
            }
        }

        private void tsOpen_Click(object sender, EventArgs e)
        {
            openFileOrFolder();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            deleteFileOrFolderAsync();
        }

        private void tsRename_Click(object sender, EventArgs e)
        {
            listView.SelectedItems[0].BeginEdit();
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            copyFileOrFolder();
        }

        private void tsCopy_Click(object sender, EventArgs e)
        {
            copyFileOrFolder();
        }

        private void copyFileOrFolder()
        {
            // Nếu chưa chọn file or folder để copy
            if (listView.SelectedItems.Count < 1)
            {
                MessageBox.Show("You need to select File/Folder to copy!");
            }
            else
            {
                try
                {
                    arrCopy.Clear();
                    arrCut.Clear();
                    btnPaste.Enabled = true;

                    // Thêm file or folder cần copy vào danh sách tạm thời
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        arrCopy.Add(item.Tag);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            cutFileOrFolder();
        }

        private void tsCut_Click(object sender, EventArgs e)
        {
            cutFileOrFolder();
        }

        private void cutFileOrFolder()
        {
            // Nếu chưa chọn folder hoặc file để cut
            if (listView.SelectedItems.Count < 1)
            {
                MessageBox.Show("You need to select File/Folder to Cut!");
            }
            else
            {
                try
                {
                    arrCut.Clear();
                    arrCopy.Clear();
                    btnPaste.Enabled = true;

                    // Thêm file or folder cần di chuyển vào danh sách tạm thời
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        arrCut.Add(item.Tag);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Cut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            checkPaste();
        }

        private void tsPaste_Click(object sender, EventArgs e)
        {
            checkPaste();
        }

        private void checkPaste()
        {
            // Nếu danh sách đang chứa các file copy
            if (arrCopy.Count > 0)
            {
                //Lấy danh sách các file đang copy
                foreach (var tmp in arrCopy)
                {
                    // folder
                    if (tmp.GetType() == typeof(DirectoryInfo))
                    {
                        DirectoryInfo folder = (DirectoryInfo)tmp;
                        // Dùng hàm CopyorCutFolder() để paste ra folder copy
                        pasteFolderCopyOrCut(folder.FullName, true);
                    }
                    else // file
                    {
                        FileInfo file = (FileInfo)tmp;
                        // Dùng hàm pasteFileCopyOrCut() để paste ra file copy
                        pasteFileCopyOrCut(file.FullName, true);
                    }
                }
            }
            // Nếu danh sách đang chứa các file Cut
            else if (arrCut.Count > 0)
            {
                // Lấy danh sách các file đang di chuyển
                foreach (var tmp in arrCut)
                {
                    // folder
                    if (tmp.GetType() == typeof(DirectoryInfo))
                    {
                        DirectoryInfo folder = (DirectoryInfo)tmp;
                        // Dùng hàm CopyorCutFolder() để paste ra folder copy
                        pasteFolderCopyOrCut(folder.FullName, false);
                        DoTheElasticThings();
                    }
                    else // file
                    {
                        FileInfo file = (FileInfo)tmp;
                        // Dùng hàm pasteFileCopyOrCut() để paste ra file
                        pasteFileCopyOrCut(file.FullName, false);
                        DoTheElasticThings();
                    }
                }
            }
            else
            {
                MessageBox.Show("No files/folders have been copied or cut out yet!");
            }
        }

        private void pasteFolderCopyOrCut(string path, bool isCopy)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(path);
                string destinationPath = System.IO.Path.Combine(txtPath.Text, folder.Name);

                DirectoryInfo destinationFolder = new DirectoryInfo(destinationPath);

                if (isCopy)
                {
                    copyAllInFolder(path, destinationPath);
                }
                else
                {
                    folder.MoveTo(destinationPath);
                    btnPaste.Enabled = false;
                }

                elasticFiles.Add(new Model.File()
                {
                    Id = folder.FullName,
                    Name = folder.Name,
                    Path = folder.FullName,
                    isFolder = true,
                    Extension = folder.Extension,
                    DateCreate = folder.CreationTime
                });

                refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Paste Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyAllInFolder(string sourceDirName, string destinationPath)
        {
            DirectoryInfo folder = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] folders = folder.GetDirectories();

            string newDestinationPath = destinationPath;

            // If the destination directory does not exist -> create it
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            else
            {
                int num = 0;
                while (Directory.Exists(destinationPath))
                {
                    var tmp = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(destinationPath)) + " - Copy (" + num + ")";
                    newDestinationPath = System.IO.Path.Combine(txtPath.Text, tmp);
                    destinationPath = newDestinationPath;
                    num++;
                }
                Directory.CreateDirectory(destinationPath);
            }

            // Get the file contents of the directory to copy
            FileInfo[] files = folder.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file
                string tempPath = System.IO.Path.Combine(destinationPath, file.Name);

                // Copy the file
                file.CopyTo(tempPath, false);
            }

            // Copy the subFolder
            foreach (DirectoryInfo subFolder in folders)
            {
                // Create the subFolder
                string temppath = System.IO.Path.Combine(destinationPath, subFolder.Name);

                // Copy the subFolder
                copyAllInFolder(subFolder.FullName, temppath);
            }
        }

        // paste file copy or cut
        private void pasteFileCopyOrCut(string path, bool isCopy)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                string destinationPath = System.IO.Path.Combine(txtPath.Text, file.Name);
                string newDestinationPath = destinationPath;

                if (isCopy)
                {
                    // Copy - nếu file trùng tên thì thêm chữ Copy (num)
                    int num = 0;
                    while (File.Exists(destinationPath))
                    {
                        var tmp = System.IO.Path.GetFileNameWithoutExtension(file.Name) + " - Copy (" + num + ")" + file.Extension;
                        newDestinationPath = System.IO.Path.Combine(txtPath.Text, tmp);
                        destinationPath = newDestinationPath;
                        num++;
                    }
                    file.CopyTo(newDestinationPath);
                }
                else // cut
                {
                    file.MoveTo(destinationPath);
                    btnPaste.Enabled = false;
                }

                elasticFiles.Add(new Model.File()
                {
                    Id = file.FullName,
                    Name = file.Name,
                    Path = file.FullName,
                    isFolder = false,
                    Extension = file.Extension,
                    DateCreate = file.CreationTime
                });

                refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Paste File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            newFolder();
        }

        private void tsNewFolder_Click(object sender, EventArgs e)
        {
            newFolder();
        }

        private void newFolder()
        {
            try
            {
                // Tạo ra Folder với tên mặc định là New Folder
                DirectoryInfo curDirectory = new DirectoryInfo(txtPath.Text);
                string path = System.IO.Path.Combine(curDirectory.FullName, "New Folder");
                string newFolderPath = path;
                int numFolder = 1;

                // Nếu tên folder trùng thì thêm (num) sau tên
                while (Directory.Exists(newFolderPath))
                {
                    newFolderPath = path + " (" + numFolder + ")";
                    numFolder++;
                }

                Directory.CreateDirectory(newFolderPath);
                DirectoryInfo directoryInfo = new DirectoryInfo(newFolderPath);
                if (elasticDAO.Create(new Model.File()
                {
                    Id = directoryInfo.FullName,
                    Name = directoryInfo.Name,
                    Path = newFolderPath,
                    isFolder = true,
                    Extension = directoryInfo.Extension,
                    DateCreate = directoryInfo.CreationTime
                }))
                {
                    addFolderToListView(newFolderPath);
                    refresh();
                    int index = listView.FindItemWithText(newFolderPath).Index;
                    listView.Items[index].Selected = true;
                    listView.Items[index].BeginEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void tsNewFile_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void newFile()
        {
            try
            {
                // Tạo ra file txt với tên mặc định là New Text Document 
                DirectoryInfo curDirectory = new DirectoryInfo(txtPath.Text);
                string defaultFile = "New Text Document.txt";
                string path = System.IO.Path.Combine(curDirectory.FullName, defaultFile);
                string newFilePath = path;

                int numFile = 1;
                while (File.Exists(newFilePath))
                {
                    var tmp = System.IO.Path.GetFileNameWithoutExtension(defaultFile) + " (" + numFile + ").txt";
                    newFilePath = System.IO.Path.Combine(curDirectory.FullName, tmp);
                    numFile++;
                }

                // làm mới và update lại danh sách file
                File.Create(newFilePath).Close();
                FileInfo fileInfo = new FileInfo(newFilePath);
                if (elasticDAO.Create(new Model.File()
                {
                    Id = fileInfo.FullName,
                    Name = fileInfo.Name,
                    Path = newFilePath,
                    isFolder = false,
                    Extension = fileInfo.Extension,
                    DateCreate = fileInfo.CreationTime
                }))
                {
                    addFileToListView(newFilePath);
                    refresh();
                    int index = listView.FindItemWithText(newFilePath).Index;
                    listView.Items[index].Selected = true;
                    listView.Items[index].BeginEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileOrFolder();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currDirPath))
            {
                MessageBox.Show("Please click a folder to be able to search", "Unable to search");
            }
            else
            {
                int selectedIndx = cbChooseSearch.SelectedIndex;
                string keyword = txtSearch.Text;

                List<Model.File> files = elasticDAO.SearchByField(selectedIndx, keyword);
                // Clear list view 
                listView.Items.Clear();
                listView.Refresh();
                // Thêm file vao list
                foreach (Model.File f in files)
                {
                    if (!f.isFolder)
                    {
                        if (f.Path.Contains(currDirPath))
                            addFileToListView(f.Path);
                    }
                }

                // Thêm folder vào list
                foreach (Model.File f in files)
                {
                    if (f.isFolder)
                    {
                        if (f.Path.Contains(currDirPath))
                            addFolderToListView(f.Path);
                    }
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter some text here")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Enter some text here";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private string ReadContent(string extension, string path)
        {
            try
            {
                if (extension.Equals(".doc") || extension.Equals(".docx"))
                {
                    return GetTextFromWord(path);
                }
                else if (extension.Equals(".pdf"))
                {
                    return GetTextFromPDF(path);
                }
                else if (extension.Equals(".txt"))
                {
                    return GetTextFromText(path);
                }
            }
            catch
            {
                return "";
            }
            return "";
        }

        private string GetTextFromPDF(string path)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();
        }

        private string GetTextFromWord(object path)
        {
            StringBuilder text = new StringBuilder();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                text.Append(" " + docs.Paragraphs[i + 1].Range.Text.ToString());
            }
            docs.Close();
            word.Quit();
            return text.ToString();
        }
        private string GetTextFromText(string path)
        {
            string text = File.ReadAllText(path);

            return text.ToString();
        }

        private void btnShorcutKey_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Copy \t\t Ctrl + C \n" +
                "Cut \t\t Ctrl + X \n" +
                "Paste \t\t Ctrl + V \n" +
                "Delete \t\t Ctrl + D | Delete \n" +
                "New Folder \t Ctrl + Shift + N\n" +
                "Rename \t\t F2 \n" +
                "Refresh \t\t F5",
                "Shortcut Key",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void tsRefreshElastic_Click(object sender, EventArgs e)
        {
            refreshWithElastic();
        }
    }
}
