namespace Equipment_Manager
{
    partial class frmClearLook
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClearLook));
                this.toolStrip1 = new System.Windows.Forms.ToolStrip();
                this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
                this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
                this.toolcbxSearchType = new System.Windows.Forms.ToolStripComboBox();
                this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
                this.tooltxtCodition = new System.Windows.Forms.ToolStripTextBox();
                this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnSearch = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnSearchAll = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
                this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnExel = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnClose = new System.Windows.Forms.ToolStripButton();
                this.tvwClearer = new System.Windows.Forms.TreeView();
                this.imgLearer = new System.Windows.Forms.ImageList(this.components);
                this.splitter1 = new System.Windows.Forms.Splitter();
                this.panel1 = new System.Windows.Forms.Panel();
                this.dbgClear = new System.Windows.Forms.DataGridView();
                this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.ToolMenuItem_Exel = new System.Windows.Forms.ToolStripMenuItem();
                this.ToolMenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
                this.ToolMenuItem_close = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStrip1.SuspendLayout();
                this.panel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dbgClear)).BeginInit();
                this.contextMenuStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // toolStrip1
                // 
                this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolcbxSearchType,
            this.toolStripSeparator2,
            this.tooltxtCodition,
            this.toolStripSeparator3,
            this.toolbtnSearch,
            this.toolStripSeparator4,
            this.toolbtnSearchAll,
            this.toolStripSeparator7,
            this.toolStripSeparator5,
            this.toolbtnExel,
            this.toolStripSeparator6,
            this.toolbtnClose});
                this.toolStrip1.Location = new System.Drawing.Point(0, 0);
                this.toolStrip1.Name = "toolStrip1";
                this.toolStrip1.Size = new System.Drawing.Size(792, 25);
                this.toolStrip1.TabIndex = 1;
                this.toolStrip1.Text = "toolStrip1";
                // 
                // toolStripLabel1
                // 
                this.toolStripLabel1.Name = "toolStripLabel1";
                this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
                this.toolStripLabel1.Text = "查询条件：";
                // 
                // toolStripSeparator1
                // 
                this.toolStripSeparator1.Name = "toolStripSeparator1";
                this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
                // 
                // toolcbxSearchType
                // 
                this.toolcbxSearchType.Items.AddRange(new object[] {
            "资产编号",
            "清理方式",
            "清理人",
            "清理日期"});
                this.toolcbxSearchType.Name = "toolcbxSearchType";
                this.toolcbxSearchType.Size = new System.Drawing.Size(121, 25);
                // 
                // toolStripSeparator2
                // 
                this.toolStripSeparator2.Name = "toolStripSeparator2";
                this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
                // 
                // tooltxtCodition
                // 
                this.tooltxtCodition.Name = "tooltxtCodition";
                this.tooltxtCodition.Size = new System.Drawing.Size(100, 25);
                this.tooltxtCodition.TextChanged += new System.EventHandler(this.tooltxtCodition_TextChanged);
                // 
                // toolStripSeparator3
                // 
                this.toolStripSeparator3.Name = "toolStripSeparator3";
                this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnSearch
                // 
                this.toolbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                this.toolbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSearch.Image")));
                this.toolbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnSearch.Name = "toolbtnSearch";
                this.toolbtnSearch.Size = new System.Drawing.Size(23, 22);
                this.toolbtnSearch.Text = "查找";
                this.toolbtnSearch.Click += new System.EventHandler(this.toolbtnSearch_Click);
                // 
                // toolStripSeparator4
                // 
                this.toolStripSeparator4.Name = "toolStripSeparator4";
                this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnSearchAll
                // 
                this.toolbtnSearchAll.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSearchAll.Image")));
                this.toolbtnSearchAll.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnSearchAll.Name = "toolbtnSearchAll";
                this.toolbtnSearchAll.Size = new System.Drawing.Size(76, 22);
                this.toolbtnSearchAll.Text = "全部记录";
                // 
                // toolStripSeparator7
                // 
                this.toolStripSeparator7.Name = "toolStripSeparator7";
                this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
                // 
                // toolStripSeparator5
                // 
                this.toolStripSeparator5.Name = "toolStripSeparator5";
                this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnExel
                // 
                this.toolbtnExel.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnExel.Image")));
                this.toolbtnExel.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnExel.Name = "toolbtnExel";
                this.toolbtnExel.Size = new System.Drawing.Size(100, 22);
                this.toolbtnExel.Text = "导出电子表格";
                this.toolbtnExel.Click += new System.EventHandler(this.toolbtnExel_Click);
                // 
                // toolStripSeparator6
                // 
                this.toolStripSeparator6.Name = "toolStripSeparator6";
                this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnClose
                // 
                this.toolbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnClose.Image")));
                this.toolbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnClose.Name = "toolbtnClose";
                this.toolbtnClose.Size = new System.Drawing.Size(52, 22);
                this.toolbtnClose.Text = "关闭";
                this.toolbtnClose.Click += new System.EventHandler(this.toolbtnClose_Click);
                // 
                // tvwClearer
                // 
                this.tvwClearer.Dock = System.Windows.Forms.DockStyle.Left;
                this.tvwClearer.ImageIndex = 0;
                this.tvwClearer.ImageList = this.imgLearer;
                this.tvwClearer.Location = new System.Drawing.Point(0, 25);
                this.tvwClearer.Name = "tvwClearer";
                this.tvwClearer.SelectedImageIndex = 0;
                this.tvwClearer.Size = new System.Drawing.Size(207, 409);
                this.tvwClearer.TabIndex = 2;
                this.tvwClearer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwClearer_AfterSelect);
                // 
                // imgLearer
                // 
                this.imgLearer.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLearer.ImageStream")));
                this.imgLearer.TransparentColor = System.Drawing.Color.Transparent;
                this.imgLearer.Images.SetKeyName(0, "group.png");
                this.imgLearer.Images.SetKeyName(1, "user.png");
                // 
                // splitter1
                // 
                this.splitter1.Location = new System.Drawing.Point(207, 25);
                this.splitter1.Name = "splitter1";
                this.splitter1.Size = new System.Drawing.Size(7, 409);
                this.splitter1.TabIndex = 3;
                this.splitter1.TabStop = false;
                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.dbgClear);
                this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.panel1.Location = new System.Drawing.Point(214, 25);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(578, 409);
                this.panel1.TabIndex = 4;
                // 
                // dbgClear
                // 
                this.dbgClear.AllowUserToAddRows = false;
                this.dbgClear.AllowUserToDeleteRows = false;
                this.dbgClear.AllowUserToResizeRows = false;
                this.dbgClear.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dbgClear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dbgClear.ContextMenuStrip = this.contextMenuStrip1;
                this.dbgClear.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dbgClear.Location = new System.Drawing.Point(0, 0);
                this.dbgClear.Name = "dbgClear";
                this.dbgClear.RowHeadersVisible = false;
                this.dbgClear.RowTemplate.Height = 23;
                this.dbgClear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dbgClear.Size = new System.Drawing.Size(578, 409);
                this.dbgClear.TabIndex = 0;
                // 
                // contextMenuStrip1
                // 
                this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolMenuItem_Exel,
            this.ToolMenuItem_Refresh,
            this.ToolMenuItem_close});
                this.contextMenuStrip1.Name = "contextMenuStrip1";
                this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
                // 
                // ToolMenuItem_Exel
                // 
                this.ToolMenuItem_Exel.Name = "ToolMenuItem_Exel";
                this.ToolMenuItem_Exel.Size = new System.Drawing.Size(148, 22);
                this.ToolMenuItem_Exel.Text = "导出电子表格";
                this.ToolMenuItem_Exel.Click += new System.EventHandler(this.ToolMenuItem_Exel_Click);
                // 
                // ToolMenuItem_Refresh
                // 
                this.ToolMenuItem_Refresh.Name = "ToolMenuItem_Refresh";
                this.ToolMenuItem_Refresh.Size = new System.Drawing.Size(148, 22);
                this.ToolMenuItem_Refresh.Text = "刷新";
                this.ToolMenuItem_Refresh.Click += new System.EventHandler(this.ToolMenuItem_Refresh_Click);
                // 
                // ToolMenuItem_close
                // 
                this.ToolMenuItem_close.Name = "ToolMenuItem_close";
                this.ToolMenuItem_close.Size = new System.Drawing.Size(148, 22);
                this.ToolMenuItem_close.Text = "关闭";
                this.ToolMenuItem_close.Click += new System.EventHandler(this.ToolMenuItem_close_Click);
                // 
                // frmClearLook
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(792, 434);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.splitter1);
                this.Controls.Add(this.tvwClearer);
                this.Controls.Add(this.toolStrip1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MinimizeBox = false;
                this.Name = "frmClearLook";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "资产清理记录一览表";
                this.Load += new System.EventHandler(this.frmClearLook_Load);
                this.toolStrip1.ResumeLayout(false);
                this.toolStrip1.PerformLayout();
                this.panel1.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.dbgClear)).EndInit();
                this.contextMenuStrip1.ResumeLayout(false);
                this.ResumeLayout(false);
                this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolcbxSearchType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tooltxtCodition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolbtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolbtnSearchAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolbtnExel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolbtnClose;
        private System.Windows.Forms.TreeView tvwClearer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dbgClear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Exel;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Refresh;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_close;
        private System.Windows.Forms.ImageList imgLearer;
    }
}