namespace Equipment_Manager
{
    partial class frmsysUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsysUser));
            this.lvwUser = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolMenu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolMenu_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolMenu_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.imgUser = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.cbxDepart = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxPower = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassAgain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnClose = new System.Windows.Forms.ToolStripButton();
            this.ToolMenu_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwUser
            // 
            this.lvwUser.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwUser.LargeImageList = this.imgUser;
            this.lvwUser.Location = new System.Drawing.Point(20, 48);
            this.lvwUser.Margin = new System.Windows.Forms.Padding(4);
            this.lvwUser.Name = "lvwUser";
            this.lvwUser.Size = new System.Drawing.Size(348, 479);
            this.lvwUser.TabIndex = 4;
            this.lvwUser.UseCompatibleStateImageBehavior = false;
            this.lvwUser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwUser_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolMenu_Add,
            this.ToolMenu_Update,
            this.ToolMenu_Del,
            this.ToolMenu_Refresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // ToolMenu_Add
            // 
            this.ToolMenu_Add.Name = "ToolMenu_Add";
            this.ToolMenu_Add.Size = new System.Drawing.Size(152, 22);
            this.ToolMenu_Add.Text = "添加用户";
            this.ToolMenu_Add.Click += new System.EventHandler(this.ToolMenu_Add_Click);
            // 
            // ToolMenu_Del
            // 
            this.ToolMenu_Del.Name = "ToolMenu_Del";
            this.ToolMenu_Del.Size = new System.Drawing.Size(152, 22);
            this.ToolMenu_Del.Text = "删除该用户";
            this.ToolMenu_Del.Click += new System.EventHandler(this.ToolMenu_Del_Click);
            // 
            // ToolMenu_Refresh
            // 
            this.ToolMenu_Refresh.Name = "ToolMenu_Refresh";
            this.ToolMenu_Refresh.Size = new System.Drawing.Size(152, 22);
            this.ToolMenu_Refresh.Text = "刷新";
            this.ToolMenu_Refresh.Click += new System.EventHandler(this.ToolMenu_Refresh_Click);
            // 
            // imgUser
            // 
            this.imgUser.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUser.ImageStream")));
            this.imgUser.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUser.Images.SetKeyName(0, "png-0010.png");
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.cbxDepart);
            this.groupBoxAdd.Controls.Add(this.label8);
            this.groupBoxAdd.Controls.Add(this.label7);
            this.groupBoxAdd.Controls.Add(this.cbxPower);
            this.groupBoxAdd.Controls.Add(this.txtEmail);
            this.groupBoxAdd.Controls.Add(this.label6);
            this.groupBoxAdd.Controls.Add(this.txtTel);
            this.groupBoxAdd.Controls.Add(this.label5);
            this.groupBoxAdd.Controls.Add(this.btnClose);
            this.groupBoxAdd.Controls.Add(this.btnOK);
            this.groupBoxAdd.Controls.Add(this.txtName);
            this.groupBoxAdd.Controls.Add(this.label3);
            this.groupBoxAdd.Controls.Add(this.txtPassAgain);
            this.groupBoxAdd.Controls.Add(this.label4);
            this.groupBoxAdd.Controls.Add(this.txtPass);
            this.groupBoxAdd.Controls.Add(this.label2);
            this.groupBoxAdd.Controls.Add(this.txtUserId);
            this.groupBoxAdd.Controls.Add(this.label1);
            this.groupBoxAdd.Location = new System.Drawing.Point(388, 47);
            this.groupBoxAdd.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAdd.Size = new System.Drawing.Size(365, 481);
            this.groupBoxAdd.TabIndex = 5;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "添加新用户";
            // 
            // cbxDepart
            // 
            this.cbxDepart.FormattingEnabled = true;
            this.cbxDepart.Location = new System.Drawing.Point(120, 247);
            this.cbxDepart.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDepart.Name = "cbxDepart";
            this.cbxDepart.Size = new System.Drawing.Size(219, 24);
            this.cbxDepart.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 247);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "所在部门：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 405);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "权限等级：";
            // 
            // cbxPower
            // 
            this.cbxPower.FormattingEnabled = true;
            this.cbxPower.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbxPower.Location = new System.Drawing.Point(120, 401);
            this.cbxPower.Margin = new System.Windows.Forms.Padding(4);
            this.cbxPower.Name = "cbxPower";
            this.cbxPower.Size = new System.Drawing.Size(47, 24);
            this.cbxPower.TabIndex = 13;
            this.cbxPower.Text = "3";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 336);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(219, 26);
            this.txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 348);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "邮箱：";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(120, 285);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(219, 26);
            this.txtTel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 297);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "联系电话：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(212, 443);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 31);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(39, 443);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 31);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 195);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(219, 26);
            this.txtName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 207);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "姓名：";
            // 
            // txtPassAgain
            // 
            this.txtPassAgain.Location = new System.Drawing.Point(120, 140);
            this.txtPassAgain.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassAgain.Name = "txtPassAgain";
            this.txtPassAgain.PasswordChar = '*';
            this.txtPassAgain.Size = new System.Drawing.Size(219, 26);
            this.txtPassAgain.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "确认密码：";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(120, 85);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(219, 26);
            this.txtPass.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "用户密码：";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(120, 31);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(219, 26);
            this.txtUserId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "编号：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolbtnDel,
            this.toolStripSeparator2,
            this.toolbtnRefresh,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.toolbtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(772, 28);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnDel
            // 
            this.toolbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnDel.Image")));
            this.toolbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDel.Name = "toolbtnDel";
            this.toolbtnDel.Size = new System.Drawing.Size(110, 25);
            this.toolbtnDel.Text = "删除该用户";
            this.toolbtnDel.Click += new System.EventHandler(this.toolbtnDel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnRefresh
            // 
            this.toolbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnRefresh.Image")));
            this.toolbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRefresh.Name = "toolbtnRefresh";
            this.toolbtnRefresh.Size = new System.Drawing.Size(62, 25);
            this.toolbtnRefresh.Text = "刷新";
            this.toolbtnRefresh.Click += new System.EventHandler(this.toolbtnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnClose
            // 
            this.toolbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnClose.Image")));
            this.toolbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnClose.Name = "toolbtnClose";
            this.toolbtnClose.Size = new System.Drawing.Size(62, 25);
            this.toolbtnClose.Text = "关闭";
            this.toolbtnClose.Click += new System.EventHandler(this.toolbtnClose_Click);
            // 
            // ToolMenu_Update
            // 
            this.ToolMenu_Update.Name = "ToolMenu_Update";
            this.ToolMenu_Update.Size = new System.Drawing.Size(152, 22);
            this.ToolMenu_Update.Text = "更改用户信息";
            this.ToolMenu_Update.Click += new System.EventHandler(this.ToolMenu_Update_Click);
            // 
            // frmsysUser
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 544);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxAdd);
            this.Controls.Add(this.lvwUser);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmsysUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统用户";
            this.Load += new System.EventHandler(this.frmsysUser_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.ListView lvwUser;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imgUser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolbtnRefresh;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolbtnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolMenu_Add;
        private System.Windows.Forms.ToolStripMenuItem ToolMenu_Del;
        private System.Windows.Forms.ToolStripMenuItem ToolMenu_Refresh;
        private System.Windows.Forms.TextBox txtPassAgain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxPower;
        private System.Windows.Forms.ComboBox cbxDepart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem ToolMenu_Update;
    }
}