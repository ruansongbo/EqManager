namespace Equipment_Manager
{
    partial class frmClear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClear));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textKeeper = new System.Windows.Forms.TextBox();
            this.textDepartment = new System.Windows.Forms.TextBox();
            this.textKeepPlace = new System.Windows.Forms.TextBox();
            this.textSerialNO = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textEqNO = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxClearType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(377, 495);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 31);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(508, 495);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 31);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.textKeeper);
            this.groupBox1.Controls.Add(this.textDepartment);
            this.groupBox1.Controls.Add(this.textKeepPlace);
            this.groupBox1.Controls.Add(this.textSerialNO);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textEqNO);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Location = new System.Drawing.Point(32, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(576, 200);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "资产基本信息";
            // 
            // textKeeper
            // 
            this.textKeeper.BackColor = System.Drawing.SystemColors.Control;
            this.textKeeper.Location = new System.Drawing.Point(137, 165);
            this.textKeeper.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textKeeper.Name = "textKeeper";
            this.textKeeper.Size = new System.Drawing.Size(132, 26);
            this.textKeeper.TabIndex = 11;
            // 
            // textDepartment
            // 
            this.textDepartment.BackColor = System.Drawing.SystemColors.Control;
            this.textDepartment.Location = new System.Drawing.Point(405, 120);
            this.textDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textDepartment.Name = "textDepartment";
            this.textDepartment.Size = new System.Drawing.Size(132, 26);
            this.textDepartment.TabIndex = 10;
            // 
            // textKeepPlace
            // 
            this.textKeepPlace.BackColor = System.Drawing.SystemColors.Control;
            this.textKeepPlace.Location = new System.Drawing.Point(137, 120);
            this.textKeepPlace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textKeepPlace.Name = "textKeepPlace";
            this.textKeepPlace.Size = new System.Drawing.Size(132, 26);
            this.textKeepPlace.TabIndex = 9;
            // 
            // textSerialNO
            // 
            this.textSerialNO.BackColor = System.Drawing.SystemColors.Control;
            this.textSerialNO.Location = new System.Drawing.Point(137, 29);
            this.textSerialNO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textSerialNO.Name = "textSerialNO";
            this.textSerialNO.Size = new System.Drawing.Size(132, 26);
            this.textSerialNO.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 125);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "存放地点：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 171);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "保管人：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(296, 125);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "所属部门：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "流水号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "资产名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "资产编码：";
            // 
            // textEqNO
            // 
            this.textEqNO.Location = new System.Drawing.Point(137, 75);
            this.textEqNO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textEqNO.Name = "textEqNO";
            this.textEqNO.ReadOnly = true;
            this.textEqNO.Size = new System.Drawing.Size(132, 26);
            this.textEqNO.TabIndex = 2;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(405, 75);
            this.textName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textName.Name = "textName";
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(132, 26);
            this.textName.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textRemark);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbxClearType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(32, 251);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(575, 221);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "资产领用信息";
            // 
            // textRemark
            // 
            this.textRemark.Location = new System.Drawing.Point(123, 83);
            this.textRemark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textRemark.Multiline = true;
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(427, 125);
            this.textRemark.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "清理备注：";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(404, 33);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(145, 26);
            this.dtpDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "清理方式：";
            // 
            // cbxClearType
            // 
            this.cbxClearType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClearType.FormattingEnabled = true;
            this.cbxClearType.Location = new System.Drawing.Point(139, 33);
            this.cbxClearType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxClearType.Name = "cbxClearType";
            this.cbxClearType.Size = new System.Drawing.Size(131, 24);
            this.cbxClearType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "清理日期：";
            // 
            // frmClear
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 541);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmClear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资产清理";
            this.Load += new System.EventHandler(this.frmClear_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textKeeper;
        private System.Windows.Forms.TextBox textDepartment;
        private System.Windows.Forms.TextBox textKeepPlace;
        private System.Windows.Forms.TextBox textSerialNO;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEqNO;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxClearType;
        private System.Windows.Forms.Label label4;

    }
}