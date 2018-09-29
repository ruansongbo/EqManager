namespace Equipment_Manager
{
    partial class frmFix
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFix));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textFixRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpRDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpMDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbxMaintainer = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.cbxMaintainer);
            this.groupBox2.Controls.Add(this.textFixRemark);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpRDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpMDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(25, 255);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(575, 287);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "资产维修信息";
            // 
            // textFixRemark
            // 
            this.textFixRemark.Location = new System.Drawing.Point(123, 127);
            this.textFixRemark.Margin = new System.Windows.Forms.Padding(4);
            this.textFixRemark.Multiline = true;
            this.textFixRemark.Name = "textFixRemark";
            this.textFixRemark.Size = new System.Drawing.Size(427, 144);
            this.textFixRemark.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "送修备注:";
            // 
            // dtpRDate
            // 
            this.dtpRDate.Location = new System.Drawing.Point(404, 80);
            this.dtpRDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpRDate.Name = "dtpRDate";
            this.dtpRDate.Size = new System.Drawing.Size(145, 26);
            this.dtpRDate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "拟完成日期：";
            // 
            // dtpMDate
            // 
            this.dtpMDate.Location = new System.Drawing.Point(404, 33);
            this.dtpMDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpMDate.Name = "dtpMDate";
            this.dtpMDate.Size = new System.Drawing.Size(145, 26);
            this.dtpMDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "维修厂商：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "送修日期：";
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
            this.groupBox1.Location = new System.Drawing.Point(25, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(576, 200);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "资产基本信息";
            // 
            // textKeeper
            // 
            this.textKeeper.BackColor = System.Drawing.SystemColors.Control;
            this.textKeeper.Location = new System.Drawing.Point(137, 165);
            this.textKeeper.Margin = new System.Windows.Forms.Padding(4);
            this.textKeeper.Name = "textKeeper";
            this.textKeeper.Size = new System.Drawing.Size(132, 26);
            this.textKeeper.TabIndex = 11;
            // 
            // textDepartment
            // 
            this.textDepartment.BackColor = System.Drawing.SystemColors.Control;
            this.textDepartment.Location = new System.Drawing.Point(405, 120);
            this.textDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.textDepartment.Name = "textDepartment";
            this.textDepartment.Size = new System.Drawing.Size(132, 26);
            this.textDepartment.TabIndex = 10;
            // 
            // textKeepPlace
            // 
            this.textKeepPlace.BackColor = System.Drawing.SystemColors.Control;
            this.textKeepPlace.Location = new System.Drawing.Point(137, 120);
            this.textKeepPlace.Margin = new System.Windows.Forms.Padding(4);
            this.textKeepPlace.Name = "textKeepPlace";
            this.textKeepPlace.Size = new System.Drawing.Size(132, 26);
            this.textKeepPlace.TabIndex = 9;
            // 
            // textSerialNO
            // 
            this.textSerialNO.BackColor = System.Drawing.SystemColors.Control;
            this.textSerialNO.Location = new System.Drawing.Point(137, 29);
            this.textSerialNO.Margin = new System.Windows.Forms.Padding(4);
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
            this.textEqNO.Margin = new System.Windows.Forms.Padding(4);
            this.textEqNO.Name = "textEqNO";
            this.textEqNO.ReadOnly = true;
            this.textEqNO.Size = new System.Drawing.Size(132, 26);
            this.textEqNO.TabIndex = 2;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(405, 75);
            this.textName.Margin = new System.Windows.Forms.Padding(4);
            this.textName.Name = "textName";
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(132, 26);
            this.textName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(477, 559);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 31);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(339, 559);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 31);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbxMaintainer
            // 
            this.cbxMaintainer.FormattingEnabled = true;
            this.cbxMaintainer.Location = new System.Drawing.Point(137, 39);
            this.cbxMaintainer.Name = "cbxMaintainer";
            this.cbxMaintainer.Size = new System.Drawing.Size(132, 24);
            this.cbxMaintainer.TabIndex = 12;
            // 
            // frmFix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 605);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "资产维修";
            this.Load += new System.EventHandler(this.frmFix_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textFixRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpRDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpMDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxMaintainer;
    }
}