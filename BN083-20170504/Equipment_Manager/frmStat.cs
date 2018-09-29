using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using DataBusiness;
using Equipment_Manager.frmReporter;
using Equipment_Manager.Reprter;

namespace Equipment_Manager
{
    public partial class frmStat : Form
    {
        public frmStat()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        System.Data.DataTable dtBecomeOld = null;
        System.Data.DataTable dtUseing = null;
        private static bool _one  = false;
        private static bool _two = false;
        private static bool _three = false;

       
        
        
        /// <summary>
        /// 初始化资产折旧表
        /// </summary>
        private void InitBecomeOld()
        {
            new System.Data.DataTable();
            dtBecomeOld = EpMgr.BecomeOld();

           
            if (dtBecomeOld != null)
            {
                //便利所有的单元格，如果有负数，就将该单元格内的值变成零
                for (int row = 0; row < dtBecomeOld.Rows.Count; row++)//控制行的循环
                {
                    for (int column = 0; column < dtBecomeOld.Columns.Count; column++)//控制列的循环
                    {
                        if (dtBecomeOld.Rows[row][column].GetType() == typeof(decimal))
                        {
                            if (decimal.Parse(dtBecomeOld.Rows[row][column].ToString()) < 0 && dtBecomeOld.Rows[row][column] != null)
                            {
                                dtBecomeOld.Rows[row][column] = "0.0000";//将资产负的现总净值便为零
                            }
 
                        }

                        
                    }
                }
                this.dbgBecomeOld.DataSource = dtBecomeOld;
            }
        }

        private void frmSata_Load(object sender, EventArgs e)
        {
            
            
            this.InitBecomeOld();//加载资产折旧表
            
        }

        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            
            if (this.tbcStat.SelectedIndex == 0)
            {
                untCommon.ToExel(this.dbgBecomeOld);
                return;
 
            }
            if (this.tbcStat.SelectedIndex == 3)
            {
                untCommon.ToExel(this.dbgEqUseing);
                return;
            }

        }
        
        private void toolbtnPrint_Click(object sender, EventArgs e)
        {
            if (tbcStat.SelectedIndex == 0)
            {
                frmReportBecomeOld frmOld = new frmReportBecomeOld();
                frmOld.dtBecomeOld = this.dtBecomeOld;//5!1*a*s*p*x
                frmOld.ShowDialog();
                return;
            }
            if (tbcStat.SelectedIndex == 3)
            {
                frmReportEqUseing frmUseing = new frmReportEqUseing();
               frmUseing.dt = this.dtUseing;
                frmUseing.ShowDialog();
                return;
            }
            
        }
      
        /// <summary>
        /// 各类别资产的领用情况统计
        /// </summary>
        private void BindReprtByType()
        {
          
 
        }
        /// <summary>
        /// 加载其他选项卡的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcStat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置相关个空间的相关属性
            if (tbcStat.SelectedIndex == 0)
            {
                this.lblMessage.Visible = true;
                this.toolbtnPrint.Enabled = true;

                this.toolbtnExel.Enabled = true;

                return;
            }
            else
            {
                this.lblMessage.Visible = false;
            }
            //加载个部门领用资产统计
            if (tbcStat.SelectedIndex == 1)
            {

                this.toolbtnPrint.Enabled = false;
                this.toolbtnExel.Enabled = false;

                if (_one == false)
                {

                    this.panelProcess.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                    this.toolStrip1.Enabled = false;
                    try
                    {
                        this.backgroundWorker1.RunWorkerAsync();//加载个部门领用资产统计表
                        
                    }
                    catch (Exception)
                    {
 
                    }
                    
                }
                return;
            }
           //加载个类别资产领用统计
            if (tbcStat.SelectedIndex == 2)
            {
               
                    this.toolbtnPrint.Enabled = false;
                    this.toolbtnExel.Enabled = false;

                    if (_two == false)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.panel4.Visible = true;
                        this.toolStrip1.Enabled = false;
                        try
                        {
                            this.backgroundWorker2.RunWorkerAsync();//加载个类别资产领用统计表
                 
                        }
                        catch(Exception)
                        {
                            
         
                        }
                    }
                    return;
                
            }
           //加载资产利用率统计
            if (tbcStat.SelectedIndex == 3)
            {
                this.toolbtnPrint.Enabled = true;
                this.toolbtnExel.Enabled = true;
                this.Cursor = Cursors.Default;
                
                if (_three==false)
                {
                    this.GetEqUseing(); //加载每笔资产的利用率情况表
                    _three = true;

                }
                return;
            }
          
        }
        /// <summary>
        /// 统计出每笔资产的利用率
        /// </summary>
        private void GetEqUseing()
        {
            this.dtUseing = EpMgr.eqUing();
            if (dtUseing != null)
            {
                this.dbgEqUseing.DataSource = dtUseing;
            }
        }

       
        private void toolbtnClose_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void frmStat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _one = false;
            _two = false;
            _three = false;

        }
        ReportBorrowByDepart rptbydepart = null;
        
        /// <summary>
        /// 加载报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //加载个部门资产领用统计图
            if (this.tbcStat.SelectedIndex == 1)
            {
                DataTable dt = BoroowMgr.BorrowStat();
                if (dt != null)
                {

                    rptbydepart = new ReportBorrowByDepart();
                    rptbydepart.SetDataSource(dt);
                    return;


                }
            }
            
        }
        /// <summary>
        /// 加载各部门领用资产统计报表后设置相关控件的属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
                RptvwByDepart.ReportSource = rptbydepart;
                _one = true;
                this.toolStrip1.Enabled = true;
                this.Cursor = Cursors.Default;
                this.panelProcess.Visible = false;
                return;
                
            
            

        }
       
        ReportByType type = null;
        /// <summary>
        /// //加载个类资产领用情况统计图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            
            
                DataTable dt = BoroowMgr.TypeBorrowSatat();
                if (dt != null)
                {
                    type = new ReportByType();
                    type.SetDataSource(dt);
                }

        }
        /// <summary>
        /// 加载各类资产领用情况报表后设置相关控件的属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
                rpttvwBoorowbyType.ReportSource = type;
                _two = true;
                this.toolStrip1.Enabled = true;
                this.Cursor = Cursors.Default;

                this.panel4.Visible = false;
               

            

        }

       
            
 
       

    }
}