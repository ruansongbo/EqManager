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
                untCommon.InfoMsg("请选择添加项的资料类别");
                return;
            }
           
            btnAdd.Enabled = false;
            txtInput.Enabled = true; 
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnDel.Enabled = false;
            txtInput.Focus();
            txtInput.Text = "请输入新加项的内容";
            txtInput.SelectAll();

        }
        /// <summary>
        /// 保存添加项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtInput.Text.Trim() == "")
            {
                untCommon.InfoMsg("不能添加空相，请填写所要添加的内容。");
                return;

            }
            if (this.txtInput.Text == "请输入新加项的内容")
            {
                untCommon.InfoMsg("请输入合法的新项");
                return;
            }
            switch (this.lblMessge.Text)
            {
                case "增长方式":  //添加增长方式
                    if (AddTypeMgr.Add(this.txtInput.Text))
                    {
                        btnAddType_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;

                    }
                    else
                    {
                        untCommon.InfoMsg("添加失败");
                    }
                    break;
                case "资产名称": ////添加资产名称
                    if (EqNameMgr.AddName(this.txtInput.Text))
                    {
                        btnName_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;
                    }
                    else
                    {
                        untCommon.InfoMsg("添加失败");
                    }
                    break;
                case "保管地点"://添加保管地点
                    if (KeepPlaceMgr.AddPlace(this.txtInput.Text))
                    {
                        btnKeepPlace_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;
                    }
                    else
                    {
                        untCommon.InfoMsg("添加失败");
                    }
                    break;
                case "计量单位": //添加计量单位
                    if (UnitMgr.Add(this.txtInput.Text))
                    {
                        btnUnit_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;
                    }
                    else
                    {
                        untCommon.InfoMsg("添加失败");
                    }
                    break;
                case "清理方式"://添加清理方式
                    if (ClearTypeMgr.Add(this.txtInput.Text))
                    {
                        btnClearType_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;
                    }
                    else
                    {
                        untCommon.InfoMsg("添加失败");
                    }
                    break;
                case "资产类别":  //添加增长方式
                    if (EqTypeMgr.AddType(this.txtInput.Text))
                    {
                        btnTyp_Click(null, null);
                        txtInput.Text = "";
                        txtInput.Focus();
                        this.btnDel.Enabled = true;

                    }
                    else
                    {
                        untCommon.InfoMsg("添加失败");
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
        /// 删除选中的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstInfo.SelectedIndex == -1)
            {
                untCommon.InfoMsg("请选择所要删除的项。");
                return;
            }
            switch (this.lblMessge.Text)
            {
                case "增长方式":  //删除增长方式
                    if (untCommon.QuestionMsg("确定要删除该项吗"))
                    {
                        if (AddTypeMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnAddType_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("删除失败");
                        }
                    }
                    break;
                case "资产名称": //删除资产名称
                    if (untCommon.QuestionMsg("确定要删除该项吗"))
                    {
                        if (EqNameMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnName_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("删除失败");
                        }
                    }
                    break;
                case "保管地点":  //删除保管地点
                    if (untCommon.QuestionMsg("确定要删除该项吗"))
                    {
                        if (KeepPlaceMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnKeepPlace_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("删除失败");
                        }
                    }
                    break;
                case "计量单位":  //删除计量单位
                    if (untCommon.QuestionMsg("确定要删除该项吗"))
                    {
                        if (UnitMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnUnit_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("删除失败");
                        }
                    }
                    break;
                case "清理方式": //删除清理方式
                    if (untCommon.QuestionMsg("确定要删除该项吗"))
                    {
                        if (ClearTypeMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnClearType_Click(null, null);
                        }
                        else
                        {
                            untCommon.InfoMsg("删除失败");
                        }
                    }
                    break;
                case "资产类别":  //添加增长方式
                    if (untCommon.QuestionMsg("确定要删除该项吗"))
                    {
                        if (EqTypeMgr.Del(int.Parse(lstInfo.SelectedValue.ToString())))
                        {
                            btnTyp_Click(null, null);

                        }
                        else
                        {
                            untCommon.InfoMsg("删除失败");
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