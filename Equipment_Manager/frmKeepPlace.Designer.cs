namespace Equipment_Manager
{
    partial class frmKeepPlace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeepPlace));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKeepPlace = new System.Windows.Forms.DataGridView();
            this.cmsKeepPlace = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolFresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtKeepPlace = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new RedrawControl.tsButton();
            this.toolCancel = new RedrawControl.tsButton();
            this.toolClose = new RedrawControl.tsButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeepPlace)).BeginInit();
            this.cmsKeepPlace.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKeepPlace);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 327);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "资产保管地点";
            // 
            // dgvKeepPlace
            // 
            this.dgvKeepPlace.AllowUserToAddRows = false;
            this.dgvKeepPlace.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKeepPlace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeepPlace.ContextMenuStrip = this.cmsKeepPlace;
            this.dgvKeepPlace.Location = new System.Drawing.Point(6, 25);
            this.dgvKeepPlace.Name = "dgvKeepPlace";
            this.dgvKeepPlace.ReadOnly = true;
            this.dgvKeepPlace.RowHeadersVisible = false;
            this.dgvKeepPlace.RowTemplate.Height = 23;
            this.dgvKeepPlace.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKeepPlace.Size = new System.Drawing.Size(335, 287);
            this.dgvKeepPlace.TabIndex = 0;
            // 
            // cmsKeepPlace
            // 
            this.cmsKeepPlace.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFresh,
            this.toolAdd,
            this.toolUpdate,
            this.toolDelete});
            this.cmsKeepPlace.Name = "cmsKeepPlace";
            this.cmsKeepPlace.Size = new System.Drawing.Size(101, 92);
            // 
            // toolFresh
            // 
            this.toolFresh.Image = ((System.Drawing.Image)(resources.GetObject("toolFresh.Image")));
            this.toolFresh.Name = "toolFresh";
            this.toolFresh.Size = new System.Drawing.Size(100, 22);
            this.toolFresh.Text = "刷新";
            this.toolFresh.Click += new System.EventHandler(this.toolFresh_Click);
            // 
            // toolAdd
            // 
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(100, 22);
            this.toolAdd.Text = "新增";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolUpdate
            // 
            this.toolUpdate.Image = ((System.Drawing.Image)(resources.GetObject("toolUpdate.Image")));
            this.toolUpdate.Name = "toolUpdate";
            this.toolUpdate.Size = new System.Drawing.Size(100, 22);
            this.toolUpdate.Text = "修改";
            this.toolUpdate.Click += new System.EventHandler(this.toolUpdate_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(152, 22);
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtId.Location = new System.Drawing.Point(27, 358);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(46, 26);
            this.txtId.TabIndex = 6;
            // 
            // txtKeepPlace
            // 
            this.txtKeepPlace.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeepPlace.Location = new System.Drawing.Point(109, 358);
            this.txtKeepPlace.Name = "txtKeepPlace";
            this.txtKeepPlace.Size = new System.Drawing.Size(244, 26);
            this.txtKeepPlace.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolClose});
            this.toolStrip1.Location = new System.Drawing.Point(19, 404);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(333, 28);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.AutoSize = false;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(110, 25);
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.AutoSize = false;
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(110, 25);
            this.toolCancel.Text = "取消";
            this.toolCancel.Click += new System.EventHandler(this.toolCancel_Click);
            // 
            // toolClose
            // 
            this.toolClose.AutoSize = false;
            this.toolClose.Image = ((System.Drawing.Image)(resources.GetObject("toolClose.Image")));
            this.toolClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClose.Name = "toolClose";
            this.toolClose.Size = new System.Drawing.Size(110, 25);
            this.toolClose.Text = "关闭";
            this.toolClose.Click += new System.EventHandler(this.toolClose_Click);
            // 
            // frmKeepPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 441);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtKeepPlace);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKeepPlace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保存地点管理";
            this.Load += new System.EventHandler(this.frmKeepPlace_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeepPlace)).EndInit();
            this.cmsKeepPlace.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKeepPlace;
        private System.Windows.Forms.ContextMenuStrip cmsKeepPlace;
        private System.Windows.Forms.ToolStripMenuItem toolFresh;
        private System.Windows.Forms.ToolStripMenuItem toolAdd;
        private System.Windows.Forms.ToolStripMenuItem toolUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolDelete;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtKeepPlace;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private RedrawControl.tsButton toolSave;
        private RedrawControl.tsButton toolCancel;
        private RedrawControl.tsButton toolClose;

    }
}