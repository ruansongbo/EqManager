using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmTree : Form
    {
        private string _dbtable="";
        private string _key = "";
        private string _nodeNum = "";

        TreeNode Snode;
        public frmTree()
        {
            InitializeComponent();
            
        }

        //要在_dbtable和_key传入后才在外部调用这个函数，否则会出错
        public void frmTree_Load()
        {
            TreeNode root = new TreeNode();
            CreateOne(root, "0");
            
        }

        /// <summary>
        /// 生产树的代码；
        /// </summary>
        /// <param name="node"> 根节点</param>
        /// <param name="id">主键</param>

        private void CreateOne(TreeNode node, string id)
        {
            string strSql = string.Format("select * from {0} where pid ='{1}' order by id",this._dbtable, id);
            DataTable dt=GetData(strSql);

            if (id == "0")                                  // id = 0 是根节点 
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode nd = new TreeNode();
                    nd.Text = dt.Rows[i][this.Key].ToString();
                    nd.Tag = dt.Rows[i]["id"].ToString();
                    CreateTwo(nd, nd.Tag.ToString());
                    this.treeView1.Nodes.Add(nd);
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode Tnode = new TreeNode();
                    Tnode.Text = dt.Rows[i][this.Key].ToString();
                    Tnode.Tag = dt.Rows[i]["id"].ToString();
                    CreateTwo(Tnode, Tnode.Tag.ToString());
                    node.Nodes.Add(Tnode);
                }
            }
        }

        private void CreateTwo(TreeNode node, string id)
        {
            string strSql = string.Format("select * from {0} where pid ='{1}'", this._dbtable,id);
            DataTable dt = GetData(strSql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode Tnode = new TreeNode();
                Tnode.Text = dt.Rows[i][this.Key].ToString();
                Tnode.Tag = dt.Rows[i]["id"].ToString();
                node.Nodes.Add(Tnode);
            }
        }

        private DataTable GetData(string sql)
        {
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }



        private void treeView1_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
           
            Snode = this.treeView1.SelectedNode;
            Snode.Nodes.Clear();
            CreateOne(Snode, Snode.Tag.ToString());
        }


        private void treeView1_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
       
        }

        private void treeView1_NodeMouseDoubleClick(object sender, EventArgs e)
        {
            Snode = this.treeView1.SelectedNode;

            //判断是否为最低的节点
            string sql = string.Format("select count(*) from {0} where pid='{1}'", this._dbtable, Snode.Tag.ToString());
            int count = 0;
            DataTable dt = GetData(sql);
            if (dt != null)
                count = int.Parse(dt.Rows[0][0].ToString());

            if (count != 0)
                untCommon.InfoMsg("该节点不是最低级节点");
            else
            {
                if(this._dbtable=="Department")
                    this._nodeNum =Snode.Text.ToString();
                else
                    this._nodeNum = Snode.Tag.ToString();

                this.DialogResult = DialogResult.OK;
            }
        }


        public string Dbtable
        {
            get { return _dbtable; }
            set { _dbtable = value; }
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string NodeNum
        {
            get { return _nodeNum; }
        }

    }

}
