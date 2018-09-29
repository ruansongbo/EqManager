namespace Equipment_Manager
{
    partial class frmKeeper
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeeper));
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.txtKeeper = new System.Windows.Forms.TextBox();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnDel = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnAdd = new System.Windows.Forms.Button();
                this.lstKeeper = new System.Windows.Forms.ListBox();
                this.groupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.txtKeeper);
                this.groupBox1.Controls.Add(this.btnClose);
                this.groupBox1.Controls.Add(this.btnSave);
                this.groupBox1.Controls.Add(this.btnDel);
                this.groupBox1.Controls.Add(this.btnCancel);
                this.groupBox1.Controls.Add(this.btnAdd);
                this.groupBox1.Controls.Add(this.lstKeeper);
                this.groupBox1.Location = new System.Drawing.Point(12, 21);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(286, 249);
                this.groupBox1.TabIndex = 4;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "资产保管人员";
                // 
                // txtKeeper
                // 
                this.txtKeeper.Enabled = false;
                this.txtKeeper.Location = new System.Drawing.Point(159, 27);
                this.txtKeeper.Name = "txtKeeper";
                this.txtKeeper.Size = new System.Drawing.Size(116, 21);
                this.txtKeeper.TabIndex = 10;
                // 
                // btnClose
                // 
                this.btnClose.Location = new System.Drawing.Point(159, 195);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(75, 23);
                this.btnClose.TabIndex = 8;
                this.btnClose.Text = "关闭";
                this.btnClose.UseVisualStyleBackColor = true;
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // btnSave
                // 
                this.btnSave.Location = new System.Drawing.Point(159, 127);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(75, 23);
                this.btnSave.TabIndex = 8;
                this.btnSave.Text = "保存";
                this.btnSave.UseVisualStyleBackColor = true;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnDel
                // 
                this.btnDel.Location = new System.Drawing.Point(159, 161);
                this.btnDel.Name = "btnDel";
                this.btnDel.Size = new System.Drawing.Size(75, 23);
                this.btnDel.TabIndex = 9;
                this.btnDel.Text = "删除";
                this.btnDel.UseVisualStyleBackColor = true;
                this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
                // 
                // btnCancel
                // 
                this.btnCancel.Enabled = false;
                this.btnCancel.Location = new System.Drawing.Point(159, 93);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(75, 23);
                this.btnCancel.TabIndex = 7;
                this.btnCancel.Text = "取消添加";
                this.btnCancel.UseVisualStyleBackColor = true;
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // btnAdd
                // 
                this.btnAdd.Location = new System.Drawing.Point(159, 59);
                this.btnAdd.Name = "btnAdd";
                this.btnAdd.Size = new System.Drawing.Size(75, 23);
                this.btnAdd.TabIndex = 6;
                this.btnAdd.Text = "添加";
                this.btnAdd.UseVisualStyleBackColor = true;
                this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                // 
                // lstKeeper
                // 
                this.lstKeeper.FormattingEnabled = true;
                this.lstKeeper.ItemHeight = 12;
                this.lstKeeper.Location = new System.Drawing.Point(19, 27);
                this.lstKeeper.Name = "lstKeeper";
                this.lstKeeper.Size = new System.Drawing.Size(120, 196);
                this.lstKeeper.TabIndex = 4;
                // 
                // frmKeeper
                // 
                this.AcceptButton = this.btnSave;
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(310, 289);
                this.Controls.Add(this.groupBox1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "frmKeeper";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "保管人员管理";
                this.Load += new System.EventHandler(this.frmKeeper_Load);
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKeeper;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstKeeper;
        private System.Windows.Forms.Button btnClose;

    }
}