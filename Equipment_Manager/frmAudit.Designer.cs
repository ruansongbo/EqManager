namespace Equipment_Manager
{
    partial class frmAudit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAudit));
            this.dgvAddAudit = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuAgree = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuDisagree = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuRevise = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvClearAudit = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvUpdateAudit = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvBorrowAudit = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvFixAudit = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.accept_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refuse_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.modify_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.delete_toolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddAudit)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClearAudit)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateAudit)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowAudit)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixAudit)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAddAudit
            // 
            this.dgvAddAudit.AllowUserToAddRows = false;
            this.dgvAddAudit.AllowUserToDeleteRows = false;
            this.dgvAddAudit.AllowUserToResizeColumns = false;
            this.dgvAddAudit.AllowUserToResizeRows = false;
            this.dgvAddAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAddAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddAudit.Location = new System.Drawing.Point(8, 8);
            this.dgvAddAudit.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAddAudit.Name = "dgvAddAudit";
            this.dgvAddAudit.RowTemplate.Height = 23;
            this.dgvAddAudit.Size = new System.Drawing.Size(879, 463);
            this.dgvAddAudit.TabIndex = 0;
            this.dgvAddAudit.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAddAudit_CellMouseDoubleClick);
            this.dgvAddAudit.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAudit_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuAgree,
            this.ToolStripMenuDisagree,
            this.ToolStripMenuRevise,
            this.ToolStripMenuDelete,
            this.ToolStripMenuReturn});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 114);
            // 
            // ToolStripMenuAgree
            // 
            this.ToolStripMenuAgree.Name = "ToolStripMenuAgree";
            this.ToolStripMenuAgree.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuAgree.Text = "审核通过";
            this.ToolStripMenuAgree.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuDisagree
            // 
            this.ToolStripMenuDisagree.Name = "ToolStripMenuDisagree";
            this.ToolStripMenuDisagree.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuDisagree.Text = "审核不通过";
            this.ToolStripMenuDisagree.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // ToolStripMenuRevise
            // 
            this.ToolStripMenuRevise.Name = "ToolStripMenuRevise";
            this.ToolStripMenuRevise.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuRevise.Text = "修改提交信息";
            this.ToolStripMenuRevise.Click += new System.EventHandler(this.ToolStripMenuRevise_Click);
            // 
            // ToolStripMenuDelete
            // 
            this.ToolStripMenuDelete.Name = "ToolStripMenuDelete";
            this.ToolStripMenuDelete.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuDelete.Text = "删除提交信息";
            this.ToolStripMenuDelete.Click += new System.EventHandler(this.ToolStripMenuDelete_Click);
            // 
            // ToolStripMenuReturn
            // 
            this.ToolStripMenuReturn.Name = "ToolStripMenuReturn";
            this.ToolStripMenuReturn.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuReturn.Text = "归还资产";
            this.ToolStripMenuReturn.Click += new System.EventHandler(this.ToolStripMenuReturn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(16, 32);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(905, 497);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Tag = "";
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvAddAudit);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(897, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "新增信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvClearAudit);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(897, 467);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "注销信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvClearAudit
            // 
            this.dgvClearAudit.AllowUserToAddRows = false;
            this.dgvClearAudit.AllowUserToDeleteRows = false;
            this.dgvClearAudit.AllowUserToResizeColumns = false;
            this.dgvClearAudit.AllowUserToResizeRows = false;
            this.dgvClearAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClearAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClearAudit.Location = new System.Drawing.Point(8, 8);
            this.dgvClearAudit.Margin = new System.Windows.Forms.Padding(4);
            this.dgvClearAudit.Name = "dgvClearAudit";
            this.dgvClearAudit.RowTemplate.Height = 23;
            this.dgvClearAudit.Size = new System.Drawing.Size(879, 463);
            this.dgvClearAudit.TabIndex = 1;
            this.dgvClearAudit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClearAudit_CellDoubleClick);
            this.dgvClearAudit.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClearAudit_CellMouseDown);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Transparent;
            this.tabPage5.Controls.Add(this.dgvUpdateAudit);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(897, 467);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "更新信息";
            // 
            // dgvUpdateAudit
            // 
            this.dgvUpdateAudit.AllowUserToAddRows = false;
            this.dgvUpdateAudit.AllowUserToDeleteRows = false;
            this.dgvUpdateAudit.AllowUserToResizeColumns = false;
            this.dgvUpdateAudit.AllowUserToResizeRows = false;
            this.dgvUpdateAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUpdateAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateAudit.Location = new System.Drawing.Point(8, 8);
            this.dgvUpdateAudit.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUpdateAudit.Name = "dgvUpdateAudit";
            this.dgvUpdateAudit.RowTemplate.Height = 23;
            this.dgvUpdateAudit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpdateAudit.Size = new System.Drawing.Size(879, 463);
            this.dgvUpdateAudit.TabIndex = 2;
            this.dgvUpdateAudit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpdateAudit_CellDoubleClick);
            this.dgvUpdateAudit.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUpdateAudit_CellMouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvBorrowAudit);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(897, 467);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "借用信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvBorrowAudit
            // 
            this.dgvBorrowAudit.AllowUserToAddRows = false;
            this.dgvBorrowAudit.AllowUserToDeleteRows = false;
            this.dgvBorrowAudit.AllowUserToResizeColumns = false;
            this.dgvBorrowAudit.AllowUserToResizeRows = false;
            this.dgvBorrowAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBorrowAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowAudit.Location = new System.Drawing.Point(8, 8);
            this.dgvBorrowAudit.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBorrowAudit.Name = "dgvBorrowAudit";
            this.dgvBorrowAudit.RowTemplate.Height = 23;
            this.dgvBorrowAudit.Size = new System.Drawing.Size(879, 463);
            this.dgvBorrowAudit.TabIndex = 0;
            this.dgvBorrowAudit.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBorrowAudit_CellMouseDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvFixAudit);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(897, 467);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "维修信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvFixAudit
            // 
            this.dgvFixAudit.AllowUserToAddRows = false;
            this.dgvFixAudit.AllowUserToDeleteRows = false;
            this.dgvFixAudit.AllowUserToResizeColumns = false;
            this.dgvFixAudit.AllowUserToResizeRows = false;
            this.dgvFixAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFixAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFixAudit.Location = new System.Drawing.Point(8, 8);
            this.dgvFixAudit.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFixAudit.Name = "dgvFixAudit";
            this.dgvFixAudit.RowTemplate.Height = 23;
            this.dgvFixAudit.Size = new System.Drawing.Size(879, 463);
            this.dgvFixAudit.TabIndex = 1;
            this.dgvFixAudit.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFixAudit_CellMouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accept_toolStripButton,
            this.toolStripSeparator1,
            this.refuse_toolStripButton,
            this.toolStripSeparator2,
            this.modify_toolStripButton,
            this.toolStripSeparator3,
            this.delete_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(937, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // accept_toolStripButton
            // 
            this.accept_toolStripButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accept_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("accept_toolStripButton.Image")));
            this.accept_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.accept_toolStripButton.Name = "accept_toolStripButton";
            this.accept_toolStripButton.Size = new System.Drawing.Size(94, 25);
            this.accept_toolStripButton.Text = "审核通过";
            this.accept_toolStripButton.Click += new System.EventHandler(this.accept_toolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // refuse_toolStripButton
            // 
            this.refuse_toolStripButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refuse_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refuse_toolStripButton.Image")));
            this.refuse_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refuse_toolStripButton.Name = "refuse_toolStripButton";
            this.refuse_toolStripButton.Size = new System.Drawing.Size(110, 25);
            this.refuse_toolStripButton.Text = "审核不通过";
            this.refuse_toolStripButton.Click += new System.EventHandler(this.refuse_toolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // modify_toolStripButton
            // 
            this.modify_toolStripButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modify_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("modify_toolStripButton.Image")));
            this.modify_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modify_toolStripButton.Name = "modify_toolStripButton";
            this.modify_toolStripButton.Size = new System.Drawing.Size(126, 25);
            this.modify_toolStripButton.Text = "修改提交信息";
            this.modify_toolStripButton.Click += new System.EventHandler(this.modify_toolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // delete_toolStripButton
            // 
            this.delete_toolStripButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delete_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("delete_toolStripButton.Image")));
            this.delete_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete_toolStripButton.Name = "delete_toolStripButton";
            this.delete_toolStripButton.Size = new System.Drawing.Size(126, 25);
            this.delete_toolStripButton.Text = "删除提交信息";
            this.delete_toolStripButton.Click += new System.EventHandler(this.delete_toolStripButton_Click);
            // 
            // frmAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 545);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAudit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提醒信息";
            this.Load += new System.EventHandler(this.frmAudit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddAudit)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClearAudit)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateAudit)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowAudit)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixAudit)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAddAudit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuAgree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuDisagree;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuRevise;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuDelete;
        private System.Windows.Forms.DataGridView dgvBorrowAudit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuReturn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvFixAudit;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvClearAudit;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvUpdateAudit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton accept_toolStripButton;
        private System.Windows.Forms.ToolStripButton refuse_toolStripButton;
        private System.Windows.Forms.ToolStripButton modify_toolStripButton;
        private System.Windows.Forms.ToolStripButton delete_toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}