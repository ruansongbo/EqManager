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

        private string selectedTable = "��������";

        private void frmBaseInfo_Load(object sender,EventArgs e)
        {
            this.BuildTree();
            this.tvBasic.Nodes[0].Expand();//չ�����ĵ�һ��ڵ�
            this.tvBasic.Nodes[0].Nodes[0].Expand();
            this.tvBasic.SelectedNode = this.tvBasic.Nodes[0].Nodes[0].Nodes[0];
        }

        /// <summary>
        /// ��ӽڵ�
        /// </summary>
        /// <param name="txt">�ڵ���ı�</param>
        /// <param name="parent">�ڵ�ĸ��ڵ�</param>
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
        /// ������
        /// </summary>
        private void BuildTree()
        {
            TreeNode nodeAll = new TreeNode();
            nodeAll.Text = "��������";
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
        /// �����ʲ������ڵ�
        /// </summary>
        /// <param name="parent"></param>
        private void BulidCar(TreeNode parent)
        {
            TreeNode Car = new TreeNode();
            this.AddNode(Car, "����","1", 1, parent);

            TreeNode CarBP = new TreeNode();
            TreeNode CarUse = new TreeNode();
            TreeNode Formation = new TreeNode();
            this.AddNode(CarBP, "��������","2", 1, Car);
            this.AddNode(CarUse, "������;", "2", 1, Car);
            this.AddNode(Formation, "�������", "2", 1, Car);
        }

        /// <summary>
        /// ���췿�����ؽڵ�
        /// </summary>
        /// <param name="parent"></param>
        private void BulidEstate(TreeNode parent)
        {
            TreeNode Estate = new TreeNode();
            this.AddNode(Estate, "��������","1", 1, parent);

            TreeNode CertNature = new TreeNode();
            TreeNode Pr = new TreeNode();
            TreeNode Structure = new TreeNode();
            this.AddNode(CertNature, "Ȩ������", "2", 1, Estate);
            this.AddNode(Pr, "��Ȩ��ʽ", "2", 1, Estate);
            this.AddNode(Structure, "�����ṹ", "2", 1, Estate);
        }

        /// <summary>
        /// ��������ͳ���Ʒ�ڵ�
        /// </summary>
        /// <param name="parent"></param>
        private void BulidRelic(TreeNode parent)
        {
            TreeNode Relic = new TreeNode();
            this.AddNode(Relic, "����ͳ���Ʒ","1", 1, parent);

            TreeNode RelicLv = new TreeNode();
            this.AddNode(RelicLv, "����ȼ�", "2", 1, Relic);
        }

        /// <summary>
        /// ���������ڵ�
        /// </summary>
        /// <param name="parent"></param>
        private void BulidOther(TreeNode parent)
        {
            TreeNode Other = new TreeNode();
            this.AddNode(Other, "����", "1",1, parent);

            TreeNode BuyWay = new TreeNode();
            TreeNode GetWay = new TreeNode();
            TreeNode Direction = new TreeNode();
            TreeNode Funds = new TreeNode();
            TreeNode PriceType = new TreeNode();
            TreeNode Unit = new TreeNode();
            TreeNode ClearType = new TreeNode();
            TreeNode Usage = new TreeNode();
            TreeNode Campus = new TreeNode();
            this.AddNode(BuyWay, "�ɹ���ʽ", "2", 1, Other);
            this.AddNode(GetWay, "ȡ�÷�ʽ", "2", 1, Other);
            this.AddNode(Direction, "ʹ�÷���", "2", 1, Other);
            this.AddNode(Funds, "���ѿ�Ŀ", "2", 1, Other);
            this.AddNode(PriceType, "��ֵ����", "2", 1, Other);
            this.AddNode(Unit, "������λ", "2", 1, Other);
            this.AddNode(ClearType, "����ʽ", "2", 1, Other);
            this.AddNode(Usage, "ʹ�����", "2", 1, Other);
            this.AddNode(Campus, "У��", "2", 1, Other);
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
            fbData.Id = this.dgvBasic.SelectedRows[0].Cells["���"].Value.ToString();
            fbData.Discrip = this.dgvBasic.SelectedRows[0].Cells["��������"].Value.ToString();
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
            int id = int.Parse(this.dgvBasic.SelectedRows[0].Cells["���"].Value.ToString());
            string discrip = this.dgvBasic.SelectedRows[0].Cells["��������"].Value.ToString();
            if (untCommon.QuestionMsg("ȷ��Ҫɾ��\n" + id.ToString() + "." +discrip + "?"))
            {
               
                if (BasicMgr.DeleteBasic(tableName,id))
                {
                    untCommon.InfoMsg("ɾ���ɹ�");
                    fresh();
                }
                else
                    untCommon.InfoMsg("ɾ��ʧ��");
            }
        }

        private void fresh()
        {
            this.dgvBasic.DataSource = BasicMgr.GetBasicInfo(this.selectedTable);
        }
    }
}