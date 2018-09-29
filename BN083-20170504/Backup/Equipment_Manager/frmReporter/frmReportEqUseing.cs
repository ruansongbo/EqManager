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
    public partial class frmReportEqUseing : Form
    {
        public frmReportEqUseing()
        {
            InitializeComponent();
        }
        public DataTable dt = new DataTable();
        private void frmReportEqUseing_Load(object sender, EventArgs e)
        {
            ReporterEqUseing use = new ReporterEqUseing();
            crystalReportViewer1.ReportSource = use;
            if (dt != null)
            {

                use.SummaryInfo.ReportTitle = "资产归还统计表";
                use.SetDataSource(dt);
            }

        }
    }
}