namespace Equipment_Manager
{
    partial class frmReturnLook
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnLook));
                this.toolStrip1 = new System.Windows.Forms.ToolStrip();
                this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
                this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
                this.toolcbxStyle = new System.Windows.Forms.ToolStripComboBox();
                this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
                this.tooltxtCondition = new System.Windows.Forms.ToolStripTextBox();
                this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnSeach = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnExel = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnSearchAll = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnClose = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
                this.dbgReturnInfo = new System.Windows.Forms.DataGridView();
                this.panel1 = new System.Windows.Forms.Panel();
                this.txtYear = new System.Windows.Forms.TextBox();
                this.cbxMonth = new System.Windows.Forms.ComboBox();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label1 = new System.Windows.Forms.Label();
                this.toolStrip1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dbgReturnInfo)).BeginInit();
                this.panel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // toolStrip1
                // 
                this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolcbxStyle,
            this.toolStripSeparator2,
            this.tooltxtCondition,
            this.toolStripSeparator3,
            this.toolbtnSeach,
            this.toolStripSeparator4,
            this.toolbtnExel,
            this.toolStripSeparator5,
            this.toolbtnSearchAll,
            this.toolStripSeparator6,
            this.toolbtnClose,
            this.toolStripSeparator7});
                this.toolStrip1.Location = new System.Drawing.Point(0, 0);
                this.toolStrip1.Name = "toolStrip1";
                this.toolStrip1.Size = new System.Drawing.Size(679, 25);
                this.toolStrip1.TabIndex = 0;
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
                // toolcbxStyle
                // 
                this.toolcbxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.toolcbxStyle.Items.AddRange(new object[] {
            "资产编号",
            "领用人工号",
            "最近半年",
            "最近一年",
            "精确日期"});
                this.toolcbxStyle.Name = "toolcbxStyle";
                this.toolcbxStyle.Size = new System.Drawing.Size(100, 25);
                this.toolcbxStyle.SelectedIndexChanged += new System.EventHandler(this.toolcbxStyle_SelectedIndexChanged);
                // 
                // toolStripSeparator2
                // 
                this.toolStripSeparator2.Name = "toolStripSeparator2";
                this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
                // 
                // tooltxtCondition
                // 
                this.tooltxtCondition.Name = "tooltxtCondition";
                this.tooltxtCondition.Size = new System.Drawing.Size(100, 25);
                this.tooltxtCondition.TextChanged += new System.EventHandler(this.tooltxtCondition_TextChanged);
                // 
                // toolStripSeparator3
                // 
                this.toolStripSeparator3.Name = "toolStripSeparator3";
                this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnSeach
                // 
                this.toolbtnSeach.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSeach.Image")));
                this.toolbtnSeach.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnSeach.Name = "toolbtnSeach";
                this.toolbtnSeach.Size = new System.Drawing.Size(52, 22);
                this.toolbtnSeach.Text = "查询";
                this.toolbtnSeach.Click += new System.EventHandler(this.toolbtnSeach_Click);
                // 
                // toolStripSeparator4
                // 
                this.toolStripSeparator4.Name = "toolStripSeparator4";
                this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
                // toolStripSeparator5
                // 
                this.toolStripSeparator5.Name = "toolStripSeparator5";
                this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnSearchAll
                // 
                this.toolbtnSearchAll.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSearchAll.Image")));
                this.toolbtnSearchAll.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnSearchAll.Name = "toolbtnSearchAll";
                this.toolbtnSearchAll.Size = new System.Drawing.Size(52, 22);
                this.toolbtnSearchAll.Text = "全部";
                this.toolbtnSearchAll.Click += new System.EventHandler(this.toolbtnSearchAll_Click);
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
                this.toolbtnClose.Text = "退出";
                this.toolbtnClose.Click += new System.EventHandler(this.toolbtnClose_Click);
                // 
                // toolStripSeparator7
                // 
                this.toolStripSeparator7.Name = "toolStripSeparator7";
                this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
                // 
                // dbgReturnInfo
                // 
                this.dbgReturnInfo.AllowUserToAddRows = false;
                this.dbgReturnInfo.AllowUserToDeleteRows = false;
                this.dbgReturnInfo.AllowUserToOrderColumns = true;
                this.dbgReturnInfo.AllowUserToResizeRows = false;
                this.dbgReturnInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dbgReturnInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dbgReturnInfo.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dbgReturnInfo.Location = new System.Drawing.Point(0, 25);
                this.dbgReturnInfo.Name = "dbgReturnInfo";
                this.dbgReturnInfo.ReadOnly = true;
                this.dbgReturnInfo.RowHeadersVisible = false;
                this.dbgReturnInfo.RowTemplate.Height = 23;
                this.dbgReturnInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dbgReturnInfo.Size = new System.Drawing.Size(679, 340);
                this.dbgReturnInfo.TabIndex = 1;
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.Transparent;
                this.panel1.Controls.Add(this.txtYear);
                this.panel1.Controls.Add(this.cbxMonth);
                this.panel1.Controls.Add(this.label2);
                this.panel1.Controls.Add(this.label3);
                this.panel1.Controls.Add(this.label1);
                this.panel1.Location = new System.Drawing.Point(74, 30);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(213, 103);
                this.panel1.TabIndex = 2;
                this.panel1.Visible = false;
                // 
                // txtYear
                // 
                this.txtYear.Location = new System.Drawing.Point(81, 28);
                this.txtYear.Name = "txtYear";
                this.txtYear.Size = new System.Drawing.Size(109, 21);
                this.txtYear.TabIndex = 2;
                // 
                // cbxMonth
                // 
                this.cbxMonth.FormattingEnabled = true;
                this.cbxMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
                this.cbxMonth.Location = new System.Drawing.Point(81, 59);
                this.cbxMonth.Name = "cbxMonth";
                this.cbxMonth.Size = new System.Drawing.Size(109, 20);
                this.cbxMonth.TabIndex = 1;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(24, 62);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(29, 12);
                this.label2.TabIndex = 0;
                this.label2.Text = "月：";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(25, 10);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(137, 12);
                this.label3.TabIndex = 0;
                this.label3.Text = "请输入您所要查询的时间";
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(24, 36);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(29, 12);
                this.label1.TabIndex = 0;
                this.label1.Text = "年：";
                // 
                // frmReturnLook
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(679, 365);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.dbgReturnInfo);
                this.Controls.Add(this.toolStrip1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmReturnLook";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "资产归还一览表";
                this.Load += new System.EventHandler(this.frmReturnLook_Load);
                this.toolStrip1.ResumeLayout(false);
                this.toolStrip1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dbgReturnInfo)).EndInit();
                this.panel1.ResumeLayout(false);
                this.panel1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolcbxStyle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tooltxtCondition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolbtnSeach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolbtnExel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolbtnSearchAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolbtnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.DataGridView dbgReturnInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label3;
    }
}