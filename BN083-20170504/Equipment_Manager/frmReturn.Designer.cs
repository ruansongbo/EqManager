namespace Equipment_Manager
{
    partial class frmReturn
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturn));
                this.btnInfo = new System.Windows.Forms.Button();
                this.btnOK = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.dtpDate = new System.Windows.Forms.DateTimePicker();
                this.label4 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.txtbooker = new System.Windows.Forms.TextBox();
                this.txtcount = new System.Windows.Forms.TextBox();
                this.label5 = new System.Windows.Forms.Label();
                this.label1 = new System.Windows.Forms.Label();
                this.txtborrower = new System.Windows.Forms.TextBox();
                this.txtEqNo = new System.Windows.Forms.TextBox();
                this.groupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // btnInfo
                // 
                this.btnInfo.Location = new System.Drawing.Point(249, 47);
                this.btnInfo.Name = "btnInfo";
                this.btnInfo.Size = new System.Drawing.Size(112, 35);
                this.btnInfo.TabIndex = 0;
                this.btnInfo.Text = "查看相关信息";
                this.btnInfo.UseVisualStyleBackColor = true;
                this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
                // 
                // btnOK
                // 
                this.btnOK.Location = new System.Drawing.Point(175, 219);
                this.btnOK.Name = "btnOK";
                this.btnOK.Size = new System.Drawing.Size(75, 23);
                this.btnOK.TabIndex = 5;
                this.btnOK.Text = "确定";
                this.btnOK.UseVisualStyleBackColor = true;
                this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
                // 
                // btnCancel
                // 
                this.btnCancel.Location = new System.Drawing.Point(269, 219);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(75, 23);
                this.btnCancel.TabIndex = 5;
                this.btnCancel.Text = "取消";
                this.btnCancel.UseVisualStyleBackColor = true;
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.dtpDate);
                this.groupBox1.Controls.Add(this.label4);
                this.groupBox1.Controls.Add(this.label3);
                this.groupBox1.Controls.Add(this.label2);
                this.groupBox1.Controls.Add(this.txtbooker);
                this.groupBox1.Controls.Add(this.txtcount);
                this.groupBox1.Controls.Add(this.label5);
                this.groupBox1.Controls.Add(this.label1);
                this.groupBox1.Controls.Add(this.txtborrower);
                this.groupBox1.Controls.Add(this.txtEqNo);
                this.groupBox1.Location = new System.Drawing.Point(12, 7);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(231, 206);
                this.groupBox1.TabIndex = 6;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "填写归还资料";
                // 
                // dtpDate
                // 
                this.dtpDate.Location = new System.Drawing.Point(100, 160);
                this.dtpDate.Name = "dtpDate";
                this.dtpDate.Size = new System.Drawing.Size(112, 21);
                this.dtpDate.TabIndex = 14;
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(18, 164);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(65, 12);
                this.label4.TabIndex = 10;
                this.label4.Text = "归还日期：";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(18, 129);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(53, 12);
                this.label3.TabIndex = 13;
                this.label3.Text = "经手人：";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(18, 95);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(65, 12);
                this.label2.TabIndex = 12;
                this.label2.Text = "归还数量：";
                // 
                // txtbooker
                // 
                this.txtbooker.Location = new System.Drawing.Point(100, 126);
                this.txtbooker.Name = "txtbooker";
                this.txtbooker.ReadOnly = true;
                this.txtbooker.Size = new System.Drawing.Size(112, 21);
                this.txtbooker.TabIndex = 6;
                // 
                // txtcount
                // 
                this.txtcount.Location = new System.Drawing.Point(100, 92);
                this.txtcount.Name = "txtcount";
                this.txtcount.Size = new System.Drawing.Size(112, 21);
                this.txtcount.TabIndex = 5;
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(18, 60);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(77, 12);
                this.label5.TabIndex = 11;
                this.label5.Text = "领用人工号：";
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(18, 27);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(65, 12);
                this.label1.TabIndex = 9;
                this.label1.Text = "资产编号：";
                // 
                // txtborrower
                // 
                this.txtborrower.Location = new System.Drawing.Point(100, 58);
                this.txtborrower.Name = "txtborrower";
                this.txtborrower.Size = new System.Drawing.Size(112, 21);
                this.txtborrower.TabIndex = 8;
                // 
                // txtEqNo
                // 
                this.txtEqNo.Location = new System.Drawing.Point(100, 24);
                this.txtEqNo.Name = "txtEqNo";
                this.txtEqNo.Size = new System.Drawing.Size(112, 21);
                this.txtEqNo.TabIndex = 7;
                // 
                // frmReturn
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(374, 266);
                this.Controls.Add(this.groupBox1);
                this.Controls.Add(this.btnCancel);
                this.Controls.Add(this.btnOK);
                this.Controls.Add(this.btnInfo);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmReturn";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "资产归还";
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtbooker;
        public System.Windows.Forms.TextBox txtborrower;
        public System.Windows.Forms.TextBox txtEqNo;
    }
}