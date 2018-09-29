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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseInfo));
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.txtInput = new System.Windows.Forms.TextBox();
                this.lblMessge = new System.Windows.Forms.Label();
                this.lstInfo = new System.Windows.Forms.ListBox();
                this.btnAddType = new System.Windows.Forms.Button();
                this.btnUnit = new System.Windows.Forms.Button();
                this.btnClearType = new System.Windows.Forms.Button();
                this.btnKeepPlace = new System.Windows.Forms.Button();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnTyp = new System.Windows.Forms.Button();
                this.btnName = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnDel = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnAdd = new System.Windows.Forms.Button();
                this.groupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.txtInput);
                this.groupBox1.Controls.Add(this.lblMessge);
                this.groupBox1.Controls.Add(this.lstInfo);
                this.groupBox1.Controls.Add(this.btnAddType);
                this.groupBox1.Controls.Add(this.btnUnit);
                this.groupBox1.Controls.Add(this.btnClearType);
                this.groupBox1.Controls.Add(this.btnKeepPlace);
                this.groupBox1.Controls.Add(this.btnSave);
                this.groupBox1.Controls.Add(this.btnTyp);
                this.groupBox1.Controls.Add(this.btnName);
                this.groupBox1.Controls.Add(this.btnCancel);
                this.groupBox1.Controls.Add(this.btnDel);
                this.groupBox1.Controls.Add(this.btnClose);
                this.groupBox1.Controls.Add(this.btnAdd);
                this.groupBox1.Location = new System.Drawing.Point(33, 12);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(457, 239);
                this.groupBox1.TabIndex = 4;
                this.groupBox1.TabStop = false;
                // 
                // txtInput
                // 
                this.txtInput.Enabled = false;
                this.txtInput.Location = new System.Drawing.Point(224, 22);
                this.txtInput.Name = "txtInput";
                this.txtInput.Size = new System.Drawing.Size(123, 21);
                this.txtInput.TabIndex = 16;
                // 
                // lblMessge
                // 
                this.lblMessge.AutoSize = true;
                this.lblMessge.Location = new System.Drawing.Point(109, 31);
                this.lblMessge.Name = "lblMessge";
                this.lblMessge.Size = new System.Drawing.Size(0, 12);
                this.lblMessge.TabIndex = 15;
                // 
                // lstInfo
                // 
                this.lstInfo.FormattingEnabled = true;
                this.lstInfo.ItemHeight = 12;
                this.lstInfo.Location = new System.Drawing.Point(111, 53);
                this.lstInfo.Name = "lstInfo";
                this.lstInfo.Size = new System.Drawing.Size(236, 160);
                this.lstInfo.TabIndex = 14;
                // 
                // btnAddType
                // 
                this.btnAddType.Location = new System.Drawing.Point(15, 129);
                this.btnAddType.Name = "btnAddType";
                this.btnAddType.Size = new System.Drawing.Size(75, 23);
                this.btnAddType.TabIndex = 11;
                this.btnAddType.Text = "增长方式";
                this.btnAddType.UseVisualStyleBackColor = true;
                this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
                // 
                // btnUnit
                // 
                this.btnUnit.Location = new System.Drawing.Point(15, 187);
                this.btnUnit.Name = "btnUnit";
                this.btnUnit.Size = new System.Drawing.Size(75, 23);
                this.btnUnit.TabIndex = 12;
                this.btnUnit.Text = "计量单位";
                this.btnUnit.UseVisualStyleBackColor = true;
                this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
                // 
                // btnClearType
                // 
                this.btnClearType.Location = new System.Drawing.Point(15, 158);
                this.btnClearType.Name = "btnClearType";
                this.btnClearType.Size = new System.Drawing.Size(75, 23);
                this.btnClearType.TabIndex = 13;
                this.btnClearType.Text = "清理方式";
                this.btnClearType.UseVisualStyleBackColor = true;
                this.btnClearType.Click += new System.EventHandler(this.btnClearType_Click);
                // 
                // btnKeepPlace
                // 
                this.btnKeepPlace.Location = new System.Drawing.Point(15, 100);
                this.btnKeepPlace.Name = "btnKeepPlace";
                this.btnKeepPlace.Size = new System.Drawing.Size(75, 23);
                this.btnKeepPlace.TabIndex = 10;
                this.btnKeepPlace.Text = "保管地点";
                this.btnKeepPlace.UseVisualStyleBackColor = true;
                this.btnKeepPlace.Click += new System.EventHandler(this.btnKeepPlace_Click);
                // 
                // btnSave
                // 
                this.btnSave.Enabled = false;
                this.btnSave.Location = new System.Drawing.Point(362, 66);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(75, 23);
                this.btnSave.TabIndex = 5;
                this.btnSave.Text = "保存";
                this.btnSave.UseVisualStyleBackColor = true;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnTyp
                // 
                this.btnTyp.Location = new System.Drawing.Point(15, 71);
                this.btnTyp.Name = "btnTyp";
                this.btnTyp.Size = new System.Drawing.Size(75, 23);
                this.btnTyp.TabIndex = 4;
                this.btnTyp.Text = "资产类别";
                this.btnTyp.UseVisualStyleBackColor = true;
                this.btnTyp.Click += new System.EventHandler(this.btnTyp_Click);
                // 
                // btnName
                // 
                this.btnName.Location = new System.Drawing.Point(15, 35);
                this.btnName.Name = "btnName";
                this.btnName.Size = new System.Drawing.Size(75, 23);
                this.btnName.TabIndex = 4;
                this.btnName.Text = "资产名称";
                this.btnName.UseVisualStyleBackColor = true;
                this.btnName.Click += new System.EventHandler(this.btnName_Click);
                // 
                // btnCancel
                // 
                this.btnCancel.Enabled = false;
                this.btnCancel.Location = new System.Drawing.Point(362, 105);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(75, 23);
                this.btnCancel.TabIndex = 9;
                this.btnCancel.Text = "取消添加";
                this.btnCancel.UseVisualStyleBackColor = true;
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // btnDel
                // 
                this.btnDel.Location = new System.Drawing.Point(362, 144);
                this.btnDel.Name = "btnDel";
                this.btnDel.Size = new System.Drawing.Size(75, 23);
                this.btnDel.TabIndex = 9;
                this.btnDel.Text = "删除";
                this.btnDel.UseVisualStyleBackColor = true;
                this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
                // 
                // btnClose
                // 
                this.btnClose.Location = new System.Drawing.Point(362, 190);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(75, 23);
                this.btnClose.TabIndex = 8;
                this.btnClose.Text = "关闭";
                this.btnClose.UseVisualStyleBackColor = true;
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // btnAdd
                // 
                this.btnAdd.Location = new System.Drawing.Point(362, 27);
                this.btnAdd.Name = "btnAdd";
                this.btnAdd.Size = new System.Drawing.Size(75, 23);
                this.btnAdd.TabIndex = 7;
                this.btnAdd.Text = "添加新项";
                this.btnAdd.UseVisualStyleBackColor = true;
                this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                // 
                // frmBaseInfo
                // 
                this.AcceptButton = this.btnSave;
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(513, 276);
                this.Controls.Add(this.groupBox1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmBaseInfo";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "基本资料";
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblMessge;
        private System.Windows.Forms.ListBox lstInfo;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.Button btnUnit;
        private System.Windows.Forms.Button btnClearType;
        private System.Windows.Forms.Button btnKeepPlace;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTyp;

    }
}