namespace Equipment_Manager
{
    partial class frmBackup
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
                this.panel1 = new System.Windows.Forms.Panel();
                this.picLoading = new System.Windows.Forms.PictureBox();
                this.lvwBackup = new System.Windows.Forms.ListView();
                this.imgBackup = new System.Windows.Forms.ImageList(this.components);
                this.chkDeleteBefor = new System.Windows.Forms.CheckBox();
                this.btnBackup = new System.Windows.Forms.Button();
                this.btnRestore = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
                this.panel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
                this.SuspendLayout();
                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.picLoading);
                this.panel1.Controls.Add(this.lvwBackup);
                this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
                this.panel1.Location = new System.Drawing.Point(0, 0);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(522, 199);
                this.panel1.TabIndex = 0;
                // 
                // picLoading
                // 
                this.picLoading.BackColor = System.Drawing.Color.Transparent;
                this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
                this.picLoading.Location = new System.Drawing.Point(246, 98);
                this.picLoading.Name = "picLoading";
                this.picLoading.Size = new System.Drawing.Size(25, 25);
                this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.picLoading.TabIndex = 3;
                this.picLoading.TabStop = false;
                this.picLoading.Visible = false;
                // 
                // lvwBackup
                // 
                this.lvwBackup.Cursor = System.Windows.Forms.Cursors.Default;
                this.lvwBackup.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lvwBackup.LargeImageList = this.imgBackup;
                this.lvwBackup.Location = new System.Drawing.Point(0, 0);
                this.lvwBackup.Name = "lvwBackup";
                this.lvwBackup.ShowItemToolTips = true;
                this.lvwBackup.Size = new System.Drawing.Size(522, 199);
                this.lvwBackup.TabIndex = 2;
                this.lvwBackup.UseCompatibleStateImageBehavior = false;
                // 
                // imgBackup
                // 
                this.imgBackup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgBackup.ImageStream")));
                this.imgBackup.TransparentColor = System.Drawing.Color.Transparent;
                this.imgBackup.Images.SetKeyName(0, "png-0034.png");
                // 
                // chkDeleteBefor
                // 
                this.chkDeleteBefor.AutoSize = true;
                this.chkDeleteBefor.Location = new System.Drawing.Point(12, 217);
                this.chkDeleteBefor.Name = "chkDeleteBefor";
                this.chkDeleteBefor.Size = new System.Drawing.Size(240, 16);
                this.chkDeleteBefor.TabIndex = 3;
                this.chkDeleteBefor.Text = "数据备份过程中，清理以前所有的备份。";
                this.chkDeleteBefor.UseVisualStyleBackColor = true;
                // 
                // btnBackup
                // 
                this.btnBackup.Location = new System.Drawing.Point(263, 213);
                this.btnBackup.Name = "btnBackup";
                this.btnBackup.Size = new System.Drawing.Size(75, 23);
                this.btnBackup.TabIndex = 4;
                this.btnBackup.Text = "数据备份";
                this.btnBackup.UseVisualStyleBackColor = true;
                this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
                // 
                // btnRestore
                // 
                this.btnRestore.Location = new System.Drawing.Point(344, 213);
                this.btnRestore.Name = "btnRestore";
                this.btnRestore.Size = new System.Drawing.Size(75, 23);
                this.btnRestore.TabIndex = 4;
                this.btnRestore.Text = "数据恢复";
                this.btnRestore.UseVisualStyleBackColor = true;
                this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
                // 
                // btnClose
                // 
                this.btnClose.Location = new System.Drawing.Point(425, 213);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(75, 23);
                this.btnClose.TabIndex = 4;
                this.btnClose.Text = "关闭";
                this.btnClose.UseVisualStyleBackColor = true;
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // backgroundWorker1
                // 
                this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                // 
                // backgroundWorker2
                // 
                this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
                // 
                // frmBackup
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(522, 259);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.btnRestore);
                this.Controls.Add(this.btnBackup);
                this.Controls.Add(this.chkDeleteBefor);
                this.Controls.Add(this.panel1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmBackup";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "系统数据管理";
                this.Load += new System.EventHandler(this.frmBackup_Load);
                this.panel1.ResumeLayout(false);
                this.panel1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvwBackup;
        private System.Windows.Forms.CheckBox chkDeleteBefor;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imgBackup;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox picLoading;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;

    }
}