using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Equipment_Manager
{
    public partial class frmLabel : Form
    {
        private int count = 1;

        
        public frmLabel()
        {
            InitializeComponent();
        }

        private void txtCopyNum_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            char result = e.KeyChar;
            if (char.IsDigit(result) || result == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.txtCopyNum.Text.Trim() != "")
            {
                this.count = Convert.ToInt32(this.txtCopyNum.Text.ToString());
                if (count > 100)
                    untCommon.ErrorMsg("打印份数不得大于100");
                else
                    this.DialogResult = DialogResult.OK;
            }
            else
            {
                untCommon.ErrorMsg("请填写打印份数");
            }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
