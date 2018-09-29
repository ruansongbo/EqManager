namespace Equipment_Manager
{
    partial class frmPowerSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPowerSet));
            this.lstUser = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvwFunc = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblnamee = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstUser
            // 
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 12;
            this.lstUser.Location = new System.Drawing.Point(28, 52);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(179, 256);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择用户：";
            // 
            // tvwFunc
            // 
            this.tvwFunc.CheckBoxes = true;
            this.tvwFunc.Location = new System.Drawing.Point(340, 52);
            this.tvwFunc.Name = "tvwFunc";
            this.tvwFunc.Size = new System.Drawing.Size(225, 256);
            this.tvwFunc.TabIndex = 3;
            this.tvwFunc.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwFunc_AfterCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "设置权限：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(240, 221);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblnamee
            // 
            this.lblnamee.AutoSize = true;
            this.lblnamee.Location = new System.Drawing.Point(226, 85);
            this.lblnamee.Name = "lblnamee";
            this.lblnamee.Size = new System.Drawing.Size(89, 12);
            this.lblnamee.TabIndex = 2;
            this.lblnamee.Text = "用户真实姓名：";
            this.lblnamee.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(226, 115);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 12);
            this.lblName.TabIndex = 2;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(240, 269);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmPowerSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 357);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tvwFunc);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblnamee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPowerSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "金钥匙——权限设置";
            this.Load += new System.EventHandler(this.frmPowerSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvwFunc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblnamee;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnclose;
    }
}