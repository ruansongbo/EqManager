using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Equipment_Manager
{
    public partial class frmFlash : Form
    {
        public frmFlash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.DialogResult = DialogResult.OK;
        }

        private void frmflash_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



    }
}