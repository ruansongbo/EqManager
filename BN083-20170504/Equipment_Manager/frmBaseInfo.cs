using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmBaseInfo : Form
    {
        public frmBaseInfo()
        {
            InitializeComponent();
        }

        

        private void btnName_Click(object sender, EventArgs e)
        {
            lstInfo.DataSource = null;
            lblMessge.Text = btnName.Text;
            DataTable dt = EqNameMgr.GetAllEqname();
            lstInfo.DataSource = dt;
            lstInfo.DisplayMember = dt.Columns[1].ToString(); ;
            lstInfo.ValueMember = dt.Columns[0].ToString();
           
            
        }
        private void btnKeepPlace_Click(object sender, EventArgs e)
        {
            lstInfo.DataSource = null;
            lblMessge.Text = btnKeepPlace.Text;
            DataTable dt = KeepPlaceMgr.GetAllPlace();
            lstInfo.DataSource = dt;
            lstInfo.DisplayMember = dt.Columns[1].ToString(); ;
            lstInfo.ValueMember = dt.Columns[0].ToString();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            lstInfo.DataSource = null;
            lblMessge.Text = btnAddType.Text;
            DataTable dt=AddTypeMgr.GetAllType();
            lstInfo.DataSource = dt;
            lstInfo.DisplayMember = dt.Columns[1].ToString(); ;
            lstInfo.ValueMember = dt.Columns[0].ToString();
        }
        private void btnTyp_Click(object sender, EventArgs e)
        {
            lstInfo.DataSource = null;
            lblMessge.Text = btnTyp.Text;
            DataTable dt = EqTypeMgr.GetAllType();
            lstInfo.DataSource = dt;
            lstInfo.DisplayMember = dt.Columns[1].ToString(); ;
            lstInfo.ValueMember = dt.Columns[0].ToString();

        }
        private void btnClearType_Click(object sender, EventArgs e)
        {
            lstInfo.DataSource = null;
            lblMessge.Text = btnClearType.Text;
            DataTable dt = ClearTypeMgr.GetAll();
            lstInfo.DataSource = dt;
            lstInfo.DisplayMember = dt.Columns[1].ToString(); ;
            lstInfo.ValueMember = dt.Columns[0].ToString();
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            lstInfo.DataSource = null;
            lblMessge.Text = btnUnit.Text;
            DataTable dt = UnitMgr.GetAll();
            lstInfo.DataSource = dt;
            lstInfo.DisplayMember = dt.Columns[1].ToString(); ;
            lstInfo.ValueMember = dt.Columns[0].ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lblMessge.Text == "")
            {
                untCommon.InfoMsg("��ѡ���������������");
                return;
            }
           
            btnAdd.Enabled = false;
            txtInput.Enabled = true; 
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnDel.Enabled = false;
            txtInput.Focus();
            txtInput.Text = "�������¼��������";
            txtInput.SelectAll();

        }
        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtInput.Text.Trim() == "")
            {
                untCommon.InfoMsg("������ӿ��࣬����д��Ҫ��ӵ����ݡ�");
                return;

            }
            if (this.txtInput.Text == "�������¼��������")
            {
                untCommon.InfoMsg("������Ϸ�������");
                return;
            }
            switch (this.lblMessge.Text)
            {
                case "������ʽ":  //���������ʽ
                    if (AddTypeMgr.Add(this.txtInput.Text))
                    {
                        btnAddType_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;

                    }
                    else
                    {
                        untCommon.InfoMsg("���ʧ��");
                    }
                    break;
                case "�ʲ�����": ////����ʲ�����
                    if (EqNameMgr.AddName(this.txtInput.Text))
                    {
                        btnName_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;
                    }
                    else
                    {
                        untCommon.InfoMsg("���ʧ��");
                    }
                    break;
                case "���ܵص�"://��ӱ��ܵص�
                    if (KeepPlaceMgr.AddPlace(this.txtInput.Text))
                    {
                        btnKeepPlace_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;
                    }
                    else
                    {
                        untCommon.InfoMsg("���ʧ��");
                    }
                    break;
                case "������λ": //��Ӽ�����λ
                    if (UnitMgr.Add(this.txtInput.Text))
                    {
                        btnUnit_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;
                    }
                    else
                    {
                        untCommon.InfoMsg("���ʧ��");
                    }
                    break;
                case "����ʽ"://�������ʽ
                    if (ClearTypeMgr.Add(this.txtInput.Text))
                    {
                        btnClearType_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;
                    }
                    else
                    {
                        untCommon.InfoMsg("���ʧ��");
                    }
                    break;
                case "�ʲ����":  //���������ʽ
                    if (EqTypeMgr.AddType(this.txtInput.Text))
                    {
                        btnTyp_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;

                    }
                    else
                    {
                        untCommon.InfoMsg("���ʧ��");
                    }
                    break;
            }
            
    
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            txtInput.Text = "";
            txtInput.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnDel.Enabled = true;
        }
        /// <summary>
        /// ɾ��ѡ�е���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstInfo.SelectedIndex == -1)
            {
                untCommon.InfoMsg("��ѡ����Ҫɾ�����");
                return;
            }
            switch (this.lblMessge.Text)
            {
                case "������ʽ":  //ɾ��������ʽ
                    if (untCommon.QuestionMsg("ȷ��Ҫɾ��������"))
                    {
                        if (AddTypeMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnAddType_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("ɾ��ʧ��");
                        }
                    }
                    break;
                case "�ʲ�����": //ɾ���ʲ�����
                    if (untCommon.QuestionMsg("ȷ��Ҫɾ��������"))
                    {
                        if (EqNameMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnName_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("ɾ��ʧ��");
                        }
                    }
                    break;
                case "���ܵص�":  //ɾ�����ܵص�
                    if (untCommon.QuestionMsg("ȷ��Ҫɾ��������"))
                    {
                        if (KeepPlaceMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnKeepPlace_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("ɾ��ʧ��");
                        }
                    }
                    break;
                case "������λ":  //ɾ��������λ
                    if (untCommon.QuestionMsg("ȷ��Ҫɾ��������"))
                    {
                        if (UnitMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnUnit_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("ɾ��ʧ��");
                        }
                    }
                    break;
                case "����ʽ": //ɾ������ʽ
                    if (untCommon.QuestionMsg("ȷ��Ҫɾ��������"))
                    {
                        if (ClearTypeMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnClearType_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("ɾ��ʧ��");
                        }
                    }
                    break;
                case "�ʲ����":  //���������ʽ
                    if (untCommon.QuestionMsg("ȷ��Ҫɾ��������"))
                    {
                        if (EqTypeMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnTyp_Click(null, null);

                        }
                        else
                        {
                            untCommon.InfoMsg("ɾ��ʧ��");
                        }
                    }
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}