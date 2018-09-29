using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmConpanyInfo : Form
    {
        public frmConpanyInfo()
        {
            InitializeComponent();
        }
        public void InitInfo()
        {
            DataTable dt = CompanyInfoMgr.GetInfo();
            if (dt != null)
            {
                this.txtName.Text = dt.Rows[0][1].ToString();
                this.txtLinkMan.Text = dt.Rows[0][2].ToString();
                this.txtAdress.Text = dt.Rows[0][3].ToString();
                this.groupBox1.Text = dt.Rows[0][1].ToString();
            }

        }

        private void frmConpanyInfo_Load(object sender, EventArgs e)
        {
            this.InitInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.InfoMsg("�����뱾��λ�����ơ�");
                return;
            }
            
            if (this.txtLinkMan.Text.Trim() == "")
            {
                untCommon.InfoMsg("��������ϵ��������");
                return;
            }
            if (this.txtAdress.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������ַ");
                return;
            }
            if (CompanyInfoMgr.update(txtName.Text, txtLinkMan.Text, txtAdress.Text))
            {
                untCommon.InfoMsg("�޸ĳɹ���");
            }
            else
            {
                untCommon.InfoMsg("�޸�ʧ�ܡ�");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}