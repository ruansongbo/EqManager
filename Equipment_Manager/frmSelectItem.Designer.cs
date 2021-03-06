﻿namespace Equipment_Manager
{
    partial class frmSelectItem
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
            this.Select_None_button = new System.Windows.Forms.Button();
            this.Invert_Selection_button = new System.Windows.Forms.Button();
            this.Select_All_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Select_button = new System.Windows.Forms.Button();
            this.chklst = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // Select_None_button
            // 
            this.Select_None_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Select_None_button.Location = new System.Drawing.Point(90, 350);
            this.Select_None_button.Name = "Select_None_button";
            this.Select_None_button.Size = new System.Drawing.Size(75, 23);
            this.Select_None_button.TabIndex = 11;
            this.Select_None_button.Text = "全不选";
            this.Select_None_button.UseVisualStyleBackColor = true;
            this.Select_None_button.Click += new System.EventHandler(this.Select_None_button_Click);
            // 
            // Invert_Selection_button
            // 
            this.Invert_Selection_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Invert_Selection_button.Location = new System.Drawing.Point(171, 350);
            this.Invert_Selection_button.Name = "Invert_Selection_button";
            this.Invert_Selection_button.Size = new System.Drawing.Size(75, 23);
            this.Invert_Selection_button.TabIndex = 10;
            this.Invert_Selection_button.Text = "反选";
            this.Invert_Selection_button.UseVisualStyleBackColor = true;
            this.Invert_Selection_button.Click += new System.EventHandler(this.Invert_Selection_button_Click);
            // 
            // Select_All_button
            // 
            this.Select_All_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Select_All_button.Location = new System.Drawing.Point(9, 350);
            this.Select_All_button.Name = "Select_All_button";
            this.Select_All_button.Size = new System.Drawing.Size(75, 23);
            this.Select_All_button.TabIndex = 9;
            this.Select_All_button.Text = "全选";
            this.Select_All_button.UseVisualStyleBackColor = true;
            this.Select_All_button.Click += new System.EventHandler(this.Select_All_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Cancel_button.Location = new System.Drawing.Point(372, 350);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 8;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Select_button
            // 
            this.Select_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Select_button.Location = new System.Drawing.Point(291, 350);
            this.Select_button.Name = "Select_button";
            this.Select_button.Size = new System.Drawing.Size(75, 23);
            this.Select_button.TabIndex = 7;
            this.Select_button.Text = "确定";
            this.Select_button.UseVisualStyleBackColor = true;
            this.Select_button.Click += new System.EventHandler(this.Select_button_Click);
            // 
            // chklst
            // 
            this.chklst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklst.FormattingEnabled = true;
            this.chklst.Location = new System.Drawing.Point(12, 12);
            this.chklst.Name = "chklst";
            this.chklst.Size = new System.Drawing.Size(433, 324);
            this.chklst.TabIndex = 6;
            // 
            // frmSelectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 385);
            this.Controls.Add(this.Select_None_button);
            this.Controls.Add(this.Invert_Selection_button);
            this.Controls.Add(this.Select_All_button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Select_button);
            this.Controls.Add(this.chklst);
            this.Name = "frmSelectItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择项目";
            this.Load += new System.EventHandler(this.frmSelectItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Select_None_button;
        private System.Windows.Forms.Button Invert_Selection_button;
        private System.Windows.Forms.Button Select_All_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button Select_button;
        private System.Windows.Forms.CheckedListBox chklst;
    }
}