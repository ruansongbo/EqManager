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
    public partial class frmAudit : Form
    {
        private string _user;
        private string _loginid;
        private string _departId;
        private string _power;
        public frmAudit()
        {
            InitializeComponent();
        }

        public frmAudit(string _user, string _loginid, string _departId, string _power)
        {
            InitializeComponent();
            this._user = _user;
            this._loginid = _loginid;
            this._departId = _departId;
            this._power = _power;
        }

        private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.tabControl1.SelectedIndex)    //当前Tab页的样式
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshFore = Brushes.Black;
            }
            else    //其余Tab页的样式
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.Blue);
                bshFore = new SolidBrush(Color.Black);
            }
            //画样式
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        }

        /// <summary>
        /// 窗口载入
        /// </summary>
        private void frmAudit_Load(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            this.tabPage2.Parent = null;
            this.tabPage3.Parent = null;
            this.LoadAddAuditData();
            this.LoadClearAuditData();
            this.LoadUpdateAuditData();
        }
        #region 加载
        

        /// <summary>
        /// 加载新增信息
        /// </summary>
        private void LoadAddAuditData()
        {
            this.ToolStripMenuReturn.Visible = false;
            if (_power == "0" || _power == "1")
            {
                this.ToolStripMenuRevise.Visible = false;
                this.ToolStripMenuDelete.Visible = false;
                this.ToolStripMenuAgree.Visible = true;
                this.ToolStripMenuDisagree.Visible = true;
                this.ToolStripMenuReturn.Visible = false;

                this.modify_toolStripButton.Visible = false;
                this.delete_toolStripButton.Visible = false;
                this.accept_toolStripButton.Visible = true;
                this.refuse_toolStripButton.Visible = true;
                DataTable dat = EqMgr.getAuditList();
                int list_count = EqMgr.getAuditListCount();
                this.tabPage1.Text = string.Format("新增信息({0}条)", list_count);
                if (dat != null)
                {
                    //绑定数据
                    dgvAddAudit.DataSource = dat.DefaultView;
                    dgvAddAudit.ScrollBars = ScrollBars.Both;
                    this.dgvAddAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
            else
            {
                this.ToolStripMenuRevise.Visible = true;
                this.ToolStripMenuDelete.Visible = true;
                this.ToolStripMenuAgree.Visible = false;
                this.ToolStripMenuDisagree.Visible = false;
                this.ToolStripMenuReturn.Visible = false;

                this.modify_toolStripButton.Visible = true;
                this.delete_toolStripButton.Visible = true;
                this.accept_toolStripButton.Visible = false;
                this.refuse_toolStripButton.Visible = false;
                DataTable dat = EqMgr.getUnAuditList(_user);
                int list_count = EqMgr.getUnAuditListCount(_user);
                this.tabPage1.Text = string.Format("新增信息({0}条)", list_count);
                if (dat != null)
                {
                    //绑定数据
                    dgvAddAudit.DataSource = dat.DefaultView;
                    dgvAddAudit.ScrollBars = ScrollBars.Both;
                    this.dgvAddAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
        }
        /// <summary>
        /// 加载借用信息
        /// </summary>
        private void LoadBorrowAuditData()
        {
            if (_power == "0" || _power == "1")
            {
                this.tabPage2.Text = "借用信息";
                this.ToolStripMenuRevise.Visible = false;
                this.ToolStripMenuDelete.Visible = false;
                this.ToolStripMenuAgree.Visible = true;
                this.ToolStripMenuDisagree.Visible = true;
                this.ToolStripMenuReturn.Visible = true;

                this.modify_toolStripButton.Visible = false;
                this.delete_toolStripButton.Visible = false;
                this.accept_toolStripButton.Visible = true;
                this.refuse_toolStripButton.Visible = true;
                DataTable dat = BoroowMgr.getAuditList(_user);
                if (dat != null)
                {
                    //绑定数据
                    dgvBorrowAudit.DataSource = dat.DefaultView;
                    dgvBorrowAudit.ScrollBars = ScrollBars.Both;
                    this.dgvBorrowAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
            else
            {
                this.tabPage2.Text = "借用信息";
                this.ToolStripMenuRevise.Visible = true;
                this.ToolStripMenuDelete.Visible = true;
                this.ToolStripMenuAgree.Visible = false;
                this.ToolStripMenuDisagree.Visible = false;
                this.ToolStripMenuReturn.Visible = true;

                this.modify_toolStripButton.Visible = true;
                this.delete_toolStripButton.Visible = true;
                this.accept_toolStripButton.Visible = false;
                this.refuse_toolStripButton.Visible = false;
                DataTable Empdt = EmployeeMgr.GetAllName();
                DataTable dat = BoroowMgr.getUnAuditList(_user);
                if (dat != null)
                {
                    //绑定数据
                    dgvBorrowAudit.DataSource = dat.DefaultView;
                    dgvBorrowAudit.ScrollBars = ScrollBars.Both;
                    this.dgvBorrowAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
        }
        /// <summary>
        /// 加载维修信息
        /// </summary>
        private void LoadFixAuditData()
        {
            if (_power == "0" || _power == "1")
            {
                this.tabPage3.Text = "维修信息";
                this.ToolStripMenuRevise.Visible = false;
                this.ToolStripMenuDelete.Visible = false;
                this.ToolStripMenuAgree.Visible = true;
                this.ToolStripMenuDisagree.Visible = true;
                this.ToolStripMenuReturn.Visible = true;

                this.modify_toolStripButton.Visible = false;
                this.delete_toolStripButton.Visible = false;
                this.accept_toolStripButton.Visible = true;
                this.refuse_toolStripButton.Visible = true;
                DataTable dat = FixMgr.getAuditList(_user);
                if (dat != null)
                {
                    //绑定数据
                    dgvFixAudit.DataSource = dat.DefaultView;
                    dgvFixAudit.ScrollBars = ScrollBars.Both;
                    this.dgvFixAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
            else
            {
                this.tabPage3.Text = "维修信息";
                this.ToolStripMenuRevise.Visible = true;
                this.ToolStripMenuDelete.Visible = true;
                this.ToolStripMenuAgree.Visible = false;
                this.ToolStripMenuDisagree.Visible = false;
                this.ToolStripMenuReturn.Visible = true;

                this.modify_toolStripButton.Visible = true;
                this.delete_toolStripButton.Visible = true;
                this.accept_toolStripButton.Visible = false;
                this.refuse_toolStripButton.Visible = false;
                DataTable Empdt = EmployeeMgr.GetAllName();
                DataTable dat = FixMgr.getUnAuditList(_user);
                if (dat != null)
                {
                    //绑定数据
                    dgvFixAudit.DataSource = dat.DefaultView;
                    dgvFixAudit.ScrollBars = ScrollBars.Both;
                    this.dgvFixAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
        }
        /// <summary>
        /// 加载注销信息
        /// </summary>
        private void LoadClearAuditData()
        {
            if (_power == "0" || _power == "1")
            {
                this.ToolStripMenuRevise.Visible = false;
                this.ToolStripMenuDelete.Visible = false;
                this.ToolStripMenuAgree.Visible = true;
                this.ToolStripMenuDisagree.Visible = true;
                this.ToolStripMenuReturn.Visible = false;

                this.modify_toolStripButton.Visible = false;
                this.delete_toolStripButton.Visible = false;
                this.accept_toolStripButton.Visible = true;
                this.refuse_toolStripButton.Visible = true;
                DataTable dat = ClearMgr.getAuditList(_departId, _power);
                int list_count = ClearMgr.getAuditListCount();
                this.tabPage4.Text = string.Format("注销信息({0}条)", list_count);
                if (dat != null)
                {
                    //绑定数据
                    dgvClearAudit.DataSource = dat.DefaultView;
                    dgvClearAudit.ScrollBars = ScrollBars.Both;
                    this.dgvClearAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
            else
            {
                this.ToolStripMenuRevise.Visible = true;
                this.ToolStripMenuDelete.Visible = true;
                this.ToolStripMenuAgree.Visible = false;
                this.ToolStripMenuDisagree.Visible = false;
                this.ToolStripMenuReturn.Visible = false;

                this.modify_toolStripButton.Visible = true;
                this.delete_toolStripButton.Visible = true;
                this.accept_toolStripButton.Visible = false;
                this.refuse_toolStripButton.Visible = false;
                DataTable Empdt = EmployeeMgr.GetAllName();
                DataTable dat = ClearMgr.getUnAuditList(_user);
                int list_count = ClearMgr.getUnAuditListCount(_user);
                this.tabPage4.Text = string.Format("注销信息({0}条)", list_count);
                if (dat != null)
                {
                    //绑定数据
                    dgvClearAudit.DataSource = dat.DefaultView;
                    dgvClearAudit.ScrollBars = ScrollBars.Both;
                    this.dgvClearAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
        }
        /// <summary>
        /// 加载更新信息
        /// </summary>
        private void LoadUpdateAuditData()
        {
            if (_power == "0" || _power == "1")
            {
                this.ToolStripMenuRevise.Visible = false;
                this.ToolStripMenuDelete.Visible = false;
                this.ToolStripMenuAgree.Visible = true;
                this.ToolStripMenuDisagree.Visible = true;
                this.ToolStripMenuReturn.Visible = false;

                this.refuse_toolStripButton.Visible = false;
                this.delete_toolStripButton.Visible = false;
                this.accept_toolStripButton.Visible = true;
                this.refuse_toolStripButton.Visible = true;
                DataTable dat = EqMgr.getUpdateAuditList(_departId, _power);
                int list_count = EqMgr.getUpdateAuditListCount();
                this.tabPage5.Text = string.Format("更新信息({0}条)", list_count);
                if (dat != null)
                {
                    //绑定数据
                    dgvUpdateAudit.DataSource = dat.DefaultView;
                    dgvUpdateAudit.ScrollBars = ScrollBars.Both;
                    this.dgvUpdateAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
            else
            {
                this.ToolStripMenuRevise.Visible = true;
                this.ToolStripMenuDelete.Visible = true;
                this.ToolStripMenuAgree.Visible = false;
                this.ToolStripMenuDisagree.Visible = false;
                this.ToolStripMenuReturn.Visible = false;

                this.refuse_toolStripButton.Visible = true;
                this.delete_toolStripButton.Visible = true;
                this.accept_toolStripButton.Visible = false;
                this.refuse_toolStripButton.Visible = false;
                DataTable Empdt = EmployeeMgr.GetAllName();
                DataTable dat = EqMgr.getUpdateUnAuditList(this.name2ID(Empdt, _user, "name"));
                int list_count = EqMgr.getUpdateUnAuditListCount(this.name2ID(Empdt, _user, "name"));
                this.tabPage5.Text = string.Format("更新信息({0}条)", list_count);
                if (dat != null)
                {
                    //绑定数据
                    dgvUpdateAudit.DataSource = dat.DefaultView;
                    dgvUpdateAudit.ScrollBars = ScrollBars.Both;
                    this.dgvUpdateAudit.Columns[1].Frozen = true;//第二列前的列都被冻结
                }
            }
        }
        #endregion

        #region 右键操作

        private void enterAgreeItem()
        {
            int suc_count = 0;
            string out_str = "";
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < dgvAddAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvAddAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string state = dr.ItemArray[0].ToString();
                        switch (state)
                        {
                            case "新增待审核":
                                int tempCount = EqMgr.getTempAssetCount();
                                int allCount = EqMgr.getAllAssetCount();
                                int eqCount = EqMgr.getAllEqCount();
                                int assetCount = allCount - tempCount + 1;
                                string tempAsset = dr.ItemArray[1].ToString();
                                int count = Convert.ToInt32(tempAsset.Substring(tempAsset.Length - 3, 3));
                                int eq_count = 0;
                                for (int j = 1; j <= count; j++)
                                {
                                    string EqNo = "TE" + tempAsset.Substring(2, 20) + string.Format("{0:D3}", j);
                                    string newEqNo = DateTime.Now.Year.ToString() + string.Format("{0:D6}", eqCount + j);
                                    string newAssetNo = dr.ItemArray[8].ToString() + DateTime.Now.Year.ToString() + string.Format("{0:D4}", assetCount);
                                    if (!EqMgr.changeEqNo(EqNo, newEqNo, newAssetNo))
                                    {
                                        untCommon.InfoMsg("操作失败。");
                                        break;
                                    }
                                    else
                                        eq_count++;
                                }
                                if (eq_count == count)
                                    suc_count++;
                                else
                                    untCommon.InfoMsg("操作失败。");
                                break;
                            default:
                                untCommon.InfoMsg("记录状态错误。");
                                break;
                        }

                    }
                    if (suc_count == dgvAddAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvAddAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadAddAuditData();
                    break;
                case 3:
                    for (int i = 0; i < dgvBorrowAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvBorrowAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string state = dr.ItemArray[16].ToString();
                        string ID = dr.ItemArray[0].ToString();
                        string eqno = dr.ItemArray[1].ToString();
                        DataTable Empdt = EmployeeMgr.GetAllName();
                        switch (state)
                        {
                            case "借出待审核":
                                if (!BoroowMgr.agreeBAudit(ID, this.name2ID(Empdt, _user, "name")))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            case "归还待审核":
                                if (!BoroowMgr.agreeRAudit(ID, this.name2ID(Empdt, _user, "name")) || !EqMgr.ReturnEq(eqno))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("记录状态错误。");
                                break;
                        }

                    }
                    if (suc_count == dgvBorrowAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvBorrowAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadBorrowAuditData();
                    break;
                case 4:
                    for (int i = 0; i < dgvFixAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvFixAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string state = dr.ItemArray[16].ToString();
                        string ID = dr.ItemArray[0].ToString();
                        string eqno = dr.ItemArray[1].ToString();
                        DataTable Empdt = EmployeeMgr.GetAllName();
                        switch (state)
                        {
                            case "送修待审核":
                                if (!FixMgr.agreeMAudit(ID, this.name2ID(Empdt, _user, "name")))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            case "完成待审核":
                                if (!FixMgr.agreeRAudit(ID, this.name2ID(Empdt, _user, "name")) || !EqMgr.ReturnEq(eqno))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("记录状态错误。");
                                break;
                        }

                    }

                    if (suc_count == dgvFixAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvFixAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadFixAuditData();
                    break;
                case 1:
                    for (int i = 0; i < dgvClearAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvClearAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string state = dr.ItemArray[0].ToString();
                        string ID = dr.ItemArray[1].ToString();
                        DataTable Empdt = EmployeeMgr.GetAllName();
                        switch (state)
                        {
                            case "注销待审核":
                                if (!ClearMgr.agreeAudit(ID, this.name2ID(Empdt, _user, "name")))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("记录状态错误。");
                                break;
                        }

                    }
                    if (suc_count == dgvClearAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvClearAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadClearAuditData();
                    break;
                case 2:
                    for (int i = 0; i < dgvUpdateAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvUpdateAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string state = dr.ItemArray[0].ToString();
                        string ID = dr.ItemArray[1].ToString();
                        switch (state)
                        {
                            case "更新待审核":
                                if (!EqMgr.agreeUpdateAudit(ID))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("记录状态错误。");
                                break;
                        }

                    }
                    if (suc_count == dgvUpdateAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvUpdateAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadUpdateAuditData();
                    break;
            }
        }

        private void enterDisAgreeItem()
        {
            int suc_count = 0;
            string out_str = "";
            frmRemark Remark = new frmRemark();
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    if (Remark.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < dgvAddAudit.SelectedRows.Count; i++)
                        {
                            DataRow dr = (dgvAddAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                            string state = dr.ItemArray[0].ToString();
                            switch (state)
                            {
                                case "新增待审核":
                                    int tempCount = EqMgr.getTempAssetCount();
                                    int allCount = EqMgr.getAllAssetCount();
                                    int eqCount = EqMgr.getAllEqCount() + 1;
                                    int assetCount = allCount - tempCount + 1;
                                    string tempAsset = dr.ItemArray[1].ToString();
                                    int count = Convert.ToInt32(tempAsset.Substring(tempAsset.Length - 3, 3));
                                    int eq_count = 0;
                                    for (int j = 1; j <= count; j++)
                                    {
                                        string EqNo = "TE" + tempAsset.Substring(2, 20) + string.Format("{0:D3}", j);
                                        if (!EqMgr.failChangeEqNo(EqNo, Remark.TextBoxValue))
                                            untCommon.InfoMsg("修改失败。");
                                        else
                                            eq_count++;
                                    }
                                    if (eq_count == count)
                                        suc_count++;
                                    break;
                                default:
                                    untCommon.InfoMsg("记录状态错误。");
                                    break;
                            }

                        }
                        if (suc_count == dgvAddAudit.SelectedRows.Count)
                        {
                            out_str = string.Format("操作成功{0}条资产", suc_count);
                            untCommon.InfoMsg(out_str);
                        }
                        else
                        {
                            out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvAddAudit.SelectedRows.Count - suc_count);
                            untCommon.InfoMsg(out_str);
                        }
                        this.LoadAddAuditData();
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 3:
                    for (int i = 0; i < dgvBorrowAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvBorrowAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string state = dr.ItemArray[16].ToString();
                        string ID = dr.ItemArray[0].ToString();
                        DataTable Empdt = EmployeeMgr.GetAllName();
                        switch (state)
                        {
                            case "借出待审核":
                                if (!BoroowMgr.disagreeAudit(ID, this.name2ID(Empdt, _user, "name")))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            case "归还待审核":
                                untCommon.InfoMsg("无法拒绝归还资产。");
                                break;
                            default:
                                untCommon.InfoMsg("信息状态错误。");
                                break;
                        }

                    }
                    if (suc_count == dgvBorrowAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvBorrowAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadBorrowAuditData();
                    break;
                case 4:
                    for (int i = 0; i < dgvFixAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvFixAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string state = dr.ItemArray[16].ToString();
                        string ID = dr.ItemArray[0].ToString();
                        DataTable Empdt = EmployeeMgr.GetAllName();
                        switch (state)
                        {
                            case "送修待审核":
                                if (!FixMgr.disagreeAudit(ID, this.name2ID(Empdt, _user, "name")))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            case "归还待审核":
                                untCommon.InfoMsg("无法拒绝归还资产。");
                                break;
                            default:
                                untCommon.InfoMsg("记录状态错误。");
                                break;
                        }

                    }
                    if (suc_count == dgvFixAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvFixAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadFixAuditData();
                    break;
                case 1:
                    if (Remark.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < dgvClearAudit.SelectedRows.Count; i++)
                        {
                            DataRow dr = (dgvClearAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                            string state = dr.ItemArray[0].ToString();
                            string ID = dr.ItemArray[1].ToString();
                            DataTable Empdt = EmployeeMgr.GetAllName();
                            switch (state)
                            {
                                case "注销待审核":
                                    if (!ClearMgr.disagreeAudit(ID, this.name2ID(Empdt, _user, "name"), Remark.TextBoxValue))
                                    {
                                        untCommon.InfoMsg("操作失败。");
                                        break;
                                    }
                                    else
                                        suc_count++;
                                    break;
                                default:
                                    untCommon.InfoMsg("记录状态错误。");
                                    break;
                            }

                        }
                        if (suc_count == dgvClearAudit.SelectedRows.Count)
                        {
                            out_str = string.Format("操作成功{0}条资产", suc_count);
                            untCommon.InfoMsg(out_str);
                        }
                        else
                        {
                            out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvClearAudit.SelectedRows.Count - suc_count);
                            untCommon.InfoMsg(out_str);
                        }
                        this.LoadClearAuditData();
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 2:
                    if (Remark.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < dgvUpdateAudit.SelectedRows.Count; i++)
                        {
                            DataRow dr = (dgvUpdateAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                            string state = dr.ItemArray[0].ToString();
                            string ID = dr.ItemArray[1].ToString();
                            switch (state)
                            {
                                case "更新待审核":
                                    if (!EqMgr.disagreeUpdateAudit(ID, Remark.TextBoxValue))
                                    {
                                        untCommon.InfoMsg("操作失败。");
                                        break;
                                    }
                                    else
                                        suc_count++;
                                    break;
                                default:
                                    untCommon.InfoMsg("记录状态错误。");
                                    break;
                            }

                        }
                        if (suc_count == dgvUpdateAudit.SelectedRows.Count)
                        {
                            out_str = string.Format("操作成功{0}条资产", suc_count);
                            untCommon.InfoMsg(out_str);
                        }
                        else
                        {
                            out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvUpdateAudit.SelectedRows.Count - suc_count);
                            untCommon.InfoMsg(out_str);
                        }
                        this.LoadUpdateAuditData();
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }

        private void enterReviseItem()
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        DataRow dr = (dgvAddAudit.Rows[dgvAddAudit.CurrentRow.Index].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[1].ToString();
                        string state = dr.ItemArray[0].ToString();
                        switch (state)
                        {
                            case "新增审核未通过":
                                frmEqUpdate frupdate = new frmEqUpdate(this._user, ID, this._power, 3);
                                frupdate.ShowDialog();
                                break;
                            default:
                                untCommon.InfoMsg("无法修改该信息。");
                                break;
                        }
                        this.LoadAddAuditData();
                        break;
                    }
                case 3:
                    {
                        DataRow dr = (dgvBorrowAudit.Rows[dgvBorrowAudit.CurrentRow.Index].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[0].ToString();
                        string state = dr.ItemArray[16].ToString();
                        switch (state)
                        {
                            case "借出审核未通过":
                                frmBorrow boroow = new frmBorrow(ID);
                                boroow.User = this._user;
                                boroow.Power = this._power;
                                boroow.ShowDialog();
                                break;
                            default:
                                untCommon.InfoMsg("无法修改该信息。");
                                break;
                        }
                        this.LoadBorrowAuditData();
                        break;
                    }
                case 4:
                    {
                        DataRow dr = (dgvFixAudit.Rows[dgvFixAudit.CurrentRow.Index].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[0].ToString();
                        string state = dr.ItemArray[16].ToString();
                        switch (state)
                        {
                            case "送修审核未通过":
                                frmFix fix = new frmFix(ID);
                                fix.User = this._user;
                                fix.Power = this._power;
                                fix.ShowDialog();
                                break;
                            default:
                                untCommon.InfoMsg("无法修改该信息。");
                                break;
                        }
                        this.LoadFixAuditData();
                        break;
                    }
                case 1:
                    {
                        DataRow dr = (dgvClearAudit.Rows[dgvClearAudit.CurrentRow.Index].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[1].ToString();
                        string state = dr.ItemArray[0].ToString();
                        switch (state)
                        {
                            case "注销审核未通过":
                                frmClear clear = new frmClear(ID, false);
                                clear.User = this._user;
                                clear.ShowDialog();
                                break;
                            default:
                                untCommon.InfoMsg("无法修改该信息。");
                                break;
                        }
                        this.LoadClearAuditData();
                        break;
                    }
                case 2:
                    {
                        List<string> EqnoList = new List<string>();
                        List<string> assertList = new List<string>();
                        List<string> statusList = new List<string>();
                        string assert;
                        for (int i = 0; i < dgvUpdateAudit.SelectedRows.Count; i++)
                        {
                            DataRow dr = (dgvUpdateAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                            EqnoList.Add(dr.ItemArray[0].ToString());
                            assertList.Add(dr.ItemArray[2].ToString());
                            statusList.Add(dr.ItemArray[11].ToString());
                        }
                        assert = assertList[0];
                        bool flag = true;
                        foreach (string str in assertList)
                        {
                            if (!assert.Equals(str))
                                flag = false;
                        }
                        if (flag)
                        {
                            foreach (string str in statusList)
                            {
                                if (!str.Equals("更新审核未通过"))
                                    flag = false;
                            }
                            if (flag)
                            {
                                frmEqUpdate frupdate = new frmEqUpdate(this._user, EqnoList, this._power, 4);
                                if (frupdate.ShowDialog() == DialogResult.OK)
                                {
                                    this.LoadClearAuditData();
                                }
                            }
                            else
                                untCommon.InfoMsg("无法修改该信息。");
                        }
                        else
                            untCommon.InfoMsg("选中数据不能同时修改");
                        this.LoadUpdateAuditData();
                        break;
                    }
            }
        }

        private void enterDeleteItem()
        {
            int suc_count = 0;
            string out_str = "";
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < dgvAddAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvAddAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[1].ToString();
                        string state = dr.ItemArray[0].ToString();
                        switch (state)
                        {
                            case "新增审核未通过":
                                if (!EqMgr.deleteByAssetNo(ID))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("无法删除该信息。");
                                break;
                        }

                    }
                    if (suc_count == dgvAddAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvAddAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadAddAuditData();
                    break;
                case 3:
                    for (int i = 0; i < dgvBorrowAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvBorrowAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[0].ToString();
                        string eqno = dr.ItemArray[1].ToString();
                        string state = dr.ItemArray[16].ToString();
                        switch (state)
                        {
                            case "借出审核未通过":
                                if (!BoroowMgr.deleteAudit(ID) || !EqMgr.ReturnEq(eqno))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("无法删除该信息。");
                                break;
                        }

                    }
                    if (suc_count == dgvBorrowAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvBorrowAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadBorrowAuditData();
                    break;
                case 4:
                    for (int i = 0; i < dgvFixAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvFixAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[0].ToString();
                        string eqno = dr.ItemArray[1].ToString();
                        string state = dr.ItemArray[16].ToString();
                        switch (state)
                        {
                            case "送修审核未通过":
                                if (!FixMgr.deleteAudit(ID) || !EqMgr.ReturnEq(eqno))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("无法删除该信息。");
                                break;
                        }

                    }
                    if (suc_count == dgvFixAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvFixAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadFixAuditData();
                    break;
                case 1:
                    for (int i = 0; i < dgvClearAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvClearAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[1].ToString();
                        string eqno = dr.ItemArray[2].ToString();
                        string state = dr.ItemArray[0].ToString();
                        switch (state)
                        {
                            case "注销审核未通过":
                                if (!ClearMgr.deleteAudit(ID) || !EqMgr.ReturnEq(eqno))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("无法删除该信息。");
                                break;
                        }

                    }
                    if (suc_count == dgvClearAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvClearAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadClearAuditData();
                    break;
                case 2:
                    for (int i = 0; i < dgvUpdateAudit.SelectedRows.Count; i++)
                    {
                        DataRow dr = (dgvUpdateAudit.SelectedRows[i].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[1].ToString();
                        string eqno = dr.ItemArray[2].ToString();
                        string state = dr.ItemArray[0].ToString();
                        switch (state)
                        {
                            case "更新审核未通过":
                                if (!EqMgr.deleteUpdateAudit(ID))
                                {
                                    untCommon.InfoMsg("操作失败。");
                                    break;
                                }
                                else
                                    suc_count++;
                                break;
                            default:
                                untCommon.InfoMsg("无法删除该信息。");
                                break;
                        }

                    }
                    if (suc_count == dgvUpdateAudit.SelectedRows.Count)
                    {
                        out_str = string.Format("操作成功{0}条资产", suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    else
                    {
                        out_str = string.Format("操作成功{0}条资产，操作失败{1}条资产", suc_count, dgvUpdateAudit.SelectedRows.Count - suc_count);
                        untCommon.InfoMsg(out_str);
                    }
                    this.LoadUpdateAuditData();
                    break;
            }
        }


        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enterAgreeItem();
        }
        /// <summary>
        /// 审核不通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enterDisAgreeItem();
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuRevise_Click(object sender, EventArgs e)
        {
            enterReviseItem();
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            enterDeleteItem();
        }

        /// <summary>
        /// 归还设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuReturn_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 3:
                    {
                        DataRow dr = (dgvBorrowAudit.Rows[dgvBorrowAudit.CurrentRow.Index].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[0].ToString();
                        string state = dr.ItemArray[16].ToString();
                        switch (state)
                        {
                            case "已借出":
                                frmBorrowReturn eqReturn = new frmBorrowReturn();
                                eqReturn.User = this._user;
                                eqReturn.Power = this._power;
                                eqReturn.ID = ID;
                                eqReturn.ShowDialog();
                                break;
                            default:
                                untCommon.InfoMsg("无法进行该操作。");
                                break;
                        }
                        this.LoadBorrowAuditData();
                        break;
                    }
                case 4:
                    {
                        DataRow dr = (dgvFixAudit.Rows[dgvFixAudit.CurrentRow.Index].DataBoundItem as DataRowView).Row;
                        string ID = dr.ItemArray[0].ToString();
                        string state = dr.ItemArray[16].ToString();
                        switch (state)
                        {
                            case "维修中":
                                frmFixReturn eqReturn = new frmFixReturn();
                                eqReturn.User = this._user;
                                eqReturn.Power = this._power;
                                eqReturn.ID = ID;
                                eqReturn.ShowDialog();
                                break;
                            default:
                                untCommon.InfoMsg("无法进行该操作。");
                                break;
                        }
                        this.LoadFixAuditData();
                        break;
                    }
                default:
                    untCommon.InfoMsg("无法进行该操作。");
                    break;
            }

        }

        #endregion

        #region 右键选中


        /// <summary>
        /// 新增表格右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAudit_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvAddAudit.Rows[e.RowIndex].Selected == false)
                    {
                        dgvAddAudit.ClearSelection();
                        dgvAddAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvAddAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvAddAudit.CurrentCell = this.dgvAddAudit.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        /// <summary>
        /// 借用表格右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBorrowAudit_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvBorrowAudit.Rows[e.RowIndex].Selected == false)
                    {
                        dgvBorrowAudit.ClearSelection();
                        dgvBorrowAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvBorrowAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvBorrowAudit.CurrentCell = this.dgvBorrowAudit.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        /// <summary>
        /// 维修表格右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFixAudit_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvFixAudit.Rows[e.RowIndex].Selected == false)
                    {
                        dgvFixAudit.ClearSelection();
                        dgvFixAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvFixAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvFixAudit.CurrentCell = this.dgvFixAudit.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        /// <summary>
        /// 注销表格右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClearAudit_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvClearAudit.Rows[e.RowIndex].Selected == false)
                    {
                        dgvClearAudit.ClearSelection();
                        dgvClearAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvClearAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvClearAudit.CurrentCell = this.dgvClearAudit.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        /// <summary>
        /// 更新表格右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUpdateAudit_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvUpdateAudit.Rows[e.RowIndex].Selected == false)
                    {
                        dgvUpdateAudit.ClearSelection();
                        dgvUpdateAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvUpdateAudit.Rows[e.RowIndex].Selected = true;
                        this.dgvUpdateAudit.CurrentCell = this.dgvUpdateAudit.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        #endregion

        /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        private string name2ID(DataTable dt, string value, string column)
        {
            dt.PrimaryKey = new System.Data.DataColumn[] { dt.Columns[column] };
            System.Data.DataRow row = dt.Rows.Find(value);
            return row.ItemArray[1].ToString();
        }

        /// <summary>
        /// 页面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    this.LoadAddAuditData();
                    break;
                case 1:
                    this.LoadClearAuditData();
                    break;
                case 2:
                    this.LoadUpdateAuditData();
                    break;
                case 3:
                    this.LoadBorrowAuditData();
                    break;
                case 4:
                    this.LoadFixAuditData();
                    break;
            }
        }

        #region 双击

        /// <summary>
        /// 新增表格双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAddAudit_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataRow dr = (dgvAddAudit.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            string Asset = dr.ItemArray[1].ToString();
            string state = dr.ItemArray[0].ToString();
            string ID = Asset.Replace('A', 'E');
            frmEqUpdate frupdate;
            switch (state)
            {
                case "新增审核未通过":
                    frmRemark Remark = new frmRemark(ID,0);
                    if (Remark.ShowDialog() == DialogResult.OK)
                    {
                        frupdate = new frmEqUpdate(this._user, ID, this._power, 3);
                        if (frupdate.ShowDialog() == DialogResult.OK)
                            this.LoadAddAuditData();
                        break;
                    }
                    else
                    {
                        break;
                    }
                default:
                    frupdate = new frmEqUpdate(this._user, ID, this._power, 3);
                    if (frupdate.ShowDialog() == DialogResult.OK)
                        this.LoadAddAuditData();
                    break;
            }
        }

        /// <summary>
        /// 注销表格双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClearAudit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr = (dgvClearAudit.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            string ID = dr.ItemArray[1].ToString();
            string state = dr.ItemArray[0].ToString();
            frmClear clear;
            switch (state)
            {
                case "注销审核未通过":
                    frmRemark Remark = new frmRemark(ID,1);
                    if (Remark.ShowDialog() == DialogResult.OK)
                    {
                        clear = new frmClear(ID, false);
                        clear.User = this._user;
                        if (clear.ShowDialog() == DialogResult.OK)
                            this.LoadClearAuditData();
                        break;
                    }
                    else
                    {
                        break;
                    }

                default:
                    clear = new frmClear(ID, true);
                    clear.User = this._user;
                    clear.ShowDialog();
                    break;
            }
        }

        /// <summary>
        /// 更新表格双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUpdateAudit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr = (dgvUpdateAudit.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            string ID = dr.ItemArray[1].ToString();
            string state = dr.ItemArray[0].ToString();
            frmRemark Remark;
            List<string> EqnoList = new List<string>();
            EqnoList.Add(ID);
            switch (state)
            {
                case "更新审核未通过":
                    {
                        Remark = new frmRemark(ID, 2);
                        if (Remark.ShowDialog() == DialogResult.OK)
                        {
                            frmEqUpdate frupdate = new frmEqUpdate(this._user, EqnoList, this._power, 4);
                            if (frupdate.ShowDialog() == DialogResult.OK)
                            {
                                this.LoadUpdateAuditData();
                            }
                            break;
                        }
                        else
                        {
                            break;
                        }

                    }
                default:
                    {
                        Remark = new frmRemark(ID, 1);
                        frmEqUpdate frupdate = new frmEqUpdate(this._user, EqnoList, this._power, 4);
                        if (frupdate.ShowDialog() == DialogResult.OK)
                        {
                            this.LoadUpdateAuditData();
                        }
                        break;
                    }
            }
        }
        #endregion 

        private void accept_toolStripButton_Click(object sender, EventArgs e)
        {
            enterAgreeItem();
        }

        private void refuse_toolStripButton_Click(object sender, EventArgs e)
        {
            enterDisAgreeItem();
        }

        private void modify_toolStripButton_Click(object sender, EventArgs e)
        {
            enterReviseItem();
        }

        private void delete_toolStripButton_Click(object sender, EventArgs e)
        {
            enterDeleteItem();
        }

    }
}
