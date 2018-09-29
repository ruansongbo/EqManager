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
            this.txtNewEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNewTel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbxNewDepart = new System.Windows.Forms.ComboBox();
            this.rabMale = new System.Windows.Forms.RadioButton();
            this.rabFemale = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpUpdate = new System.Windows.Forms.TabPage();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
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
            this.tvwEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tvwEmp.Name = "tvwEmp";
            this.tvwEmp.SelectedImageIndex = 0;
            this.tvwEmp.Size = new System.Drawing.Size(265, 455);
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
            this.panel1.Location = new System.Drawing.Point(265, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 455);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 408);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 31);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(433, 408);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 31);
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
            this.tctrEmp.Location = new System.Drawing.Point(0, 31);
            this.tctrEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tctrEmp.Name = "tctrEmp";
            this.tctrEmp.SelectedIndex = 0;
            this.tctrEmp.Size = new System.Drawing.Size(673, 355);
            this.tctrEmp.TabIndex = 0;
            this.tctrEmp.SelectedIndexChanged += new System.EventHandler(this.tctrEmp_SelectedIndexChanged);
            // 
            // tbpInfo
            // 
            this.tbpInfo.Controls.Add(this.dbgEmp);
            this.tbpInfo.Location = new System.Drawing.Point(4, 26);
            this.tbpInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbpInfo.Name = "tbpInfo";
            this.tbpInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbpInfo.Size = new System.Drawing.Size(665, 325);
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
            this.dbgEmp.Location = new System.Drawing.Point(4, 4);
            this.dbgEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dbgEmp.Name = "dbgEmp";
            this.dbgEmp.ReadOnly = true;
            this.dbgEmp.RowHeadersVisible = false;
            this.dbgEmp.RowTemplate.Height = 23;
            this.dbgEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgEmp.Size = new System.Drawing.Size(657, 317);
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
            this.tbpAdd.Controls.Add(this.txtNewEmail);
            this.tbpAdd.Controls.Add(this.label10);
            this.tbpAdd.Controls.Add(this.txtNewTel);
            this.tbpAdd.Controls.Add(this.label8);
            this.tbpAdd.Controls.Add(this.txtNewId);
            this.tbpAdd.Controls.Add(this.label1);
            this.tbpAdd.Controls.Add(this.pictureBox1);
            this.tbpAdd.Controls.Add(this.cbxNewDepart);
            this.tbpAdd.Controls.Add(this.rabMale);
            this.tbpAdd.Controls.Add(this.rabFemale);
            this.tbpAdd.Controls.Add(this.label5);
            this.tbpAdd.Controls.Add(this.txtNewName);
            this.tbpAdd.Controls.Add(this.label4);
            this.tbpAdd.Controls.Add(this.label2);
            this.tbpAdd.Location = new System.Drawing.Point(4, 22);
            this.tbpAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbpAdd.Name = "tbpAdd";
            this.tbpAdd.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbpAdd.Size = new System.Drawing.Size(665, 329);
            this.tbpAdd.TabIndex = 1;
            this.tbpAdd.Text = "新员工注册";
            this.tbpAdd.UseVisualStyleBackColor = true;
            // 
            // txtNewEmail
            // 
            this.txtNewEmail.Location = new System.Drawing.Point(151, 275);
            this.txtNewEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewEmail.Name = "txtNewEmail";
            this.txtNewEmail.Size = new System.Drawing.Size(241, 26);
            this.txtNewEmail.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 279);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "电子邮箱：";
            // 
            // txtNewTel
            // 
            this.txtNewTel.Location = new System.Drawing.Point(151, 228);
            this.txtNewTel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewTel.Name = "txtNewTel";
            this.txtNewTel.Size = new System.Drawing.Size(241, 26);
            this.txtNewTel.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 232);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "联系电话：";
            // 
            // txtNewId
            // 
            this.txtNewId.Location = new System.Drawing.Point(152, 27);
            this.txtNewId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewId.Name = "txtNewId";
            this.txtNewId.Size = new System.Drawing.Size(240, 26);
            this.txtNewId.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "校园卡号：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(484, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // cbxNewDepart
            // 
            this.cbxNewDepart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxNewDepart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNewDepart.FormattingEnabled = true;
            this.cbxNewDepart.Location = new System.Drawing.Point(151, 173);
            this.cbxNewDepart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNewDepart.Name = "cbxNewDepart";
            this.cbxNewDepart.Size = new System.Drawing.Size(241, 24);
            this.cbxNewDepart.TabIndex = 4;
            // 
            // rabMale
            // 
            this.rabMale.AutoSize = true;
            this.rabMale.Location = new System.Drawing.Point(293, 129);
            this.rabMale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rabMale.Name = "rabMale";
            this.rabMale.Size = new System.Drawing.Size(42, 20);
            this.rabMale.TabIndex = 3;
            this.rabMale.TabStop = true;
            this.rabMale.Text = "男";
            this.rabMale.UseVisualStyleBackColor = true;
            // 
            // rabFemale
            // 
            this.rabFemale.AutoSize = true;
            this.rabFemale.Location = new System.Drawing.Point(151, 129);
            this.rabFemale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rabFemale.Name = "rabFemale";
            this.rabFemale.Size = new System.Drawing.Size(42, 20);
            this.rabFemale.TabIndex = 3;
            this.rabFemale.TabStop = true;
            this.rabFemale.Text = "女";
            this.rabFemale.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 177);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "部门：";
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(152, 75);
            this.txtNewName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(240, 26);
            this.txtNewName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "性别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名：";
            // 
            // tbpUpdate
            // 
            this.tbpUpdate.Controls.Add(this.txtEmail);
            this.tbpUpdate.Controls.Add(this.label11);
            this.tbpUpdate.Controls.Add(this.txtTel);
            this.tbpUpdate.Controls.Add(this.label12);
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
            this.tbpUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbpUpdate.Name = "tbpUpdate";
            this.tbpUpdate.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbpUpdate.Size = new System.Drawing.Size(665, 329);
            this.tbpUpdate.TabIndex = 3;
            this.tbpUpdate.Text = "修改信息";
            this.tbpUpdate.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(159, 287);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(233, 26);
            this.txtEmail.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 291);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "电子邮箱：";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(159, 240);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(233, 26);
            this.txtTel.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 244);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "联系电话：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(484, 51);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // cbxDepart
            // 
            this.cbxDepart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxDepart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxDepart.FormattingEnabled = true;
            this.cbxDepart.Location = new System.Drawing.Point(159, 195);
            this.cbxDepart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxDepart.Name = "cbxDepart";
            this.cbxDepart.Size = new System.Drawing.Size(233, 24);
            this.cbxDepart.TabIndex = 13;
            // 
            // rabBoy
            // 
            this.rabBoy.AutoSize = true;
            this.rabBoy.Location = new System.Drawing.Point(293, 149);
            this.rabBoy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rabBoy.Name = "rabBoy";
            this.rabBoy.Size = new System.Drawing.Size(42, 20);
            this.rabBoy.TabIndex = 11;
            this.rabBoy.TabStop = true;
            this.rabBoy.Text = "男";
            this.rabBoy.UseVisualStyleBackColor = true;
            // 
            // rabGirl
            // 
            this.rabGirl.AutoSize = true;
            this.rabGirl.Location = new System.Drawing.Point(159, 149);
            this.rabGirl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rabGirl.Name = "rabGirl";
            this.rabGirl.Size = new System.Drawing.Size(42, 20);
            this.rabGirl.TabIndex = 12;
            this.rabGirl.TabStop = true;
            this.rabGirl.Text = "女";
            this.rabGirl.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "部门：";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Enabled = false;
            this.txtEmpNo.Location = new System.Drawing.Point(159, 40);
            this.txtEmpNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(233, 26);
            this.txtEmpNo.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(159, 97);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(233, 26);
            this.txtName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 152);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "性别：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "编号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 101);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "姓名：";
            // 
            // toolSearh
            // 
            this.toolSearh.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.toolSearh.Size = new System.Drawing.Size(679, 28);
            this.toolSearh.TabIndex = 0;
            this.toolSearh.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 25);
            this.toolStripLabel1.Text = "条件查询：";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
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
            this.toolcbxSearchtype.Size = new System.Drawing.Size(132, 28);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tooltxtContaint
            // 
            this.tooltxtContaint.Name = "tooltxtContaint";
            this.tooltxtContaint.Size = new System.Drawing.Size(92, 28);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnSearch
            // 
            this.toolbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnSearch.Image")));
            this.toolbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSearch.Name = "toolbtnSearch";
            this.toolbtnSearch.Size = new System.Drawing.Size(23, 25);
            this.toolbtnSearch.Text = "查询";
            this.toolbtnSearch.Click += new System.EventHandler(this.toolbtnSearch_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnAll
            // 
            this.toolbtnAll.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnAll.Image")));
            this.toolbtnAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnAll.Name = "toolbtnAll";
            this.toolbtnAll.Size = new System.Drawing.Size(94, 25);
            this.toolbtnAll.Text = "所有员工";
            this.toolbtnAll.Click += new System.EventHandler(this.toolbtnAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnDel
            // 
            this.toolbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnDel.Image")));
            this.toolbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDel.Name = "toolbtnDel";
            this.toolbtnDel.Size = new System.Drawing.Size(23, 25);
            this.toolbtnDel.Text = "toolStripButton1";
            this.toolbtnDel.ToolTipText = "删除";
            this.toolbtnDel.Click += new System.EventHandler(this.toolbtnDel_Click);
            // 
            // frmEmployee
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tvwEmp);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.TextBox txtNewId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNewTel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label12;
    }
}