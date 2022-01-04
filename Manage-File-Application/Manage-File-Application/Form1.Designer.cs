
namespace Manage_File_Application
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.numItemsSelected = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.funcBox = new System.Windows.Forms.GroupBox();
            this.btnRenameFile = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imageSmall = new System.Windows.Forms.ImageList(this.components);
            this.viewsBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnTile = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnSmallIcon = new System.Windows.Forms.Button();
            this.btnLargeIcon = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeFolder = new System.Windows.Forms.TreeView();
            this.imageTreeFolder = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageLarge = new System.Windows.Forms.ImageList(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchContent = new System.Windows.Forms.TextBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.GroupBox();
            this.numItems = new System.Windows.Forms.Label();
            this.funcBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.viewsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.searchBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // numItemsSelected
            // 
            this.numItemsSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numItemsSelected.AutoSize = true;
            this.numItemsSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numItemsSelected.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.numItemsSelected.Location = new System.Drawing.Point(821, 471);
            this.numItemsSelected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numItemsSelected.Name = "numItemsSelected";
            this.numItemsSelected.Size = new System.Drawing.Size(99, 13);
            this.numItemsSelected.TabIndex = 16;
            this.numItemsSelected.Text = "0 items selected";
            this.numItemsSelected.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(2, 2);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 24);
            this.btnBack.TabIndex = 3;
            this.btnBack.Tag = "";
            this.btnBack.Text = "←";
            this.btnBack.UseCompatibleTextRendering = true;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(939, 2);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(55, 24);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnForward
            // 
            this.btnForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Location = new System.Drawing.Point(47, 2);
            this.btnForward.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(40, 24);
            this.btnForward.TabIndex = 4;
            this.btnForward.Text = "→";
            this.btnForward.UseCompatibleTextRendering = true;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(92, 4);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(843, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPath_KeyDown);
            // 
            // funcBox
            // 
            this.funcBox.Controls.Add(this.btnRenameFile);
            this.funcBox.Controls.Add(this.btnDeleteFile);
            this.funcBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcBox.Location = new System.Drawing.Point(230, 8);
            this.funcBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.funcBox.Name = "funcBox";
            this.funcBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.funcBox.Size = new System.Drawing.Size(243, 81);
            this.funcBox.TabIndex = 14;
            this.funcBox.TabStop = false;
            this.funcBox.Text = "Function";
            // 
            // btnRenameFile
            // 
            this.btnRenameFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnRenameFile.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameFile.Image")));
            this.btnRenameFile.Location = new System.Drawing.Point(66, 17);
            this.btnRenameFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRenameFile.Name = "btnRenameFile";
            this.btnRenameFile.Size = new System.Drawing.Size(57, 49);
            this.btnRenameFile.TabIndex = 5;
            this.btnRenameFile.UseVisualStyleBackColor = false;
            this.btnRenameFile.Click += new System.EventHandler(this.btnRenameFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.Image")));
            this.btnDeleteFile.Location = new System.Drawing.Point(4, 17);
            this.btnDeleteFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(57, 49);
            this.btnDeleteFile.TabIndex = 4;
            this.btnDeleteFile.UseVisualStyleBackColor = false;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Controls.Add(this.btnBack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnForward, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPath, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 94);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(996, 28);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // imageSmall
            // 
            this.imageSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // viewsBox
            // 
            this.viewsBox.Controls.Add(this.label7);
            this.viewsBox.Controls.Add(this.label6);
            this.viewsBox.Controls.Add(this.label5);
            this.viewsBox.Controls.Add(this.label4);
            this.viewsBox.Controls.Add(this.label3);
            this.viewsBox.Controls.Add(this.btnDetail);
            this.viewsBox.Controls.Add(this.btnTile);
            this.viewsBox.Controls.Add(this.btnList);
            this.viewsBox.Controls.Add(this.btnSmallIcon);
            this.viewsBox.Controls.Add(this.btnLargeIcon);
            this.viewsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewsBox.Location = new System.Drawing.Point(11, 8);
            this.viewsBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.viewsBox.Name = "viewsBox";
            this.viewsBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.viewsBox.Size = new System.Drawing.Size(214, 81);
            this.viewsBox.TabIndex = 15;
            this.viewsBox.TabStop = false;
            this.viewsBox.Text = "Views";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(172, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 14);
            this.label7.TabIndex = 22;
            this.label7.Text = "Tiles";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(130, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "Details";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "List";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "Small";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "Large";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDetail
            // 
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.Location = new System.Drawing.Point(130, 17);
            this.btnDetail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(38, 41);
            this.btnDetail.TabIndex = 5;
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnTile
            // 
            this.btnTile.Image = ((System.Drawing.Image)(resources.GetObject("btnTile.Image")));
            this.btnTile.Location = new System.Drawing.Point(172, 17);
            this.btnTile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTile.Name = "btnTile";
            this.btnTile.Size = new System.Drawing.Size(38, 41);
            this.btnTile.TabIndex = 4;
            this.btnTile.UseVisualStyleBackColor = true;
            this.btnTile.Click += new System.EventHandler(this.btnTile_Click);
            // 
            // btnList
            // 
            this.btnList.Image = ((System.Drawing.Image)(resources.GetObject("btnList.Image")));
            this.btnList.Location = new System.Drawing.Point(88, 17);
            this.btnList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(38, 41);
            this.btnList.TabIndex = 3;
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnSmallIcon
            // 
            this.btnSmallIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnSmallIcon.Image")));
            this.btnSmallIcon.Location = new System.Drawing.Point(46, 17);
            this.btnSmallIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSmallIcon.Name = "btnSmallIcon";
            this.btnSmallIcon.Size = new System.Drawing.Size(38, 41);
            this.btnSmallIcon.TabIndex = 2;
            this.btnSmallIcon.UseVisualStyleBackColor = true;
            this.btnSmallIcon.Click += new System.EventHandler(this.btnSmallIcon_Click);
            // 
            // btnLargeIcon
            // 
            this.btnLargeIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnLargeIcon.Image")));
            this.btnLargeIcon.Location = new System.Drawing.Point(4, 17);
            this.btnLargeIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLargeIcon.Name = "btnLargeIcon";
            this.btnLargeIcon.Size = new System.Drawing.Size(38, 41);
            this.btnLargeIcon.TabIndex = 0;
            this.btnLargeIcon.UseVisualStyleBackColor = true;
            this.btnLargeIcon.Click += new System.EventHandler(this.btnLargeIcon_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(9, 128);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeFolder);
            this.splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Panel2MinSize = 200;
            this.splitContainer.Size = new System.Drawing.Size(996, 341);
            this.splitContainer.SplitterDistance = 216;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 17;
            // 
            // treeFolder
            // 
            this.treeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFolder.CausesValidation = false;
            this.treeFolder.HotTracking = true;
            this.treeFolder.ImageIndex = 0;
            this.treeFolder.ImageList = this.imageTreeFolder;
            this.treeFolder.Location = new System.Drawing.Point(0, 0);
            this.treeFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeFolder.Name = "treeFolder";
            this.treeFolder.SelectedImageIndex = 0;
            this.treeFolder.ShowLines = false;
            this.treeFolder.Size = new System.Drawing.Size(218, 342);
            this.treeFolder.TabIndex = 4;
            this.treeFolder.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFolder_BeforeCollapse);
            this.treeFolder.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFolder_BeforeExpand);
            this.treeFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolder_AfterSelect);
            // 
            // imageTreeFolder
            // 
            this.imageTreeFolder.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageTreeFolder.ImageStream")));
            this.imageTreeFolder.TransparentColor = System.Drawing.Color.Transparent;
            this.imageTreeFolder.Images.SetKeyName(0, "folder.png");
            this.imageTreeFolder.Images.SetKeyName(1, "folder_open.png");
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.LabelEdit = true;
            this.listView.LargeImageList = this.imageLarge;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(779, 342);
            this.listView.SmallImageList = this.imageSmall;
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_AfterLabelEdit);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Extension";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Created";
            this.columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Modified";
            this.columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Size";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Content";
            this.columnHeader7.Width = 100;
            // 
            // imageLarge
            // 
            this.imageLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageLarge.ImageSize = new System.Drawing.Size(64, 64);
            this.imageLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(442, 22);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 49);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchContent
            // 
            this.txtSearchContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchContent.Location = new System.Drawing.Point(57, 53);
            this.txtSearchContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchContent.Name = "txtSearchContent";
            this.txtSearchContent.Size = new System.Drawing.Size(381, 19);
            this.txtSearchContent.TabIndex = 3;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchName.Location = new System.Drawing.Point(57, 22);
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(381, 19);
            this.txtSearchName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Content:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Controls.Add(this.btnSearch);
            this.searchBox.Controls.Add(this.txtSearchContent);
            this.searchBox.Controls.Add(this.txtSearchName);
            this.searchBox.Controls.Add(this.label2);
            this.searchBox.Controls.Add(this.label1);
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(478, 8);
            this.searchBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchBox.Name = "searchBox";
            this.searchBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchBox.Size = new System.Drawing.Size(522, 81);
            this.searchBox.TabIndex = 13;
            this.searchBox.TabStop = false;
            this.searchBox.Text = "Search";
            // 
            // numItems
            // 
            this.numItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numItems.AutoSize = true;
            this.numItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numItems.Location = new System.Drawing.Point(952, 471);
            this.numItems.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numItems.Name = "numItems";
            this.numItems.Size = new System.Drawing.Size(52, 13);
            this.numItems.TabIndex = 12;
            this.numItems.Text = "Items: 0";
            this.numItems.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 493);
            this.Controls.Add(this.numItemsSelected);
            this.Controls.Add(this.funcBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.viewsBox);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.numItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Manager Files";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.funcBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.viewsBox.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.searchBox.ResumeLayout(false);
            this.searchBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numItemsSelected;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.GroupBox funcBox;
        private System.Windows.Forms.Button btnRenameFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ImageList imageSmall;
        private System.Windows.Forms.GroupBox viewsBox;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnTile;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnSmallIcon;
        private System.Windows.Forms.Button btnLargeIcon;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeFolder;
        private System.Windows.Forms.ImageList imageTreeFolder;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ImageList imageLarge;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchContent;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox searchBox;
        private System.Windows.Forms.Label numItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

