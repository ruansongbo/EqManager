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

        //新增标志，新增为true，修改为false
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
            untCommon.InfoMsg("请将需新增的保存地点填写至下方文本框，\n并点击保存");
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            this.txtId.Text = this.dgvKeepPlace.SelectedRows[0].Cells["编号"].Value.ToString();
            this.txtKeepPlace.Text = this.dgvKeepPlace.SelectedRows[0].Cells["保存地点"].Value.ToString();
            isAdd = false;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.dgvKeepPlace.SelectedRows[0].Cells["编号"].Value.ToString());
            if (untCommon.QuestionMsg("您确定要删除选中的保存地点吗？"))
            {
                if (KeepPlaceMgr.Del(id))
                {
                    untCommon.InfoMsg("删除成功");
                    fresh();
                }
                else
                {
                    untCommon.InfoMsg("删除失败");
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
                        untCommon.InfoMsg("增加成功");
                        fresh();
                        clear();
                    }

                    else
                        untCommon.InfoMsg("增加失败");
                }
                else
                {
                    id = int.Parse(this.txtId.Text);
                    if (KeepPlaceMgr.UpdatePlace(id, place))
                    {
                        untCommon.InfoMsg("修改成功");
                        clear();
                        fresh();
                        isAdd = true;
                    }
                    else
                        untCommon.InfoMsg("修改失败");
                }
            }
            else
            {
                untCommon.InfoMsg("请在上方文本框内填写保存地点的名称");
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