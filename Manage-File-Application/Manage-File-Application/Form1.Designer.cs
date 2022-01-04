
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
            this.btnRename = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imageSmall = new System.Windows.Forms.ImageList(this.components);
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLine1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.imageLarge = new System.Windows.Forms.ImageList(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.numItems = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbChooseSearch = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tsNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLine3 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // numItemsSelected
            // 
            this.numItemsSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numItemsSelected.AutoSize = true;
            this.numItemsSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numItemsSelected.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.numItemsSelected.Location = new System.Drawing.Point(1095, 580);
            this.numItemsSelected.Name = "numItemsSelected";
            this.numItemsSelected.Size = new System.Drawing.Size(126, 17);
            this.numItemsSelected.TabIndex = 16;
            this.numItemsSelected.Text = "0 items selected";
            this.numItemsSelected.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(3, 2);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(53, 35);
            this.btnBack.TabIndex = 3;
            this.btnBack.Tag = "";
            this.btnBack.UseCompatibleTextRendering = true;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.Location = new System.Drawing.Point(1252, 2);
            this.btnGo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(73, 35);
            this.btnGo.TabIndex = 2;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.Location = new System.Drawing.Point(63, 2);
            this.btnForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(53, 35);
            this.btnForward.TabIndex = 4;
            this.btnForward.UseCompatibleTextRendering = true;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(123, 5);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(1123, 28);
            this.txtPath.TabIndex = 1;
            this.txtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPath_KeyDown);
            // 
            // btnRename
            // 
            this.btnRename.BackColor = System.Drawing.SystemColors.Control;
            this.btnRename.Image = ((System.Drawing.Image)(resources.GetObject("btnRename.Image")));
            this.btnRename.Location = new System.Drawing.Point(427, 5);
            this.btnRename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(113, 60);
            this.btnRename.TabIndex = 5;
            this.btnRename.Text = "Rename";
            this.btnRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRename.UseVisualStyleBackColor = false;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(316, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 60);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Controls.Add(this.btnBack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnForward, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPath, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGo, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 111);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1328, 39);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // imageSmall
            // 
            this.imageSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageSmall.ImageStream")));
            this.imageSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageSmall.Images.SetKeyName(0, "folder.png");
            // 
            // btnDetail
            // 
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.Location = new System.Drawing.Point(258, 5);
            this.btnDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(120, 60);
            this.btnDetail.TabIndex = 5;
            this.btnDetail.Text = "Details";
            this.btnDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnTile
            // 
            this.btnTile.Image = ((System.Drawing.Image)(resources.GetObject("btnTile.Image")));
            this.btnTile.Location = new System.Drawing.Point(510, 5);
            this.btnTile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTile.Name = "btnTile";
            this.btnTile.Size = new System.Drawing.Size(120, 60);
            this.btnTile.TabIndex = 4;
            this.btnTile.Text = "Tiles";
            this.btnTile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTile.UseVisualStyleBackColor = true;
            this.btnTile.Click += new System.EventHandler(this.btnTile_Click);
            // 
            // btnList
            // 
            this.btnList.Image = ((System.Drawing.Image)(resources.GetObject("btnList.Image")));
            this.btnList.Location = new System.Drawing.Point(384, 5);
            this.btnList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(120, 60);
            this.btnList.TabIndex = 3;
            this.btnList.Text = "List";
            this.btnList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnSmallIcon
            // 
            this.btnSmallIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnSmallIcon.Image")));
            this.btnSmallIcon.Location = new System.Drawing.Point(132, 5);
            this.btnSmallIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSmallIcon.Name = "btnSmallIcon";
            this.btnSmallIcon.Size = new System.Drawing.Size(120, 60);
            this.btnSmallIcon.TabIndex = 2;
            this.btnSmallIcon.Text = "Small";
            this.btnSmallIcon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSmallIcon.UseVisualStyleBackColor = true;
            this.btnSmallIcon.Click += new System.EventHandler(this.btnSmallIcon_Click);
            // 
            // btnLargeIcon
            // 
            this.btnLargeIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnLargeIcon.Image")));
            this.btnLargeIcon.Location = new System.Drawing.Point(6, 5);
            this.btnLargeIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLargeIcon.Name = "btnLargeIcon";
            this.btnLargeIcon.Size = new System.Drawing.Size(120, 60);
            this.btnLargeIcon.TabIndex = 0;
            this.btnLargeIcon.Text = "Large";
            this.btnLargeIcon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLargeIcon.UseVisualStyleBackColor = true;
            this.btnLargeIcon.Click += new System.EventHandler(this.btnLargeIcon_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(12, 158);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.splitContainer.Size = new System.Drawing.Size(1328, 420);
            this.splitContainer.SplitterDistance = 216;
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
            this.treeFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeFolder.Name = "treeFolder";
            this.treeFolder.SelectedImageIndex = 0;
            this.treeFolder.ShowLines = false;
            this.treeFolder.Size = new System.Drawing.Size(217, 420);
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
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.LabelEdit = true;
            this.listView.LargeImageList = this.imageLarge;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1109, 420);
            this.listView.SmallImageList = this.imageSmall;
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_AfterLabelEdit);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.ItemActivate += new System.EventHandler(this.listView_ItemActivate);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
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
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpen,
            this.tsRefresh,
            this.tsLine1,
            this.tsCut,
            this.tsCopy,
            this.tsLine2,
            this.tsDelete,
            this.tsRename,
            this.tsPaste,
            this.tsLine3,
            this.tsNewFile,
            this.tsNewFolder});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(155, 238);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // tsOpen
            // 
            this.tsOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(154, 24);
            this.tsOpen.Text = "Open";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsRefresh
            // 
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(154, 24);
            this.tsRefresh.Text = "Refresh";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // tsLine1
            // 
            this.tsLine1.Name = "tsLine1";
            this.tsLine1.Size = new System.Drawing.Size(151, 6);
            // 
            // tsCut
            // 
            this.tsCut.Name = "tsCut";
            this.tsCut.Size = new System.Drawing.Size(154, 24);
            this.tsCut.Text = "Cut";
            this.tsCut.Click += new System.EventHandler(this.tsCut_Click);
            // 
            // tsCopy
            // 
            this.tsCopy.Name = "tsCopy";
            this.tsCopy.Size = new System.Drawing.Size(154, 24);
            this.tsCopy.Text = "Copy";
            this.tsCopy.Click += new System.EventHandler(this.tsCopy_Click);
            // 
            // tsLine2
            // 
            this.tsLine2.Name = "tsLine2";
            this.tsLine2.Size = new System.Drawing.Size(151, 6);
            // 
            // tsDelete
            // 
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(154, 24);
            this.tsDelete.Text = "Delete";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // tsRename
            // 
            this.tsRename.Name = "tsRename";
            this.tsRename.Size = new System.Drawing.Size(154, 24);
            this.tsRename.Text = "Rename";
            this.tsRename.Click += new System.EventHandler(this.tsRename_Click);
            // 
            // tsPaste
            // 
            this.tsPaste.Name = "tsPaste";
            this.tsPaste.Size = new System.Drawing.Size(154, 24);
            this.tsPaste.Text = "Paste";
            this.tsPaste.Click += new System.EventHandler(this.tsPaste_Click);
            // 
            // imageLarge
            // 
            this.imageLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageLarge.ImageStream")));
            this.imageLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageLarge.Images.SetKeyName(0, "folder.png");
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1226, 3);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 65);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(174, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1046, 28);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // numItems
            // 
            this.numItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numItems.AutoSize = true;
            this.numItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numItems.Location = new System.Drawing.Point(1269, 580);
            this.numItems.Name = "numItems";
            this.numItems.Size = new System.Drawing.Size(65, 17);
            this.numItems.TabIndex = 12;
            this.numItems.Text = "Items: 0";
            this.numItems.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1329, 100);
            this.tabControl.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLargeIcon);
            this.tabPage1.Controls.Add(this.btnDetail);
            this.tabPage1.Controls.Add(this.btnTile);
            this.tabPage1.Controls.Add(this.btnSmallIcon);
            this.tabPage1.Controls.Add(this.btnList);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1321, 71);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Layout";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnOpen);
            this.tabPage2.Controls.Add(this.btnNewFile);
            this.tabPage2.Controls.Add(this.btnNewFolder);
            this.tabPage2.Controls.Add(this.btnCut);
            this.tabPage2.Controls.Add(this.btnPaste);
            this.tabPage2.Controls.Add(this.btnCopy);
            this.tabPage2.Controls.Add(this.btnRename);
            this.tabPage2.Controls.Add(this.btnDelete);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1321, 71);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Function";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(821, 5);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(101, 60);
            this.btnOpen.TabIndex = 13;
            this.btnOpen.Text = "Open";
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnNewFile
            // 
            this.btnNewFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btnNewFile.Image")));
            this.btnNewFile.Location = new System.Drawing.Point(684, 5);
            this.btnNewFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(131, 60);
            this.btnNewFile.TabIndex = 12;
            this.btnNewFile.Text = "New file";
            this.btnNewFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewFile.UseVisualStyleBackColor = false;
            this.btnNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnNewFolder.Image")));
            this.btnNewFolder.Location = new System.Drawing.Point(546, 5);
            this.btnNewFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(132, 60);
            this.btnNewFolder.TabIndex = 11;
            this.btnNewFolder.Text = "New folder";
            this.btnNewFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewFolder.UseVisualStyleBackColor = false;
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // btnCut
            // 
            this.btnCut.BackColor = System.Drawing.SystemColors.Control;
            this.btnCut.Image = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));
            this.btnCut.Location = new System.Drawing.Point(225, 5);
            this.btnCut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(85, 60);
            this.btnCut.TabIndex = 8;
            this.btnCut.Text = "Cut";
            this.btnCut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCut.UseVisualStyleBackColor = false;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.BackColor = System.Drawing.SystemColors.Control;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.Location = new System.Drawing.Point(118, 5);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(101, 60);
            this.btnPaste.TabIndex = 7;
            this.btnPaste.Text = "Paste";
            this.btnPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPaste.UseVisualStyleBackColor = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.SystemColors.Control;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(6, 5);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(106, 60);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dateTimePicker);
            this.tabPage3.Controls.Add(this.cbChooseSearch);
            this.tabPage3.Controls.Add(this.btnSearch);
            this.tabPage3.Controls.Add(this.txtSearch);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1321, 71);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbChooseSearch
            // 
            this.cbChooseSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChooseSearch.FormattingEnabled = true;
            this.cbChooseSearch.Items.AddRange(new object[] {
            "Name",
            "Content",
            "Date Created"});
            this.cbChooseSearch.Location = new System.Drawing.Point(6, 20);
            this.cbChooseSearch.Name = "cbChooseSearch";
            this.cbChooseSearch.Size = new System.Drawing.Size(162, 28);
            this.cbChooseSearch.TabIndex = 5;
            this.cbChooseSearch.SelectedIndexChanged += new System.EventHandler(this.cbChooseSearch_SelectedIndexChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(174, 21);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(300, 28);
            this.dateTimePicker.TabIndex = 6;
            // 
            // tsNewFile
            // 
            this.tsNewFile.Name = "tsNewFile";
            this.tsNewFile.Size = new System.Drawing.Size(154, 24);
            this.tsNewFile.Text = "New File";
            this.tsNewFile.Click += new System.EventHandler(this.tsNewFile_Click);
            // 
            // tsNewFolder
            // 
            this.tsNewFolder.Name = "tsNewFolder";
            this.tsNewFolder.Size = new System.Drawing.Size(154, 24);
            this.tsNewFolder.Text = "New Folder";
            this.tsNewFolder.Click += new System.EventHandler(this.tsNewFolder_Click);
            // 
            // tsLine3
            // 
            this.tsLine3.Name = "tsLine3";
            this.tsLine3.Size = new System.Drawing.Size(151, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 607);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.numItemsSelected);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.numItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Manager Files";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numItemsSelected;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ImageList imageSmall;
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
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label numItems;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsOpen;
        private System.Windows.Forms.ToolStripSeparator tsLine1;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.ToolStripMenuItem tsRename;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem tsRefresh;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.ToolStripMenuItem tsCut;
        private System.Windows.Forms.ToolStripMenuItem tsCopy;
        private System.Windows.Forms.ToolStripSeparator tsLine2;
        private System.Windows.Forms.ToolStripMenuItem tsPaste;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnNewFile;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.ComboBox cbChooseSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ToolStripSeparator tsLine3;
        private System.Windows.Forms.ToolStripMenuItem tsNewFile;
        private System.Windows.Forms.ToolStripMenuItem tsNewFolder;
    }
}

