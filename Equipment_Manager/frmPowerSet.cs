using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmPowerSet : Form
    {
        public frmPowerSet()
        {
            InitializeComponent();
            
        }
        ArrayList list = null;//�����û�ԭ����Ȩ��

        ArrayList Lastlist = new ArrayList();//�����û������Ĺ����Ȩ��

        private string _loginid;
        public string LoginId
        {
            set
            {
                this._loginid = value;
            }
        }
        public void initListbox()
        {
            DataTable dt = SysUserMgr.GetAllLoginName();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstUser.Items.Add(dt.Rows[i][0].ToString());
                }
                //�������û���saһ���ǲ��ɸĶ��ģ����ڴ洢���������û���Ĭ��Ȩ�ޣ������⿪��
                lstUser.Items.Remove("һ���û�");
                lstUser.Items.Remove("�����û�");
                lstUser.Items.Remove("�����û�");
            }
        }

        private void frmPowerSet_Load(object sender, EventArgs e)
        {
            this.initListbox();//�����û��б�
            this.BuildTree(null,0);//���ع�����
        }
        /// <summary>
        /// ѡ�в�ͬ���û����õ��û�����ʵ����
        /// ���ҵõ��û���Ȩ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "";
            if (lstUser.SelectedIndex != -1)
            {
                id = SysUserMgr.GetIdByLoginName(lstUser.SelectedItems[0].ToString());
 
            }
            if (id!="")
            {
                this.label3.Visible = true;
                this.lblid.Text = id;
            }

            this.panelCheck.Enabled = true;
            this.rbtnFree.Checked = true;
            this.GetFuncByUser(this.lblid.Text);//�õ�Ȩ��

        }
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentid"></param>
        private void BuildTree(TreeNode parentNode, int parentid)
        {
            DataTable dt = SysUserMgr.GetFuncList(parentid);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = dt.Rows[i][1].ToString();
                    node.Tag = dt.Rows[i][0].ToString();
                   // node.Nodes.Add("���ڼ���...");
                    tvwFunc.Nodes.Add(node);
                    this.Buildfunc(tvwFunc.Nodes[i]);
                    this.tvwFunc.ExpandAll();

                }
               
            }
            
 
        }
        /// <summary>
        /// ���칦�ܽڵ�
        /// </summary>
        /// <param name="parent"></param>
        private void Buildfunc(TreeNode parent)
        {
            int menuid = int.Parse(parent.Tag.ToString());
            DataTable dt = SysUserMgr.GetFuncList(menuid);
            if (dt != null)
            {

                for (int i = 0; i< dt.Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = dt.Rows[i][1].ToString();
                    node.Tag = dt.Rows[i][0].ToString();
                    parent.Nodes.Add(node);
                }

            }
 
        }
        /// <summary>
        /// ���һ���ڵ�ѡ�У�������ӽڵ㣬�����ӽڵ�ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwFunc_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool ischecked = e.Node.Checked;
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = ischecked;
            }
        }
        /// <summary>
        /// �õ�ĳ�û���Ȩ�ޣ��������Ĳ������������ֳ���
        /// </summary>
        private void GetFuncByUser(string id)
        {
            this.list = SysUserMgr.GetOneListByUser(id);
            for (int i = 0; i < tvwFunc.Nodes.Count; i++)
            {
                tvwFunc.Nodes[i].Checked = false;

            }

            for (int i = 0; i < tvwFunc.Nodes.Count;i++ )
            {
                this.GetNodes(this.tvwFunc.Nodes[i]);
               
            }

           
        }
        /// <summary>
        /// ��������������ֽڵ��tag��ֵ��Ȩ���б� list ���ֵ�����ܱ�ţ���ͬ��
        /// �ͰѸýڵ��checkboxѡ��
        /// </summary>
        /// <param name="tnParent"></param>
        private void GetNodes(TreeNode tnParent)
        {
            if (tnParent != null)
            {
                foreach (TreeNode tn in tnParent.Nodes)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        //������ֽڵ��tag��ֵ��Ȩ���б� list ���ֵ�����ܱ�ţ���ͬ��
                        // �ͰѸýڵ��checkboxѡ��
                        if (tn.Tag.ToString() == list[i].ToString())
                        {
                            tn.Checked = true;
                        }
                    }
                   
                }
            }
        }
        /// <summary>
        /// ��������������ֽڵ��checkboxѡ�У�
        /// �ͰѸýڵ��tag�ŵ�Lastlist�У����ڵ���⣩
        /// </summary>
        /// <param name="tnParent"></param>
        private void GetNodesLast(TreeNode tnParent)
        {
            if (tnParent != null)
            {
                foreach (TreeNode tn in tnParent.Nodes)
                {
                    if (tn.Checked)
                    {
                        if (tn.Parent != null)
                        {
                          
                            Lastlist.Add(tn.Tag);

                        }
                    }
                    
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int error = 0;
            
            if (this.lstUser.SelectedIndex == -1)
            {
                untCommon.InfoMsg("��ѡ���û���");
                return;
            }
            if (this.lstUser.SelectedItems[0].ToString() == this._loginid)
            {
                untCommon.ErrorMsg("����,�����������Լ���Ȩ�ޡ�");
                return;
            }
            if (this.lstUser.SelectedItems[0].ToString() == "sa")
            {
                untCommon.ErrorMsg("����,�����������û�" + "sa" + "��Ȩ�ޡ��û�" + "sa" + "�Ա�ϵͳ������ȫ����Ȩ");
                GetFuncByUser(this.lblid.Text);
                return;
            }
            string loginid = this.lblid.Text;
            //�ѽڵ��checkboxѡ�еĽڵ�tag�ŵ�Lastlist�У����ڵ���⣩
            for (int i = 0; i < tvwFunc.Nodes.Count; i++)
            {
                GetNodesLast(this.tvwFunc.Nodes[i]);
            }
            if (!untCommon.QuestionMsg("��ȷ��Ҫ�����û�"+ this.lstUser.SelectedItem.ToString()+ "��Ȩ����"))
            {
                return;
            }
            // ���list�е�ĳ��Ԫ����lastlist�в����ڣ��û���ɾ���˸ù���
            
            for (int i = 0; i < list.Count; i++)
            {
                if (Lastlist.Contains(list[i]) == false)
                {
                    
                    if (SysUserMgr.Del(loginid, int.Parse(list[i].ToString())) == false)
                    {
                        
                        error++;//��������
                    }
   
                }
               

            }
            
            //���lastlistt�е�ĳ��Ԫ����list�в����ڣ��û��������˸ù���
            
                for (int i = 0; i < Lastlist.Count; i++)
                {
                    if (list.Contains(Lastlist[i]) == false)
                    {
                        if (SysUserMgr.Add(loginid, int.Parse(Lastlist[i].ToString())) == false)
                        {
                            error++;//��������
                        }

                    }
                }
                if (error == 0)
                {

                    untCommon.InfoMsg("Ȩ�޸��ĳɹ���");

                }
                else
                {
                    untCommon.InfoMsg("Ȩ�޸���ʧ�ܡ�");
                    error = 0;
                    GetFuncByUser(this.lblid.Text);

                }
            

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ����Ȩ��ѡ��Ĳ�ͬ���費ͬȨ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            string rechargeMoney = string.Empty;
            switch (((RadioButton)sender).Text.ToString())
            {
                case "��ѡ":
                    this.GetFuncByUser(this.lblid.Text);//�õ�Ȩ��
                    break;
                case "һ���û�":
                    this.GetFuncByUser("999991");//�õ�һ��Ȩ��
                    break;
                case "�����û�":
                    this.GetFuncByUser("999992");//�õ�����Ȩ��
                    break;
                case "�����û�":
                    this.GetFuncByUser("999993");//�õ�����Ȩ��
                    break;
                default:
                    break;
            }
        }

    }
    
}