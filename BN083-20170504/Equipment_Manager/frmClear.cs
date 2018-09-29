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
    public partial class frmClear : Form
    {
        public frmClear()
        {
            InitializeComponent();
        }
        
        private int _max;
        private string _user;
        private string _eqno;
        public string Eqno
        {
            set
            {
                this._eqno = value;
            }
        }
        public int Max
        {
            set
            {
                this._max = value;
            }
        }
        public string User
        {
            set
            {
                this._user = value;
            }
        }
        /// <summary>
        /// ��ʼ����Ҫ������ʲ���Ϣ
        /// </summary>
        private void load()
        {
            DataTable dt = EpMgr.GetOneMostInfo(this._eqno);
            if (dt != null)
            {
                this.lblEqNo.Text = dt.Rows[0][0].ToString();
                this.txttype.Text = dt.Rows[0][1].ToString();
                this.txtName.Text = dt.Rows[0][2].ToString();
                this.txtLable.Text = dt.Rows[0][3].ToString();
                this.txtModle.Text = dt.Rows[0][4].ToString();
                this.txtPluse.Text = dt.Rows[0][5].ToString();
                this.txtTotal.Text=dt.Rows[0][6].ToString();
                this.txtUnit.Text=dt.Rows[0][7].ToString();
                this.txtPrice.Text = dt.Rows[0][8].ToString();
                this.txtMaker.Text=dt.Rows[0][9].ToString();
                this.dtpBirth.Value = DateTime.Parse(dt.Rows[0][10].ToString());
                this.txtUsetime.Text=dt.Rows[0][14].ToString();
                this.txtClear.Text = this._user;
                this.txtMax.Text = this._max.ToString();
            }
            this.txtCount.Focus();


            
        }

        private void frmClear_Load(object sender, EventArgs e)
        {
            this.load();

            this.InitClearType();//��������ʽ

           
        }
        /// <summary>
        /// ��ʼ������ʽ
        /// </summary>
        private void InitClearType()
        {
            DataTable dt = ClearTypeMgr.GetAll();
            if (dt != null)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    cbxClearType.Items.Add(dt.Rows[i][1].ToString());
                    

                }
                cbxClearType.SelectedIndex = 1;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtCount.Text) > int.Parse(txtMax.Text))
                {
                    untCommon.InfoMsg("�����������ܴ��ڿ���������");
                    return;
                }
            }
            catch (FormatException )
            {
                untCommon.ErrorMsg("��������������������Ӣ������״̬����������");
                return;
 
            }
            Clear cl = new Clear();
            cl.Mark = this.txtRemark.Text;
            cl.EqNo = this.lblEqNo.Text;
            cl.ClearType = this.cbxClearType.Text;
            cl.Count = int.Parse(this.txtCount.Text);
            cl.Clearer = this.txtClear.Text;
            cl.ClearDate = this.dtpBookDate.Value.ToShortDateString();
            if (untCommon.QuestionMsg("�����ʲ������أ�ȷ��Ҫ������"))
            {
                if (ClearMgr.Clear(cl))
                {
                    untCommon.InfoMsg("����ɹ���");
                    this.DialogResult = DialogResult.OK;
                    
                }
                else
                {
                    untCommon.InfoMsg("����ʧ�ܡ�");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}