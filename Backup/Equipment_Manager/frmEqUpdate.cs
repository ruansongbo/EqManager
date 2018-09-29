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

        //}
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

        private void frmEqUpdate_Load(object sender, EventArgs e)
        {
            this.InitAddType();//�����ʲ�������ʽ

            this.InitType();//�����ʲ������

            this.InitName();//�����ʲ������б�

            this.InitKeepPlace();//���ش�ŵص��б�

            this.InitUnit();//���ؼ�����λ�б�

            this.InitKeeper();//���ر�����Ա�б�
            if (this.Eqno != "")
            {
                this.load(); //������ʲ�����Ϣ������Ӧ�Ŀؼ���
            }
            else
            {
                this.btnOK.Enabled = false;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
                
            }
        }
        /// <summary>
        /// ���մ������洫�������ʲ���ţ�
        /// ��������ʲ�����Ϣ������Ӧ�Ŀؼ���
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
                        

                        //�����������Ƭ����ͼƬ����
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
                            this.picPhoto.Image = imageList1.Images[0];//���û��ͼƬ���ͽ�Ĭ��ͼƬ����ͼƬ����
 
                        }
                        

                    }
                }

           
        }


        /// <summary>
        /// �ʲ�����
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
                untCommon.ErrorMsg("�������������֡�");
                return;
            }
            if (this.txtPrice.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������ʲ��ĵ��ۡ�");
                return;
            }
            if (int.Parse(this.txtUsetime.Text) <= 0)
            {
                untCommon.InfoMsg("��������������������");
                return;
            }
            try
            {
                equ.UseTime = int.Parse(this.txtUsetime.Text);
            }
            catch (FormatException)
            {
                untCommon.ErrorMsg("Ԥ���������������֡�");
                return;
            }
            if (int.Parse(this.txtUsetime.Text) <= 0)
            {
                untCommon.InfoMsg("Ԥ����������������������");
                return;
            }
            if (this.txtUsetime.Text.Trim() == "")
            {
                untCommon.InfoMsg("������Ԥ������");
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
                untCommon.InfoMsg("�ʲ����³ɹ���");
                

            }
            else
            {
                untCommon.InfoMsg("�޸�ʧ�ܡ�");
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "ͼƬ�ļ�(*.jpg)|*.jpg|ͼƬ�ļ�(*.gif)|*.gif|ͼƬ�ļ�(*.bmp)|*.bmp|ͼƬ�ļ�(*.png)|*.png";//���ı��ļ�(*.txt)|*.txt|�����ļ�(*.*)|*.*��
            
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PhotoFilePath = openFileDialog1.FileName;
                picPhoto.Image = Image.FromFile(PhotoFilePath);
            }
            
        }

       
    }
}