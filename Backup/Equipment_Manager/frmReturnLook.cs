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
    public partial class frmReturnLook : Form
    {
        public frmReturnLook()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ������Ҫ�����ÿؼ��Ƿ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolcbxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.toolcbxStyle.SelectedItem.ToString() == "��ȷ����")
            {
                this.panel1.Visible = true;
                this.tooltxtCondition.Enabled = false;
            }
            else
            {
                this.panel1.Visible = false;
                this.tooltxtCondition.Enabled = true;
 
            }
            if (this.toolcbxStyle.SelectedItem.ToString() == "�������" || this.toolcbxStyle.SelectedItem.ToString() == "���һ��")
            {
                this.tooltxtCondition.Enabled = false;
                this.tooltxtCondition.Text = "";
            }
            else
            {
                this.tooltxtCondition.Enabled = true;
            }
            
        }
        /// <summary>
        /// ��ʼ���ʲ��黹��
        /// </summary>
        private void initReturnInfo()
        {
            DataTable dt = ReturnMgr.GetAll();
            if (dt != null)
            {
                dbgReturnInfo.DataSource = dt;
            }
           
        }

        private void frmReturnLook_Load(object sender, EventArgs e)
        {
            this.initReturnInfo(); // �����ʲ��黹��
        }

        private void toolbtnSeach_Click(object sender, EventArgs e)
        {
            
            //���ʲ�����������ʲ����ñ�
            if (toolcbxStyle.Text == "�ʲ����")
            {
                GetInfoByEqno();
                return;
   
            }
            //�����ʲ������˹����������ʲ����ñ�
            if (toolcbxStyle.Text == "�����˹���")
            {
                GetInfoByBorrower();
                return;
 
            }
            //�������������ʲ��黹��¼
            if (toolcbxStyle.Text == "�������")
            {
                GetInfoLast6Month();
                return;
            }
            //�������1����ʲ��黹��¼
            if (toolcbxStyle.Text == "���һ��")
            {
                GetInfoLastYear();
                return;
            }
            //�����û�ָ�����꣬�·�Χ�ڵļ�¼
            if (toolcbxStyle.Text == "��ȷ����")
            {
                GetInfoYearMonth();
                return;
 
            }
        }
        /// <summary>
        /// ���ʲ���Ų�ѯ(��ȷ)
        /// </summary>
        private void GetInfoByEqno()
        {
            if (this.tooltxtCondition.Text.Trim() == "")
            {
                this.tooltxtCondition.Focus();
                untCommon.InfoMsg("��������Ҫ��ѯ���ʲ���š�");
                return;

            }

            DataTable dt = ReturnMgr.GetInfoByEqno(this.tooltxtCondition.Text);
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    untCommon.InfoMsg("û������Ҫ��ѯ���ʲ���Ϣ��");
                }
                else
                {
                    this.dbgReturnInfo.DataSource = dt;
                }
            }
        }
        /// <summary>
        /// ���������˱�Ų�ѯ����ȷ��ѯ��
        /// </summary>
        private void GetInfoByBorrower()
        {
            if (this.tooltxtCondition.Text.Trim() == "")
            {
                this.tooltxtCondition.Focus();
                untCommon.InfoMsg("��������Ҫ��ѯ�������˹��š�");
                return;

            }
            DataTable dt = ReturnMgr.GetInfoByBorrower(int.Parse(this.tooltxtCondition.Text));
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    untCommon.InfoMsg("û������Ҫ��ѯ���ʲ���Ϣ��");
                }
                else
                {
                    this.dbgReturnInfo.DataSource = dt;
                }
            }
 
        }

        private void tooltxtCondition_TextChanged(object sender, EventArgs e)
        {
            if (toolcbxStyle.Text == "�ʲ����")
            {
                GetInfo2();
                return;

            }

            if (toolcbxStyle.Text == "�����˹���")
            {
                GetInfoByBorrower2();
                return;

            }
            

           

        }
        /// <summary>
        /// �����ʲ���Ų�ѯ��ģ����ѯ��
        /// </summary>
        private void GetInfo2()
        {
            DataTable dt = ReturnMgr.GetInfoByEqno2(this.tooltxtCondition.Text);
            if (dt != null)
            {
                this.dbgReturnInfo.DataSource = dt;

            }
 
        }
        /// <summary>
        /// ���������˱�Ų�ѯ��ģ����ѯ��
        /// </summary>
        private void GetInfoByBorrower2()
        {
            DataTable dt = ReturnMgr.GetInfoByBorrower2(int.Parse(this.tooltxtCondition.Text));
            if (dt != null)
            {
                this.dbgReturnInfo.DataSource = dt;

            }

        }
        /// <summary>
        /// ��ѯ��������ڵ��ʲ��黹��¼
        /// </summary>
        private void GetInfoLast6Month()
        {
            DataTable dt = ReturnMgr.getInfoLast6Month();
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    untCommon.InfoMsg("û������Ҫ��ѯ���ʲ���Ϣ��");
                }
                else
                {
                    this.dbgReturnInfo.DataSource = dt;
                }
            }
 
        }
        /// <summary>
        /// ��ѯ���1���ڵ��ʲ��黹��¼
        /// </summary>
        private void GetInfoLastYear()
        {
            DataTable dt = ReturnMgr.getInfoLastYear();
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    untCommon.InfoMsg("û������Ҫ��ѯ���ʲ���Ϣ��");
                }
                else
                {
                    this.dbgReturnInfo.DataSource = dt;
                }
            }

        }
        /// <summary>
        /// ��ѯָ�����꣬���ڵ��ʲ��黹��¼
        /// </summary>
        private void GetInfoYearMonth()
        {
            if (this.txtYear.Text.Trim() == "")
            {
                untCommon.InfoMsg("��������Ҫ��ѯ��¼���ꡣ");
                return;
            }
            if (this.cbxMonth.Text.Trim() == "")
            {
                untCommon.InfoMsg("��������Ҫ��ѯ��¼���¡�");
                return;
 
            }
            try
            {
               int year=int.Parse(this.txtYear.Text);
               int month=int.Parse(this.cbxMonth.Text);
                DataTable dt = ReturnMgr.getInfoYearMonth(year, month);
                if (dt != null)
                {
                    if (dt.Rows.Count == 0)
                    {
                        untCommon.InfoMsg("û������Ҫ��ѯ���ʲ���Ϣ��");
                    }
                    else
                    {
                        this.dbgReturnInfo.DataSource = dt;
                        this.panel1.Visible = false;
                    }
                }

            }
            catch(Exception)
            {
                untCommon.ErrorMsg("���������������������֡�");
            }
            
           
        }
        /// <summary>
        /// ����ѯ���Ľ������ΪExel���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgReturnInfo);
        }

        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            this.initReturnInfo();
        }

        private void toolbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

      
    }
}