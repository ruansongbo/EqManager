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
        /// 跟据需要来设置控件是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolcbxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.toolcbxStyle.SelectedItem.ToString() == "精确日期")
            {
                this.panel1.Visible = true;
                this.tooltxtCondition.Enabled = false;
            }
            else
            {
                this.panel1.Visible = false;
                this.tooltxtCondition.Enabled = true;
 
            }
            if (this.toolcbxStyle.SelectedItem.ToString() == "最近半年" || this.toolcbxStyle.SelectedItem.ToString() == "最近一年")
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
        /// 初始化资产归还表
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
            this.initReturnInfo(); // 加载资产归还表
        }

        private void toolbtnSeach_Click(object sender, EventArgs e)
        {
            
            //按资产编号来过滤资产领用表
            if (toolcbxStyle.Text == "资产编号")
            {
                GetInfoByEqno();
                return;
   
            }
            //根据资产领用人工号来过滤资产领用表
            if (toolcbxStyle.Text == "领用人工号")
            {
                GetInfoByBorrower();
                return;
 
            }
            //过滤最近半年的资产归还记录
            if (toolcbxStyle.Text == "最近半年")
            {
                GetInfoLast6Month();
                return;
            }
            //过滤最近1年的资产归还记录
            if (toolcbxStyle.Text == "最近一年")
            {
                GetInfoLastYear();
                return;
            }
            //过滤用户指定的年，月范围内的记录
            if (toolcbxStyle.Text == "精确日期")
            {
                GetInfoYearMonth();
                return;
 
            }
        }
        /// <summary>
        /// 按资产编号查询(精确)
        /// </summary>
        private void GetInfoByEqno()
        {
            if (this.tooltxtCondition.Text.Trim() == "")
            {
                this.tooltxtCondition.Focus();
                untCommon.InfoMsg("请输入所要查询的资产编号。");
                return;

            }

            DataTable dt = ReturnMgr.GetInfoByEqno(this.tooltxtCondition.Text);
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    untCommon.InfoMsg("没有您所要查询的资产信息。");
                }
                else
                {
                    this.dbgReturnInfo.DataSource = dt;
                }
            }
        }
        /// <summary>
        /// 跟据领用人编号查询（精确查询）
        /// </summary>
        private void GetInfoByBorrower()
        {
            if (this.tooltxtCondition.Text.Trim() == "")
            {
                this.tooltxtCondition.Focus();
                untCommon.InfoMsg("请输入所要查询的领用人工号。");
                return;

            }
            DataTable dt = ReturnMgr.GetInfoByBorrower(int.Parse(this.tooltxtCondition.Text));
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    untCommon.InfoMsg("没有您所要查询的资产信息。");
                }
                else
                {
                    this.dbgReturnInfo.DataSource = dt;
                }
            }
 
        }

        private void tooltxtCondition_TextChanged(object sender, EventArgs e)
        {
            if (toolcbxStyle.Text == "资产编号")
            {
                GetInfo2();
                return;

            }

            if (toolcbxStyle.Text == "领用人工号")
            {
                GetInfoByBorrower2();
                return;

            }
            

           

        }
        /// <summary>
        /// 跟据资产编号查询（模糊查询）
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
        /// 根据领用人编号查询（模糊查询）
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
        /// 查询最近半年内的资产归还记录
        /// </summary>
        private void GetInfoLast6Month()
        {
            DataTable dt = ReturnMgr.getInfoLast6Month();
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    untCommon.InfoMsg("没有您所要查询的资产信息。");
                }
                else
                {
                    this.dbgReturnInfo.DataSource = dt;
                }
            }
 
        }
        /// <summary>
        /// 查询最近1年内的资产归还记录
        /// </summary>
        private void GetInfoLastYear()
        {
            DataTable dt = ReturnMgr.getInfoLastYear();
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    untCommon.InfoMsg("没有您所要查询的资产信息。");
                }
                else
                {
                    this.dbgReturnInfo.DataSource = dt;
                }
            }

        }
        /// <summary>
        /// 查询指定的年，月内的资产归还记录
        /// </summary>
        private void GetInfoYearMonth()
        {
            if (this.txtYear.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入所要查询记录的年。");
                return;
            }
            if (this.cbxMonth.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入所要查询记录的月。");
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
                        untCommon.InfoMsg("没有您所要查询的资产信息。");
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
                untCommon.ErrorMsg("输入错误，年和月请输入数字。");
            }
            
           
        }
        /// <summary>
        /// 将查询出的结果导出为Exel表格
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