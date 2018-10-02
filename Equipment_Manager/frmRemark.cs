using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmRemark : Form
    {
        private bool view_only;
        private string ID;
        private int tab_index;
        public frmRemark()
        {
            InitializeComponent();
            this.view_only = false; ;
        }

        public frmRemark(string ID,int tab_index)
        {
            InitializeComponent();
            this.view_only = true;
            this.tab_index = tab_index;
            this.ID = ID;
        }
       
        public string TextBoxValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }


        private void frmRemark_Load(object sender, EventArgs e)
        {
            if (view_only)
            {
                this.label1.Text = "审核意见：";
                switch (tab_index)
                {
                    case 0:
                        textBox1.Text = EqMgr.GetAuditFromID(ID);
                        break;
                    case 1:
                        textBox1.Text = ClearMgr.GetAuditFromID(ID);
                        break;
                    case 2:
                        textBox1.Text = EqMgr.GetAuditFromID(ID);
                        break;
                    default:
                        break;
                }

            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            if (!view_only)
            {
                if (textBox1.Text == "")
                    untCommon.InfoMsg("审核意见为空。");
                else
                    this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}
