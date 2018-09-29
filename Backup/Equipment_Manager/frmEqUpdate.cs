using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DataBusiness;
using DataEntity;

namespace Equipment_Manager
{
    public partial class frmEqUpdate : Form
    {
        public frmEqUpdate()
        {
            InitializeComponent();
        }
        private string _keeper;
        public string Eqno;
        string PhotoFilePath = "";
        public string Keeper
        {
            set
            {
                this._keeper = value;
            }

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

        //}
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

        private void frmEqUpdate_Load(object sender, EventArgs e)
        {
            this.InitAddType();//加载资产增长方式

            this.InitType();//加载资产的类别

            this.InitName();//加载资产名称列表

            this.InitKeepPlace();//加载存放地点列表

            this.InitUnit();//加载计量单位列表

            this.InitKeeper();//加载保管人员列表
            if (this.Eqno != "")
            {
                this.load(); //查出该资产的信息放在相应的控件中
            }
            else
            {
                this.btnOK.Enabled = false;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
                
            }
        }
        /// <summary>
        /// 接收从主界面传过来的资产编号，
        /// 并查出该资产的信息放在相应的控件中
        /// </summary>
        private void load()
        {
            DataTable dt = EpMgr.GetOneMostInfo(this.Eqno);
            
                if(dt!=null)
                {
                    if(dt.Rows.Count!=0)
                    {
                        this.lblEqNo.Text=dt.Rows[0][0].ToString();
                        this.cbxType.Text=dt.Rows[0][1].ToString();
                        this.cbxEqName.Text=dt.Rows[0][2].ToString();
                        this.txtLable.Text=dt.Rows[0][3].ToString();
                        this.txtModle.Text=dt.Rows[0][4].ToString();
                        this.txtPluse.Text=dt.Rows[0][5].ToString();
                        this.nudNum.Value=decimal.Parse(dt.Rows[0][6].ToString());
                        this.cbxUnit.Text=dt.Rows[0][7].ToString();
                        this.txtPrice.Text=dt.Rows[0][8].ToString();
                        this.txtMaker.Text=dt.Rows[0][9].ToString();
                        this.dtpBirth.Value=DateTime.Parse(dt.Rows[0][10].ToString());
                        this.cbxAddType.Text=dt.Rows[0][11].ToString();
                        this.cbxKeepPlace.Text=dt.Rows[0][12].ToString();
                        this.cbxKeeper.Text = this._keeper;
                        this.txtUsetime.Text=dt.Rows[0][14].ToString();
                        this.txtBooker.Text=dt.Rows[0][15].ToString();
                        this.dtpBookDate.Value=DateTime.Parse(dt.Rows[0][16].ToString());
                        

                        //将查出来的相片放在图片框内
                        const int oleTypeStart = 20;
                        const int oleTypeLength = 12;
                     //  MessageBox.Show(dt.Rows[0][16])
                        if (!(dt.Rows[0][17] is DBNull))
                        {
                            byte[] imageBytes = (byte[])(dt.Rows[0][17]);

                            if (imageBytes == null || imageBytes.Length == 0)
                            {
                                return;
                            }

                            MemoryStream photoStream;
                            string type = System.Text.Encoding.ASCII.GetString(imageBytes, oleTypeStart, oleTypeLength);


                            photoStream = new MemoryStream(imageBytes, 0, imageBytes.Length);


                            this.picPhoto.Image = Image.FromStream(photoStream);
                        }
                        else
                        {
                            this.picPhoto.Image = imageList1.Images[0];//如果没有图片，就将默认图片放在图片框内
 
                        }
                        

                    }
                }

           
        }


        /// <summary>
        /// 资产更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Equipment equ = new Equipment();
            try
            {

                equ.Price = double.Parse(this.txtPrice.Text);
            }
            catch (FormatException)
            {
                untCommon.ErrorMsg("单价请输入数字。");
                return;
            }
            if (this.txtPrice.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入资产的单价。");
                return;
            }
            if (int.Parse(this.txtUsetime.Text) <= 0)
            {
                untCommon.InfoMsg("单价请输入大于零的数字");
                return;
            }
            try
            {
                equ.UseTime = int.Parse(this.txtUsetime.Text);
            }
            catch (FormatException)
            {
                untCommon.ErrorMsg("预期寿命请输入数字。");
                return;
            }
            if (int.Parse(this.txtUsetime.Text) <= 0)
            {
                untCommon.InfoMsg("预计寿命请输入大于零的数字");
                return;
            }
            if (this.txtUsetime.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入预计寿命");
                return;
            }


            equ.Keeper = int.Parse(this.cbxKeeper.SelectedValue.ToString());
            equ.KeepPlace = this.cbxKeepPlace.Text;
            equ.Lable = txtLable.Text;
            equ.Maker = this.txtMaker.Text;
            equ.Count = int.Parse(this.nudNum.Value.ToString());
            equ.Booker = this.txtBooker.Text;
            equ.BookDate = this.dtpBookDate.Value.ToShortDateString();
            equ.AddType = this.cbxAddType.Text;
            equ.Model = this.txtModle.Text;
            equ.Plus = this.txtPluse.Text;
            equ.Unit = this.cbxUnit.Text;
            equ.UseTime = int.Parse(this.txtUsetime.Text);
            equ.Birthday = this.dtpBirth.Value.ToShortDateString();
            equ.Name = this.cbxEqName.Text;
            equ.EqNo = this.lblEqNo.Text;
            equ.Type = this.cbxType.Text;
            equ.Price = double.Parse(this.txtPrice.Text);

            equ.Photo = this.PhotoFilePath;
            

            if (EpMgr.Update(equ))
            {
                untCommon.InfoMsg("资产更新成功。");
                

            }
            else
            {
                untCommon.InfoMsg("修改失败。");
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg|图片文件(*.gif)|*.gif|图片文件(*.bmp)|*.bmp|图片文件(*.png)|*.png";//“文本文件(*.txt)|*.txt|所有文件(*.*)|*.*”
            
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PhotoFilePath = openFileDialog1.FileName;
                picPhoto.Image = Image.FromFile(PhotoFilePath);
            }
            
        }

       
    }
}