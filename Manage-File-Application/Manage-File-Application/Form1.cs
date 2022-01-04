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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_File_Application
{
    public partial class Form1 : Form
    {
        private ElasticDAO elasticDAO;
        private ListViewColumnSorter lvwColumnSorter;

        // Stack chứa đường dẫn
        private Stack<string> pathStack = new Stack<string>();

        // Stack chứa đường dẫn bị xóa tạm htời
        private Stack<string> tmpPathPop = new Stack<string>();

        private ToolTip toolTip = new ToolTip();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Manager Files";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tránh khi load Form auto focus vào các textbox
            this.ActiveControl = numItems;

            // Khởi tạo Elastic
            elasticDAO = new ElasticDAO();
            
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
            toolTip.SetToolTip(btnDeleteFile, "Delete selected file");
            toolTip.SetToolTip(btnRenameFile, "Rename selected file name");
            toolTip.SetToolTip(btnGo, "Open file by path");
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
            // Scan file trong folder được chọn trong cây thư mục
            scanFileAsync(e.Node.FullPath);

            // Push đường dẫn folder vào stack để navigation
            pathStack.Push(e.Node.FullPath);

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
        private void addItemToListView(string item)
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
            FileInfo fileInfo = new FileInfo(item);

            // Hiển thị ảnh phù hợp với file
            imgList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName));

            // Đưa các thành phần của 1 file vào col tương ứng trong listview
            // Col Name
            ListViewItem itemList = new ListViewItem(fileInfo.Name, imgList.Images.Count - 1);

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
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            double sizesFile = fileInfo.Length;
            int tmp = 0;
            while (sizesFile >= 1024 && tmp < units.Length - 1)
            {
                tmp++;
                sizesFile = sizesFile / 1024;
            }

            itemList.SubItems.Add(String.Format("{0:0.##} {1}", sizesFile, units[tmp]));

            // Col content
            itemList.SubItems.Add(File.ReadAllText(fileInfo.ToString()));

            // update item (file) vào list view
            listView.Invoke((Action)(() =>
            {
                listView.BeginUpdate();
                listView.Items.Add(itemList);
                listView.EndUpdate();
            }));

            // Đếm số file trong folder hiện tại
            numItems.Text = "Items: " + listView.Items.Count;
        }

        // Scan file trong thư mục hiện tại theo đường dẫn để add vào listview
        private async Task scanFileAsync(string path)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                listView.Items.Clear();
                numItems.Text = "Items: 0";
                txtPath.Text = path;

                // lấy danh sách các file trong thư mục path
                string[] arrFiles = Directory.GetFiles(path);

                // lấy danh sách các file dưa lên elastic
                List<Models.File> elasticFiles = new List<Models.File>();

                // xoá index trên elastic
                bool response = await elasticDAO.DeleteAll();
                foreach (string file in arrFiles)
                {
                    // duyệt qua các file có nội dung là text
                    if (file.ToLower().EndsWith(".txt") ||
                        file.ToLower().EndsWith(".doc") ||
                        file.ToLower().EndsWith(".docx") ||
                        file.ToLower().EndsWith(".pdf"))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        await elasticDAO.Create(new Models.File()
                        {
                            Id = fileInfo.FullName,
                            Name = fileInfo.Name,
                            Path = file,
                            Content = File.ReadAllText(fileInfo.ToString()),
                            Extension = fileInfo.Extension,
                            DateCreate = fileInfo.CreationTime
                        });
                        addItemToListView(file);
                    }
                }
                
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex) // Có một số folder không cấp quyền truy cập sẽ lỗi
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
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
        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                Process.Start(listView.FocusedItem.SubItems[1].Text);
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

        // Hiển thị số item selected
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            numItemsSelected.Text = listView.SelectedIndices.Count.ToString() + " items selected";
        }

        // Bấm F2 để Rename File
        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && listView.SelectedItems.Count > 0)
            {
                listView.SelectedItems[0].BeginEdit();
            }
        }

        // Đổi tên file trong hệ thống sau khi sửa trên listView
        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                string filePath = listView.FocusedItem.SubItems[1].Text;

                var currentDir = Path.GetDirectoryName(filePath);

                // Kiểm tra đường dẫn có tồn tại hay không ?
                if (File.Exists(filePath))
                {
                    // Nối path với tên file sửa
                    string newFileName = currentDir + @"\" + e.Label;

                    // Kiểm tra tên file sửa có null 
                    if (e.Label != null)
                    {
                        // Kiểm tra tên file sửa có trùng với tên file nào hiện có trong thư mục
                        if (File.Exists(newFileName))
                        {
                            MessageBox.Show("There is already a file with the same name in this location");
                            e.CancelEdit = true;
                        }
                        else
                        {
                            // Đổi tên file
                            File.Move(filePath, newFileName);
                            scanFileAsync(currentDir);

                            // Thông báo đổi tên thành công
                            if (File.Exists(newFileName))
                            {
                                MessageBox.Show("The file was renamed to " + e.Label);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File does not exists");
                }
            }
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

        // Nút xóa 1 file
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                string filePath = listView.FocusedItem.SubItems[1].Text;

                var currentDir = Path.GetDirectoryName(filePath);

                // Kiểm tra đường dẫn có tồn tại hay không ?
                if (File.Exists(filePath))
                {
                    DialogResult result = MessageBox.Show("Do you want to delete " + filePath + "?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        // Xóa file
                        File.Delete(filePath);

                        scanFileAsync(currentDir);

                        // Kiểm tra lại xem file còn tồn tại không.
                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("File deleted...");
                        }
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("File does not exists");
                }
            }
        }

        // Nút Rename 1 file
        // Sau khi rename xong bấm enter
        private void btnRenameFile_Click(object sender, EventArgs e)
        {
            listView.SelectedItems[0].BeginEdit();
        }

        // View LargeIcon
        private void btnLargeIcon_Click(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;
            string path = txtPath.Text;
            if (path != String.Empty)
                scanFileAsync(path);
        }

        // View SmallIcon
        private void btnSmallIcon_Click(object sender, EventArgs e)
        {
            listView.View = View.SmallIcon;
            string path = txtPath.Text;
            if (path != String.Empty)
                scanFileAsync(path);
        }

        // View Details
        private void btnDetail_Click(object sender, EventArgs e)
        {
            listView.View = View.Details;
            string path = txtPath.Text;
            if (path != String.Empty)
                scanFileAsync(path);
        }

        // View List
        private void btnList_Click(object sender, EventArgs e)
        {
            listView.View = View.List;
            string path = txtPath.Text;
            if (path != String.Empty)
                scanFileAsync(path);
        }

        // View Tile
        private void btnTile_Click(object sender, EventArgs e)
        {
            listView.View = View.Tile;
            string path = txtPath.Text;
            if (path != String.Empty)
                scanFileAsync(path);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string nameField = txtSearchName.Text;
            string contentField = txtSearchContent.Text;
            List<Models.File> files = elasticDAO.Search(nameField);

            listView.Items.Clear();
            listView.Refresh();
            foreach (Models.File f in files)
            {
                addItemToListView(f.Path);
            }
        }
    }
}
