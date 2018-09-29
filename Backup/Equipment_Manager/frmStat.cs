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
        /// ��ʼ���ʲ��۾ɱ�
        /// </summary>
        private void InitBecomeOld()
        {
            new System.Data.DataTable();
            dtBecomeOld = EpMgr.BecomeOld();

           
            if (dtBecomeOld != null)
            {
                //�������еĵ�Ԫ������и������ͽ��õ�Ԫ���ڵ�ֵ�����
                for (int row = 0; row < dtBecomeOld.Rows.Count; row++)//�����е�ѭ��
                {
                    for (int column = 0; column < dtBecomeOld.Columns.Count; column++)//�����е�ѭ��
                    {
                        if (dtBecomeOld.Rows[row][column].GetType() == typeof(decimal))
                        {
                            if (decimal.Parse(dtBecomeOld.Rows[row][column].ToString()) < 0 && dtBecomeOld.Rows[row][column] != null)
                            {
                                dtBecomeOld.Rows[row][column] = "0.0000";//���ʲ��������ܾ�ֵ��Ϊ��
                            }
 
                        }

                        
                    }
                }
                this.dbgBecomeOld.DataSource = dtBecomeOld;
            }
        }

        private void frmSata_Load(object sender, EventArgs e)
        {
            
            
            this.InitBecomeOld();//�����ʲ��۾ɱ�
            
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
        /// ������ʲ����������ͳ��
        /// </summary>
        private void BindReprtByType()
        {
          
 
        }
        /// <summary>
        /// ��������ѡ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcStat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //������ظ��ռ���������
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
            //���ظ����������ʲ�ͳ��
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
                        this.backgroundWorker1.RunWorkerAsync();//���ظ����������ʲ�ͳ�Ʊ�
                        
                    }
                    catch (Exception)
                    {
 
                    }
                    
                }
                return;
            }
           //���ظ�����ʲ�����ͳ��
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
                            this.backgroundWorker2.RunWorkerAsync();//���ظ�����ʲ�����ͳ�Ʊ�
                 
                        }
                        catch(Exception)
                        {
                            
         
                        }
                    }
                    return;
                
            }
           //�����ʲ�������ͳ��
            if (tbcStat.SelectedIndex == 3)
            {
                this.toolbtnPrint.Enabled = true;
                this.toolbtnExel.Enabled = true;
                this.Cursor = Cursors.Default;
                
                if (_three==false)
                {
                    this.GetEqUseing(); //����ÿ���ʲ��������������
                    _three = true;

                }
                return;
            }
          
        }
        /// <summary>
        /// ͳ�Ƴ�ÿ���ʲ���������
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
        /// ���ر���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //���ظ������ʲ�����ͳ��ͼ
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
        /// ���ظ����������ʲ�ͳ�Ʊ����������ؿؼ�������
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
        /// //���ظ����ʲ��������ͳ��ͼ
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
        /// ���ظ����ʲ�������������������ؿؼ�������
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