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
    public partial class frmRemark : Form
    {
        public frmRemark()
        {
            InitializeComponent();
        }

        
        public string TextBoxValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
                untCommon.InfoMsg("审核意见为空。");
            else
                this.DialogResult = DialogResult.OK;
        }
    }
}
