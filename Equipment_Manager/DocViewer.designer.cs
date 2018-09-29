namespace Equipment_Manager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 
        private void InitializeComponent()
        {
            this.docViewer1 = new Spire.DocViewer.Forms.DocViewer();
            this.SuspendLayout();
            // 
            // docViewer1
            // 
            this.docViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docViewer1.IsToolBarVisible = true;
            this.docViewer1.Location = new System.Drawing.Point(0, 0);
            this.docViewer1.Name = "docViewer1";
            this.docViewer1.Size = new System.Drawing.Size(792, 573);
            this.docViewer1.TabIndex = 0;
            this.docViewer1.Text = "docViewer1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.docViewer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "三联单打印预览.";
            this.ResumeLayout(false);

        }

        #endregion

        private Spire.DocViewer.Forms.DocViewer docViewer1;
    }
}

