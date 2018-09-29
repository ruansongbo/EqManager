using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Equipment_Manager.Reprter;

namespace Equipment_Manager.frmReporter
{
    public partial class frmReportBecomeOld : Form
    {
        public frmReportBecomeOld()
        {
            InitializeComponent();
        }
        public DataTable dtBecomeOld = new DataTable();

        private void frmReportBecomeOld_Load(object sender, EventArgs e)
        {
            ReportBecomeOld Old = new ReportBecomeOld();
            crystalReportViewer1.ReportSource = Old;
            if (dtBecomeOld != null)
            {
               
                Old.SummaryInfo.ReportTitle = "资产折旧统计表";
                Old.SetDataSource(dtBecomeOld);
            }
        }
    }
}