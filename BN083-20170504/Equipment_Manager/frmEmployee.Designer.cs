namespace Equipment_Manager
{
    partial class frmEmployee
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
                this.tvwEmp = new System.Windows.Forms.TreeView();
                this.imgemp = new System.Windows.Forms.ImageList(this.components);
                this.panel1 = new System.Windows.Forms.Panel();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                this.tctrEmp = new System.Windows.Forms.TabControl();
                this.tbpInfo = new System.Windows.Forms.TabPage();
                this.dbgEmp = new System.Windows.Forms.DataGridView();
                this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.ToolMenuItem_update = new System.Windows.Forms.ToolStripMenuItem();
                this.ToolMenuItem_del = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
                this.ToolMenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
                this.ToolMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
                this.tbpAdd = new System.Windows.Forms.TabPage();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.cbxNewDepart = new System.Windows.Forms.ComboBox();
                this.rabMale = new System.Windows.Forms.RadioButton();
                this.rabFemale = new System.Windows.Forms.RadioButton();
                this.label5 = new System.Windows.Forms.Label();
                this.txtNewName = new System.Windows.Forms.TextBox();
                this.label4 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.tbpUpdate = new System.Windows.Forms.TabPage();
                this.pictureBox2 = new System.Windows.Forms.PictureBox();
                this.cbxDepart = new System.Windows.Forms.ComboBox();
                this.rabBoy = new System.Windows.Forms.RadioButton();
                this.rabGirl = new System.Windows.Forms.RadioButton();
                this.label3 = new System.Windows.Forms.Label();
                this.txtEmpNo = new System.Windows.Forms.TextBox();
                this.txtName = new System.Windows.Forms.TextBox();
                this.label6 = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.toolSearh = new System.Windows.Forms.ToolStrip();
                this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
                this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
                this.toolcbxSearchtype = new System.Windows.Forms.ToolStripComboBox();
                this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
                this.tooltxtContaint = new System.Windows.Forms.ToolStripTextBox();
                this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnSearch = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnAll = new System.Windows.Forms.ToolStripButton();
                this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
                this.toolbtnDel = new System.Windows.Forms.ToolStripButton();
                this.panel1.SuspendLayout();
                this.tctrEmp.SuspendLayout();
                this.tbpInfo.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dbgEmp)).BeginInit();
                this.contextMenuStrip1.SuspendLayout();
                this.tbpAdd.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.tbpUpdate.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                this.toolSearh.SuspendLayout();
                this.SuspendLayout();
                // 
                // tvwEmp
                // 
                this.tvwEmp.Dock = System.Windows.Forms.DockStyle.Left;
                this.tvwEmp.ImageIndex = 0;
                this.tvwEmp.ImageList = this.imgemp;
                this.tvwEmp.Location = new System.Drawing.Point(0, 0);
                this.tvwEmp.Name = "tvwEmp";
                this.tvwEmp.SelectedImageIndex = 0;
                this.tvwEmp.Size = new System.Drawing.Size(200, 341);
                this.tvwEmp.TabIndex = 0;
                this.tvwEmp.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwEmp_AfterSelect);
                // 
                // imgemp
                // 
                this.imgemp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgemp.ImageStream")));
                this.imgemp.TransparentColor = System.Drawing.Color.Transparent;
                this.imgemp.Images.SetKeyName(0, "chart_organisation_add.png");
                this.imgemp.Images.SetKeyName(1, "house.png");
                this.imgemp.Images.SetKeyName(2, "user.png");
                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.btnSave);
                this.panel1.Controls.Add(this.btnClose);
                this.panel1.Controls.Add(this.tctrEmp);
                this.panel1.Controls.Add(this.toolSearh);
                this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.panel1.Location = new System.Drawing.Point(200, 0);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(414, 341);
                this.panel1.TabIndex = 1;
                // 
                // btnSave
                // 
                this.btnSave.Location = new System.Drawing.Point(224, 295);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(75, 23);
                this.btnSave.TabIndex = 4;
                this.btnSave.Text = "保存";
                this.btnSave.UseVisualStyleBackColor = true;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnClose
                // 
                this.btnClose.Location = new System.Drawing.Point(320, 295);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(75, 23);
                this.btnClose.TabIndex = 3;
                this.btnClose.Text = "关闭";
                this.btnClose.UseVisualStyleBackColor = true;
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // tctrEmp
                // 
                this.tctrEmp.Controls.Add(this.tbpInfo);
                this.tctrEmp.Controls.Add(this.tbpAdd);
                this.tctrEmp.Controls.Add(this.tbpUpdate);
                this.tctrEmp.Location = new System.Drawing.Point(0, 23);
                this.tctrEmp.Name = "tctrEmp";
                this.tctrEmp.SelectedIndex = 0;
                this.tctrEmp.Size = new System.Drawing.Size(414, 253);
                this.tctrEmp.TabIndex = 0;
                this.tctrEmp.SelectedIndexChanged += new System.EventHandler(this.tctrEmp_SelectedIndexChanged);
                // 
                // tbpInfo
                // 
                this.tbpInfo.Controls.Add(this.dbgEmp);
                this.tbpInfo.Location = new System.Drawing.Point(4, 22);
                this.tbpInfo.Name = "tbpInfo";
                this.tbpInfo.Padding = new System.Windows.Forms.Padding(3);
                this.tbpInfo.Size = new System.Drawing.Size(406, 227);
                this.tbpInfo.TabIndex = 0;
                this.tbpInfo.Text = "员工信息";
                this.tbpInfo.UseVisualStyleBackColor = true;
                // 
                // dbgEmp
                // 
                this.dbgEmp.AllowUserToAddRows = false;
                this.dbgEmp.AllowUserToDeleteRows = false;
                this.dbgEmp.AllowUserToOrderColumns = true;
                this.dbgEmp.AllowUserToResizeRows = false;
                this.dbgEmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dbgEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dbgEmp.ContextMenuStrip = this.contextMenuStrip1;
                this.dbgEmp.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dbgEmp.Location = new System.Drawing.Point(3, 3);
                this.dbgEmp.Name = "dbgEmp";
                this.dbgEmp.ReadOnly = true;
                this.dbgEmp.RowHeadersVisible = false;
                this.dbgEmp.RowTemplate.Height = 23;
                this.dbgEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dbgEmp.Size = new System.Drawing.Size(400, 221);
                this.dbgEmp.TabIndex = 0;
                this.dbgEmp.TabStop = false;
                // 
                // contextMenuStrip1
                // 
                this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolMenuItem_update,
            this.ToolMenuItem_del,
            this.toolStripSeparator7,
            this.ToolMenuItem_Refresh,
            this.toolStripSeparator8,
            this.ToolMenuItem_Close});
                this.contextMenuStrip1.Name = "contextMenuStrip1";
                this.contextMenuStrip1.Size = new System.Drawing.Size(125, 104);
                // 
                // ToolMenuItem_update
                // 
                this.ToolMenuItem_update.Name = "ToolMenuItem_update";
                this.ToolMenuItem_update.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_update.Text = "修改资料";
                this.ToolMenuItem_update.Click += new System.EventHandler(this.ToolMenuItem_update_Click);
                // 
                // ToolMenuItem_del
                // 
                this.ToolMenuItem_del.Name = "ToolMenuItem_del";
                this.ToolMenuItem_del.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_del.Text = "删除";
                this.ToolMenuItem_del.Click += new System.EventHandler(this.ToolMenuItem_del_Click);
                // 
                // toolStripSeparator7
                // 
                this.toolStripSeparator7.Name = "toolStripSeparator7";
                this.toolStripSeparator7.Size = new System.Drawing.Size(121, 6);
                // 
                // ToolMenuItem_Refresh
                // 
                this.ToolMenuItem_Refresh.Name = "ToolMenuItem_Refresh";
                this.ToolMenuItem_Refresh.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_Refresh.Text = "刷新";
                this.ToolMenuItem_Refresh.Click += new System.EventHandler(this.ToolMenuItem_Refresh_Click);
                // 
                // toolStripSeparator8
                // 
                this.toolStripSeparator8.Name = "toolStripSeparator8";
                this.toolStripSeparator8.Size = new System.Drawing.Size(121, 6);
                // 
                // ToolMenuItem_Close
                // 
                this.ToolMenuItem_Close.Name = "ToolMenuItem_Close";
                this.ToolMenuItem_Close.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_Close.Text = "关闭";
                this.ToolMenuItem_Close.Click += new System.EventHandler(this.ToolMenuItem_Close_Click);
                // 
                // tbpAdd
                // 
                this.tbpAdd.Controls.Add(this.pictureBox1);
                this.tbpAdd.Controls.Add(this.cbxNewDepart);
                this.tbpAdd.Controls.Add(this.rabMale);
                this.tbpAdd.Controls.Add(this.rabFemale);
                this.tbpAdd.Controls.Add(this.label5);
                this.tbpAdd.Controls.Add(this.txtNewName);
                this.tbpAdd.Controls.Add(this.label4);
                this.tbpAdd.Controls.Add(this.label2);
                this.tbpAdd.Location = new System.Drawing.Point(4, 22);
                this.tbpAdd.Name = "tbpAdd";
                this.tbpAdd.Padding = new System.Windows.Forms.Padding(3);
                this.tbpAdd.Size = new System.Drawing.Size(406, 227);
                this.tbpAdd.TabIndex = 1;
                this.tbpAdd.Text = "新员工注册";
                this.tbpAdd.UseVisualStyleBackColor = true;
                // 
                // pictureBox1
                // 
                this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                this.pictureBox1.Location = new System.Drawing.Point(268, 45);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(128, 128);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.pictureBox1.TabIndex = 5;
                this.pictureBox1.TabStop = false;
                // 
                // cbxNewDepart
                // 
                this.cbxNewDepart.FormattingEnabled = true;
                this.cbxNewDepart.Location = new System.Drawing.Point(115, 125);
                this.cbxNewDepart.Name = "cbxNewDepart";
                this.cbxNewDepart.Size = new System.Drawing.Size(121, 20);
                this.cbxNewDepart.TabIndex = 4;
                // 
                // rabMale
                // 
                this.rabMale.AutoSize = true;
                this.rabMale.Location = new System.Drawing.Point(167, 87);
                this.rabMale.Name = "rabMale";
                this.rabMale.Size = new System.Drawing.Size(35, 16);
                this.rabMale.TabIndex = 3;
                this.rabMale.TabStop = true;
                this.rabMale.Text = "男";
                this.rabMale.UseVisualStyleBackColor = true;
                // 
                // rabFemale
                // 
                this.rabFemale.AutoSize = true;
                this.rabFemale.Location = new System.Drawing.Point(115, 87);
                this.rabFemale.Name = "rabFemale";
                this.rabFemale.Size = new System.Drawing.Size(35, 16);
                this.rabFemale.TabIndex = 3;
                this.rabFemale.TabStop = true;
                this.rabFemale.Text = "女";
                this.rabFemale.UseVisualStyleBackColor = true;
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(41, 128);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(41, 12);
                this.label5.TabIndex = 0;
                this.label5.Text = "部门：";
                // 
                // txtNewName
                // 
                this.txtNewName.Location = new System.Drawing.Point(115, 40);
                this.txtNewName.Name = "txtNewName";
                this.txtNewName.Size = new System.Drawing.Size(121, 21);
                this.txtNewName.TabIndex = 1;
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(41, 89);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(41, 12);
                this.label4.TabIndex = 0;
                this.label4.Text = "性别：";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(41, 43);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(41, 12);
                this.label2.TabIndex = 0;
                this.label2.Text = "姓名：";
                // 
                // tbpUpdate
                // 
                this.tbpUpdate.Controls.Add(this.pictureBox2);
                this.tbpUpdate.Controls.Add(this.cbxDepart);
                this.tbpUpdate.Controls.Add(this.rabBoy);
                this.tbpUpdate.Controls.Add(this.rabGirl);
                this.tbpUpdate.Controls.Add(this.label3);
                this.tbpUpdate.Controls.Add(this.txtEmpNo);
                this.tbpUpdate.Controls.Add(this.txtName);
                this.tbpUpdate.Controls.Add(this.label6);
                this.tbpUpdate.Controls.Add(this.label9);
                this.tbpUpdate.Controls.Add(this.label7);
                this.tbpUpdate.Location = new System.Drawing.Point(4, 22);
                this.tbpUpdate.Name = "tbpUpdate";
                this.tbpUpdate.Padding = new System.Windows.Forms.Padding(3);
                this.tbpUpdate.Size = new System.Drawing.Size(406, 227);
                this.tbpUpdate.TabIndex = 3;
                this.tbpUpdate.Text = "修改信息";
                this.tbpUpdate.UseVisualStyleBackColor = true;
                // 
                // pictureBox2
                // 
                this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
                this.pictureBox2.Location = new System.Drawing.Point(263, 38);
                this.pictureBox2.Name = "pictureBox2";
                this.pictureBox2.Size = new System.Drawing.Size(128, 128);
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.pictureBox2.TabIndex = 14;
                this.pictureBox2.TabStop = false;
                // 
                // cbxDepart
                // 
                this.cbxDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbxDepart.FormattingEnabled = true;
                this.cbxDepart.Location = new System.Drawing.Point(119, 146);
                this.cbxDepart.Name = "cbxDepart";
                this.cbxDepart.Size = new System.Drawing.Size(121, 20);
                this.cbxDepart.TabIndex = 13;
                // 
                // rabBoy
                // 
                this.rabBoy.AutoSize = true;
                this.rabBoy.Location = new System.Drawing.Point(173, 112);
                this.rabBoy.Name = "rabBoy";
                this.rabBoy.Size = new System.Drawing.Size(35, 16);
                this.rabBoy.TabIndex = 11;
                this.rabBoy.TabStop = true;
                this.rabBoy.Text = "男";
                this.rabBoy.UseVisualStyleBackColor = true;
                // 
                // rabGirl
                // 
                this.rabGirl.AutoSize = true;
                this.rabGirl.Location = new System.Drawing.Point(119, 112);
                this.rabGirl.Name = "rabGirl";
                this.rabGirl.Size = new System.Drawing.Size(35, 16);
                this.rabGirl.TabIndex = 12;
                this.rabGirl.TabStop = true;
                this.rabGirl.Text = "女";
                this.rabGirl.UseVisualStyleBackColor = true;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(45, 150);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(41, 12);
                this.label3.TabIndex = 5;
                this.label3.Text = "部门：";
                // 
                // txtEmpNo
                // 
                this.txtEmpNo.Enabled = false;
                this.txtEmpNo.Location = new System.Drawing.Point(119, 30);
                this.txtEmpNo.Name = "txtEmpNo";
                this.txtEmpNo.Size = new System.Drawing.Size(121, 21);
                this.txtEmpNo.TabIndex = 10;
                // 
                // txtName
                // 
                this.txtName.Location = new System.Drawing.Point(119, 73);
                this.txtName.Name = "txtName";
                this.txtName.Size = new System.Drawing.Size(121, 21);
                this.txtName.TabIndex = 10;
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Location = new System.Drawing.Point(45, 114);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(41, 12);
                this.label6.TabIndex = 6;
                this.label6.Text = "性别：";
                // 
                // label9
                // 
                this.label9.AutoSize = true;
                this.label9.Location = new System.Drawing.Point(45, 33);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(41, 12);
                this.label9.TabIndex = 7;
                this.label9.Text = "工号：";
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Location = new System.Drawing.Point(45, 76);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(41, 12);
                this.label7.TabIndex = 7;
                this.label7.Text = "姓名：";
                // 
                // toolSearh
                // 
                this.toolSearh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolcbxSearchtype,
            this.toolStripSeparator2,
            this.tooltxtContaint,
            this.toolStripSeparator5,
            this.toolbtnSearch,
            this.toolStripSeparator3,
            this.toolbtnAll,
            this.toolStripSeparator4,
            this.toolbtnDel});
                this.toolSearh.Location = new System.Drawing.Point(0, 0);
                this.toolSearh.Name = "toolSearh";
                this.toolSearh.Size = new System.Drawing.Size(414, 25);
                this.toolSearh.TabIndex = 0;
                this.toolSearh.Text = "toolStrip1";
                // 
                // toolStripLabel1
                // 
                this.toolStripLabel1.Name = "toolStripLabel1";
                this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
                this.toolStripLabel1.Text = "条件查询：";
                // 
                // toolStripSeparator1
                // 
                this.toolStripSeparator1.Name = "toolStripSeparator1";
                this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
                // 
                // toolcbxSearchtype
                // 
                this.toolcbxSearchtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.toolcbxSearchtype.Items.AddRange(new object[] {
            "工号",
            "姓名",
            "性别",
            "所在部门"});
                this.toolcbxSearchtype.Name = "toolcbxSearchtype";
                this.toolcbxSearchtype.Size = new System.Drawing.Size(100, 25);
                // 
                // toolStripSeparator2
                // 
                this.toolStripSeparator2.Name = "toolStripSeparator2";
                this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
                // 
                // tooltxtContaint
                // 
                this.tooltxtContaint.Name = "tooltxtContaint";
                this.tooltxtContaint.Size = new System.Drawing.Size(70, 25);
                // 
                // toolStripSeparator5
                // 
                this.toolStripSeparator5.Name = "toolStripSeparator5";
                this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnSearch
                // 
                this.toolbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                this.toolbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSearch.Image")));
                this.toolbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnSearch.Name = "toolbtnSearch";
                this.toolbtnSearch.Size = new System.Drawing.Size(23, 22);
                this.toolbtnSearch.Text = "查询";
                this.toolbtnSearch.Click += new System.EventHandler(this.toolbtnSearch_Click);
                // 
                // toolStripSeparator3
                // 
                this.toolStripSeparator3.Name = "toolStripSeparator3";
                this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnAll
                // 
                this.toolbtnAll.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnAll.Image")));
                this.toolbtnAll.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnAll.Name = "toolbtnAll";
                this.toolbtnAll.Size = new System.Drawing.Size(76, 22);
                this.toolbtnAll.Text = "所有员工";
                this.toolbtnAll.Click += new System.EventHandler(this.toolbtnAll_Click);
                // 
                // toolStripSeparator4
                // 
                this.toolStripSeparator4.Name = "toolStripSeparator4";
                this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
                // 
                // toolbtnDel
                // 
                this.toolbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                this.toolbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnDel.Image")));
                this.toolbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolbtnDel.Name = "toolbtnDel";
                this.toolbtnDel.Size = new System.Drawing.Size(23, 22);
                this.toolbtnDel.Text = "toolStripButton1";
                this.toolbtnDel.ToolTipText = "删除";
                this.toolbtnDel.Click += new System.EventHandler(this.toolbtnDel_Click);
                // 
                // frmEmployee
                // 
                this.AcceptButton = this.btnSave;
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(614, 341);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.tvwEmp);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmEmployee";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "员工管理";
                this.Load += new System.EventHandler(this.frmEmployee_Load);
                this.panel1.ResumeLayout(false);
                this.panel1.PerformLayout();
                this.tctrEmp.ResumeLayout(false);
                this.tbpInfo.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.dbgEmp)).EndInit();
                this.contextMenuStrip1.ResumeLayout(false);
                this.tbpAdd.ResumeLayout(false);
                this.tbpAdd.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.tbpUpdate.ResumeLayout(false);
                this.tbpUpdate.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                this.toolSearh.ResumeLayout(false);
                this.toolSearh.PerformLayout();
                this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvwEmp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tctrEmp;
        private System.Windows.Forms.TabPage tbpInfo;
        private System.Windows.Forms.TabPage tbpAdd;
        private System.Windows.Forms.DataGridView dbgEmp;
        private System.Windows.Forms.TabPage tbpUpdate;
        private System.Windows.Forms.ToolStrip toolSearh;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolcbxSearchtype;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tooltxtContaint;
        private System.Windows.Forms.ToolStripButton toolbtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolbtnAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ComboBox cbxNewDepart;
        private System.Windows.Forms.RadioButton rabMale;
        private System.Windows.Forms.RadioButton rabFemale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripButton toolbtnDel;
        private System.Windows.Forms.ComboBox cbxDepart;
        private System.Windows.Forms.RadioButton rabBoy;
        private System.Windows.Forms.RadioButton rabGirl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_update;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Close;
        private System.Windows.Forms.ImageList imgemp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}