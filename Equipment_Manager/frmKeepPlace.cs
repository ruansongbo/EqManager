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
    public partial class frmKeepPlace : Form
    {
        public frmKeepPlace()
        {
            InitializeComponent();
        }

        //������־������Ϊtrue���޸�Ϊfalse
        private bool isAdd = true;

        private void frmKeepPlace_Load(object sender,EventArgs e)
        {
            this.dgvKeepPlace.DataSource = KeepPlaceMgr.GetAllPlace();
        }

        private void toolFresh_Click(object sender, EventArgs e)
        {
            fresh();
        }

        private void fresh()
        {
            this.dgvKeepPlace.DataSource = KeepPlaceMgr.GetAllPlace();
        }

        private void clear()
        {
            this.txtId.Text = "";
            this.txtKeepPlace.Text = "";
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            untCommon.InfoMsg("�뽫�������ı���ص���д���·��ı���\n���������");
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            this.txtId.Text = this.dgvKeepPlace.SelectedRows[0].Cells["���"].Value.ToString();
            this.txtKeepPlace.Text = this.dgvKeepPlace.SelectedRows[0].Cells["����ص�"].Value.ToString();
            isAdd = false;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.dgvKeepPlace.SelectedRows[0].Cells["���"].Value.ToString());
            if (untCommon.QuestionMsg("��ȷ��Ҫɾ��ѡ�еı���ص���"))
            {
                if (KeepPlaceMgr.Del(id))
                {
                    untCommon.InfoMsg("ɾ���ɹ�");
                    fresh();
                }
                else
                {
                    untCommon.InfoMsg("ɾ��ʧ��");
                }
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            int id =0;
            string place = this.txtKeepPlace.Text;
            if (this.txtKeepPlace.Text.Trim() != "")
            {
                if (isAdd)
                {
                    if (KeepPlaceMgr.AddPlace(place))
                    { 
                        untCommon.InfoMsg("���ӳɹ�");
                        fresh();
                        clear();
                    }

                    else
                        untCommon.InfoMsg("����ʧ��");
                }
                else
                {
                    id = int.Parse(this.txtId.Text);
                    if (KeepPlaceMgr.UpdatePlace(id, place))
                    {
                        untCommon.InfoMsg("�޸ĳɹ�");
                        clear();
                        fresh();
                        isAdd = true;
                    }
                    else
                        untCommon.InfoMsg("�޸�ʧ��");
                }
            }
            else
            {
                untCommon.InfoMsg("�����Ϸ��ı�������д����ص������");
            }
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            clear();
            isAdd = true;
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}