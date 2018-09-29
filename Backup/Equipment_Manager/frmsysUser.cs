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
    public partial class frmsysUser : Form
    {
        public frmsysUser()
        {
            InitializeComponent();
        }
        private string _loginname;
        public string LoginName
        {
            set
            {
                this._loginname = value;
            }
 
        }

            
        /// <summary>
        /// �������û����󶨵�listveiw��
        /// </summary>
        private void InitUser()
        {
            DataTable dt = SysUserMgr.GetAllUser();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dt.Rows[i][1].ToString();
                    item.Tag = dt.Rows[i][0].ToString();
                    item.ImageIndex = 0;
                    lvwUser.Items.Add(item);
                }
            }

        }

        private void frmsysUser_Load(object sender, EventArgs e)
        {
            this.InitUser();//����ϵͳ�û��б�
        }

        /// <summary>
        /// ȡ����ӣ��ر�����û�����ؿؼ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnCamcel_Click(object sender, EventArgs e)
        {
            this.groupBoxAdd.Enabled = false;
            this.cleartxt();
            
        }
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
             ;
            if (this.checkInput())
            {
                int result=SysUserMgr.Add(this.txtUsername.Text, this.txtPass.Text, this.txtName.Text, this.chkDefaultPower.Checked);
                if (result==-2)
                {

                    untCommon.InfoMsg("����û�ʧ��");
                    return;
                   

                }
                if (result == -5)//ֻ����û�
                {
                    untCommon.InfoMsg("����û��ɹ�");
                    this.cleartxt(); //����ı���
                    return;
                }
                if (result != -3)//������û��� ���Ĭ��Ȩ��
                {
                    untCommon.InfoMsg("����û��ɹ������ɹ���������Ĭ��Ȩ�ޡ�");
                    this.cleartxt(); //����ı���
                    
                    
                }
                else 
                {
                    if (untCommon.QuestionMsg("����û��ɹ�,���Զ�����Ȩ��ʧ�ܡ��Ƿ�Ҫ�ֶ�����Ȩ�ޣ�"))
                    {
                        frmPowerSet power = new frmPowerSet();
                        power.ShowDialog();
                        return;
                    }
                }
               
                
            }
           
        }
        /// <summary>
        /// ����ı���
        /// </summary>
        private void cleartxt()
        {
            this.txtUsername.Text = "";
            this.txtPass.Text = "";
            this.txtName.Text = "";
            this.txtPassAgain .Text= "";
        }
        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            this.Del();
        
        }
        /// <summary>
        /// ɾ���û�
        /// </summary>
        private void Del()
        {
            if (this.lvwUser.SelectedItems.Count == 0)
            {
                untCommon.InfoMsg("��ѡ����Ҫɾ����ϵͳ�û���");
                return;
            }
            if (untCommon.QuestionMsg("��ȷ��Ҫɾ�����û���"))//ȷ��ɾ��
            {
                if (this.lvwUser.SelectedItems[0].Tag.ToString() == this._loginname)
                {
                    untCommon.ErrorMsg("����������ɾ�����Լ���");
                    return;
                }
                if (SysUserMgr.Del(this.lvwUser.SelectedItems[0].Tag.ToString()))
                {
                    lvwUser.Items.Clear();
                    InitUser();

                }
                else
                {
                    untCommon.InfoMsg("ɾ��ʧ�ܡ�");
                }
            }
        }
        /// <summary>
        /// ˢ���û��б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            this.lvwUser.Items.Clear();
            this.InitUser();
        }
        /// <summary>
        /// ����ı������Ƿ���������
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtUsername.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������¼����");
                return false;
            }
            if (this.txtPass.Text.Trim() == "")
            {
                untCommon.InfoMsg("���������롣");
                return false;
            }
            if(this.txtPass.Text.Trim()!=this.txtPassAgain.Text.Trim())
            {
                untCommon.InfoMsg("��������������������Ĳ�һ�¡�");
            }
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.InfoMsg("��������ʵ������");
                return false;
            }
            return true;
        }
        /// <summary>
        /// �ز�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolMenu_Add_Click(object sender, EventArgs e)
        {
            this.groupBoxAdd.Enabled = true;
            this.txtUsername.Focus();

        }
        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ToolMenu_Del_Click(object sender, EventArgs e)
        {
            this.Del();

        }

        private void ToolMenu_Refresh_Click(object sender, EventArgs e)
        {
            this.InitUser();
        }

       

       

        
    }
}