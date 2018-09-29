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
    public partial class frmMaintainer : Form
    {
        public frmMaintainer()
        {
            InitializeComponent();
        }

        //��ӱ�־λ������Ϊtrue���޸�Ϊfalse
        private bool isAdd = true;

        //��ʼ������
        private void frmMaintainer_Load(object sender, EventArgs e)
        {
            initDgv();
            this.btnSave.Enabled = false;
        }

        //ѡ��������Ӧ�¼�
        private void tabMaintainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMaintainer.SelectedIndex == 0)
            {
                this.btnSave.Enabled = false;
            }
            if (this.tabMaintainer.SelectedIndex == 1)
            {
                this.btnSave.Enabled = true;
                isAdd = true;
            }
            if (this.tabMaintainer.SelectedIndex == 2)
            {
                this.btnSave.Enabled = true;
                isAdd = false;
                this.txtId.Text = this.dgvMaintainer.SelectedRows[0].Cells["���"].Value.ToString();
                this.txtName.Text = this.dgvMaintainer.SelectedRows[0].Cells["����"].Value.ToString();
                this.txtAddress.Text = this.dgvMaintainer.SelectedRows[0].Cells["��ַ"].Value.ToString();
                this.txtContracts.Text = this.dgvMaintainer.SelectedRows[0].Cells["��ϵ��"].Value.ToString();
                this.txtTel.Text = this.dgvMaintainer.SelectedRows[0].Cells["��ϵ�绰"].Value.ToString();
            }
        }

        //��ʼ��datagridview
        private void initDgv()
        {
            this.dgvMaintainer.DataSource = MaintainerMgr.GetAll();
        }

        //�����������
        private void clearNew()
        {
            this.txtNewName.Text = "";
            this.txtNewAddress.Text = "";
            this.txtNewContracts.Text= "";
            this.txtNewTel.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                string newname = this.txtNewName.Text;
                string newaddress = this.txtNewAddress.Text;
                string newcontracts = this.txtNewContracts.Text;
                string newtel = this.txtNewTel.Text;
                if (newInput())
                {
                    if (MaintainerMgr.Add(newname, newaddress, newcontracts, newtel))
                    {
                        untCommon.InfoMsg("���ӳɹ�");
                        clearNew();
                        initDgv();
                    }
                    else
                        untCommon.InfoMsg("����ʧ��");
                }
            }
            else
            {
                int id = int.Parse(this.txtId.Text);
                string name = this.txtName.Text;
                string address = this.txtAddress.Text;
                string contracts = this.txtContracts.Text;
                string tel = this.txtTel.Text;
                if (updateInput())
                {
                    if(MaintainerMgr.Update(id,name,address,contracts,tel))
                    {
                        untCommon.InfoMsg("�޸ĳɹ�");
                        initDgv();
                    }
                    else
                        untCommon.InfoMsg("�޸�ʧ��");
                }
            }
        }


        //�ж��������������Ƿ�Ϸ�
        private bool newInput()
        {
            if (this.txtNewName.Text.Trim() == "")
            {
                untCommon.ErrorMsg("����дά��������");
                return false;
            }
            if (this.txtNewAddress.Text.Trim() == "")
            {
                untCommon.ErrorMsg("����дά���̵�ַ");
                return false;
            }
            if (this.txtNewContracts.Text.Trim() == "")
            {
                untCommon.ErrorMsg("����дά������ϵ��");
                return false;
            }
            if (this.txtNewTel.Text.Trim() == "")
            {
                untCommon.ErrorMsg("����дά������ϵ�绰");
                return false;
            }
            return true;
        }


        //�ж��޸Ľ��������Ƿ�Ϸ�
        private bool updateInput()
        {
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.ErrorMsg("����дά��������");
                return false;
            }
            if (this.txtAddress.Text.Trim() == "")
            {
                untCommon.ErrorMsg("����дά���̵�ַ");
                return false;
            }
            if (this.txtContracts.Text.Trim() == "")
            {
                untCommon.ErrorMsg("����дά������ϵ��");
                return false;
            }
            if (this.txtTel.Text.Trim() == "")
            {
                untCommon.ErrorMsg("����дά������ϵ�绰");
                return false;
            }
            return true;
        }

        //����ѡ�еĲ�ѯ����Ϊ
        private void toolcbxSearchtype_SelectedIndexChanged(object sender,EventArgs e)
        {
            this.tooltxtContaint.Text = "";
        }

        private void tooltxtContaint_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (this.toolcbxSearchtype.Text == "���")
            {
                char result = e.KeyChar;
                if (char.IsDigit(result) || result == 8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolMenuItem_update_Click(object sender, EventArgs e)
        {
            this.tabMaintainer.SelectedIndex = 2;
        }

        private void ToolMenuItem_del_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("ȷ��Ҫɾ��" + this.dgvMaintainer.SelectedRows[0].Cells["����"].Value.ToString() + "��"))
            {
                if(MaintainerMgr.Del(int.Parse(this.dgvMaintainer.SelectedRows[0].Cells["���"].Value.ToString())))
                {
                    untCommon.InfoMsg("ɾ���ɹ�");
                    initDgv();
                }
                else
                    untCommon.InfoMsg("ɾ��ʧ��");
            }
        }

        private void ToolMenuItem_Refresh_Click(object sender, EventArgs e)
        {
            initDgv();
        }

        private void ToolMenuItem_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolbtnAll_Click(object sender, EventArgs e)
        {
            initDgv();
        }

        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt;
            switch (this.toolcbxSearchtype.SelectedIndex)
            {

                case 0:
                    {
                        if (this.tooltxtContaint.Text.Trim() != "")
                        {
                            dt = MaintainerMgr.GetInfoById(int.Parse(this.tooltxtContaint.Text));
                            if (dt != null)
                                this.dgvMaintainer.DataSource = dt;
                        }
                        break;
                    }
                case 1:
                    {
                        if (this.tooltxtContaint.Text.Trim() != "")
                        {
                            dt = MaintainerMgr.GetInfoByName(this.tooltxtContaint.Text);
                            if (dt != null)
                                this.dgvMaintainer.DataSource = dt;
                        }
                        break;
                    }
                case 2:
                    {
                        if (this.tooltxtContaint.Text.Trim() != "")
                        {
                            dt = MaintainerMgr.GetInfoByAddress(this.tooltxtContaint.Text);
                            if (dt != null)
                                this.dgvMaintainer.DataSource = dt;
                        }
                        break;
                    }
                case 3:
                    {
                        if (this.tooltxtContaint.Text.Trim() != "")
                        {
                            dt = MaintainerMgr.GetInfoByContracts(this.tooltxtContaint.Text);
                            if (dt != null)
                                this.dgvMaintainer.DataSource = dt;
                        }
                        break;
                    }
                case 4:
                    {
                        if (this.tooltxtContaint.Text.Trim() != "")
                        {
                            dt = MaintainerMgr.GetInfoByTel(this.tooltxtContaint.Text);
                            if (dt != null)
                                this.dgvMaintainer.DataSource = dt;
                        }
                        break;
                    }
            }
        }
        







       
    }
}