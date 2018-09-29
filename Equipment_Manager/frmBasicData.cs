using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmBasicData : Form
    {
        public frmBasicData()
        {
            InitializeComponent();
        }

        //新增标志位，true为新增，false为修改
        private bool isAdd = true;
        //项目对应的表名
        private string table = "";
        private string id = "";
        private string discrip = "";

       

        private void frmBasicData_Load(object sender, EventArgs e)
        {
            this.tpMost.Text = table;
            this.txtId.Text= id;
            this.txtDiscrip.Text = discrip;
        }

        public bool IsAdd
        {
            get { return isAdd; }
            set { isAdd = value; }
        }

        public string Table
        {
            get { return table; }
            set { table = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Discrip
        {
            get { return discrip; }
            set { discrip = value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                if (this.txtDiscrip.Text.Trim() == "")
                    untCommon.ErrorMsg("请填写项目名");
                else
                    if (BasicMgr.AddBasic(BasicMgr.GetTableName(table), this.txtDiscrip.Text))
                    {
                        untCommon.InfoMsg("添加成功");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        untCommon.InfoMsg("添加失败");
            }
            else
            {
                if (this.txtDiscrip.Text.Trim() == "")
                    untCommon.ErrorMsg("请填写项目名");
                else
                    if (BasicMgr.UpdateBasic(BasicMgr.GetTableName(table),int.Parse(this.txtId.Text), this.txtDiscrip.Text))
                    {
                        untCommon.InfoMsg("修改成功");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        untCommon.InfoMsg("修改失败");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
