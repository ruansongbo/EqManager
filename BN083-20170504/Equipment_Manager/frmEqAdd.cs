using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DataBusiness;
using DataEntity;

namespace Equipment_Manager
{
    public partial class frmEqAdd : Form
    {
        public frmEqAdd()
        {
            InitializeComponent();
        }
        public string Booker
        {
            set
            {
                txtBooker.Text = value;
            }
            get
            {
                return this.txtBooker.Text;
            }
           
        }

        string PhotoFilePath = "";
        private void frmEqAdd_Load(object sender, EventArgs e)
        {
            this.InitAddType();//加载资产增长方式

            this.InitType();//加载资产的类别

            this.InitName();//加载资产名称列表

            this.InitKeepPlace();//加载存放地点列表

            this.InitUnit();//加载计量单位列表

            this.InitKeeper();//加载保管人员列表

            this.SetEqNo(); //加载资产资产编号

            //初始化资产相片
            //picPhoto.Image = Image.FromFile(Application.StartupPath + "\\" + "Images\\no_image_available_large.gif");
            picPhoto.Image = imageList1.Images[0];


        }
        /// <summary>
        /// 初始化增长方式列表
        /// </summary>
        private void InitAddType()
        {
            DataTable dt = AddTypeMgr.GetAllType();
            if (dt != null)
            {
                cbxAddType.DataSource = dt;
                cbxAddType.DisplayMember = dt.Columns[1].ToString();
            }
        }
        /// <summary>
        /// 初始化资产类型
        /// </summary>
        private void InitType()
        {
            DataTable dt = EqTypeMgr.GetAllType();
            if (dt != null)
            {
                cbxType.DataSource = dt;
                cbxType.DisplayMember = dt.Columns[1].ToString();
            }
        }
        /// <summary>
        /// 初始化资产名称
        /// </summary>
        private void InitName()
        {
            DataTable dt = EqNameMgr.GetAllEqname();
            if (dt != null)
            {
                cbxEqName.DataSource = dt;
                cbxEqName.DisplayMember = dt.Columns[1].ToString();
            }
        }
        /// <summary>
        /// 初始化计量单位列表
        /// </summary>
        private void InitUnit()
        {
            DataTable dt = UnitMgr.GetAll();
            if (dt != null)
            {
                cbxUnit.DataSource = dt;
                cbxUnit.DisplayMember = dt.Columns[1].ToString();
                cbxUnit.ValueMember = dt.Columns[0].ToString();
            }
        }
        /// <summary>
        /// 初始化存地点列表
        /// </summary>
        private void InitKeepPlace()
        {
            DataTable dt = KeepPlaceMgr.GetAllPlace();
            if (dt != null)
            {
                cbxKeepPlace.DataSource = dt;
                cbxKeepPlace.DisplayMember = dt.Columns[1].ToString();
                cbxKeepPlace.ValueMember = dt.Columns[0].ToString();
            }
        }
        /// <summary>
        /// 初始化保管人员列表
        /// </summary>
        private void InitKeeper()
        {
            DataTable dt = KeeperMgr.GetAll();
            if (dt != null)
            {
                cbxKeeper.DataSource = dt;
                cbxKeeper.DisplayMember = dt.Columns[1].ToString();
                cbxKeeper.ValueMember = dt.Columns[0].ToString();
            }
        }
        /// <summary>
        /// 自动产生资产编号
        /// </summary>
        private void SetEqNo()
        {
            string No=EpMgr.GetLastEqNo();
            string yy = DateTime.Now.Year.ToString().Substring(2);
            if (No != "")
            {
                //如果从数据库中查到有值，就才分字符串后自加1
                string eqNo = (int.Parse(No.Substring(7))+ 1).ToString();
                lblEqNo.Text =yy+DateTime.Now.ToString("MMdd")+"-"+eqNo;
                
            }
            else
            {
                //取当前时间的月，年，和数字拼成编号
                string eqno=yy+DateTime.Now.ToString("MMdd")+"-"+"1000";
                lblEqNo.Text = eqno;
            }
           
        }

        /// <summary>
        /// 添加资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.checkInput())
            {


                Equipment eq = new Equipment();
                eq.Keeper = int.Parse(this.cbxKeeper.SelectedValue.ToString());
                eq.KeepPlace = this.cbxKeepPlace.Text;
                eq.Lable = txtLable.Text;
                eq.Maker = this.txtMaker.Text;
                eq.Count = int.Parse(this.nudNum.Value.ToString());
                eq.Booker = this.Booker;
                eq.BookDate = dtpBookDate.Value.ToShortDateString();
                eq.AddType = this.cbxAddType.Text;
                eq.Model = this.txtModle.Text;

                eq.Plus = this.txtPluse.Text;
                eq.Unit = this.cbxUnit.Text;

                eq.Birthday = this.dtpBirth.Value.ToShortDateString();
                eq.Name = this.cbxEqName.Text;
                eq.EqNo = this.lblEqNo.Text;
                eq.Type = this.cbxType.Text;

                if (PhotoFilePath == "")
                {
                    PhotoFilePath = Application.StartupPath + @"\defaultImage\no_image_available_large.gif"; ;
                }
                eq.Photo = PhotoFilePath;
               
                try
                {

                    eq.Price = double.Parse(this.txtPrice.Text);
                }
                catch (FormatException)
                {
                    untCommon.ErrorMsg("单价请输入数字。");
                    return;
                     
                }


                try
                {
                    eq.UseTime = int.Parse(this.txtUsetime.Text);
                }
                catch (FormatException)
                {
                    untCommon.ErrorMsg("预期寿命请输入数字。");
                    return;
                    
                }


                if (EpMgr.Add(eq))
                {
                    untCommon.InfoMsg("添加成功");
                    ClearInput();
                    this.PhotoFilePath = "";
                    picPhoto.Image = imageList1.Images[0];
                    this.SetEqNo();
                }
                else
                {
                    untCommon.InfoMsg("添加失败。");
                }
            }
            
        }
        /// <summary>
        /// 检查输入是否合法
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtPrice.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入资产的单价。");
                return false;
            }
            if (this.txtUsetime.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入预计寿命");
                return false;
            }
            if (int.Parse(this.txtUsetime.Text) <= 0)
            {
                untCommon.InfoMsg("单价请输入大于零的数字");
                return false;
            }

            
            if (int.Parse(this.txtUsetime.Text) <= 0)
            {
                untCommon.InfoMsg("预计寿命请输入大于零的数字");
                return false ;
            }
            return true;
            
            

        }

        private void ClearInput()
        {
            txtLable.Text = "";
            txtMaker.Text = "";
            txtModle.Text = "";
            txtPluse.Text = "";
            txtPrice.Text = "";
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// 选择相片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddphoto_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg|图片文件(*.gif)|*.gif|图片文件(*.bmp)|*.bmp|图片文件(*.png)|*.png";//“文本文件(*.txt)|*.txt|所有文件(*.*)|*.*”

            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PhotoFilePath = openFileDialog1.FileName;
                picPhoto.Image = Image.FromFile(PhotoFilePath);
            }
            else
            {

                PhotoFilePath = Application.StartupPath + @"\defaultImage\no_image_available_large.gif";
            }
        }

        

    }
    
}