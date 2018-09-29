namespace Equipment_Manager
{
    partial class frmBaseInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseInfo));
            this.tvBasic = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgvBasic = new System.Windows.Forms.DataGridView();
            this.cmsBasic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolFresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolChange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasic)).BeginInit();
            this.cmsBasic.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvBasic
            // 
            this.tvBasic.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvBasic.ImageIndex = 0;
            this.tvBasic.ImageList = this.imageList1;
            this.tvBasic.Location = new System.Drawing.Point(12, 12);
            this.tvBasic.Name = "tvBasic";
            this.tvBasic.SelectedImageIndex = 0;
            this.tvBasic.Size = new System.Drawing.Size(207, 422);
            this.tvBasic.TabIndex = 0;
            this.tvBasic.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBasic_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "notepad_128px_1099293_easyicon.net.ico");
            this.imageList1.Images.SetKeyName(1, "file_note.png");
            // 
            // dgvBasic
            // 
            this.dgvBasic.AllowUserToAddRows = false;
            this.dgvBasic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBasic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasic.ContextMenuStrip = this.cmsBasic;
            this.dgvBasic.Font = new System.Drawing.Font("SimSun", 12F);
            this.dgvBasic.Location = new System.Drawing.Point(225, 12);
            this.dgvBasic.Name = "dgvBasic";
            this.dgvBasic.ReadOnly = true;
            this.dgvBasic.RowHeadersVisible = false;
            this.dgvBasic.RowTemplate.Height = 30;
            this.dgvBasic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBasic.Size = new System.Drawing.Size(661, 375);
            this.dgvBasic.TabIndex = 1;
            // 
            // cmsBasic
            // 
            this.cmsBasic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFresh,
            this.toolAdd,
            this.toolChange,
            this.toolDelete});
            this.cmsBasic.Name = "cmsBasic";
            this.cmsBasic.Size = new System.Drawing.Size(101, 92);
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
            this.toolAdd.Text = "增加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolChange
            // 
            this.toolChange.Image = ((System.Drawing.Image)(resources.GetObject("toolChange.Image")));
            this.toolChange.Name = "toolChange";
            this.toolChange.Size = new System.Drawing.Size(100, 22);
            this.toolChange.Text = "修改";
            this.toolChange.Click += new System.EventHandler(this.toolChange_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(100, 22);
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // frmBaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 446);
            this.Controls.Add(this.dgvBasic);
            this.Controls.Add(this.tvBasic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBaseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基本资料";
            this.Load += new System.EventHandler(this.frmBaseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasic)).EndInit();
            this.cmsBasic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        

        #endregion

        private System.Windows.Forms.TreeView tvBasic;
        private System.Windows.Forms.DataGridView dgvBasic;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmsBasic;
        private System.Windows.Forms.ToolStripMenuItem toolAdd;
        private System.Windows.Forms.ToolStripMenuItem toolDelete;
        private System.Windows.Forms.ToolStripMenuItem toolChange;
        private System.Windows.Forms.ToolStripMenuItem toolFresh;



    }
}