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
    public partial class frmMonitorAdd : Form
    {
        public frmMonitorAdd()
        {
            InitializeComponent();
        }




        private void btnOK_Click(object sender, EventArgs e)
        {




            Monitor mt = new Monitor();
            mt.MtNo = Convert.ToInt32(this.txtMtNo.Text);
            mt.Place = this.txtPlace.Text;
            mt.DoNo = Convert.ToInt32(this.txtDoNo.Text);
            mt.IP = this.txtIP.Text;
            mt.Status = this.txtStatus.Text;
            if (MonitorMgr.Add(mt))
            {
                untCommon.InfoMsg("OK");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                untCommon.InfoMsg("Fail");
            }



        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}