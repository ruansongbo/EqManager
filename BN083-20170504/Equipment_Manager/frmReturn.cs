using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using DataEntity;
using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmReturn : Form
    {
        public frmReturn()
        {
            InitializeComponent();
        }
        ArrayList info = null;
        ArrayList borrow = null;
        /// <summary>
        /// �õ�ָ���ʲ�����Ϣ
        /// </summary>
        private ArrayList GetInfo()
        {
            DataTable dt = EpMgr.GetOneInfo(this.txtEqNo.Text);
            
                if (dt.Rows.Count != 0)
                {
                    ArrayList al = new ArrayList();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        al.Add(dt.Rows[0][i].ToString());

                    }
                    return al;
                    
                }
                else
                {
                    //untCommon.InfoMsg("���ʲ�������,�����ʲ���������Ƿ���ȷ��");
                    return null;
                    
                }
            
           
 
        }
        /// <summary>
        /// �õ�ĳԱ�����õ�ĳ���ʲ���������Ϣ
        /// </summary>
        /// <returns>true���ɹ���ȡ����Ϣ��fasle����ѯ��Ϣʧ��</returns>
        private ArrayList GetBorrowInfo()
        {

            DataTable dt = BoroowMgr.GetOneBorrow(this.txtEqNo.Text, int.Parse(this.txtborrower.Text));
            
                if (dt.Rows.Count != 0)
                {
                    ArrayList al = new ArrayList();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        al.Add(dt.Rows[0][i].ToString());
                    }
                    return al;
                }
                else
                {
                    
                    return null ;

                }
            
   


        }
        /// <summary>
        /// �鿴�ʲ���������Ϣ���ʲ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, EventArgs e)
        { 
            if (this.txtEqNo.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������ʲ����");
                return;
            }
            if (this.txtborrower.Text.Trim() == "")
            {
                untCommon.InfoMsg("�����������˹���");
                return ;
            }

            this.info = this.GetInfo();
            this.borrow = this.GetBorrowInfo();
            if (info != null || borrow != null)
            {
                frmOneEqInfo frmone = new frmOneEqInfo();
                frmone.info = this.info;
                frmone.borrow = this.borrow;
                frmone.ShowDialog();

            }
            else
            {
                untCommon.InfoMsg("���ʲ������ü�¼�����ڡ�\r\nԭ��������ʲ���ź������˹�����д�ǵĲ���ȷ��");
            }

           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            if (info != null)
            {

            }
            if (this.CheckInput())
            {
                Returns re = new Returns();
                re.EqNo = this.txtEqNo.Text;
                re.Count = int.Parse(this.txtcount.Text);
                re.Booker = this.txtbooker.Text;
                re.Date = this.dtpDate.Value.ToShortDateString();
                re.Borrower = int.Parse(this.txtborrower.Text);
                if (ReturnMgr.Returns(re))
                {
                    untCommon.InfoMsg("��ɹ��黹�������õ��ʲ���");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    untCommon.InfoMsg("���黹�ʲ�ʧ�ܡ�");
                }

            }

        }
        /// <summary>
        /// ������������Ƿ�Ϸ�
        /// </summary>
        /// <returns>true:�Ϸ�;false:���Ϸ�</returns>
        private bool CheckInput()
        {
            if (this.txtEqNo.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������ʲ����");
                return false;
            }
            if (this.txtborrower.Text.Trim() == "")
            {
                untCommon.InfoMsg("�����������˹���");
                return false;
            }
            //�õ��ʲ�����Ϣ��������Ϣ
            this.info = new ArrayList();
            this.borrow = new ArrayList();
            this.info.Clear();
            this.borrow.Clear();
            this.info = this.GetInfo();
            this.borrow = this.GetBorrowInfo();
            if(this.borrow==null||this.info==null)
            {
                untCommon.InfoMsg("���ʲ������ü�¼�����ڡ�\r\n�����ʲ���ź������˹�����д�Ƿ���ȷ��");
                return false;
            }
            if (txtcount.Text.Trim() == "")
            {
                untCommon.InfoMsg("������黹�ʲ���������");
                return false;
            }
            try
            {
                if (int.Parse(txtcount.Text) > int.Parse(this.borrow[0].ToString()))
                {
                    untCommon.InfoMsg("�黹�ʲ����������ܴ��������ʲ�������");
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                untCommon.ErrorMsg("��������Ӣ�����뻷������������");
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}