﻿namespace Equipment_Manager
{
    partial class frmUpdateSysUserInfo
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateSysUserInfo));
                this.label1 = new System.Windows.Forms.Label();
                this.txtLoginname = new System.Windows.Forms.TextBox();
                this.btnOk = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                this.label2 = new System.Windows.Forms.Label();
                this.txtName = new System.Windows.Forms.TextBox();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.chkPass = new System.Windows.Forms.CheckBox();
                this.txtPassAgain = new System.Windows.Forms.TextBox();
                this.txtNewPass = new System.Windows.Forms.TextBox();
                this.lblOldPass = new System.Windows.Forms.Label();
                this.txtOldPass = new System.Windows.Forms.TextBox();
                this.lblNewPassAgain = new System.Windows.Forms.Label();
                this.lblNewPass = new System.Windows.Forms.Label();
                this.groupBox1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(15, 29);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(77, 12);
                this.label1.TabIndex = 0;
                this.label1.Text = "系统登录名：";
                // 
                // txtLoginname
                // 
                this.txtLoginname.Location = new System.Drawing.Point(130, 26);
                this.txtLoginname.Name = "txtLoginname";
                this.txtLoginname.ReadOnly = true;
                this.txtLoginname.Size = new System.Drawing.Size(167, 21);
                this.txtLoginname.TabIndex = 0;
                // 
                // btnOk
                // 
                this.btnOk.Location = new System.Drawing.Point(169, 280);
                this.btnOk.Name = "btnOk";
                this.btnOk.Size = new System.Drawing.Size(75, 23);
                this.btnOk.TabIndex = 5;
                this.btnOk.Text = "确定";
                this.btnOk.UseVisualStyleBackColor = true;
                this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
                // 
                // btnClose
                // 
                this.btnClose.Location = new System.Drawing.Point(251, 280);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(75, 23);
                this.btnClose.TabIndex = 6;
                this.btnClose.Text = "关闭";
                this.btnClose.UseVisualStyleBackColor = true;
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(15, 59);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(65, 12);
                this.label2.TabIndex = 0;
                this.label2.Text = "真实姓名：";
                // 
                // txtName
                // 
                this.txtName.Location = new System.Drawing.Point(130, 56);
                this.txtName.Name = "txtName";
                this.txtName.Size = new System.Drawing.Size(167, 21);
                this.txtName.TabIndex = 1;
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.pictureBox1);
                this.groupBox1.Controls.Add(this.groupBox2);
                this.groupBox1.Controls.Add(this.chkPass);
                this.groupBox1.Controls.Add(this.txtPassAgain);
                this.groupBox1.Controls.Add(this.txtNewPass);
                this.groupBox1.Controls.Add(this.txtName);
                this.groupBox1.Controls.Add(this.label1);
                this.groupBox1.Controls.Add(this.lblOldPass);
                this.groupBox1.Controls.Add(this.txtOldPass);
                this.groupBox1.Controls.Add(this.lblNewPassAgain);
                this.groupBox1.Controls.Add(this.txtLoginname);
                this.groupBox1.Controls.Add(this.lblNewPass);
                this.groupBox1.Controls.Add(this.label2);
                this.groupBox1.Location = new System.Drawing.Point(12, 10);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(315, 251);
                this.groupBox1.TabIndex = 3;
                this.groupBox1.TabStop = false;
                // 
                // pictureBox1
                // 
                this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                this.pictureBox1.Location = new System.Drawing.Point(17, 126);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(16, 16);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.pictureBox1.TabIndex = 6;
                this.pictureBox1.TabStop = false;
                // 
                // groupBox2
                // 
                this.groupBox2.Location = new System.Drawing.Point(44, 133);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(253, 3);
                this.groupBox2.TabIndex = 8;
                this.groupBox2.TabStop = false;
                // 
                // chkPass
                // 
                this.chkPass.AutoSize = true;
                this.chkPass.Location = new System.Drawing.Point(17, 100);
                this.chkPass.Name = "chkPass";
                this.chkPass.Size = new System.Drawing.Size(72, 16);
                this.chkPass.TabIndex = 2;
                this.chkPass.Text = "修改密码";
                this.chkPass.UseVisualStyleBackColor = true;
                this.chkPass.CheckedChanged += new System.EventHandler(this.chkPass_CheckedChanged);
                // 
                // txtPassAgain
                // 
                this.txtPassAgain.Enabled = false;
                this.txtPassAgain.Location = new System.Drawing.Point(130, 217);
                this.txtPassAgain.Name = "txtPassAgain";
                this.txtPassAgain.PasswordChar = '*';
                this.txtPassAgain.Size = new System.Drawing.Size(167, 21);
                this.txtPassAgain.TabIndex = 4;
                // 
                // txtNewPass
                // 
                this.txtNewPass.Enabled = false;
                this.txtNewPass.Location = new System.Drawing.Point(130, 189);
                this.txtNewPass.Name = "txtNewPass";
                this.txtNewPass.PasswordChar = '*';
                this.txtNewPass.Size = new System.Drawing.Size(167, 21);
                this.txtNewPass.TabIndex = 3;
                // 
                // lblOldPass
                // 
                this.lblOldPass.AutoSize = true;
                this.lblOldPass.Enabled = false;
                this.lblOldPass.Location = new System.Drawing.Point(15, 162);
                this.lblOldPass.Name = "lblOldPass";
                this.lblOldPass.Size = new System.Drawing.Size(53, 12);
                this.lblOldPass.TabIndex = 0;
                this.lblOldPass.Text = "旧密码：";
                // 
                // txtOldPass
                // 
                this.txtOldPass.Enabled = false;
                this.txtOldPass.Location = new System.Drawing.Point(130, 159);
                this.txtOldPass.Name = "txtOldPass";
                this.txtOldPass.PasswordChar = '*';
                this.txtOldPass.Size = new System.Drawing.Size(167, 21);
                this.txtOldPass.TabIndex = 2;
                // 
                // lblNewPassAgain
                // 
                this.lblNewPassAgain.AutoSize = true;
                this.lblNewPassAgain.Enabled = false;
                this.lblNewPassAgain.Location = new System.Drawing.Point(15, 222);
                this.lblNewPassAgain.Name = "lblNewPassAgain";
                this.lblNewPassAgain.Size = new System.Drawing.Size(113, 12);
                this.lblNewPassAgain.TabIndex = 0;
                this.lblNewPassAgain.Text = "确认新密码新密码：";
                // 
                // lblNewPass
                // 
                this.lblNewPass.AutoSize = true;
                this.lblNewPass.Enabled = false;
                this.lblNewPass.Location = new System.Drawing.Point(15, 192);
                this.lblNewPass.Name = "lblNewPass";
                this.lblNewPass.Size = new System.Drawing.Size(53, 12);
                this.lblNewPass.TabIndex = 0;
                this.lblNewPass.Text = "新密码：";
                // 
                // frmUpdateSysUserInfo
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(342, 329);
                this.Controls.Add(this.groupBox1);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.btnOk);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmUpdateSysUserInfo";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "修改用户资料";
                this.Load += new System.EventHandler(this.frmUpdateSysUserInfo_Load);
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoginname;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtPassAgain;
        private System.Windows.Forms.Label lblNewPassAgain;
        private System.Windows.Forms.CheckBox chkPass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}