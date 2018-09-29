using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Equipment_Manager
{
    public partial class frmOneEqInfo : Form
    {
        public frmOneEqInfo()
        {
            InitializeComponent();
        }
        public ArrayList info = new ArrayList();
        public ArrayList borrow = new ArrayList();

        private void LoadEqInfo()
        {
           //eqno,type,name,label,price,birthday,model,plus,keepplace,keeper,maker
            txtNO.Text=info[0].ToString();
            txtType.Text = info[1].ToString();
            txtName.Text = info[2].ToString();
            txtLable.Text = info[3].ToString();
            txtPrice.Text = info[4].ToString();
            txtBirth.Text = info[5].ToString();
            txtModle.Text = info[6].ToString();
            txtPluse.Text = info[7].ToString();
            txtKeepPlace.Text = info[8].ToString();
            txtKeeper.Text = info[9].ToString();
            txtMaker.Text = info[10].ToString();
        }
        private void loadBorrowInfo()
        {
            //eqno,count,depart,borrwer,date
            txtCount.Text = borrow[0].ToString();
            txtDepart.Text = borrow[1].ToString();
            txtBorrower.Text = borrow[2].ToString();
            txtBoorowDate.Text = borrow[3].ToString();
        }

        private void frmOneEqInfo_Load(object sender, EventArgs e)
        {
            this.LoadEqInfo();
            this.loadBorrowInfo();
            this.btnClose.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}