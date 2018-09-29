namespace Equipment_Manager
{
    partial class frmStat
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStat));
                this.toolStrip1 = new System.Windows.Forms.ToolStrip();
                this.toolbtnExel = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnPrint = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnClose = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
                this.panel1 = new System.Windows.Forms.Panel();
                this.tbcStat = new System.Windows.Forms.TabControl();
                this.tabPage1 = new System.Windows.Forms.TabPage();
                this.panel3 = new System.Windows.Forms.Panel();
                this.dbgBecomeOld = new System.Windows.Forms.DataGridView();
                this.panel2 = new System.Windows.Forms.Panel();
                this.lblMessage = new System.Windows.Forms.Label();
                this.tabPage2 = new System.Windows.Forms.TabPage();
                this.panelProcess = new System.Windows.Forms.Panel();
                this.label1 = new System.Windows.Forms.Label();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.RptvwByDepart = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                this.tabPage3 = new System.Windows.Forms.TabPage();
                this.panel4 = new System.Windows.Forms.Panel();
                this.label2 = new System.Windows.Forms.Label();
                this.pictureBox2 = new System.Windows.Forms.PictureBox();
                this.rpttvwBoorowbyType = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                this.tabPage4 = new System.Windows.Forms.TabPage();
                this.dbgEqUseing = new System.Windows.Forms.DataGridView();
                this.imgLoad = new System.Windows.Forms.ImageList(this.components);
                this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
                this.toolStrip1.SuspendLayout();
                this.panel1.SuspendLayout();
                this.tbcStat.SuspendLayout();
                this.tabPage1.SuspendLayout();
                this.panel3.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dbgBecomeOld)).BeginInit();
                this.panel2.SuspendLayout();
                this.tabPage2.SuspendLayout();
                this.panelProcess.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.tabPage3.SuspendLayout();
                this.panel4.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                this.tabPage4.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dbgEqUseing)).BeginInit();
                this.SuspendLayout();
                // 
                // toolStrip1
                // 
                this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnExel,
            this.toolStripSeparator1,
            this.toolbtnPrint,
            this.toolStripSeparator2,
            this.toolbtnClose,
            this.toolStripSeparator3});
                this.toolStrip1.Location = new System.Drawing.Point(0, 0);
                this.toolStrip1.Name = "toolStrip1";
                this.toolStrip1.ShowItemToolTips = false;
                this.toolStrip1.Size = new System.Drawing.Size(756, 25);
                this.toolStrip1.TabIndex = 1;
                this.toolStrip1.Text = "toolStrip1";
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
                // toolStripSeparator1
                // 
                this.toolStripSeparator1.Name = "toolStripSeparator1";
                this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnPrint
                // 
                this.toolbtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnPrint.Image")));
                this.toolbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnPrint.Name = "toolbtnPrint";
                this.toolbtnPrint.Size = new System.Drawing.Size(52, 22);
                this.toolbtnPrint.Text = "打印";
                this.toolbtnPrint.Click += new System.EventHandler(this.toolbtnPrint_Click);
                // 
                // toolStripSeparator2
                // 
                this.toolStripSeparator2.Name = "toolStripSeparator2";
                this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
                // toolStripSeparator3
                // 
                this.toolStripSeparator3.Name = "toolStripSeparator3";
                this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.tbcStat);
                this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.panel1.Location = new System.Drawing.Point(0, 25);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(756, 555);
                this.panel1.TabIndex = 2;
                // 
                // tbcStat
                // 
                this.tbcStat.Controls.Add(this.tabPage1);
                this.tbcStat.Controls.Add(this.tabPage2);
                this.tbcStat.Controls.Add(this.tabPage3);
                this.tbcStat.Controls.Add(this.tabPage4);
                this.tbcStat.Dock = System.Windows.Forms.DockStyle.Fill;
                this.tbcStat.Location = new System.Drawing.Point(0, 0);
                this.tbcStat.Name = "tbcStat";
                this.tbcStat.SelectedIndex = 0;
                this.tbcStat.Size = new System.Drawing.Size(756, 555);
                this.tbcStat.TabIndex = 0;
                this.tbcStat.SelectedIndexChanged += new System.EventHandler(this.tbcStat_SelectedIndexChanged);
                // 
                // tabPage1
                // 
                this.tabPage1.Controls.Add(this.panel3);
                this.tabPage1.Controls.Add(this.panel2);
                this.tabPage1.Location = new System.Drawing.Point(4, 22);
                this.tabPage1.Name = "tabPage1";
                this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
                this.tabPage1.Size = new System.Drawing.Size(748, 529);
                this.tabPage1.TabIndex = 0;
                this.tabPage1.Text = "资产折旧统计";
                this.tabPage1.UseVisualStyleBackColor = true;
                // 
                // panel3
                // 
                this.panel3.Controls.Add(this.dbgBecomeOld);
                this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
                this.panel3.Location = new System.Drawing.Point(3, 24);
                this.panel3.Name = "panel3";
                this.panel3.Size = new System.Drawing.Size(742, 502);
                this.panel3.TabIndex = 2;
                // 
                // dbgBecomeOld
                // 
                this.dbgBecomeOld.AllowUserToAddRows = false;
                this.dbgBecomeOld.AllowUserToDeleteRows = false;
                this.dbgBecomeOld.AllowUserToOrderColumns = true;
                this.dbgBecomeOld.AllowUserToResizeRows = false;
                this.dbgBecomeOld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dbgBecomeOld.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dbgBecomeOld.Location = new System.Drawing.Point(0, 0);
                this.dbgBecomeOld.Name = "dbgBecomeOld";
                this.dbgBecomeOld.ReadOnly = true;
                this.dbgBecomeOld.RowHeadersVisible = false;
                this.dbgBecomeOld.RowTemplate.Height = 23;
                this.dbgBecomeOld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dbgBecomeOld.ShowCellToolTips = false;
                this.dbgBecomeOld.Size = new System.Drawing.Size(742, 502);
                this.dbgBecomeOld.TabIndex = 1;
                // 
                // panel2
                // 
                this.panel2.Controls.Add(this.lblMessage);
                this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
                this.panel2.Location = new System.Drawing.Point(3, 3);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(742, 21);
                this.panel2.TabIndex = 1;
                // 
                // lblMessage
                // 
                this.lblMessage.AutoSize = true;
                this.lblMessage.Font = new System.Drawing.Font("SimSun", 10F);
                this.lblMessage.Location = new System.Drawing.Point(5, 3);
                this.lblMessage.Name = "lblMessage";
                this.lblMessage.Size = new System.Drawing.Size(462, 14);
                this.lblMessage.TabIndex = 2;
                this.lblMessage.Text = "说明：当折旧表中的列“现净总值”的值为0时，则说明该笔资产报废了。";
                // 
                // tabPage2
                // 
                this.tabPage2.Controls.Add(this.panelProcess);
                this.tabPage2.Controls.Add(this.RptvwByDepart);
                this.tabPage2.Location = new System.Drawing.Point(4, 22);
                this.tabPage2.Name = "tabPage2";
                this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
                this.tabPage2.Size = new System.Drawing.Size(748, 529);
                this.tabPage2.TabIndex = 1;
                this.tabPage2.Text = "各部门资产领用量";
                this.tabPage2.UseVisualStyleBackColor = true;
                // 
                // panelProcess
                // 
                this.panelProcess.BackColor = System.Drawing.Color.Transparent;
                this.panelProcess.Controls.Add(this.label1);
                this.panelProcess.Controls.Add(this.pictureBox1);
                this.panelProcess.Location = new System.Drawing.Point(330, 244);
                this.panelProcess.Name = "panelProcess";
                this.panelProcess.Size = new System.Drawing.Size(134, 34);
                this.panelProcess.TabIndex = 1;
                this.panelProcess.Visible = false;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(45, 12);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(83, 12);
                this.label1.TabIndex = 1;
                this.label1.Text = "数据加载中...";
                // 
                // pictureBox1
                // 
                this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                this.pictureBox1.Location = new System.Drawing.Point(14, 6);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(25, 25);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                // 
                // RptvwByDepart
                // 
                this.RptvwByDepart.ActiveViewIndex = -1;
                this.RptvwByDepart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.RptvwByDepart.DisplayStatusBar = false;
                this.RptvwByDepart.DisplayToolbar = false;
                this.RptvwByDepart.Dock = System.Windows.Forms.DockStyle.Fill;
                this.RptvwByDepart.Location = new System.Drawing.Point(3, 3);
                this.RptvwByDepart.Name = "RptvwByDepart";
                this.RptvwByDepart.SelectionFormula = "";
                this.RptvwByDepart.ShowCloseButton = false;
                this.RptvwByDepart.ShowGroupTreeButton = false;
                this.RptvwByDepart.ShowTextSearchButton = false;
                this.RptvwByDepart.ShowZoomButton = false;
                this.RptvwByDepart.Size = new System.Drawing.Size(742, 523);
                this.RptvwByDepart.TabIndex = 0;
                this.RptvwByDepart.ViewTimeSelectionFormula = "";
                // 
                // tabPage3
                // 
                this.tabPage3.Controls.Add(this.panel4);
                this.tabPage3.Controls.Add(this.rpttvwBoorowbyType);
                this.tabPage3.Location = new System.Drawing.Point(4, 22);
                this.tabPage3.Name = "tabPage3";
                this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
                this.tabPage3.Size = new System.Drawing.Size(748, 529);
                this.tabPage3.TabIndex = 2;
                this.tabPage3.Text = "各类别资产借出量";
                this.tabPage3.UseVisualStyleBackColor = true;
                // 
                // panel4
                // 
                this.panel4.BackColor = System.Drawing.Color.Transparent;
                this.panel4.Controls.Add(this.label2);
                this.panel4.Controls.Add(this.pictureBox2);
                this.panel4.Location = new System.Drawing.Point(307, 248);
                this.panel4.Name = "panel4";
                this.panel4.Size = new System.Drawing.Size(134, 34);
                this.panel4.TabIndex = 2;
                this.panel4.Visible = false;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(45, 12);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(83, 12);
                this.label2.TabIndex = 1;
                this.label2.Text = "数据加载中...";
                // 
                // pictureBox2
                // 
                this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
                this.pictureBox2.Location = new System.Drawing.Point(14, 6);
                this.pictureBox2.Name = "pictureBox2";
                this.pictureBox2.Size = new System.Drawing.Size(25, 25);
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.pictureBox2.TabIndex = 0;
                this.pictureBox2.TabStop = false;
                // 
                // rpttvwBoorowbyType
                // 
                this.rpttvwBoorowbyType.ActiveViewIndex = -1;
                this.rpttvwBoorowbyType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.rpttvwBoorowbyType.DisplayStatusBar = false;
                this.rpttvwBoorowbyType.DisplayToolbar = false;
                this.rpttvwBoorowbyType.Dock = System.Windows.Forms.DockStyle.Fill;
                this.rpttvwBoorowbyType.Location = new System.Drawing.Point(3, 3);
                this.rpttvwBoorowbyType.Name = "rpttvwBoorowbyType";
                this.rpttvwBoorowbyType.SelectionFormula = "";
                this.rpttvwBoorowbyType.ShowCloseButton = false;
                this.rpttvwBoorowbyType.ShowGroupTreeButton = false;
                this.rpttvwBoorowbyType.ShowTextSearchButton = false;
                this.rpttvwBoorowbyType.ShowZoomButton = false;
                this.rpttvwBoorowbyType.Size = new System.Drawing.Size(742, 523);
                this.rpttvwBoorowbyType.TabIndex = 0;
                this.rpttvwBoorowbyType.ViewTimeSelectionFormula = "";
                // 
                // tabPage4
                // 
                this.tabPage4.Controls.Add(this.dbgEqUseing);
                this.tabPage4.Location = new System.Drawing.Point(4, 22);
                this.tabPage4.Name = "tabPage4";
                this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
                this.tabPage4.Size = new System.Drawing.Size(748, 529);
                this.tabPage4.TabIndex = 3;
                this.tabPage4.Text = "各笔资产的使用率";
                this.tabPage4.UseVisualStyleBackColor = true;
                // 
                // dbgEqUseing
                // 
                this.dbgEqUseing.AllowUserToAddRows = false;
                this.dbgEqUseing.AllowUserToDeleteRows = false;
                this.dbgEqUseing.AllowUserToResizeRows = false;
                this.dbgEqUseing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dbgEqUseing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dbgEqUseing.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dbgEqUseing.Location = new System.Drawing.Point(3, 3);
                this.dbgEqUseing.Name = "dbgEqUseing";
                this.dbgEqUseing.RowHeadersVisible = false;
                this.dbgEqUseing.RowTemplate.Height = 23;
                this.dbgEqUseing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dbgEqUseing.Size = new System.Drawing.Size(742, 523);
                this.dbgEqUseing.TabIndex = 0;
                // 
                // imgLoad
                // 
                this.imgLoad.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLoad.ImageStream")));
                this.imgLoad.TransparentColor = System.Drawing.Color.Transparent;
                this.imgLoad.Images.SetKeyName(0, "333.gif");
                // 
                // backgroundWorker1
                // 
                this.backgroundWorker1.WorkerReportsProgress = true;
                this.backgroundWorker1.WorkerSupportsCancellation = true;
                this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                // 
                // backgroundWorker2
                // 
                this.backgroundWorker2.WorkerReportsProgress = true;
                this.backgroundWorker2.WorkerSupportsCancellation = true;
                this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
                this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
                // 
                // frmStat
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(756, 580);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.toolStrip1);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "frmStat";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "统计分析";
                this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStat_FormClosed);
                this.Load += new System.EventHandler(this.frmSata_Load);
                this.toolStrip1.ResumeLayout(false);
                this.toolStrip1.PerformLayout();
                this.panel1.ResumeLayout(false);
                this.tbcStat.ResumeLayout(false);
                this.tabPage1.ResumeLayout(false);
                this.panel3.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.dbgBecomeOld)).EndInit();
                this.panel2.ResumeLayout(false);
                this.panel2.PerformLayout();
                this.tabPage2.ResumeLayout(false);
                this.panelProcess.ResumeLayout(false);
                this.panelProcess.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.tabPage3.ResumeLayout(false);
                this.panel4.ResumeLayout(false);
                this.panel4.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                this.tabPage4.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.dbgEqUseing)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tbcStat;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton toolbtnExel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolbtnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dbgBecomeOld;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RptvwByDepart;
        private System.Windows.Forms.TabPage tabPage4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpttvwBoorowbyType;
        private System.Windows.Forms.DataGridView dbgEqUseing;
        private System.Windows.Forms.Panel panelProcess;
        private System.Windows.Forms.ImageList imgLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}