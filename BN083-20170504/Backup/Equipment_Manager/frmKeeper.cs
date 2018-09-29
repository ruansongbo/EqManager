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
    public partial class frmKeeper : Form
    {
        public frmKeeper()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��ʼ������Ա�б�
        /// </summary>
        public void InitKeeper()
        {
            DataTable dt = KeeperMgr.GetAll();
            if (dt != null)
            {
                this.lstKeeper.DataSource = dt;
                this.lstKeeper.DisplayMember = dt.Columns[1].ToString();
                this.lstKeeper.ValueMember = dt.Columns[0].ToString();
            }
 
        }

        

        private void frmKeeper_Load(object sender, EventArgs e)
        {
            this.InitKeeper(); //���ر���Ա�б�

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.btnCancel.Enabled = true;
            this.txtKeeper.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnDel.Enabled = false;
            
            this.txtKeeper.Focus();
            this.txtKeeper.Text = "��д�±���Ա�Ĺ���";
            this.txtKeeper.SelectAll();
        }
        /// <summary>
        /// ȡ����Ӻ�������ذ�ť��״̬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            
            txtKeeper.Text = "";
            txtKeeper.Enabled = false;
            btnDel.Enabled = true;
        }
        /// <summary>
        /// ������ӵı�����Ա
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKeeper.Text == "��д�±���Ա�Ĺ���")
            {
                untCommon.InfoMsg("��д�±���Ա�Ĺ���");
                return;
            }
            if (txtKeeper.Text.Trim() == "")
            {
                untCommon.InfoMsg("��д�±���Ա�Ĺ���");
                return;
            }
            int empid;
            try
            {
                empid = int.Parse(txtKeeper.Text);
            
                DataTable dt = EmployeeMgr.GetOneEmp(empid);//����û�����Ĺ����Ƿ���ȷ
            
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        //�������Ĺ�����ȷ
                        string name = dt.Rows[0][1].ToString();

                        if (KeeperMgr.Add(empid, name)) 
                        {
                            //��ӳɹ��Ժ������Ҫ������ذ�ť��״̬
                            this.btnCancel.Enabled = false;
                            this.btnSave.Enabled = false;
                            this.btnDel.Enabled = true;
                            txtKeeper.Text = "";
                            txtKeeper.Enabled = false;
                           
                            InitKeeper();
                        }
                        else
                        {
                            untCommon.InfoMsg("���ʧ��");
                        }

                    }

                    else
                    {
                        untCommon.ErrorMsg("�������Ա�����Ǳ���λԱ�������ܱ��ܱ���λ���ʲ���\r\n��ȷ��Ա������Ƿ���ȷ��");
                    }


                }
            }
            catch (FormatException)
            {
                untCommon.ErrorMsg("��������������");

            }
            
        }
        /// <summary>
        /// ɾ������Ա
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstKeeper.SelectedIndex==-1)
            {
                untCommon.InfoMsg("��ѡ����Ҫɾ���ı���Ա��");
                return;
 
            }
            
            if (untCommon.QuestionMsg("ȷ��Ҫɾ���ñ���Ա��"))
            {
                int result=KeeperMgr.Del(int.Parse(lstKeeper.SelectedValue.ToString()));
                if (result>0)//ɾ���ɹ�
                {
                    this.InitKeeper();
                }
                else //ɾ��ʧ��
                {
                    if (result == -1)
                    {
                        untCommon.ErrorMsg("ɾ��ʧ�ܣ��ù���Ա�������б���λ�Ĺ̶��ʲ���\r\n�뽫�ʲ��ı���Ȩ����ɾ���ñ���Ա��");
                    }
                    else
                    {
                        untCommon.InfoMsg("ɾ��ʧ�ܡ�");
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