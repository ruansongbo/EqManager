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
            this.InitAddType();//�����ʲ�������ʽ

            this.InitType();//�����ʲ������

            this.InitName();//�����ʲ������б�

            this.InitKeepPlace();//���ش�ŵص��б�

            this.InitUnit();//���ؼ�����λ�б�

            this.InitKeeper();//���ر�����Ա�б�

            this.SetEqNo(); //�����ʲ��ʲ����

            //��ʼ���ʲ���Ƭ
            //picPhoto.Image = Image.FromFile(Application.StartupPath + "\\" + "Images\\no_image_available_large.gif");
            picPhoto.Image = imageList1.Images[0];


        }
        /// <summary>
        /// ��ʼ��������ʽ�б�
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
        /// ��ʼ���ʲ�����
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
        /// ��ʼ���ʲ�����
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
        /// ��ʼ��������λ�б�
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
        /// ��ʼ����ص��б�
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
        /// ��ʼ��������Ա�б�
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
        /// �Զ������ʲ����
        /// </summary>
        private void SetEqNo()
        {
            string No=EpMgr.GetLastEqNo();
            string yy = DateTime.Now.Year.ToString().Substring(2);
            if (No != "")
            {
                //��������ݿ��в鵽��ֵ���Ͳŷ��ַ������Լ�1
                string eqNo = (int.Parse(No.Substring(7))+ 1).ToString();
                lblEqNo.Text =yy+DateTime.Now.ToString("MMdd")+"-"+eqNo;
                
            }
            else
            {
                //ȡ��ǰʱ����£��꣬������ƴ�ɱ��
                string eqno=yy+DateTime.Now.ToString("MMdd")+"-"+"1000";
                lblEqNo.Text = eqno;
            }
           
        }

        /// <summary>
        /// ����ʲ�
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
                    untCommon.ErrorMsg("�������������֡�");
                    return;
                     
                }


                try
                {
                    eq.UseTime = int.Parse(this.txtUsetime.Text);
                }
                catch (FormatException)
                {
                    untCommon.ErrorMsg("Ԥ���������������֡�");
                    return;
                    
                }


                if (EpMgr.Add(eq))
                {
                    untCommon.InfoMsg("��ӳɹ�");
                    ClearInput();
                    this.PhotoFilePath = "";
                    picPhoto.Image = imageList1.Images[0];
                    this.SetEqNo();
                }
                else
                {
                    untCommon.InfoMsg("���ʧ�ܡ�");
                }
            }
            
        }
        /// <summary>
        /// ��������Ƿ�Ϸ�
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtPrice.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������ʲ��ĵ��ۡ�");
                return false;
            }
            if (this.txtUsetime.Text.Trim() == "")
            {
                untCommon.InfoMsg("������Ԥ������");
                return false;
            }
            if (int.Parse(this.txtUsetime.Text) <= 0)
            {
                untCommon.InfoMsg("��������������������");
                return false;
            }

            
            if (int.Parse(this.txtUsetime.Text) <= 0)
            {
                untCommon.InfoMsg("Ԥ����������������������");
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
        /// ѡ����Ƭ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddphoto_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "ͼƬ�ļ�(*.jpg)|*.jpg|ͼƬ�ļ�(*.gif)|*.gif|ͼƬ�ļ�(*.bmp)|*.bmp|ͼƬ�ļ�(*.png)|*.png";//���ı��ļ�(*.txt)|*.txt|�����ļ�(*.*)|*.*��

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