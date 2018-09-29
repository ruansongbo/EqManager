namespace Equipment_Manager
{
    partial class ZCGridSortForm
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
            this.pnlAZ = new System.Windows.Forms.Label();
            this.lZA = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSecondKey = new System.Windows.Forms.TextBox();
            this.cbbSecondLogic = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoOr = new System.Windows.Forms.RadioButton();
            this.rdoAnd = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFirstKey = new System.Windows.Forms.TextBox();
            this.cbbFirstLogic = new System.Windows.Forms.ComboBox();
            this.lFilter = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cklList = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lClear = new System.Windows.Forms.Label();
            this.bwReadList = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAZ
            // 
            this.pnlAZ.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAZ.Location = new System.Drawing.Point(1, 1);
            this.pnlAZ.Name = "pnlAZ";
            this.pnlAZ.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.pnlAZ.Size = new System.Drawing.Size(271, 32);
            this.pnlAZ.TabIndex = 0;
            this.pnlAZ.Text = "升序";
            this.pnlAZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlAZ.Click += new System.EventHandler(this.lAZ_Click);
            this.pnlAZ.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAZ_Paint);
            this.pnlAZ.MouseEnter += new System.EventHandler(this.lAZ_MouseEnter);
            this.pnlAZ.MouseLeave += new System.EventHandler(this.lSort_MouseLeave);
            // 
            // lZA
            // 
            this.lZA.Dock = System.Windows.Forms.DockStyle.Top;
            this.lZA.Location = new System.Drawing.Point(1, 33);
            this.lZA.Name = "lZA";
            this.lZA.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.lZA.Size = new System.Drawing.Size(271, 32);
            this.lZA.TabIndex = 1;
            this.lZA.Text = "降序";
            this.lZA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lZA.Click += new System.EventHandler(this.lZA_Click);
            this.lZA.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAZ_Paint);
            this.lZA.MouseEnter += new System.EventHandler(this.lAZ_MouseEnter);
            this.lZA.MouseLeave += new System.EventHandler(this.lSort_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 97);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(271, 62);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSecondKey);
            this.panel4.Controls.Add(this.cbbSecondLogic);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(15, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 20);
            this.panel4.TabIndex = 6;
            // 
            // txtSecondKey
            // 
            this.txtSecondKey.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSecondKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSecondKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSecondKey.Enabled = false;
            this.txtSecondKey.Font = new System.Drawing.Font("SimSun", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSecondKey.Location = new System.Drawing.Point(74, 0);
            this.txtSecondKey.Name = "txtSecondKey";
            this.txtSecondKey.Size = new System.Drawing.Size(182, 20);
            this.txtSecondKey.TabIndex = 1;
            this.txtSecondKey.MouseEnter += new System.EventHandler(this.lAZ_MouseEnter);
            this.txtSecondKey.MouseLeave += new System.EventHandler(this.lAZ_MouseLeave);
            // 
            // cbbSecondLogic
            // 
            this.cbbSecondLogic.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbSecondLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSecondLogic.Enabled = false;
            this.cbbSecondLogic.FormattingEnabled = true;
            this.cbbSecondLogic.Items.AddRange(new object[] {
            "等于",
            "大于",
            "小于",
            "不等于",
            "开头是",
            "结尾是",
            "包含",
            "不包含",
            " "});
            this.cbbSecondLogic.Location = new System.Drawing.Point(0, 0);
            this.cbbSecondLogic.Name = "cbbSecondLogic";
            this.cbbSecondLogic.Size = new System.Drawing.Size(74, 20);
            this.cbbSecondLogic.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoOr);
            this.panel3.Controls.Add(this.rdoAnd);
            this.panel3.Controls.Add(this.rdoSingle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(15, 22);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(256, 20);
            this.panel3.TabIndex = 5;
            // 
            // rdoOr
            // 
            this.rdoOr.AutoSize = true;
            this.rdoOr.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoOr.Location = new System.Drawing.Point(111, 0);
            this.rdoOr.Name = "rdoOr";
            this.rdoOr.Size = new System.Drawing.Size(47, 20);
            this.rdoOr.TabIndex = 1;
            this.rdoOr.Text = "或者";
            this.rdoOr.UseVisualStyleBackColor = true;
            // 
            // rdoAnd
            // 
            this.rdoAnd.AutoSize = true;
            this.rdoAnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoAnd.Location = new System.Drawing.Point(64, 0);
            this.rdoAnd.Name = "rdoAnd";
            this.rdoAnd.Size = new System.Drawing.Size(47, 20);
            this.rdoAnd.TabIndex = 0;
            this.rdoAnd.Text = "并且";
            this.rdoAnd.UseVisualStyleBackColor = true;
            // 
            // rdoSingle
            // 
            this.rdoSingle.AutoSize = true;
            this.rdoSingle.Checked = true;
            this.rdoSingle.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoSingle.Location = new System.Drawing.Point(5, 0);
            this.rdoSingle.Name = "rdoSingle";
            this.rdoSingle.Size = new System.Drawing.Size(59, 20);
            this.rdoSingle.TabIndex = 2;
            this.rdoSingle.TabStop = true;
            this.rdoSingle.Text = "不附加";
            this.rdoSingle.UseVisualStyleBackColor = true;
            this.rdoSingle.CheckedChanged += new System.EventHandler(this.rdoSingle_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFirstKey);
            this.panel2.Controls.Add(this.cbbFirstLogic);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(15, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 20);
            this.panel2.TabIndex = 4;
            // 
            // txtFirstKey
            // 
            this.txtFirstKey.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFirstKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFirstKey.Font = new System.Drawing.Font("SimSun", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFirstKey.Location = new System.Drawing.Point(74, 0);
            this.txtFirstKey.Name = "txtFirstKey";
            this.txtFirstKey.Size = new System.Drawing.Size(182, 20);
            this.txtFirstKey.TabIndex = 1;
            this.txtFirstKey.MouseEnter += new System.EventHandler(this.lAZ_MouseEnter);
            this.txtFirstKey.MouseLeave += new System.EventHandler(this.lAZ_MouseLeave);
            // 
            // cbbFirstLogic
            // 
            this.cbbFirstLogic.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbFirstLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFirstLogic.FormattingEnabled = true;
            this.cbbFirstLogic.Items.AddRange(new object[] {
            "等于",
            "大于",
            "小于",
            "不等于",
            "开头是",
            "结尾是",
            "包含",
            "不包含",
            " "});
            this.cbbFirstLogic.Location = new System.Drawing.Point(0, 0);
            this.cbbFirstLogic.Name = "cbbFirstLogic";
            this.cbbFirstLogic.Size = new System.Drawing.Size(74, 20);
            this.cbbFirstLogic.TabIndex = 0;
            this.cbbFirstLogic.SelectedIndexChanged += new System.EventHandler(this.cbbFirstLogic_SelectedIndexChanged);
            // 
            // lFilter
            // 
            this.lFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.lFilter.Location = new System.Drawing.Point(0, 2);
            this.lFilter.Name = "lFilter";
            this.lFilter.Size = new System.Drawing.Size(15, 60);
            this.lFilter.TabIndex = 3;
            this.lFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cklList);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 159);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(271, 206);
            this.panel5.TabIndex = 4;
            // 
            // cklList
            // 
            this.cklList.CheckOnClick = true;
            this.cklList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklList.FormattingEnabled = true;
            this.cklList.IntegralHeight = false;
            this.cklList.Location = new System.Drawing.Point(15, 0);
            this.cklList.Name = "cklList";
            this.cklList.Size = new System.Drawing.Size(256, 206);
            this.cklList.TabIndex = 4;
            this.cklList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklList_ItemCheck);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 206);
            this.label4.TabIndex = 3;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(1, 365);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.pnlBottom.Size = new System.Drawing.Size(271, 31);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(116, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(191, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lClear
            // 
            this.lClear.Dock = System.Windows.Forms.DockStyle.Top;
            this.lClear.Location = new System.Drawing.Point(1, 65);
            this.lClear.Name = "lClear";
            this.lClear.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.lClear.Size = new System.Drawing.Size(271, 32);
            this.lClear.TabIndex = 6;
            this.lClear.Text = "清除筛选与排序";
            this.lClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lClear.Click += new System.EventHandler(this.lClear_Click);
            this.lClear.MouseEnter += new System.EventHandler(this.lAZ_MouseEnter);
            this.lClear.MouseLeave += new System.EventHandler(this.lSort_MouseLeave);
            // 
            // bwReadList
            // 
            this.bwReadList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwReadList_DoWork);
            this.bwReadList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwReadList_RunWorkerCompleted);
            // 
            // ZCGridSortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(273, 416);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.lClear);
            this.Controls.Add(this.lZA);
            this.Controls.Add(this.pnlAZ);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ZCGridSortForm";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 20);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZCGridViewSortForm";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.ZCGridViewSortForm_VisibleChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZCGridViewSortForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ZCGridViewSortForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZCGridViewSortForm_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label pnlAZ;
        private System.Windows.Forms.Label lZA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFirstKey;
        private System.Windows.Forms.ComboBox cbbFirstLogic;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdoSingle;
        private System.Windows.Forms.RadioButton rdoOr;
        private System.Windows.Forms.RadioButton rdoAnd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSecondKey;
        private System.Windows.Forms.ComboBox cbbSecondLogic;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox cklList;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lClear;
        private System.ComponentModel.BackgroundWorker bwReadList;
    }
}