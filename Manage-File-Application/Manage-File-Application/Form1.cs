using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_File_Application
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

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

            // Disable nút back, forward
            btnBack.Enabled = false;
            btnForward.Enabled = false;

            // Khởi tạo sort col trong listView
            lvwColumnSorter = new ListViewColumnSorter();
            listView.ListViewItemSorter = lvwColumnSorter;

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
            toolTip.SetToolTip(btnGo, "Open file by path");

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

                    TreeNode n = node.Nodes.Add(Path.GetFileName(dir));
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
            scanFile(fullPath);

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

            // Col content
            if (fileInfo.Extension == ".txt")
            {
                itemList.SubItems.Add(File.ReadAllText(fileInfo.ToString()));
            }
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
        private void scanFile(string path)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                listView.Items.Clear();
                numItems.Text = "Items: 0";
                txtPath.Text = path;

                // lấy danh sách các file trong thư mục path
                string[] arrFiles = Directory.GetFiles(path);

                foreach (string file in arrFiles)
                {
                    // duyệt qua các file có nội dung là text
                    if (file.ToLower().EndsWith(".txt") ||
                        file.ToLower().EndsWith(".doc") ||
                        file.ToLower().EndsWith(".docx") ||
                        file.ToLower().EndsWith(".pdf"))
                    {
                        addFileToListView(file);
                    }
                }

                // lấy danh sách các folder trong thư mục path
                string[] arrFolders = Directory.GetDirectories(path);

                foreach (string folder in arrFolders)
                {
                    addFolderToListView(folder);
                }

                // Đếm số file trong folder hiện tại
                numItems.Text = "Items: " + listView.Items.Count;

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
                MessageBox.Show(ex.Message);
            }
        }

        // Scan file in folder in txtPath
        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                scanFile(txtPath.Text);
            }
        }

        // Scan file in folder in txtPath
        private void btnGo_Click(object sender, EventArgs e)
        {
            scanFile(txtPath.Text);
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

        // Sorting theo column trên listview
        // Tham khảo Code
        // Chưa sort được size file
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            listView.Sort();
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

        // Bấm F2 để Rename File
        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && listView.SelectedItems.Count > 0)
            {
                listView.SelectedItems[0].BeginEdit();
            }
        }

        // Đổi tên file or folder trong hệ thống sau khi sửa trên listView
        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string path = listView.FocusedItem.SubItems[1].Text;

            var currentDir = Path.GetDirectoryName(path);

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
                    string newFolderName = Path.Combine(currentDir, e.Label);
                    // Bắt trùng tên folder
                    if (Directory.Exists(newFolderName))
                    {
                        MessageBox.Show("There is already a folder with the same name in this location", "Rename Folder");

                        e.CancelEdit = true;
                    }
                    else
                    {
                        Directory.Move(path, newFolderName);
                        refresh();
                    }
                }
                else  // file
                {
                    // Nối path với tên file sửa
                    string newFileName = Path.Combine(currentDir, e.Label);

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
                        refresh();
                    }
                }
            }
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

                scanFile(pathStack.Peek());
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

                scanFile(pathStack.Peek());
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
            deleteFileOrFolder();
        }

        private void deleteFileOrFolder()
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
                                DirectoryInfo folderdelete = (DirectoryInfo) item.Tag;
                                Directory.Delete(folderdelete.FullName, true);
                            }
                            else // File
                            {
                                FileInfo file = (FileInfo) item.Tag;
                                File.Delete(file.FullName);
                            }
                        }
                        refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void refresh()
        {
            string path = txtPath.Text;
            if (path != String.Empty)
                scanFile(path);
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
            deleteFileOrFolder();
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
            copyFile();
        }

        private void tsCopy_Click(object sender, EventArgs e)
        {
            copyFile();
        }

        private int numFilePaste = 0;

        private void copyFile()
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
                    numFilePaste = 0;
                    btnPaste.Enabled = true;

                    // Thêm file or folder cần copy vào danh sách tạm thời
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        arrCopy.Add(item.Tag);
                        //arrCopy.Add(item.SubItems[1].Text);
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
            cutFile();
        }

        private void tsCut_Click(object sender, EventArgs e)
        {
            cutFile();
        }

        private void cutFile()
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
                    numFilePaste = 0;
                    btnPaste.Enabled = true;

                    // Thêm file or folder cần di chuyển vào danh sách tạm thời
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        arrCut.Add(item.Tag);
                        //arrCut.Add(item.SubItems[1].Text);
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
                        DirectoryInfo folderpaste = (DirectoryInfo)tmp;
                        // Dùng hàm CopyorCutFolder() để paste ra folder copy
                        pasteFolderCopyOrCut(folderpaste.FullName, true);
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
                        DirectoryInfo folderpaste = (DirectoryInfo)tmp;
                        // Dùng hàm CopyorCutFolder() để paste ra folder copy
                        pasteFolderCopyOrCut(folderpaste.FullName, false);
                    }
                    else // file
                    {
                        FileInfo file = (FileInfo)tmp;
                        // Dùng hàm pasteFileCopyOrCut() để paste ra file
                        pasteFileCopyOrCut(file.FullName, false);
                    }
                }
            }
            else
            {
                MessageBox.Show("No files/folders have been copied or cut out yet!");
            }
            refresh();
        }

        private void pasteFolderCopyOrCut(string path, bool isCopy)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(path);
                string destinationPath = Path.Combine(txtPath.Text, folder.Name);

                DirectoryInfo destinationFolder = new DirectoryInfo(destinationPath);

                if (isCopy)
                {
                    copyAllInFolder(folder, destinationFolder);
                }
                else
                {
                    folder.MoveTo(destinationPath);
                    btnPaste.Enabled = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Paste Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyAllInFolder(DirectoryInfo folder, DirectoryInfo destinationFolder)
        {
            Directory.CreateDirectory(destinationFolder.FullName);

            foreach (FileInfo file in folder.GetFiles())
            {
                file.CopyTo(Path.Combine(destinationFolder.FullName, file.Name));
            }

            foreach (DirectoryInfo subFolder in folder.GetDirectories())
            {
                DirectoryInfo destPath = new DirectoryInfo(Path.Combine(destinationFolder.FullName, subFolder.Name));
                copyAllInFolder(subFolder, destPath);
            }
        }

        private void pasteFileCopyOrCut(string path, bool isCopy)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                string destinationPath = Path.Combine(txtPath.Text, file.Name);
                string newDestinationPath = destinationPath;

                if (isCopy)
                {
                    if (File.Exists(destinationPath))
                    {
                        var tmp = Path.GetFileNameWithoutExtension(file.Name) + " - Copy (" + numFilePaste + ")" + file.Extension;
                        newDestinationPath = Path.Combine(txtPath.Text, tmp);
                        numFilePaste++;
                    }
                    file.CopyTo(newDestinationPath);
                }
                else
                {
                    file.MoveTo(newDestinationPath);
                    btnPaste.Enabled = false;
                }
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
            // Tạo ra Folder với tên mặc định là New Folder
            DirectoryInfo curDirectory = new DirectoryInfo(txtPath.Text);
            string path = Path.Combine(curDirectory.FullName, "New Folder");
            string newFolderPath = path;
            int numFolder = 1;

            while (Directory.Exists(newFolderPath))
            {
                newFolderPath = path + " (" + numFolder + ")";
                numFolder++;
            }

            Directory.CreateDirectory(newFolderPath);
            refresh();
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
            // Tạo ra file txt với tên mặc định là New Text Document 
            DirectoryInfo curDirectory = new DirectoryInfo(txtPath.Text);
            string defaultFile = "New Text Document.txt";
            string path = Path.Combine(curDirectory.FullName, defaultFile);
            string newFilePath = path;

            int numFile = 1;

            while (File.Exists(newFilePath))
            {
                var tmp = Path.GetFileNameWithoutExtension(defaultFile) + " (" + numFile + ").txt";
                newFilePath = Path.Combine(curDirectory.FullName, tmp);
                numFile++;
            }

            // làm mới và update lại danh sách file
            File.Create(newFilePath).Close();

            refresh();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileOrFolder();
        }

        private void cbChooseSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = this.cbChooseSearch.SelectedItem.ToString();
            if (selectedItem == "Name")
            {
                txtSearch.Visible = true;
                dateTimePicker.Visible = false;
            }
            else if (selectedItem == "Content")
            {
                txtSearch.Visible = true;
                dateTimePicker.Visible = false;
            }
            else if (selectedItem == "Date Created")
            {
                txtSearch.Visible = false;
                dateTimePicker.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

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
    }
}
