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

        //添加标志位，新增为true，修改为false
        private bool isAdd = true;

        //初始化界面
        private void frmMaintainer_Load(object sender, EventArgs e)
        {
            initDgv();
            this.btnSave.Enabled = false;
        }

        //选择界面的响应事件
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
                this.txtId.Text = this.dgvMaintainer.SelectedRows[0].Cells["编号"].Value.ToString();
                this.txtName.Text = this.dgvMaintainer.SelectedRows[0].Cells["名称"].Value.ToString();
                this.txtAddress.Text = this.dgvMaintainer.SelectedRows[0].Cells["地址"].Value.ToString();
                this.txtContracts.Text = this.dgvMaintainer.SelectedRows[0].Cells["联系人"].Value.ToString();
                this.txtTel.Text = this.dgvMaintainer.SelectedRows[0].Cells["联系电话"].Value.ToString();
            }
        }

        //初始化datagridview
        private void initDgv()
        {
            this.dgvMaintainer.DataSource = MaintainerMgr.GetAll();
        }

        //清空新增界面
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
                        untCommon.InfoMsg("增加成功");
                        clearNew();
                        initDgv();
                    }
                    else
                        untCommon.InfoMsg("增加失败");
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
                        untCommon.InfoMsg("修改成功");
                        initDgv();
                    }
                    else
                        untCommon.InfoMsg("修改失败");
                }
            }
        }


        //判断新增界面输入是否合法
        private bool newInput()
        {
            if (this.txtNewName.Text.Trim() == "")
            {
                untCommon.ErrorMsg("请填写维修商名称");
                return false;
            }
            if (this.txtNewAddress.Text.Trim() == "")
            {
                untCommon.ErrorMsg("请填写维修商地址");
                return false;
            }
            if (this.txtNewContracts.Text.Trim() == "")
            {
                untCommon.ErrorMsg("请填写维修商联系人");
                return false;
            }
            if (this.txtNewTel.Text.Trim() == "")
            {
                untCommon.ErrorMsg("请填写维修商联系电话");
                return false;
            }
            return true;
        }


        //判断修改界面输入是否合法
        private bool updateInput()
        {
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.ErrorMsg("请填写维修商名称");
                return false;
            }
            if (this.txtAddress.Text.Trim() == "")
            {
                untCommon.ErrorMsg("请填写维修商地址");
                return false;
            }
            if (this.txtContracts.Text.Trim() == "")
            {
                untCommon.ErrorMsg("请填写维修商联系人");
                return false;
            }
            if (this.txtTel.Text.Trim() == "")
            {
                untCommon.ErrorMsg("请填写维修商联系电话");
                return false;
            }
            return true;
        }

        //根据选中的查询类型为
        private void toolcbxSearchtype_SelectedIndexChanged(object sender,EventArgs e)
        {
            this.tooltxtContaint.Text = "";
        }

        private void tooltxtContaint_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (this.toolcbxSearchtype.Text == "编号")
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
            if (untCommon.QuestionMsg("确定要删除" + this.dgvMaintainer.SelectedRows[0].Cells["名称"].Value.ToString() + "吗？"))
            {
                if(MaintainerMgr.Del(int.Parse(this.dgvMaintainer.SelectedRows[0].Cells["编号"].Value.ToString())))
                {
                    untCommon.InfoMsg("删除成功");
                    initDgv();
                }
                else
                    untCommon.InfoMsg("删除失败");
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