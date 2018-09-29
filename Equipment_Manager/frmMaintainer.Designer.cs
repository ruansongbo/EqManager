namespace Equipment_Manager
{
    partial class frmMaintainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintainer));
            this.imgemp = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabMaintainer = new System.Windows.Forms.TabControl();
            this.tbpInfo = new System.Windows.Forms.TabPage();
            this.dgvMaintainer = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolMenuItem_update = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolMenuItem_del = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolMenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpAdd = new System.Windows.Forms.TabPage();
            this.txtNewId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewTel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNewContracts = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpUpdate = new System.Windows.Forms.TabPage();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContracts = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.panel1.SuspendLayout();
            this.tabMaintainer.SuspendLayout();
            this.tbpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintainer)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tbpAdd.SuspendLayout();
            this.tbpUpdate.SuspendLayout();
            this.toolSearh.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Controls.Add(this.tabMaintainer);
            this.panel1.Controls.Add(this.toolSearh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 341);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(224, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(325, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabMaintainer
            // 
            this.tabMaintainer.Controls.Add(this.tbpInfo);
            this.tabMaintainer.Controls.Add(this.tbpAdd);
            this.tabMaintainer.Controls.Add(this.tbpUpdate);
            this.tabMaintainer.Location = new System.Drawing.Point(0, 31);
            this.tabMaintainer.Name = "tabMaintainer";
            this.tabMaintainer.SelectedIndex = 0;
            this.tabMaintainer.Size = new System.Drawing.Size(595, 266);
            this.tabMaintainer.TabIndex = 0;
            this.tabMaintainer.SelectedIndexChanged += new System.EventHandler(this.tabMaintainer_SelectedIndexChanged);
            // 
            // tbpInfo
            // 
            this.tbpInfo.Controls.Add(this.dgvMaintainer);
            this.tbpInfo.Location = new System.Drawing.Point(4, 26);
            this.tbpInfo.Name = "tbpInfo";
            this.tbpInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInfo.Size = new System.Drawing.Size(587, 236);
            this.tbpInfo.TabIndex = 0;
            this.tbpInfo.Text = "维修商信息";
            this.tbpInfo.UseVisualStyleBackColor = true;
            // 
            // dgvMaintainer
            // 
            this.dgvMaintainer.AllowUserToAddRows = false;
            this.dgvMaintainer.AllowUserToDeleteRows = false;
            this.dgvMaintainer.AllowUserToOrderColumns = true;
            this.dgvMaintainer.AllowUserToResizeRows = false;
            this.dgvMaintainer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaintainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaintainer.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvMaintainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaintainer.Location = new System.Drawing.Point(3, 3);
            this.dgvMaintainer.Name = "dgvMaintainer";
            this.dgvMaintainer.ReadOnly = true;
            this.dgvMaintainer.RowHeadersVisible = false;
            this.dgvMaintainer.RowTemplate.Height = 23;
            this.dgvMaintainer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaintainer.Size = new System.Drawing.Size(581, 230);
            this.dgvMaintainer.TabIndex = 0;
            this.dgvMaintainer.TabStop = false;
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
            this.ToolMenuItem_update.Image = ((System.Drawing.Image)(resources.GetObject("ToolMenuItem_update.Image")));
            this.ToolMenuItem_update.Name = "ToolMenuItem_update";
            this.ToolMenuItem_update.Size = new System.Drawing.Size(124, 22);
            this.ToolMenuItem_update.Text = "修改资料";
            this.ToolMenuItem_update.Click += new System.EventHandler(this.ToolMenuItem_update_Click);
            // 
            // ToolMenuItem_del
            // 
            this.ToolMenuItem_del.Image = ((System.Drawing.Image)(resources.GetObject("ToolMenuItem_del.Image")));
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
            this.ToolMenuItem_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("ToolMenuItem_Refresh.Image")));
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
            this.ToolMenuItem_Close.Image = ((System.Drawing.Image)(resources.GetObject("ToolMenuItem_Close.Image")));
            this.ToolMenuItem_Close.Name = "ToolMenuItem_Close";
            this.ToolMenuItem_Close.Size = new System.Drawing.Size(124, 22);
            this.ToolMenuItem_Close.Text = "关闭";
            this.ToolMenuItem_Close.Click += new System.EventHandler(this.ToolMenuItem_Close_Click);
            // 
            // tbpAdd
            // 
            this.tbpAdd.Controls.Add(this.txtNewId);
            this.tbpAdd.Controls.Add(this.label4);
            this.tbpAdd.Controls.Add(this.txtNewTel);
            this.tbpAdd.Controls.Add(this.label10);
            this.tbpAdd.Controls.Add(this.txtNewContracts);
            this.tbpAdd.Controls.Add(this.label8);
            this.tbpAdd.Controls.Add(this.txtNewName);
            this.tbpAdd.Controls.Add(this.label1);
            this.tbpAdd.Controls.Add(this.txtNewAddress);
            this.tbpAdd.Controls.Add(this.label2);
            this.tbpAdd.Location = new System.Drawing.Point(4, 26);
            this.tbpAdd.Name = "tbpAdd";
            this.tbpAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAdd.Size = new System.Drawing.Size(587, 236);
            this.tbpAdd.TabIndex = 1;
            this.tbpAdd.Text = "增加维修商";
            this.tbpAdd.UseVisualStyleBackColor = true;
            // 
            // txtNewId
            // 
            this.txtNewId.Enabled = false;
            this.txtNewId.Location = new System.Drawing.Point(113, 23);
            this.txtNewId.Name = "txtNewId";
            this.txtNewId.ReadOnly = true;
            this.txtNewId.Size = new System.Drawing.Size(135, 26);
            this.txtNewId.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "编号：";
            // 
            // txtNewTel
            // 
            this.txtNewTel.Location = new System.Drawing.Point(113, 206);
            this.txtNewTel.Name = "txtNewTel";
            this.txtNewTel.Size = new System.Drawing.Size(283, 26);
            this.txtNewTel.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "联系电话：";
            // 
            // txtNewContracts
            // 
            this.txtNewContracts.Location = new System.Drawing.Point(112, 158);
            this.txtNewContracts.Name = "txtNewContracts";
            this.txtNewContracts.Size = new System.Drawing.Size(284, 26);
            this.txtNewContracts.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "联系人：";
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(113, 71);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(283, 26);
            this.txtNewName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "名称：";
            // 
            // txtNewAddress
            // 
            this.txtNewAddress.Location = new System.Drawing.Point(113, 116);
            this.txtNewAddress.Name = "txtNewAddress";
            this.txtNewAddress.Size = new System.Drawing.Size(283, 26);
            this.txtNewAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "地址：";
            // 
            // tbpUpdate
            // 
            this.tbpUpdate.Controls.Add(this.txtId);
            this.tbpUpdate.Controls.Add(this.label3);
            this.tbpUpdate.Controls.Add(this.txtTel);
            this.tbpUpdate.Controls.Add(this.label5);
            this.tbpUpdate.Controls.Add(this.txtContracts);
            this.tbpUpdate.Controls.Add(this.label6);
            this.tbpUpdate.Controls.Add(this.txtName);
            this.tbpUpdate.Controls.Add(this.label7);
            this.tbpUpdate.Controls.Add(this.txtAddress);
            this.tbpUpdate.Controls.Add(this.label9);
            this.tbpUpdate.Location = new System.Drawing.Point(4, 26);
            this.tbpUpdate.Name = "tbpUpdate";
            this.tbpUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUpdate.Size = new System.Drawing.Size(587, 236);
            this.tbpUpdate.TabIndex = 3;
            this.tbpUpdate.Text = "修改信息";
            this.tbpUpdate.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(113, 23);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(135, 26);
            this.txtId.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "编号：";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(113, 206);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(283, 26);
            this.txtTel.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "联系电话：";
            // 
            // txtContracts
            // 
            this.txtContracts.Location = new System.Drawing.Point(112, 158);
            this.txtContracts.Name = "txtContracts";
            this.txtContracts.Size = new System.Drawing.Size(284, 26);
            this.txtContracts.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "联系人：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(113, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(283, 26);
            this.txtName.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "名称：";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(113, 116);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(283, 26);
            this.txtAddress.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "地址：";
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
            this.toolStripSeparator4});
            this.toolSearh.Location = new System.Drawing.Point(0, 0);
            this.toolSearh.Name = "toolSearh";
            this.toolSearh.Size = new System.Drawing.Size(607, 28);
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
            "编号",
            "名称",
            "地址",
            "联系人",
            "电话"});
            this.toolcbxSearchtype.Name = "toolcbxSearchtype";
            this.toolcbxSearchtype.Size = new System.Drawing.Size(100, 28);
            this.toolcbxSearchtype.SelectedIndexChanged += new System.EventHandler(this.toolcbxSearchtype_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tooltxtContaint
            // 
            this.tooltxtContaint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tooltxtContaint.Name = "tooltxtContaint";
            this.tooltxtContaint.Size = new System.Drawing.Size(200, 28);
            this.tooltxtContaint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tooltxtContaint_KeyPress);
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
            this.toolbtnAll.Text = "所有信息";
            this.toolbtnAll.Click += new System.EventHandler(this.toolbtnAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // frmMaintainer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 341);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMaintainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "维修商管理";
            this.Load += new System.EventHandler(this.frmMaintainer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMaintainer.ResumeLayout(false);
            this.tbpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintainer)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tbpAdd.ResumeLayout(false);
            this.tbpAdd.PerformLayout();
            this.tbpUpdate.ResumeLayout(false);
            this.tbpUpdate.PerformLayout();
            this.toolSearh.ResumeLayout(false);
            this.toolSearh.PerformLayout();
            this.ResumeLayout(false);

        }

        

       

        

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabMaintainer;
        private System.Windows.Forms.TabPage tbpInfo;
        private System.Windows.Forms.TabPage tbpAdd;
        private System.Windows.Forms.DataGridView dgvMaintainer;
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
        private System.Windows.Forms.TextBox txtNewAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_update;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Close;
        private System.Windows.Forms.ImageList imgemp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewTel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNewContracts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNewId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContracts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label9;
    }
}