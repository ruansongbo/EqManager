namespace Equipment_Manager
{
    partial class frmBorrow
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrow));
                this.btnOK = new System.Windows.Forms.Button();
                this.cbxDepart = new System.Windows.Forms.ComboBox();
                this.txtBooker = new System.Windows.Forms.TextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.label6 = new System.Windows.Forms.Label();
                this.cbxEmp = new System.Windows.Forms.ComboBox();
                this.nubCount = new System.Windows.Forms.NumericUpDown();
                this.btnCancel = new System.Windows.Forms.Button();
                this.dtpDate = new System.Windows.Forms.DateTimePicker();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.label12 = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.label10 = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.label11 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.txtEqNO = new System.Windows.Forms.TextBox();
                this.txtLabel = new System.Windows.Forms.TextBox();
                this.txtType = new System.Windows.Forms.TextBox();
                this.txtPlus = new System.Windows.Forms.TextBox();
                this.txtModel = new System.Windows.Forms.TextBox();
                this.txtMaxNO = new System.Windows.Forms.TextBox();
                this.txtName = new System.Windows.Forms.TextBox();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                ((System.ComponentModel.ISupportInitialize)(this.nubCount)).BeginInit();
                this.groupBox1.SuspendLayout();
                this.groupBox2.SuspendLayout();
                this.SuspendLayout();
                // 
                // btnOK
                // 
                this.btnOK.Location = new System.Drawing.Point(248, 328);
                this.btnOK.Name = "btnOK";
                this.btnOK.Size = new System.Drawing.Size(75, 23);
                this.btnOK.TabIndex = 0;
                this.btnOK.Text = "确定";
                this.btnOK.UseVisualStyleBackColor = true;
                this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
                // 
                // cbxDepart
                // 
                this.cbxDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbxDepart.FormattingEnabled = true;
                this.cbxDepart.Location = new System.Drawing.Point(85, 20);
                this.cbxDepart.Name = "cbxDepart";
                this.cbxDepart.Size = new System.Drawing.Size(99, 20);
                this.cbxDepart.TabIndex = 1;
                this.cbxDepart.SelectionChangeCommitted += new System.EventHandler(this.cbxDepart_SelectionChangeCommitted);
                // 
                // txtBooker
                // 
                this.txtBooker.Location = new System.Drawing.Point(84, 80);
                this.txtBooker.Name = "txtBooker";
                this.txtBooker.ReadOnly = true;
                this.txtBooker.Size = new System.Drawing.Size(100, 21);
                this.txtBooker.TabIndex = 2;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(13, 30);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(41, 12);
                this.label1.TabIndex = 3;
                this.label1.Text = "编号：";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(12, 26);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(65, 12);
                this.label2.TabIndex = 3;
                this.label2.Text = "领用部门：";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(13, 56);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(53, 12);
                this.label3.TabIndex = 3;
                this.label3.Text = "领用人：";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(217, 26);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(65, 12);
                this.label4.TabIndex = 3;
                this.label4.Text = "领用日期：";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(217, 53);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(41, 12);
                this.label5.TabIndex = 3;
                this.label5.Text = "数量：";
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Location = new System.Drawing.Point(13, 89);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(53, 12);
                this.label6.TabIndex = 3;
                this.label6.Text = "经手人：";
                // 
                // cbxEmp
                // 
                this.cbxEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbxEmp.FormattingEnabled = true;
                this.cbxEmp.Location = new System.Drawing.Point(85, 50);
                this.cbxEmp.Name = "cbxEmp";
                this.cbxEmp.Size = new System.Drawing.Size(99, 20);
                this.cbxEmp.TabIndex = 1;
                // 
                // nubCount
                // 
                this.nubCount.Location = new System.Drawing.Point(295, 50);
                this.nubCount.Name = "nubCount";
                this.nubCount.Size = new System.Drawing.Size(110, 21);
                this.nubCount.TabIndex = 4;
                this.nubCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
                // 
                // btnCancel
                // 
                this.btnCancel.Location = new System.Drawing.Point(352, 328);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(75, 23);
                this.btnCancel.TabIndex = 0;
                this.btnCancel.Text = "取消";
                this.btnCancel.UseVisualStyleBackColor = true;
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // dtpDate
                // 
                this.dtpDate.Location = new System.Drawing.Point(295, 20);
                this.dtpDate.Name = "dtpDate";
                this.dtpDate.Size = new System.Drawing.Size(110, 21);
                this.dtpDate.TabIndex = 5;
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.label12);
                this.groupBox1.Controls.Add(this.label8);
                this.groupBox1.Controls.Add(this.label10);
                this.groupBox1.Controls.Add(this.label9);
                this.groupBox1.Controls.Add(this.label11);
                this.groupBox1.Controls.Add(this.label7);
                this.groupBox1.Controls.Add(this.label1);
                this.groupBox1.Controls.Add(this.txtEqNO);
                this.groupBox1.Controls.Add(this.txtLabel);
                this.groupBox1.Controls.Add(this.txtType);
                this.groupBox1.Controls.Add(this.txtPlus);
                this.groupBox1.Controls.Add(this.txtModel);
                this.groupBox1.Controls.Add(this.txtMaxNO);
                this.groupBox1.Controls.Add(this.txtName);
                this.groupBox1.Location = new System.Drawing.Point(28, 31);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(432, 150);
                this.groupBox1.TabIndex = 6;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "资产基本信息";
                // 
                // label12
                // 
                this.label12.AutoSize = true;
                this.label12.Location = new System.Drawing.Point(13, 83);
                this.label12.Name = "label12";
                this.label12.Size = new System.Drawing.Size(41, 12);
                this.label12.TabIndex = 3;
                this.label12.Text = "品牌：";
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.Location = new System.Drawing.Point(13, 56);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(41, 12);
                this.label8.TabIndex = 3;
                this.label8.Text = "类别：";
                // 
                // label10
                // 
                this.label10.AutoSize = true;
                this.label10.Location = new System.Drawing.Point(11, 113);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(41, 12);
                this.label10.TabIndex = 3;
                this.label10.Text = "配置：";
                // 
                // label9
                // 
                this.label9.AutoSize = true;
                this.label9.Location = new System.Drawing.Point(206, 87);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(41, 12);
                this.label9.TabIndex = 3;
                this.label9.Text = "型号：";
                // 
                // label11
                // 
                this.label11.AutoSize = true;
                this.label11.BackColor = System.Drawing.Color.Transparent;
                this.label11.Location = new System.Drawing.Point(205, 56);
                this.label11.Name = "label11";
                this.label11.Size = new System.Drawing.Size(101, 12);
                this.label11.TabIndex = 3;
                this.label11.Text = "最大可领用数量：";
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Location = new System.Drawing.Point(204, 28);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(41, 12);
                this.label7.TabIndex = 3;
                this.label7.Text = "名称：";
                // 
                // txtEqNO
                // 
                this.txtEqNO.Location = new System.Drawing.Point(69, 25);
                this.txtEqNO.Name = "txtEqNO";
                this.txtEqNO.ReadOnly = true;
                this.txtEqNO.Size = new System.Drawing.Size(100, 21);
                this.txtEqNO.TabIndex = 2;
                // 
                // txtLabel
                // 
                this.txtLabel.Location = new System.Drawing.Point(69, 80);
                this.txtLabel.Name = "txtLabel";
                this.txtLabel.ReadOnly = true;
                this.txtLabel.Size = new System.Drawing.Size(100, 21);
                this.txtLabel.TabIndex = 2;
                // 
                // txtType
                // 
                this.txtType.Location = new System.Drawing.Point(69, 53);
                this.txtType.Name = "txtType";
                this.txtType.ReadOnly = true;
                this.txtType.Size = new System.Drawing.Size(100, 21);
                this.txtType.TabIndex = 2;
                // 
                // txtPlus
                // 
                this.txtPlus.Location = new System.Drawing.Point(67, 110);
                this.txtPlus.Name = "txtPlus";
                this.txtPlus.ReadOnly = true;
                this.txtPlus.Size = new System.Drawing.Size(339, 21);
                this.txtPlus.TabIndex = 2;
                // 
                // txtModel
                // 
                this.txtModel.Location = new System.Drawing.Point(262, 80);
                this.txtModel.Name = "txtModel";
                this.txtModel.ReadOnly = true;
                this.txtModel.Size = new System.Drawing.Size(144, 21);
                this.txtModel.TabIndex = 2;
                // 
                // txtMaxNO
                // 
                this.txtMaxNO.Location = new System.Drawing.Point(306, 53);
                this.txtMaxNO.Name = "txtMaxNO";
                this.txtMaxNO.ReadOnly = true;
                this.txtMaxNO.Size = new System.Drawing.Size(100, 21);
                this.txtMaxNO.TabIndex = 2;
                // 
                // txtName
                // 
                this.txtName.Location = new System.Drawing.Point(306, 25);
                this.txtName.Name = "txtName";
                this.txtName.ReadOnly = true;
                this.txtName.Size = new System.Drawing.Size(100, 21);
                this.txtName.TabIndex = 2;
                // 
                // groupBox2
                // 
                this.groupBox2.Controls.Add(this.cbxDepart);
                this.groupBox2.Controls.Add(this.label2);
                this.groupBox2.Controls.Add(this.label6);
                this.groupBox2.Controls.Add(this.dtpDate);
                this.groupBox2.Controls.Add(this.label3);
                this.groupBox2.Controls.Add(this.label5);
                this.groupBox2.Controls.Add(this.txtBooker);
                this.groupBox2.Controls.Add(this.cbxEmp);
                this.groupBox2.Controls.Add(this.nubCount);
                this.groupBox2.Controls.Add(this.label4);
                this.groupBox2.Location = new System.Drawing.Point(29, 187);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(431, 117);
                this.groupBox2.TabIndex = 7;
                this.groupBox2.TabStop = false;
                this.groupBox2.Text = "资产领用信息";
                // 
                // frmBorrow
                // 
                this.AcceptButton = this.btnOK;
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(480, 378);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.groupBox1);
                this.Controls.Add(this.btnCancel);
                this.Controls.Add(this.btnOK);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "frmBorrow";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "资产领用";
                this.Load += new System.EventHandler(this.frmBorrow_Load);
                ((System.ComponentModel.ISupportInitialize)(this.nubCount)).EndInit();
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.groupBox2.ResumeLayout(false);
                this.groupBox2.PerformLayout();
                this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxDepart;
        private System.Windows.Forms.TextBox txtBooker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxEmp;
        private System.Windows.Forms.NumericUpDown nubCount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEqNO;
        private System.Windows.Forms.TextBox txtPlus;
        private System.Windows.Forms.TextBox txtMaxNO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLabel;
    }
}