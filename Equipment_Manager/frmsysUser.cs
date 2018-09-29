using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmsysUser : Form
    {
        public frmsysUser()
        {
            InitializeComponent();
        }
        private string _loginId;
        public string LoginId
        {
            set
            {
                this._loginId = value;
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

                    //�������û�ʱΪ�˱���Ĭ��Ȩ�������õģ��������⿪��
                    if (item.Text == "һ���û�" || item.Text == "�����û�" || item.Text == "�����û�")
                        continue;
                    lvwUser.Items.Add(item);
                }
                
            }

        }

        private void InitDepart()
        {
            DataTable dt = DepartMgr.GetAll();
            if (dt != null)
            {
                this.cbxDepart.Items.Clear();
                this.cbxDepart.DataSource = dt;
                this.cbxDepart.DisplayMember = dt.Columns[1].ToString();
                this.cbxDepart.ValueMember = dt.Columns[0].ToString();
            }
        }

        private void frmsysUser_Load(object sender, EventArgs e)
        {
            this.InitUser();//����ϵͳ�û��б�
            this.InitDepart();//��ʼ������ѡ��
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
            
            if (this.checkInput())
            {
                int result=SysUserMgr.Add(this.txtUserId.Text, this.txtPass.Text, this.txtName.Text,this.cbxDepart.SelectedValue.ToString()
                    ,this.txtTel.Text,this.txtEmail.Text,this.cbxPower.Text);
                if (result==-1)
                {

                    untCommon.InfoMsg("����û�ʧ��");
                    return;
                   

                }
                if (result != -2)//������û��� ���Ĭ��Ȩ��
                {
                    untCommon.InfoMsg("����û��ɹ������ɹ���������Ȩ�ޡ�");
                    this.cleartxt(); //����ı���
                    this.lvwUser.Items.Clear();
                    this.InitUser();
                    
                }
                else 
                {
                    if (untCommon.QuestionMsg("����û��ɹ�,���Զ�����Ȩ��ʧ�ܡ��Ƿ�Ҫ�ֶ�����Ȩ�ޣ�"))
                    {
                        this.lvwUser.Items.Clear();
                        this.InitUser();
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
            this.txtUserId.Text = "";
            this.txtPass.Text = "";
            this.txtName.Text = "";
            this.txtPassAgain .Text= "";
            this.txtTel.Text = "";
            this.txtEmail.Text = "";
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
                if (this.lvwUser.SelectedItems[0].Tag.ToString() == this._loginId)
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
            if (this.txtUserId.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������¼ID��");
                return false;
            }
            if (!IsNumber(this.txtUserId.Text))
            {
                untCommon.InfoMsg("��¼ID����Ϊ�����֡�");
                return false;
            }
            if (this.txtUserId.Text.Length != 6)
            {
                untCommon.InfoMsg("��¼ID����Ϊ6λ���֡�");
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
            this.txtUserId.Focus();

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
            this.lvwUser.Items.Clear();
            this.InitUser();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �ж��ַ����Ƿ�������
        /// </summary>
        private bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        //lvwUser˫���¼�
        private void lvwUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lvwUser.SelectedItems[0].Text == "sa")
            {
                untCommon.ErrorMsg("���û�Ϊ���Ȩ���û���ֻ�����и�������");
                return;
            }
            frmUpdateSysUserInfo fuSysUser=new frmUpdateSysUserInfo(this.lvwUser.SelectedItems[0].Tag.ToString(), true);
            fuSysUser.ShowDialog();
        }

        private void ToolMenu_Update_Click(object sender, EventArgs e)
        {
            if (this.lvwUser.SelectedItems.Count > 0)
            {
                if (this.lvwUser.SelectedItems[0].Text == "sa")
                {
                    untCommon.ErrorMsg("���û�Ϊ���Ȩ���û���ֻ�����и�������");
                    return;
                }
                frmUpdateSysUserInfo fuSysUser = new frmUpdateSysUserInfo(this.lvwUser.SelectedItems[0].Tag.ToString(), true);
                fuSysUser.ShowDialog();
            }
        }

        
    }
}