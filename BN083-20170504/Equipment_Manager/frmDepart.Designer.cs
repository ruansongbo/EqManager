namespace Equipment_Manager
{
    partial class frmDepart
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepart));
                this.btnAdd = new System.Windows.Forms.Button();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnDel = new System.Windows.Forms.Button();
                this.btnUpdate = new System.Windows.Forms.Button();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.btnCancel = new System.Windows.Forms.Button();
                this.tvwDepart = new System.Windows.Forms.TreeView();
                this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.ToolMenuItem_Add = new System.Windows.Forms.ToolStripMenuItem();
                this.ToolMenuItem_Cancel = new System.Windows.Forms.ToolStripMenuItem();
                this.ToolMenuItem_Update = new System.Windows.Forms.ToolStripMenuItem();
                this.ToolMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
                this.ToolMenuItem_del = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
                this.ToolMenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
                this.imgDepart = new System.Windows.Forms.ImageList(this.components);
                this.btnClose = new System.Windows.Forms.Button();
                this.groupBox1.SuspendLayout();
                this.contextMenuStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // btnAdd
                // 
                this.btnAdd.Location = new System.Drawing.Point(217, 39);
                this.btnAdd.Name = "btnAdd";
                this.btnAdd.Size = new System.Drawing.Size(100, 25);
                this.btnAdd.TabIndex = 0;
                this.btnAdd.Text = "添加部门";
                this.btnAdd.UseVisualStyleBackColor = true;
                this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                // 
                // btnSave
                // 
                this.btnSave.Enabled = false;
                this.btnSave.Location = new System.Drawing.Point(217, 117);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(100, 25);
                this.btnSave.TabIndex = 0;
                this.btnSave.Text = "保存设置";
                this.btnSave.UseVisualStyleBackColor = true;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnDel
                // 
                this.btnDel.Location = new System.Drawing.Point(217, 156);
                this.btnDel.Name = "btnDel";
                this.btnDel.Size = new System.Drawing.Size(100, 25);
                this.btnDel.TabIndex = 0;
                this.btnDel.Text = "删除部门";
                this.btnDel.UseVisualStyleBackColor = true;
                this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
                // 
                // btnUpdate
                // 
                this.btnUpdate.Location = new System.Drawing.Point(217, 195);
                this.btnUpdate.Name = "btnUpdate";
                this.btnUpdate.Size = new System.Drawing.Size(100, 25);
                this.btnUpdate.TabIndex = 0;
                this.btnUpdate.Text = "修改部门";
                this.btnUpdate.UseVisualStyleBackColor = true;
                this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.btnCancel);
                this.groupBox1.Controls.Add(this.tvwDepart);
                this.groupBox1.Controls.Add(this.btnClose);
                this.groupBox1.Controls.Add(this.btnUpdate);
                this.groupBox1.Controls.Add(this.btnAdd);
                this.groupBox1.Controls.Add(this.btnSave);
                this.groupBox1.Controls.Add(this.btnDel);
                this.groupBox1.Location = new System.Drawing.Point(12, 21);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(335, 300);
                this.groupBox1.TabIndex = 3;
                this.groupBox1.TabStop = false;
                // 
                // btnCancel
                // 
                this.btnCancel.Location = new System.Drawing.Point(217, 78);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(100, 25);
                this.btnCancel.TabIndex = 3;
                this.btnCancel.Text = "取消添加/修改";
                this.btnCancel.UseVisualStyleBackColor = true;
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // tvwDepart
                // 
                this.tvwDepart.ContextMenuStrip = this.contextMenuStrip1;
                this.tvwDepart.ImageIndex = 0;
                this.tvwDepart.ImageList = this.imgDepart;
                this.tvwDepart.Location = new System.Drawing.Point(20, 27);
                this.tvwDepart.Name = "tvwDepart";
                this.tvwDepart.SelectedImageIndex = 0;
                this.tvwDepart.Size = new System.Drawing.Size(178, 247);
                this.tvwDepart.TabIndex = 2;
                // 
                // contextMenuStrip1
                // 
                this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolMenuItem_Add,
            this.ToolMenuItem_Cancel,
            this.ToolMenuItem_Update,
            this.ToolMenuItem_Save,
            this.ToolMenuItem_del,
            this.toolStripSeparator1,
            this.ToolMenuItem_Refresh});
                this.contextMenuStrip1.Name = "contextMenuStrip1";
                this.contextMenuStrip1.Size = new System.Drawing.Size(125, 142);
                // 
                // ToolMenuItem_Add
                // 
                this.ToolMenuItem_Add.Name = "ToolMenuItem_Add";
                this.ToolMenuItem_Add.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_Add.Text = "添加";
                this.ToolMenuItem_Add.Click += new System.EventHandler(this.ToolMenuItem_Add_Click);
                // 
                // ToolMenuItem_Cancel
                // 
                this.ToolMenuItem_Cancel.Name = "ToolMenuItem_Cancel";
                this.ToolMenuItem_Cancel.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_Cancel.Text = "取消添加";
                this.ToolMenuItem_Cancel.Click += new System.EventHandler(this.ToolMenuItem_Cancel_Click);
                // 
                // ToolMenuItem_Update
                // 
                this.ToolMenuItem_Update.Name = "ToolMenuItem_Update";
                this.ToolMenuItem_Update.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_Update.Text = "修改";
                this.ToolMenuItem_Update.Click += new System.EventHandler(this.ToolMenuItem_Update_Click);
                // 
                // ToolMenuItem_Save
                // 
                this.ToolMenuItem_Save.Name = "ToolMenuItem_Save";
                this.ToolMenuItem_Save.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_Save.Text = "保存";
                this.ToolMenuItem_Save.Click += new System.EventHandler(this.ToolMenuItem_Save_Click);
                // 
                // ToolMenuItem_del
                // 
                this.ToolMenuItem_del.Name = "ToolMenuItem_del";
                this.ToolMenuItem_del.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_del.Text = "删除";
                this.ToolMenuItem_del.Click += new System.EventHandler(this.ToolMenuItem_del_Click);
                // 
                // toolStripSeparator1
                // 
                this.toolStripSeparator1.Name = "toolStripSeparator1";
                this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
                // 
                // ToolMenuItem_Refresh
                // 
                this.ToolMenuItem_Refresh.Name = "ToolMenuItem_Refresh";
                this.ToolMenuItem_Refresh.Size = new System.Drawing.Size(124, 22);
                this.ToolMenuItem_Refresh.Text = "刷新";
                this.ToolMenuItem_Refresh.Click += new System.EventHandler(this.ToolMenuItem_Refresh_Click);
                // 
                // imgDepart
                // 
                this.imgDepart.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgDepart.ImageStream")));
                this.imgDepart.TransparentColor = System.Drawing.Color.Transparent;
                this.imgDepart.Images.SetKeyName(0, "chart_organisation_add.png");
                this.imgDepart.Images.SetKeyName(1, "house.png");
                // 
                // btnClose
                // 
                this.btnClose.Location = new System.Drawing.Point(217, 234);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(100, 25);
                this.btnClose.TabIndex = 0;
                this.btnClose.Text = "关闭窗口";
                this.btnClose.UseVisualStyleBackColor = true;
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // frmDepart
                // 
                this.AcceptButton = this.btnSave;
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(359, 333);
                this.Controls.Add(this.groupBox1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "frmDepart";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "部门管理";
                this.Load += new System.EventHandler(this.frmDepart_Load);
                this.groupBox1.ResumeLayout(false);
                this.contextMenuStrip1.ResumeLayout(false);
                this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TreeView tvwDepart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Add;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Update;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_del;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Refresh;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem_Cancel;
        private System.Windows.Forms.ImageList imgDepart;
    }
}