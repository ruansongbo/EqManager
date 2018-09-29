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
        private string _loginid;
        //�����жϸ��ĵ����Լ������ϻ��Ǳ��˵�����
        private bool _isother=false;

        public frmUpdateSysUserInfo(string Loginid, bool isOther)
        {
            InitializeComponent();
            this._loginid = Loginid;
            this._isother = isOther;
        }


        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            this.Enable();
            this.Cleartxt();

        }

        /// <summary>
        /// �����޸�������ؿؼ�������״̬
        /// </summary>
        private void Enable()
        {
            this.lblOldPass.Enabled = !this.lblOldPass.Enabled;
            this.lblNewPass.Enabled = !this.lblNewPass.Enabled;
            this.lblNewPassAgain.Enabled = !this.lblNewPassAgain.Enabled;
            if(!_isother)
                this.txtOldPass.Enabled = !this.txtOldPass.Enabled;
            this.txtNewPass.Enabled = !this.txtNewPass.Enabled;
            this.txtPassAgain.Enabled = !this.txtPassAgain.Enabled;

        }
        /// <summary>
        /// �����������ڵ��ַ�
        /// </summary>
        private void Cleartxt()
        {
            if(!_isother)
                this.txtOldPass.Text = "";
            this.txtNewPass.Text = "";
            this.txtPassAgain.Text = "";
        }

        private void frmUpdateSysUserInfo_Load(object sender, EventArgs e)
        {
            this.txtLoginId.Text = this._loginid;//���ص�¼id
            DataTable dt = SysUserMgr.GetOneUser(this._loginid);
            DataTable dtDepart = DepartMgr.GetAllDepartment();
            this.cbxDepart.DataSource = dtDepart;
            this.cbxDepart.DisplayMember = dtDepart.Columns[0].ToString();
            this.cbxDepart.ValueMember = dtDepart.Columns[1].ToString();

            if (dt != null)
            {
                this.txtName.Text = dt.Rows[0][2].ToString();
                this.cbxDepart.Text = DepartMgr.GetNameFromId(dt.Rows[0][3].ToString());
                this.txtTel.Text = dt.Rows[0][4].ToString();
                this.txtEmail.Text = dt.Rows[0][5].ToString();

            }

            

            if (this._isother)
            {
                this.txtOldPass.PasswordChar = new char();
                this.txtOldPass.Text = SysUserMgr.GetPass(this._loginid);
                //�Լ����ɸ����������ڲ��ţ�ֻ���������˽��и��Ĳ���
                this.cbxDepart.Enabled = true;
            }
            

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
                if (SysUserMgr.UpdateNoPass(this.txtLoginId.Text, this.txtName.Text,this.txtTel.Text,this.txtEmail.Text,this.cbxDepart.SelectedValue.ToString()))
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
                   
                    int result = SysUserMgr.UpdatePass(this.txtLoginId.Text,this.txtOldPass.Text,this.txtNewPass.Text,this.txtName.Text,
                                                       this.txtTel.Text,this.txtEmail.Text,this.cbxDepart.SelectedValue.ToString());
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