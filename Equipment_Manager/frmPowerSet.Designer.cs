namespace Equipment_Manager
{
    partial class frmPowerSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPowerSet));
            this.lstUser = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvwFunc = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.rbtnFree = new System.Windows.Forms.RadioButton();
            this.panelCheck = new System.Windows.Forms.Panel();
            this.rbtnFirst = new System.Windows.Forms.RadioButton();
            this.rbtnSecond = new System.Windows.Forms.RadioButton();
            this.rbtnThird = new System.Windows.Forms.RadioButton();
            this.panelCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUser
            // 
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 16;
            this.lstUser.Location = new System.Drawing.Point(37, 69);
            this.lstUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(237, 420);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择用户：";
            // 
            // tvwFunc
            // 
            this.tvwFunc.CheckBoxes = true;
            this.tvwFunc.Location = new System.Drawing.Point(453, 95);
            this.tvwFunc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tvwFunc.Name = "tvwFunc";
            this.tvwFunc.Size = new System.Drawing.Size(341, 404);
            this.tvwFunc.TabIndex = 3;
            this.tvwFunc.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwFunc_AfterCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "设置权限：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(320, 295);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 31);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户登录ID：";
            this.label3.Visible = false;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(301, 153);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(0, 16);
            this.lblid.TabIndex = 2;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(320, 359);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(100, 31);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // rbtnFree
            // 
            this.rbtnFree.AutoSize = true;
            this.rbtnFree.Location = new System.Drawing.Point(18, 10);
            this.rbtnFree.Name = "rbtnFree";
            this.rbtnFree.Size = new System.Drawing.Size(58, 20);
            this.rbtnFree.TabIndex = 5;
            this.rbtnFree.TabStop = true;
            this.rbtnFree.Text = "自选";
            this.rbtnFree.UseVisualStyleBackColor = true;
            this.rbtnFree.CheckedChanged += new System.EventHandler(radioBtn_CheckedChange);
            // 
            // panelCheck
            // 
            this.panelCheck.Controls.Add(this.rbtnThird);
            this.panelCheck.Controls.Add(this.rbtnSecond);
            this.panelCheck.Controls.Add(this.rbtnFirst);
            this.panelCheck.Controls.Add(this.rbtnFree);
            this.panelCheck.Enabled = false;
            this.panelCheck.Location = new System.Drawing.Point(546, 25);
            this.panelCheck.Name = "panelCheck";
            this.panelCheck.Size = new System.Drawing.Size(248, 63);
            this.panelCheck.TabIndex = 6;
            // 
            // rbtnFirst
            // 
            this.rbtnFirst.AutoSize = true;
            this.rbtnFirst.Location = new System.Drawing.Point(155, 10);
            this.rbtnFirst.Name = "rbtnFirst";
            this.rbtnFirst.Size = new System.Drawing.Size(90, 20);
            this.rbtnFirst.TabIndex = 6;
            this.rbtnFirst.TabStop = true;
            this.rbtnFirst.Text = "一级用户";
            this.rbtnFirst.UseVisualStyleBackColor = true;
            this.rbtnFirst.CheckedChanged += new System.EventHandler(radioBtn_CheckedChange);
            // 
            // rbtnSecond
            // 
            this.rbtnSecond.AutoSize = true;
            this.rbtnSecond.Location = new System.Drawing.Point(18, 36);
            this.rbtnSecond.Name = "rbtnSecond";
            this.rbtnSecond.Size = new System.Drawing.Size(90, 20);
            this.rbtnSecond.TabIndex = 7;
            this.rbtnSecond.TabStop = true;
            this.rbtnSecond.Text = "二级用户";
            this.rbtnSecond.UseVisualStyleBackColor = true;
            this.rbtnSecond.CheckedChanged += new System.EventHandler(radioBtn_CheckedChange);
            // 
            // rbtnThird
            // 
            this.rbtnThird.AutoSize = true;
            this.rbtnThird.Location = new System.Drawing.Point(155, 36);
            this.rbtnThird.Name = "rbtnThird";
            this.rbtnThird.Size = new System.Drawing.Size(90, 20);
            this.rbtnThird.TabIndex = 8;
            this.rbtnThird.TabStop = true;
            this.rbtnThird.Text = "三级用户";
            this.rbtnThird.UseVisualStyleBackColor = true;
            this.rbtnThird.CheckedChanged += new System.EventHandler(radioBtn_CheckedChange);
            // 
            // frmPowerSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 512);
            this.Controls.Add(this.panelCheck);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tvwFunc);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUser);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmPowerSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "权限设置";
            this.Load += new System.EventHandler(this.frmPowerSet_Load);
            this.panelCheck.ResumeLayout(false);
            this.panelCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvwFunc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.RadioButton rbtnFree;
        private System.Windows.Forms.Panel panelCheck;
        private System.Windows.Forms.RadioButton rbtnThird;
        private System.Windows.Forms.RadioButton rbtnSecond;
        private System.Windows.Forms.RadioButton rbtnFirst;
    }
}