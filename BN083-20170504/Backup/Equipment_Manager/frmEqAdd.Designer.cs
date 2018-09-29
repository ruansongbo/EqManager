namespace Equipment_Manager
{
    partial class frmEqAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEqAdd));
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPluse = new System.Windows.Forms.TextBox();
            this.lblEqNo = new System.Windows.Forms.Label();
            this.cbxEqName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddphoto = new System.Windows.Forms.Button();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.txtUsetime = new System.Windows.Forms.TextBox();
            this.nudNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLable = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpBookDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxKeepPlace = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxKeeper = new System.Windows.Forms.ComboBox();
            this.txtBooker = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxAddType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(401, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPluse
            // 
            this.txtPluse.Location = new System.Drawing.Point(324, 102);
            this.txtPluse.Name = "txtPluse";
            this.txtPluse.Size = new System.Drawing.Size(125, 21);
            this.txtPluse.TabIndex = 1;
            // 
            // lblEqNo
            // 
            this.lblEqNo.AutoSize = true;
            this.lblEqNo.Location = new System.Drawing.Point(94, 41);
            this.lblEqNo.Name = "lblEqNo";
            this.lblEqNo.Size = new System.Drawing.Size(47, 12);
            this.lblEqNo.TabIndex = 2;
            this.lblEqNo.Text = "lblEqNo";
            // 
            // cbxEqName
            // 
            this.cbxEqName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEqName.FormattingEnabled = true;
            this.cbxEqName.Location = new System.Drawing.Point(87, 68);
            this.cbxEqName.Name = "cbxEqName";
            this.cbxEqName.Size = new System.Drawing.Size(120, 20);
            this.cbxEqName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "资产名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "型号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "资产编号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "资产类型：";
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(87, 103);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(120, 20);
            this.cbxType.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "配置：";
            // 
            // txtModle
            // 
            this.txtModle.Location = new System.Drawing.Point(324, 67);
            this.txtModle.Name = "txtModle";
            this.txtModle.Size = new System.Drawing.Size(125, 21);
            this.txtModle.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnAddphoto);
            this.groupBox1.Controls.Add(this.picPhoto);
            this.groupBox1.Controls.Add(this.txtUsetime);
            this.groupBox1.Controls.Add(this.nudNum);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dtpBirth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbxUnit);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cbxType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblEqNo);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.txtMaker);
            this.groupBox1.Controls.Add(this.txtPluse);
            this.groupBox1.Controls.Add(this.cbxEqName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLable);
            this.groupBox1.Controls.Add(this.txtModle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(32, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 256);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "资产基本资料";
            // 
            // btnAddphoto
            // 
            this.btnAddphoto.Location = new System.Drawing.Point(521, 149);
            this.btnAddphoto.Name = "btnAddphoto";
            this.btnAddphoto.Size = new System.Drawing.Size(67, 23);
            this.btnAddphoto.TabIndex = 21;
            this.btnAddphoto.Text = "选择相片";
            this.btnAddphoto.UseVisualStyleBackColor = true;
            this.btnAddphoto.Click += new System.EventHandler(this.btnAddphoto_Click);
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.Transparent;
            this.picPhoto.Location = new System.Drawing.Point(459, 29);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(129, 107);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 20;
            this.picPhoto.TabStop = false;
            this.toolTip1.SetToolTip(this.picPhoto, "资产相片，支持JPG,GIF,BMP格式。尺寸为130*110效果最佳。");
            // 
            // txtUsetime
            // 
            this.txtUsetime.Location = new System.Drawing.Point(87, 175);
            this.txtUsetime.Name = "txtUsetime";
            this.txtUsetime.Size = new System.Drawing.Size(100, 21);
            this.txtUsetime.TabIndex = 19;
            // 
            // nudNum
            // 
            this.nudNum.Location = new System.Drawing.Point(324, 175);
            this.nudNum.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudNum.Name = "nudNum";
            this.nudNum.Size = new System.Drawing.Size(96, 21);
            this.nudNum.TabIndex = 18;
            this.nudNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(228, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1, 192);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Location = new System.Drawing.Point(86, 136);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(121, 21);
            this.dtpBirth.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "生产厂家：";
            // 
            // cbxUnit
            // 
            this.cbxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.Location = new System.Drawing.Point(472, 176);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(56, 20);
            this.cbxUnit.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(425, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "单位：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(260, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "单价：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(260, 180);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 11;
            this.label19.Text = "数量：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "生产时间：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(190, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 2;
            this.label17.Text = "年";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "预计寿命：";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(324, 136);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(125, 21);
            this.txtPrice.TabIndex = 1;
            // 
            // txtMaker
            // 
            this.txtMaker.Location = new System.Drawing.Point(87, 216);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(458, 21);
            this.txtMaker.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "品牌：";
            // 
            // txtLable
            // 
            this.txtLable.Location = new System.Drawing.Point(324, 32);
            this.txtLable.Name = "txtLable";
            this.txtLable.Size = new System.Drawing.Size(125, 21);
            this.txtLable.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpBookDate);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.cbxKeepPlace);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbxKeeper);
            this.groupBox2.Controls.Add(this.txtBooker);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cbxAddType);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(32, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 125);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "资产入库信息";
            // 
            // dtpBookDate
            // 
            this.dtpBookDate.Location = new System.Drawing.Point(369, 78);
            this.dtpBookDate.Name = "dtpBookDate";
            this.dtpBookDate.Size = new System.Drawing.Size(178, 21);
            this.dtpBookDate.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(298, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 14;
            this.label18.Text = "登记日期：";
            // 
            // cbxKeepPlace
            // 
            this.cbxKeepPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKeepPlace.FormattingEnabled = true;
            this.cbxKeepPlace.Location = new System.Drawing.Point(277, 33);
            this.cbxKeepPlace.Name = "cbxKeepPlace";
            this.cbxKeepPlace.Size = new System.Drawing.Size(104, 20);
            this.cbxKeepPlace.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "登记人：";
            // 
            // cbxKeeper
            // 
            this.cbxKeeper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKeeper.FormattingEnabled = true;
            this.cbxKeeper.Location = new System.Drawing.Point(459, 32);
            this.cbxKeeper.Name = "cbxKeeper";
            this.cbxKeeper.Size = new System.Drawing.Size(88, 20);
            this.cbxKeeper.TabIndex = 4;
            // 
            // txtBooker
            // 
            this.txtBooker.Location = new System.Drawing.Point(87, 78);
            this.txtBooker.Name = "txtBooker";
            this.txtBooker.ReadOnly = true;
            this.txtBooker.Size = new System.Drawing.Size(187, 21);
            this.txtBooker.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(209, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "存放地点：";
            // 
            // cbxAddType
            // 
            this.cbxAddType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAddType.FormattingEnabled = true;
            this.cbxAddType.Location = new System.Drawing.Point(87, 32);
            this.cbxAddType.Name = "cbxAddType";
            this.cbxAddType.Size = new System.Drawing.Size(104, 20);
            this.cbxAddType.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(400, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 11;
            this.label15.Text = "保管人：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "增长方式：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(504, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "no_image_available_large.gif");
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 60000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 200;
            this.toolTip1.ShowAlways = true;
            // 
            // frmEqAdd
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 493);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEqAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "金钥匙——资产增加";
            this.Load += new System.EventHandler(this.frmEqAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPluse;
        private System.Windows.Forms.Label lblEqNo;
        private System.Windows.Forms.ComboBox cbxEqName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtModle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpBookDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbxKeepPlace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxKeeper;
        private System.Windows.Forms.TextBox txtBooker;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxAddType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLable;
        private System.Windows.Forms.TextBox txtUsetime;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Button btnAddphoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}