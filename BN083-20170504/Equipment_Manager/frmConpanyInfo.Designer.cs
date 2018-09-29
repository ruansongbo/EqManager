namespace Equipment_Manager
{
    partial class frmConpanyInfo
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConpanyInfo));
                this.btnUpdate = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.txtAdress = new System.Windows.Forms.RichTextBox();
                this.txtLinkMan = new System.Windows.Forms.TextBox();
                this.label3 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.txtName = new System.Windows.Forms.TextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.groupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // btnUpdate
                // 
                this.btnUpdate.Location = new System.Drawing.Point(147, 219);
                this.btnUpdate.Name = "btnUpdate";
                this.btnUpdate.Size = new System.Drawing.Size(75, 23);
                this.btnUpdate.TabIndex = 0;
                this.btnUpdate.Text = "修改";
                this.btnUpdate.UseVisualStyleBackColor = true;
                this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(251, 219);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(75, 23);
                this.button2.TabIndex = 0;
                this.button2.Text = "关闭";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.txtAdress);
                this.groupBox1.Controls.Add(this.txtLinkMan);
                this.groupBox1.Controls.Add(this.label3);
                this.groupBox1.Controls.Add(this.label2);
                this.groupBox1.Controls.Add(this.txtName);
                this.groupBox1.Controls.Add(this.label1);
                this.groupBox1.Location = new System.Drawing.Point(20, 12);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(330, 192);
                this.groupBox1.TabIndex = 1;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "groupBox1";
                // 
                // txtAdress
                // 
                this.txtAdress.Location = new System.Drawing.Point(93, 102);
                this.txtAdress.Name = "txtAdress";
                this.txtAdress.Size = new System.Drawing.Size(213, 74);
                this.txtAdress.TabIndex = 9;
                this.txtAdress.Text = "";
                // 
                // txtLinkMan
                // 
                this.txtLinkMan.Location = new System.Drawing.Point(95, 62);
                this.txtLinkMan.Name = "txtLinkMan";
                this.txtLinkMan.Size = new System.Drawing.Size(210, 21);
                this.txtLinkMan.TabIndex = 8;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(16, 105);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(41, 12);
                this.label3.TabIndex = 6;
                this.label3.Text = "地址：";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(16, 65);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(53, 12);
                this.label2.TabIndex = 4;
                this.label2.Text = "联系人：";
                // 
                // txtName
                // 
                this.txtName.Location = new System.Drawing.Point(96, 22);
                this.txtName.Name = "txtName";
                this.txtName.Size = new System.Drawing.Size(209, 21);
                this.txtName.TabIndex = 7;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(16, 26);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(77, 12);
                this.label1.TabIndex = 5;
                this.label1.Text = "本单位名称：";
                // 
                // frmConpanyInfo
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(370, 263);
                this.Controls.Add(this.groupBox1);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.btnUpdate);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "frmConpanyInfo";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "本单位信息管理";
                this.Load += new System.EventHandler(this.frmConpanyInfo_Load);
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtAdress;
        private System.Windows.Forms.TextBox txtLinkMan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}