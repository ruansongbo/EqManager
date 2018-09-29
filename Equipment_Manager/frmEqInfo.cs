using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DataBusiness;
using System.Runtime.InteropServices;

namespace Equipment_Manager
{
    public partial class frmEqInfo : Form
    {
        public frmEqInfo()
        {
            InitializeComponent();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 2;
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();

        private string _eqno;
        public string Eqno
        {
            set
            {
                this._eqno = value;
            }
        }
  
        /// <summary>
        /// 移动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEqInfo_MouseMove(object sender, MouseEventArgs e)
        {
           
            //为当前的应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息，让系统误以为你在标题拦上按下鼠标
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
        public void GetInfo()
        {
            DataTable dt = EqMgr.GetOneBaseInfo(this._eqno);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.lblLabel.Text = dt.Rows[0][1].ToString();
                    this.lblPrice.Text = dt.Rows[0][2].ToString();
                    this.lblBirth.Text = dt.Rows[0][3].ToString();
                    this.lblModel.Text = dt.Rows[0][4].ToString();
                    this.lblPluse.Text = dt.Rows[0][5].ToString();//5%1%a%s%p%x
                    this.lblUseTime.Text = dt.Rows[0][6].ToString();
                    this.lblMaker.Text = dt.Rows[0][7].ToString();
                  //将查出来的相片放在图片框内
                    const int oleTypeStart = 20;
                    const int oleTypeLength = 12;
                    MemoryStream photoStream;
                 //  MessageBox.Show(dt.Rows[0][16])
                    if (!(dt.Rows[0][8] is DBNull))
                    {
                        byte[] imageBytes = (byte[])(dt.Rows[0][8]);

                        if (imageBytes == null || imageBytes.Length == 0)
                        {
                            return;
                        }
   
                        string type = System.Text.Encoding.ASCII.GetString(imageBytes, oleTypeStart, oleTypeLength);


                        photoStream = new MemoryStream(imageBytes, 0, imageBytes.Length);


                        this.pictureBox1.Image = Image.FromStream(photoStream);
                    }
                    else
                    {
                        this.pictureBox1.Image = imageList1.Images[0];

                    }
                }
            }
        }

        private void frmEqInfo_Load(object sender, EventArgs e)
        {
            this.GetInfo();
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}