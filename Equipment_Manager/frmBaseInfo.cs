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

        private string selectedTable = "车辆产地";

        private void frmBaseInfo_Load(object sender,EventArgs e)
        {
            this.BuildTree();
            this.tvBasic.Nodes[0].Expand();//展开树的第一层节点
            this.tvBasic.Nodes[0].Nodes[0].Expand();
            this.tvBasic.SelectedNode = this.tvBasic.Nodes[0].Nodes[0].Nodes[0];
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="txt">节点的文本</param>
        /// <param name="parent">节点的父节点</param>
        private void AddNode(TreeNode node, string txt,string tag, int imageindex, TreeNode parent)
        {
            //TreeNode node = new TreeNode();
            node.Text = txt;
            node.Tag = tag;
            node.ImageIndex = imageindex;
            node.SelectedImageIndex = imageindex;//5-1-a-s-p-x
            parent.Nodes.Add(node);

        }

        /// <summary>
        /// 构造树
        /// </summary>
        private void BuildTree()
        {
            TreeNode nodeAll = new TreeNode();
            nodeAll.Text = "基本设置";
            nodeAll.Tag = "0";
            nodeAll.ImageIndex = 0;
            nodeAll.SelectedImageIndex = 0;
            tvBasic.Nodes.Add(nodeAll);

            this.BulidCar(nodeAll);
            this.BulidEstate(nodeAll);
            this.BulidRelic(nodeAll);
            this.BulidOther(nodeAll);

        }


        /// <summary>
        /// 构造资产车辆节点
        /// </summary>
        /// <param name="parent"></param>
        private void BulidCar(TreeNode parent)
        {
            TreeNode Car = new TreeNode();
            this.AddNode(Car, "车辆","1", 1, parent);

            TreeNode CarBP = new TreeNode();
            TreeNode CarUse = new TreeNode();
            TreeNode Formation = new TreeNode();
            this.AddNode(CarBP, "车辆产地","2", 1, Car);
            this.AddNode(CarUse, "车辆用途", "2", 1, Car);
            this.AddNode(Formation, "编制情况", "2", 1, Car);
        }

        /// <summary>
        /// 构造房屋土地节点
        /// </summary>
        /// <param name="parent"></param>
        private void BulidEstate(TreeNode parent)
        {
            TreeNode Estate = new TreeNode();
            this.AddNode(Estate, "房屋土地","1", 1, parent);

            TreeNode CertNature = new TreeNode();
            TreeNode Pr = new TreeNode();
            TreeNode Structure = new TreeNode();
            this.AddNode(CertNature, "权属性质", "2", 1, Estate);
            this.AddNode(Pr, "产权形式", "2", 1, Estate);
            this.AddNode(Structure, "建筑结构", "2", 1, Estate);
        }

        /// <summary>
        /// 构造文物和陈列品节点
        /// </summary>
        /// <param name="parent"></param>
        private void BulidRelic(TreeNode parent)
        {
            TreeNode Relic = new TreeNode();
            this.AddNode(Relic, "文物和陈列品","1", 1, parent);

            TreeNode RelicLv = new TreeNode();
            this.AddNode(RelicLv, "文物等级", "2", 1, Relic);
        }

        /// <summary>
        /// 构造其他节点
        /// </summary>
        /// <param name="parent"></param>
        private void BulidOther(TreeNode parent)
        {
            TreeNode Other = new TreeNode();
            this.AddNode(Other, "其他", "1",1, parent);

            TreeNode BuyWay = new TreeNode();
            TreeNode GetWay = new TreeNode();
            TreeNode Direction = new TreeNode();
            TreeNode Funds = new TreeNode();
            TreeNode PriceType = new TreeNode();
            TreeNode Unit = new TreeNode();
            TreeNode ClearType = new TreeNode();
            TreeNode Usage = new TreeNode();
            TreeNode Campus = new TreeNode();
            this.AddNode(BuyWay, "采购形式", "2", 1, Other);
            this.AddNode(GetWay, "取得方式", "2", 1, Other);
            this.AddNode(Direction, "使用方向", "2", 1, Other);
            this.AddNode(Funds, "经费科目", "2", 1, Other);
            this.AddNode(PriceType, "价值类型", "2", 1, Other);
            this.AddNode(Unit, "计量单位", "2", 1, Other);
            this.AddNode(ClearType, "清理方式", "2", 1, Other);
            this.AddNode(Usage, "使用情况", "2", 1, Other);
            this.AddNode(Campus, "校区", "2", 1, Other);
        }

        private void tvBasic_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvBasic.SelectedNode.Tag.ToString() == "2")
            {
                this.dgvBasic.DataSource = BasicMgr.GetBasicInfo(this.tvBasic.SelectedNode.Text);
                this.selectedTable = this.tvBasic.SelectedNode.Text;
            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            frmBasicData fbData = new frmBasicData();
            fbData.IsAdd = true;
            fbData.Table = this.selectedTable;
            fbData.ShowDialog();
            if (fbData.DialogResult == DialogResult.OK)
                fresh();
        }

        private void toolChange_Click(object sender, EventArgs e)
        {
            frmBasicData fbData = new frmBasicData();
            fbData.IsAdd = false;
            fbData.Table = this.selectedTable;
            fbData.Id = this.dgvBasic.SelectedRows[0].Cells["编号"].Value.ToString();
            fbData.Discrip = this.dgvBasic.SelectedRows[0].Cells["基本描述"].Value.ToString();
            fbData.ShowDialog();
            if (fbData.DialogResult == DialogResult.OK)
                fresh();
        }

        private void toolFresh_Click(object sender, EventArgs e)
        {
            fresh();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string tableName = BasicMgr.GetTableName(this.selectedTable);
            int id = int.Parse(this.dgvBasic.SelectedRows[0].Cells["编号"].Value.ToString());
            string discrip = this.dgvBasic.SelectedRows[0].Cells["基本描述"].Value.ToString();
            if (untCommon.QuestionMsg("确定要删除\n" + id.ToString() + "." +discrip + "?"))
            {
               
                if (BasicMgr.DeleteBasic(tableName,id))
                {
                    untCommon.InfoMsg("删除成功");
                    fresh();
                }
                else
                    untCommon.InfoMsg("删除失败");
            }
        }

        private void fresh()
        {
            this.dgvBasic.DataSource = BasicMgr.GetBasicInfo(this.selectedTable);
        }
    }
}