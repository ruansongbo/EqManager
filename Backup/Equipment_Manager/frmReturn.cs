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
        /// 得到指定资产的信息
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
                    //untCommon.InfoMsg("该资产不存在,请检查资产编号输入是否正确。");
                    return null;
                    
                }
            
           
 
        }
        /// <summary>
        /// 得到某员工领用的某比资产的领用信息
        /// </summary>
        /// <returns>true：成功的取得信息；fasle：查询信息失败</returns>
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
        /// 查看资产的领用信息和资产的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, EventArgs e)
        { 
            if (this.txtEqNo.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入资产编号");
                return;
            }
            if (this.txtborrower.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入领用人工号");
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
                untCommon.InfoMsg("该资产的领用记录不存在。\r\n原因可能是资产编号和领用人工号填写是的不正确。");
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
                    untCommon.InfoMsg("你成功归还了所领用的资产。");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    untCommon.InfoMsg("您归还资产失败。");
                }

            }

        }
        /// <summary>
        /// 检查输入数据是否合法
        /// </summary>
        /// <returns>true:合法;false:不合法</returns>
        private bool CheckInput()
        {
            if (this.txtEqNo.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入资产编号");
                return false;
            }
            if (this.txtborrower.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入领用人工号");
                return false;
            }
            //得到资产的信息和领用信息
            this.info = new ArrayList();
            this.borrow = new ArrayList();
            this.info.Clear();
            this.borrow.Clear();
            this.info = this.GetInfo();
            this.borrow = this.GetBorrowInfo();
            if(this.borrow==null||this.info==null)
            {
                untCommon.InfoMsg("该资产的领用记录不存在。\r\n请检查资产编号和领用人工号填写是否正确？");
                return false;
            }
            if (txtcount.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入归还资产的数量？");
                return false;
            }
            try
            {
                if (int.Parse(txtcount.Text) > int.Parse(this.borrow[0].ToString()))
                {
                    untCommon.InfoMsg("归还资产的数量不能大于领用资产的数量");
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                untCommon.ErrorMsg("数量请在英文输入环境下输入数字");
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}