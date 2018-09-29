namespace Equipment_Manager
{
    partial class frmBorrowLook
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrowLook));
                this.toolStrip1 = new System.Windows.Forms.ToolStrip();
                this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
                this.toolcbxSeachType = new System.Windows.Forms.ToolStripComboBox();
                this.toolStripTextBox2 = new System.Windows.Forms.ToolStripSeparator();
                this.tooltxtCondition = new System.Windows.Forms.ToolStripTextBox();
                this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnSearch = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
                this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnRefresh = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
                this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnExel = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
                this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnReturn = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
                this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnClose = new System.Windows.Forms.ToolStripButton();
                this.dbgBorrow = new System.Windows.Forms.DataGridView();
                this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.ToolMenuItem_Return = new System.Windows.Forms.ToolStripMenuItem();
                this.ToolMenuItem_Exel = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
                this.ToolMenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
                this.ToolMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
                this.tvwEmp = new System.Windows.Forms.TreeView();
                this.imgemp = new System.Windows.Forms.ImageList(this.components);
                this.splitter1 = new System.Windows.Forms.Splitter();
                this.panel1 = new System.Windows.Forms.Panel();
                this.toolStrip1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dbgBorrow)).BeginInit();
                this.contextMenuStrip1.SuspendLayout();
                this.panel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // toolStrip1
                // 
                this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolcbxSeachType,
            this.toolStripTextBox2,
            this.tooltxtCondition,
            this.toolStripSeparator1,
            this.toolbtnSearch,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.toolbtnRefresh,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.toolbtnExel,
            this.toolStripSeparator8,
            this.toolStripSeparator6,
            this.toolbtnReturn,
            this.toolStripSeparator7,
            this.toolStripSeparator9,
            this.toolbtnClose});
                this.toolStrip1.Location = new System.Drawing.Point(0, 0);
                this.toolStrip1.Name = "toolStrip1";
                this.toolStrip1.Size = new System.Drawing.Size(756, 25);
                this.toolStrip1.TabIndex = 1;
                this.toolStrip1.Text = "toolStrip1";
                // 
                // toolStripButton1
                // 
                this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
                this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolStripButton1.Name = "toolStripButton1";
                this.toolStripButton1.Size = new System.Drawing.Size(59, 22);
                this.toolStripButton1.Text = "查询条件:";
                // 
                // toolcbxSeachType
                // 
                this.toolcbxSeachType.Items.AddRange(new object[] {
            "资产编号",
            "领用人工号",
            "领用人姓名",
            "资产名称",
            "使用部门"});
                this.toolcbxSeachType.Name = "toolcbxSeachType";
                this.toolcbxSeachType.Size = new System.Drawing.Size(100, 25);
                // 
                // toolStripTextBox2
                // 
                this.toolStripTextBox2.Name = "toolStripTextBox2";
                this.toolStripTextBox2.Size = new System.Drawing.Size(6, 25);
                // 
                // tooltxtCondition
                // 
                this.tooltxtCondition.Name = "tooltxtCondition";
                this.tooltxtCondition.Size = new System.Drawing.Size(100, 25);
                this.tooltxtCondition.TextChanged += new System.EventHandler(this.tooltxtCondition_TextChanged);
                // 
                // toolStripSeparator1
                // 
                this.toolStripSeparator1.Name = "toolStripSeparator1";
                this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnSearch
                // 
                this.toolbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                this.toolbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSearch.Image")));
                this.toolbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnSearch.Name = "toolbtnSearch";
                this.toolbtnSearch.Size = new System.Drawing.Size(23, 22);
                this.toolbtnSearch.Text = "toolStripButton2";
                this.toolbtnSearch.Click += new System.EventHandler(this.toolbtnSearch_Click);
                // 
                // toolStripSeparator2
                // 
                this.toolStripSeparator2.Name = "toolStripSeparator2";
                this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
                // 
                // toolStripSeparator3
                // 
                this.toolStripSeparator3.Name = "toolStripSeparator3";
                this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnRefresh
                // 
                this.toolbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnRefresh.Image")));
                this.toolbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnRefresh.Name = "toolbtnRefresh";
                this.toolbtnRefresh.Size = new System.Drawing.Size(52, 22);
                this.toolbtnRefresh.Text = "刷新";
                this.toolbtnRefresh.Click += new System.EventHandler(this.toolbtnSearchAll_Click);
                // 
                // toolStripSeparator4
                // 
                this.toolStripSeparator4.Name = "toolStripSeparator4";
                this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
                // toolStripSeparator8
                // 
                this.toolStripSeparator8.Name = "toolStripSeparator8";
                this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
                // 
                // toolStripSeparator6
                // 
                this.toolStripSeparator6.Name = "toolStripSeparator6";
                this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnReturn
                // 
                this.toolbtnReturn.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnReturn.Image")));
                this.toolbtnReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnReturn.Name = "toolbtnReturn";
                this.toolbtnReturn.Size = new System.Drawing.Size(76, 22);
                this.toolbtnReturn.Text = "归还资产";
                this.toolbtnReturn.Click += new System.EventHandler(this.toolbtnReturn_Click);
                // 
                // toolStripSeparator7
                // 
                this.toolStripSeparator7.Name = "toolStripSeparator7";
                this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
                // 
                // toolStripSeparator9
                // 
                this.toolStripSeparator9.Name = "toolStripSeparator9";
                this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
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
                // dbgBorrow
                // 
                this.dbgBorrow.AllowDrop = true;
                this.dbgBorrow.AllowUserToAddRows = false;
                this.dbgBorrow.AllowUserToDeleteRows = false;
                this.dbgBorrow.AllowUserToResizeRows = false;
                this.dbgBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dbgBorrow.ContextMenuStrip = this.contextMenuStrip1;
                this.dbgBorrow.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dbgBorrow.Location = new System.Drawing.Point(0, 0);
                this.dbgBorrow.MultiSelect = false;
                this.dbgBorrow.Name = "dbgBorrow";
                this.dbgBorrow.RowHeadersVisible = false;
                this.dbgBorrow.RowTemplate.Height = 23;
                this.dbgBorrow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dbgBorrow.Size = new System.Drawing.Size(550, 455);
                this.dbgBorrow.TabIndex = 1;
                this.dbgBorrow.TabStop = false;
                // 
                // contextMenuStrip1
                // 
                this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolMenuItem_Return,
            this.ToolMenuItem_Exel,
            this.toolStripSeparator10,
            this.ToolMenuItem_Refresh,
            this.toolStripSeparator11,
            this.ToolMenuItem_Close});
                this.contextMenuStrip1.Name = "contextMenuStrip1";
                this.contextMenuStrip1.Size = new System.Drawing.Size(149, 104);
                // 
                // ToolMenuItem_Return
                // 
                this.ToolMenuItem_Return.Name = "ToolMenuItem_Return";
                this.ToolMenuItem_Return.Size = new System.Drawing.Size(148, 22);
                this.ToolMenuItem_Return.Text = "归还该资产";
                this.ToolMenuItem_Return.Click += new System.EventHandler(this.ToolMenuItem_Return_Click);
                // 
                // ToolMenuItem_Exel
                // 
                this.ToolMenuItem_Exel.Name = "ToolMenuItem_Exel";
                this.ToolMenuItem_Exel.Size = new System.Drawing.Size(148, 22);
                this.ToolMenuItem_Exel.Text = "导出电子表格";
                this.ToolMenuItem_Exel.Click += new System.EventHandler(this.ToolMenuItem_Exel_Click);
                // 
                // toolStripSeparator10
                // 
                this.toolStripSeparator10.Name = "toolStripSeparator10";
                this.toolStripSeparator10.Size = new System.Drawing.Size(145, 6);
                // 
                // ToolMenuItem_Refresh
                // 
                this.ToolMenuItem_Refresh.Name = "ToolMenuItem_Refresh";
                this.ToolMenuItem_Refresh.Size = new System.Drawing.Size(148, 22);
                this.ToolMenuItem_Refresh.Text = "刷新";
                this.ToolMenuItem_Refresh.Click += new System.EventHandler(this.ToolMenuItem_Refresh_Click);
                // 
                // toolStripSeparator11
                // 
                this.toolStripSeparator11.Name = "toolStripSeparator11";
                this.toolStripSeparator11.Size = new System.Drawing.Size(145, 6);
                // 
                // ToolMenuItem_Close
                // 
                this.ToolMenuItem_Close.Name = "ToolMenuItem_Close";
                this.ToolMenuItem_Close.Size = new System.Drawing.Size(148, 22);
                this.ToolMenuItem_Close.Text = "关闭";
                this.ToolMenuItem_Close.Click += new System.EventHandler(this.ToolMenuItem_Close_Click);
                // 
                // tvwEmp
                // 
                this.tvwEmp.Dock = System.Windows.Forms.DockStyle.Left;
                this.tvwEmp.ImageIndex = 0;
                this.tvwEmp.ImageList = this.imgemp;
                this.tvwEmp.Location = new System.Drawing.Point(0, 25);
                this.tvwEmp.Name = "tvwEmp";
                this.tvwEmp.SelectedImageIndex = 0;
                this.tvwEmp.Size = new System.Drawing.Size(199, 455);
                this.tvwEmp.TabIndex = 2;
                this.tvwEmp.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwEmp_AfterSelect);
                // 
                // imgemp
                // 
                this.imgemp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgemp.ImageStream")));
                this.imgemp.TransparentColor = System.Drawing.Color.Transparent;
                this.imgemp.Images.SetKeyName(0, "chart_organisation_add.png");
                this.imgemp.Images.SetKeyName(1, "house.png");
                this.imgemp.Images.SetKeyName(2, "user.png");
                // 
                // splitter1
                // 
                this.splitter1.Location = new System.Drawing.Point(199, 25);
                this.splitter1.Name = "splitter1";
                this.splitter1.Size = new System.Drawing.Size(7, 455);
                this.splitter1.TabIndex = 3;
                this.splitter1.TabStop = false;
                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.dbgBorrow);
                this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.panel1.Location = new System.Drawing.Point(206, 25);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(550, 455);
                this.panel1.TabIndex = 4;
                // 
                // frmBorrowLook
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(756, 480);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.splitter1);
                this.Controls.Add(this.tvwEmp);
                this.Controls.Add(this.toolStrip1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmBorrowLook";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "资产领用一览表";
                this.Load += new System.EventHandler(this.frmBorrowLook_Load);
                this.toolStrip1.ResumeLayout(false);
                this.toolStrip1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dbgBorrow)).EndInit();
                this.contextMenuStrip1.ResumeLayout(false);
                this.panel1.ResumeLayout(false);
                this.ResumeLayout(false);
                this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox toolcbxSeachType;
        private System.Windows.Forms.ToolStripSeparator toolStripTextBox2;
        private System.Windows.Forms.ToolStripTextBox tooltxtCondition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolbtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolbtnExel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolbtnReturn;
        private System.Windows.Forms.DataGridView dbgBorrow;
        private System.Windows.Forms.TreeView tvwEmp;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolbtnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Return;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Exel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Close;
        private System.Windows.Forms.ImageList imgemp;
    }
}