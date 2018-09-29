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
            this.btnOK = new System.Windows.Forms.Button();
            this.chkDefaultPower = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassAgain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnClose = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwUser
            // 
            this.lvwUser.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwUser.LargeImageList = this.imgUser;
            this.lvwUser.Location = new System.Drawing.Point(15, 36);
            this.lvwUser.Name = "lvwUser";
            this.lvwUser.Size = new System.Drawing.Size(262, 219);
            this.lvwUser.TabIndex = 4;
            this.lvwUser.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolMenu_Add,
            this.ToolMenu_Del,
            this.ToolMenu_Refresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 70);
            // 
            // ToolMenu_Add
            // 
            this.ToolMenu_Add.Name = "ToolMenu_Add";
            this.ToolMenu_Add.Size = new System.Drawing.Size(130, 22);
            this.ToolMenu_Add.Text = "添加用户";
            this.ToolMenu_Add.Click += new System.EventHandler(this.ToolMenu_Add_Click);
            // 
            // ToolMenu_Del
            // 
            this.ToolMenu_Del.Name = "ToolMenu_Del";
            this.ToolMenu_Del.Size = new System.Drawing.Size(130, 22);
            this.ToolMenu_Del.Text = "删除该用户";
            this.ToolMenu_Del.Click += new System.EventHandler(this.ToolMenu_Del_Click);
            // 
            // ToolMenu_Refresh
            // 
            this.ToolMenu_Refresh.Name = "ToolMenu_Refresh";
            this.ToolMenu_Refresh.Size = new System.Drawing.Size(130, 22);
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
            this.groupBoxAdd.Controls.Add(this.btnOK);
            this.groupBoxAdd.Controls.Add(this.chkDefaultPower);
            this.groupBoxAdd.Controls.Add(this.txtName);
            this.groupBoxAdd.Controls.Add(this.label3);
            this.groupBoxAdd.Controls.Add(this.txtPassAgain);
            this.groupBoxAdd.Controls.Add(this.label4);
            this.groupBoxAdd.Controls.Add(this.txtPass);
            this.groupBoxAdd.Controls.Add(this.label2);
            this.groupBoxAdd.Controls.Add(this.txtUsername);
            this.groupBoxAdd.Controls.Add(this.label1);
            this.groupBoxAdd.Location = new System.Drawing.Point(291, 35);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(274, 219);
            this.groupBoxAdd.TabIndex = 5;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "添加新用户";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(180, 184);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkDefaultPower
            // 
            this.chkDefaultPower.AutoSize = true;
            this.chkDefaultPower.Location = new System.Drawing.Point(9, 188);
            this.chkDefaultPower.Name = "chkDefaultPower";
            this.chkDefaultPower.Size = new System.Drawing.Size(132, 16);
            this.chkDefaultPower.TabIndex = 5;
            this.chkDefaultPower.Text = "赋予该用户默认权限";
            this.chkDefaultPower.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 146);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 21);
            this.txtName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "真实姓名：";
            // 
            // txtPassAgain
            // 
            this.txtPassAgain.Location = new System.Drawing.Point(90, 105);
            this.txtPassAgain.Name = "txtPassAgain";
            this.txtPassAgain.PasswordChar = '*';
            this.txtPassAgain.Size = new System.Drawing.Size(165, 21);
            this.txtPassAgain.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "确认密码：";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(90, 64);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(165, 21);
            this.txtPass.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "用户密码：";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(90, 23);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(165, 21);
            this.txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "系统登录名：";
            // 
            // toolStrip1
            // 
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
            this.toolStrip1.Size = new System.Drawing.Size(581, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnDel
            // 
            this.toolbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnDel.Image")));
            this.toolbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDel.Name = "toolbtnDel";
            this.toolbtnDel.Size = new System.Drawing.Size(85, 22);
            this.toolbtnDel.Text = "删除该用户";
            this.toolbtnDel.Click += new System.EventHandler(this.toolbtnDel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnRefresh
            // 
            this.toolbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnRefresh.Image")));
            this.toolbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRefresh.Name = "toolbtnRefresh";
            this.toolbtnRefresh.Size = new System.Drawing.Size(49, 22);
            this.toolbtnRefresh.Text = "刷新";
            this.toolbtnRefresh.Click += new System.EventHandler(this.toolbtnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnClose
            // 
            this.toolbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnClose.Image")));
            this.toolbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnClose.Name = "toolbtnClose";
            this.toolbtnClose.Size = new System.Drawing.Size(49, 22);
            this.toolbtnClose.Text = "关闭";
            this.toolbtnClose.Click += new System.EventHandler(this.toolbtnClose_Click);
            // 
            // frmsysUser
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 276);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxAdd);
            this.Controls.Add(this.lvwUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmsysUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "金钥匙——系统用户";
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
        private System.Windows.Forms.CheckBox chkDefaultPower;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
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
    }
}