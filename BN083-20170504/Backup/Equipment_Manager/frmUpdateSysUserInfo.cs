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
    public partial class frmUpdateSysUserInfo : Form
    {
        public frmUpdateSysUserInfo()
        {
            InitializeComponent();
        }
        private string _loginname;
        private string _name;
        public string LoginName
        {
            set
            {
                this._loginname = value;
            }
        }
        public string Names
        {
            set
            {
                this._name = value;
            }
        }


        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            this.Eneble();
            this.Cleartxt();

        }

        /// <summary>
        /// �����޸�������ؿؼ�������״̬
        /// </summary>
        private void Eneble()
        {
            this.lblOldPass.Enabled = !this.lblOldPass.Enabled;
            this.lblNewPass.Enabled = !this.lblNewPass.Enabled;
            this.lblNewPassAgain.Enabled = !this.lblNewPassAgain.Enabled;
            this.txtOldPass.Enabled = !this.txtOldPass.Enabled;
            this.txtNewPass.Enabled = !this.txtNewPass.Enabled;
            this.txtPassAgain.Enabled = !this.txtPassAgain.Enabled;

        }
        /// <summary>
        /// �����������ڵ��ַ�
        /// </summary>
        private void Cleartxt()
        {
            this.txtOldPass.Text = "";
            this.txtNewPass.Text = "";
            this.txtPassAgain.Text = "";
        }

        private void frmUpdateSysUserInfo_Load(object sender, EventArgs e)
        {
            this.txtLoginname.Text = this._loginname;//���ص�¼��
            this.txtName.Text = this._name;     //������ʵ����

        }
        /// <summary>
        /// ��������Ƿ�Ϸ�
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.InfoMsg("��������ʵ������");
                return false;
            }
            if (this.txtOldPass.Text.Trim() == "")
            {
                untCommon.InfoMsg("������ԭ���롣");
                return false;
            }
            if (this.txtNewPass.Text.Trim() == "")
            {
                untCommon.InfoMsg("�����������롣");
                return false;
            }
            if (this.txtNewPass.Text != this.txtPassAgain.Text)
            {
                untCommon.InfoMsg("������������벻һ��");
                this.txtNewPass.Text = "";
                this.txtPassAgain.Text = "";
                return false;
            }
            return true;
        }
  

        private void btnOk_Click(object sender, EventArgs e)
        {
            //�޸����ϣ����޸����룩
            if (this.chkPass.Checked == false)
            {
                if (this.txtName.Text.Trim() == "")
                {
                    untCommon.InfoMsg("��������ʵ������");
                    return;
                }
                if (SysUserMgr.UpdateNoPass(this.txtLoginname.Text, this.txtName.Text))
                {
                    untCommon.InfoMsg("�޸ĳɹ���");
                    
                }
                else
                {
                    untCommon.InfoMsg("�޸�ʧ��");
                }

            }
            else
            {
                if (this.checkInput())//�޸�����
                {
                   
                    int result = SysUserMgr.UpdatePass(this.txtLoginname.Text,this.txtOldPass.Text,this.txtNewPass.Text,this.txtName.Text);
                    if (result>0)
                    {
                        untCommon.InfoMsg("�޸ĳɹ���");
                        this.Cleartxt();
                        this.chkPass.Checked = false;
                    }
                    else
                    {
                        if(result==-1)
                        {
                            untCommon.InfoMsg("ԭ���������ȷ�Ϻ������롣�޸�ʧ�ܡ�");
                            this.Cleartxt();
                            return;
                        }
                        untCommon.InfoMsg("�޸�ʧ��");
                    }
                }
 
            }
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}