using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;
using System.Text.RegularExpressions;
using ZXing.QrCode;

namespace Equipment_Manager
{
    public partial class frmBarCode : Form
    {
        public frmBarCode()
        {
            InitializeComponent();
        }

        private DocementBase _docement;
        


        public void getCode(string code) 
        {
            txtMsg.Text = code;
        }

         
 
        //生成条形码
        private void button1_Click(object sender,EventArgs e)
        {
 
            CreateBarCode(pictureBox1,txtMsg.Text);
          
        }
        //生成二维码
        private void button2_Click(object sender,EventArgs e)
        {
            CreateQuickMark(pictureBox1, txtMsg.Text);
        }
 
        private void Form1_Load(object sender,EventArgs e)
        {
            txtMsg.Text = System.DateTime.Now.ToString("yyyyMMddhhmmss").Substring(0,12);
        }
        //解码
        private void button4_Click(object sender,EventArgs e)
        {
            if(pictureBox1.Image ==null)
            {
                MessageBox.Show("请录入图像后再进行解码!");
                return;
            }
            BarcodeReader reader =new BarcodeReader(); 
            Result result = reader.Decode((Bitmap)pictureBox1.Image);
            MessageBox.Show(result.Text);
        }
 
        //打印
        private void button3_Click(object sender,EventArgs e)
        {
          
            if(pictureBox1.Image ==null)
            {
                MessageBox.Show("You Must Load an Image first!");
                return;
            }
            else
            {
                _docement=new imageDocument(pictureBox1.Image);
            }
          _docement.showPrintPreviewDialog();
        }



        ///<summary>
        ///生成条形码
        ///</summary>
        ///<paramname="pictureBox1"></param>
        ///<paramname="Contents"></param>
        public void CreateBarCode(PictureBox pictureBox1, string Contents)
        {
            Regex rg = new Regex("^[0-9]{12}$");
            if (!rg.IsMatch(Contents))
            {
                MessageBox.Show("本例子采用EAN_13编码，需要输入12位数字");
                return;
            }

            EncodingOptions options = null;
            BarcodeWriter writer = null;
            options = new EncodingOptions
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.ITF;
            writer.Options = options;

            Bitmap bitmap = writer.Write(Contents);
            pictureBox1.Image = bitmap;
        }

        ///<summary>
        ///生成二维码
        ///</summary>
        ///<paramname="pictureBox1"></param>
        ///<paramname="Contents"></param>
        public void CreateQuickMark(PictureBox pictureBox1, string Contents)
        {
            if (Contents == string.Empty)
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }

            EncodingOptions options = null;
            BarcodeWriter writer = null;

            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = pictureBox1.Width,
                Height = pictureBox1.Height
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;


            Bitmap bitmap = writer.Write(Contents);
            pictureBox1.Image = bitmap;
        }

        ///<summary>
        ///解码
        ///</summary>
        ///<paramname="pictureBox1"></param>
        public void Decode(PictureBox pictureBox1)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox1.Image);
        }
    }
    
}
