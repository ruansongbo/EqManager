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
            System.Windows.Forms.ToolStripButton toolbtnRefresh;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClearLook));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCurPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalpage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtPage = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator35 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnSearchAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnExel = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnSelectItem = new System.Windows.Forms.ToolStripButton();
            this.dbgClear = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolMenuItem_Exel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolMenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolMenuItem_close = new System.Windows.Forms.ToolStripMenuItem();
            toolbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgClear)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbtnRefresh
            // 
            toolbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnRefresh.Image")));
            toolbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolbtnRefresh.Name = "toolbtnRefresh";
            toolbtnRefresh.Size = new System.Drawing.Size(62, 25);
            toolbtnRefresh.Text = "刷新";
            toolbtnRefresh.Click += new System.EventHandler(this.toolbtnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip3);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.dbgClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 496);
            this.panel1.TabIndex = 4;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirst,
            this.toolStripSeparator24,
            this.btnBack,
            this.toolStripSeparator25,
            this.btnNext,
            this.toolStripSeparator26,
            this.btnLast,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.toolStripSeparator27,
            this.lblCurPage,
            this.toolStripSeparator30,
            this.lblTotalpage,
            this.toolStripSeparator4,
            this.toolStripSeparator3,
            this.toolStripSeparator32,
            this.toolStripLabel2,
            this.txtPage,
            this.toolStripLabel3,
            this.toolStripSeparator35,
            this.btnFind});
            this.toolStrip3.Location = new System.Drawing.Point(0, 28);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1059, 28);
            this.toolStrip3.TabIndex = 31;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(46, 25);
            this.btnFirst.Text = "首页";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(6, 28);
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(62, 25);
            this.btnBack.Text = "上一页";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(6, 28);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(62, 25);
            this.btnNext.Text = "下一页";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(6, 28);
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(46, 25);
            this.btnLast.Text = "尾页";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(6, 28);
            // 
            // lblCurPage
            // 
            this.lblCurPage.Name = "lblCurPage";
            this.lblCurPage.Size = new System.Drawing.Size(51, 25);
            this.lblCurPage.Text = "第1页";
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(6, 28);
            // 
            // lblTotalpage
            // 
            this.lblTotalpage.Name = "lblTotalpage";
            this.lblTotalpage.Size = new System.Drawing.Size(42, 25);
            this.lblTotalpage.Text = "共页";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator32
            // 
            this.toolStripSeparator32.Name = "toolStripSeparator32";
            this.toolStripSeparator32.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(42, 25);
            this.toolStripLabel2.Text = "第：";
            // 
            // txtPage
            // 
            this.txtPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(53, 28);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(26, 25);
            this.toolStripLabel3.Text = "页";
            // 
            // toolStripSeparator35
            // 
            this.toolStripSeparator35.Name = "toolStripSeparator35";
            this.toolStripSeparator35.Size = new System.Drawing.Size(6, 28);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(62, 25);
            this.btnFind.Text = "跳转";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSearch,
            this.toolStripSeparator16,
            toolbtnRefresh,
            this.toolStripSeparator5,
            this.toolbtnSearchAll,
            this.toolStripSeparator6,
            this.toolbtnExel,
            this.btnPrint,
            this.toolStripSeparator8,
            this.toolbtnSelectItem});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1059, 28);
            this.toolStrip2.TabIndex = 30;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolbtnSearch
            // 
            this.toolbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSearch.Image")));
            this.toolbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSearch.Name = "toolbtnSearch";
            this.toolbtnSearch.Size = new System.Drawing.Size(62, 25);
            this.toolbtnSearch.Text = "查询";
            this.toolbtnSearch.Click += new System.EventHandler(this.toolbtnSearch_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnSearchAll
            // 
            this.toolbtnSearchAll.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSearchAll.Image")));
            this.toolbtnSearchAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSearchAll.Name = "toolbtnSearchAll";
            this.toolbtnSearchAll.Size = new System.Drawing.Size(158, 25);
            this.toolbtnSearchAll.Text = "查看所有资产信息";
            this.toolbtnSearchAll.Click += new System.EventHandler(this.toolbtnSearchAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnExel
            // 
            this.toolbtnExel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExel.Name = "toolbtnExel";
            this.toolbtnExel.Size = new System.Drawing.Size(110, 25);
            this.toolbtnExel.Text = "导出当前表格";
            this.toolbtnExel.Click += new System.EventHandler(this.toolbtnExel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Equipment_Manager.Properties.Resources.printer_blue;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(62, 25);
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnSelectItem
            // 
            this.toolbtnSelectItem.Image = global::Equipment_Manager.Properties.Resources.text_list_bullets;
            this.toolbtnSelectItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSelectItem.Name = "toolbtnSelectItem";
            this.toolbtnSelectItem.Size = new System.Drawing.Size(94, 25);
            this.toolbtnSelectItem.Text = "选择项目";
            this.toolbtnSelectItem.Click += new System.EventHandler(this.toolbtnSelectItem_Click);
            // 
            // dbgClear
            // 
            this.dbgClear.AllowUserToAddRows = false;
            this.dbgClear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgClear.Location = new System.Drawing.Point(4, 71);
            this.dbgClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dbgClear.Name = "dbgClear";
            this.dbgClear.RowTemplate.Height = 23;
            this.dbgClear.Size = new System.Drawing.Size(1051, 421);
            this.dbgClear.TabIndex = 27;
            this.dbgClear.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dbgClear_ColumnWidthChanged);
            this.dbgClear.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dbgClear_Scroll);
            this.dbgClear.SizeChanged += new System.EventHandler(this.dbgClear_SizeChanged);
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
            // 
            // ToolMenuItem_Refresh
            // 
            this.ToolMenuItem_Refresh.Name = "ToolMenuItem_Refresh";
            this.ToolMenuItem_Refresh.Size = new System.Drawing.Size(148, 22);
            this.ToolMenuItem_Refresh.Text = "刷新";
            // 
            // ToolMenuItem_close
            // 
            this.ToolMenuItem_close.Name = "ToolMenuItem_close";
            this.ToolMenuItem_close.Size = new System.Drawing.Size(148, 22);
            this.ToolMenuItem_close.Text = "关闭";
            // 
            // frmClearLook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 496);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "frmClearLook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资产清理记录一览表";
            this.Load += new System.EventHandler(this.frmClearLook_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgClear)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Exel;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Refresh;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_close;
        private System.Windows.Forms.DataGridView dbgClear;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripLabel lblCurPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator30;
        private System.Windows.Forms.ToolStripLabel lblTotalpage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator32;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator35;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolbtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolbtnSearchAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolbtnExel;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolbtnSelectItem;
    }
}