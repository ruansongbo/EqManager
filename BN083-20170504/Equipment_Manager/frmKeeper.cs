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
        /// 初始化保管员列表
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
            this.InitKeeper(); //加载保管员列表；

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.btnCancel.Enabled = true;
            this.txtKeeper.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnDel.Enabled = false;
            
            this.txtKeeper.Focus();
            this.txtKeeper.Text = "填写新保管员的工号";
            this.txtKeeper.SelectAll();
        }
        /// <summary>
        /// 取消添加后设置相关按钮的状态
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
        /// 保存添加的保管人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKeeper.Text == "填写新保管员的工号")
            {
                untCommon.InfoMsg("填写新保管员的工号");
                return;
            }
            if (txtKeeper.Text.Trim() == "")
            {
                untCommon.InfoMsg("填写新保管员的工号");
                return;
            }
            int empid;
            try
            {
                empid = int.Parse(txtKeeper.Text);
            
                DataTable dt = EmployeeMgr.GetOneEmp(empid);//检查用户输入的工号是否正确
            
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        //如果输入的工号正确
                        string name = dt.Rows[0][1].ToString();

                        if (KeeperMgr.Add(empid, name)) 
                        {
                            //添加成功以后根据需要设置相关按钮的状态
                            this.btnCancel.Enabled = false;
                            this.btnSave.Enabled = false;
                            this.btnDel.Enabled = true;
                            txtKeeper.Text = "";
                            txtKeeper.Enabled = false;
                           
                            InitKeeper();
                        }
                        else
                        {
                            untCommon.InfoMsg("添加失败");
                        }

                    }

                    else
                    {
                        untCommon.ErrorMsg("您所填的员工不是本单位员工，不能保管本单位的资产。\r\n请确认员工编号是否正确。");
                    }


                }
            }
            catch (FormatException)
            {
                untCommon.ErrorMsg("工号请输入数字");

            }
            
        }
        /// <summary>
        /// 删除保管员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstKeeper.SelectedIndex==-1)
            {
                untCommon.InfoMsg("请选择所要删除的保管员。");
                return;
 
            }
            
            if (untCommon.QuestionMsg("确定要删除该保管员吗？"))
            {
                int result=KeeperMgr.Del(int.Parse(lstKeeper.SelectedValue.ToString()));
                if (result>0)//删除成功
                {
                    this.InitKeeper();
                }
                else //删除失败
                {
                    if (result == -1)
                    {
                        untCommon.ErrorMsg("删除失败，该管理员还保管有本单位的固定资产，\r\n请将资产的保管权后在删除该保管员。");
                    }
                    else
                    {
                        untCommon.InfoMsg("删除失败。");
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