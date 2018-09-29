using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using DataBusiness;
using DataEntity;
using System.IO;

namespace Equipment_Manager
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // ��ֹ��������.
            SetStyle(ControlStyles.DoubleBuffer, true); // ˫����
           
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private static int curPage = 1;  //��ǰҳ
        private static int TotalPage = 0; //��ҳ��
        private static int pageCount = 30; //��ҳ����
        private Dictionary<string, ZCGridColumnSortButton> sortButtons = new Dictionary<string, ZCGridColumnSortButton>();
        private static List<string> AvailableColumns = new List<string>();
        private static List<string> SelectedColumns = new List<string>();
        private bool query_flag = false;
        public Dictionary<String, ZCGridSortHelper> Sorts = new Dictionary<string, ZCGridSortHelper>();
        public Dictionary<String, String> SortsString = new Dictionary<string, string>();
        public ZCGridSortForm frmSort;
       
        private string _user;
        private string _loginid;
        private string _departId;
        private string _power;

        ArrayList MenuList = null;
      

        public string LoginID
        {
            set
            {
                this._loginid = value;
            }
            
        }
        
        public string User
        {
            set
            {
                this._user = value;
 
            }
            
           
        }

        public string DepartId
        {
            set
            {
                this._departId = value;

            }


        }

        public string Power
        {
            set
            {
                this._power = value;

            }


        }

        
        
        /// <summary>
        /// �ʲ���ŵ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">dbg</param>
        private void colEqNo_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)(sender);
            // ȷ���Ƿ�ȷʵ���ڡ��ʲ���š������е��еĳ��������ϰ�һ�¡�
            if (e.RowIndex >= 0 && e.ColumnIndex == grid.Columns["�ʲ����"].Index)
            {
                this.UpdateEnter();

            }
        }

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.MenuList = SysUserMgr.GetPower(_loginid);//�õ���¼�û���Ȩ�ޣ���ִ�еĲ�����
            this.initMenu();//���ز˵�
            this.initToolBar();//�����ʲ������Ĺ�����
            this.InitDbgEq();//�����ʲ���

            this.BuilTree();//������
            this.tvwEqSeach.Nodes[0].Expand();//չ�����ĵ�һ��ڵ�

            this.InitStatusInfo();//����״̬��
            TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��
            this.lblTotalpage.Text = "��"+TotalPage.ToString()+"ҳ";

           

        }
        /// <summary>
        /// ���ӽڵ�
        /// </summary>
        /// <param name="txt">�ڵ���ı�</param>
        /// <param name="parent">�ڵ�ĸ��ڵ�</param>
        private void AddNode(TreeNode node, string txt,int imageindex, TreeNode parent)
        {
            //TreeNode node = new TreeNode();
            node.Text = txt;
            node.ImageIndex = imageindex;
            node.SelectedImageIndex = imageindex;//5-1-a-s-p-x
            parent.Nodes.Add(node);
            
        }
        /// <summary>
        /// ������
        /// </summary>
        private void BuilTree()
        {
            TreeNode nodeAll = new TreeNode();
            nodeAll.Text = "ȫ���ʲ�";
            nodeAll.ImageIndex = 0;
            nodeAll.SelectedImageIndex = 0;
            tvwEqSeach.Nodes.Add(nodeAll);
            


            this.BuildType(nodeAll);//�����ʲ����l�б�
            this.BuildName(nodeAll);//�����ʲ������б�
            this.BuildKeepPlace(nodeAll);//���ر���ص��б�
            this.BuildAddType(nodeAll);//����������ʽ�б�
            
        }
        /// <summary>
        /// �����ʲ�����ص�ڵ�
        /// </summary>
        /// <param name="parent">���ڵ�</param>
        private void BuildKeepPlace(TreeNode parent)
        {
            TreeNode KeepPlace = new TreeNode();
            this.AddNode(KeepPlace,"����ص�",1, parent);
            DataTable dt = KeepPlaceMgr.GetAllPlace();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode keep = new TreeNode();
                    this.AddNode(keep, dt.Rows[i][1].ToString(),2, KeepPlace);
                }
            }


        }
        /// <summary>
        /// �����ʲ����ƽڵ�
        /// </summary>
        /// <param name="parent">���ڵ�</param>
        private void BuildName(TreeNode parent)
        {
            TreeNode Name = new TreeNode();
            this.AddNode(Name, "�ʲ�����",5, parent);
            DataTable dt = EqNameMgr.GetAllEqname();
            
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TreeNode name = new TreeNode();
                        this.AddNode(name,dt.Rows[i][1].ToString() ,2, Name);

                    }
                }
            

        }
        /// <summary>
        /// �����ʲ���Ƚڵ�
        /// </summary>
        /// <param name="parent">���ڵ�</param>
        private void BuildType(TreeNode parent)
        {
            TreeNode Type = new TreeNode();
            this.AddNode(Type, "�ʲ����",7, parent);

            DataTable dt = EqTypeMgr.GetAllType();
            
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TreeNode type = new TreeNode();
                        this.AddNode(type, dt.Rows[i][1].ToString(),2, Type);

                    }
                }
            
 
        }
        /// <summary>
        /// ����������ʽ�ڵ�
        /// </summary>
        /// <param name="parent"></param>
        private void BuildAddType(TreeNode parent)
        {
            TreeNode nodeAddType = new TreeNode();
            this.AddNode(nodeAddType,"������ʽ",9,parent);

            DataTable dt = AddTypeMgr.GetAllType();
            
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TreeNode addtype = new TreeNode();
                        this.AddNode(addtype, dt.Rows[i][1].ToString(),2, nodeAddType);
 
                    }
                }
            
        }


        /// <summary>
        /// �����û�������ϵĲ�ͬ�ڵ��������ʲ���¼��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwEqSeach_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)//������ڵ�
            {
                return;
            }

            if (e.Node.Parent.Parent == null && e.Node != null)//�����֦�ڵ�
            {
                return;
            }
            if (e.Node.Parent.Parent.Parent == null && e.Node != null)//���Ҷ�ڵ�
            {
                if (e.Node.Parent.Text == "�ʲ����")
                {
                    this.SearchByEqno(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;
 
                }
                if (e.Node.Parent.Text == "�ʲ����")
                {
                    this.SearchByType(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "�ʲ�����")
                {
                    this.SearchByName(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "������ʽ")
                {
                    this.searchByAddtype(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "����ص�")
                {
                    this.SearchByKeepPlace(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "�Ǽ���")
                {
                    this.SearchByBooker(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
            }
           
        }
        /// <summary>
        /// ������ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSearch_Click(object sender, EventArgs e)
        {
            if (!query_flag)
            {
                query_flag = true;

                DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

                if (dat != null)
                {
                    TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��

                    //������
                    dbgEq.DataSource = dat.DefaultView;
                    AvailableColumns.Clear();
                    foreach (DataGridViewColumn c in dbgEq.Columns)
                    {
                        if (!c.Visible) continue;
                        AvailableColumns.Add(c.HeaderText);
                    }
                    foreach (string field in AvailableColumns)
                    {
                        if (!SelectedColumns.Contains(field))
                            dbgEq.Columns.Remove(field);
                    }
                    List<string> SelectedItem = new List<string>();
                    foreach (string key in Sorts.Keys)
                    {
                        SelectedItem.Add(key);
                    }
                    foreach (string field in SelectedItem)
                    {
                        Sorts[field] = null;
                        SortsString[field] = null;
                        sortButtons[field].sortHelper = new ZCGridSortHelper();
                    }
                    Sorts.Clear();
                    SortsString.Clear();
                }
                this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
                this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";

                ZCGridColumnSortButton btnSort = null;
                foreach (DataGridViewColumn c in dbgEq.Columns)
                {
                    if (!c.Visible) continue;
                    if (sortButtons.ContainsKey(c.HeaderText)) continue;
                    btnSort = new ZCGridColumnSortButton();
                    btnSort.Text = ".";
                    btnSort.Click += btnSort_Click;
                    btnSort.Size = new Size(16, 16);
                    btnSort.MinimumSize = btnSort.Size;
                    btnSort.sortHelper = new ZCGridSortHelper();
                    this.sortButtons.Add(c.HeaderText, btnSort);
                    this.dbgEq.Controls.Add(btnSort);
                    btnSort.Visible = true;
                    btnSort = this.sortButtons[c.HeaderText];
                    btnSort.Column = dbgEq.Columns[c.Index];

                }
                SetupControlsPosition();
                this.toolStripButton2.Enabled = false;
                this.toolbtnSearchAll.Enabled = false;
            }
            else
            {
                query_flag = false;
                if (this.frmSort != null)
                    frmSort.Close();
                foreach (string key in sortButtons.Keys)
                {
                    sortButtons[key].Dispose();
                }
                sortButtons.Clear();
                List<string> SelectedItem = new List<string>();
                foreach (string key in Sorts.Keys)
                {
                    SelectedItem.Add(key);
                }
                foreach (string field in SelectedItem)
                {
                    Sorts[field] = null;
                    SortsString[field] = null;
                }
                Sorts.Clear();
                SortsString.Clear();
                this.toolStripButton2.Enabled = true;
                this.toolbtnSearchAll.Enabled = true;
            }
        }

        /// <summary>
        /// ���Ǽ��˲���
        /// </summary>
        public void SearchByBooker(string booker)
        {
            DataTable dt = EqMgr.GetInfobyBooker(booker);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                }


            }
        }
        /// <summary>
        /// ������ص����
        /// </summary>
        private void SearchByKeepPlace(string place)
        {
            DataTable dt = EqMgr.GetInfobyKeepplace(place);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                }


            }
        }
        /// <summary>
        /// �����Ʋ���
        /// </summary>
        private void SearchByName(string name)
        {
            DataTable dt = EqMgr.GetInfobyName(name);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                }


            }
        }
        /// <summary>
        /// ��������ʽ����
        /// </summary>
        private void searchByAddtype(string addtype)
        {
            DataTable dt = EqMgr.GetInfobyAddtype(addtype);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                }


            }
        }
        /// <summary>
        /// ���ʲ�������
        /// </summary>
        private void SearchByType(string type)
        {
            DataTable dt = EqMgr.GetInfobyType(type);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                }


            }
        }
        /// <summary>
        /// ���ʲ���Ų���
        /// </summary>
        private void SearchByEqno(string eqno)
        {
            DataTable dt = EqMgr.GetInfobyEqno(eqno);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                }


            }
 
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.statusInfo.Items[1].Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// ��ʼ��״̬��
        /// </summary>
        private void InitStatusInfo()
        {
            DataTable dt = CompanyInfoMgr.GetInfo();
            if (dt != null)
            {
                this.statusInfo.Items[2].Text = dt.Rows[0][1].ToString();
                this.statusInfo.Items[3].Text = dt.Rows[0][3].ToString();
            }
            this.statusInfo.Items[0].Text = "��ǰϵͳ����Ա��" + this._user;
            this.timer.Start();

        }


        /// <summary>
        /// �����ʲ����½���
        /// </summary>
        private void UpdateEnter()
        {
            frmEqUpdate frupdate = new frmEqUpdate();
            if (this.dbgEq.Rows.Count == 0)
            {
                frupdate.ShowDialog();

            }
            else
            {
               frupdate.Eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
               frupdate.Sysuser = this._user;
               

                if (frupdate.ShowDialog() == DialogResult.OK)
                {
                    this.DataRefresh();
                }
                
              
                
            }

        }
        /// <summary>
        /// �����ʲ����ý���
        /// </summary>
        private void BoroowEnter()
        {
            if (this.dbgEq.Rows.Count == 0)
            {
                untCommon.InfoMsg("û�пɹ����õ��ʲ���");
                return;
            }
            if (dbgEq.SelectedRows.Count == 0)
            {
                untCommon.InfoMsg("�����ʲ��б���ѡ����Ҫ���õ��ʲ���");
                return;
            }
            
            string eqNo = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
            frmBorrow boroow = new frmBorrow();

            //���ѡ�е��ʲ��Ƿ���Խ���
            int max = BoroowMgr.GetMaxBoroow(eqNo);
            if (max != -1)
            {
                boroow.Max = max;
                boroow.User = this._user;
                boroow.Eqno = eqNo;
                boroow.ShowDialog();
          

            }
            else
            {
                untCommon.InfoMsg("����ʲ��Ѿ�����������");
            }

        }
        /// <summary>
        /// ���������ʲ�����
        /// </summary>
        private void ClearEnter()
        {
            
            
            frmClear clear = new frmClear();
            //��ѡ�е��ʲ��Ƿ��ܹ�����
            if (this.dbgEq.Rows.Count != 0)//�ʲ��б���������
            {
                string eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
                int max = ClearMgr.GetMaxClear(eqno);
                //��������
                if (max != -1)
                {
                    clear.User = this._user;
                    clear.Max = max;
                    clear.Eqno=eqno;
                    clear.ShowDialog();
                    

                }
                else
                {
                    untCommon.InfoMsg("�ñ��ʲ�Ŀǰȫ��������ʹ��,����������");
                }
            }
            else
            {
                untCommon.InfoMsg("û���ʲ��ɹ�������");
            }

        }

        /// <summary>
        /// ���뵼����ǰ�ʲ�����
        /// </summary>
        private void CurrentExcel()
        {
            DataTable dt = DgvMgr.GetDgvToTable(this.dbgEq);
            ExportToExcel(dt, "��ǰ�ʲ�����");
        }

        /// <summary>
        /// ���밴���͵�����ǰ����
        /// </summary>
        private void CurrentExcelInType()
        {
            List<string> list = EqTypeMgr.GetEqTypes(this.dbgEq);
            List<DataTable> dts = new List<DataTable> { null };
            string[] p = { "" };

            //ֻ�ܴ�ѭ�����ȸ���һ��λ��ֵ
            p = EqTypeMgr.GetProperties(list[0]);
            dts[0] = DgvMgr.GetDgvToTableInType(this.dbgEq, p, list[0].ToString());

            for (int i = 1; i < list.Count; i++)
            {
                p = EqTypeMgr.GetProperties(list[i]);
                dts.Add(DgvMgr.GetDgvToTableInType(this.dbgEq, p, list[i].ToString()));                
            }
            ExportToExcelInType(dts, list);
        }

        private void ScExcelInType()
        {
            List<string> list = EqTypeMgr.GetScEqTypes(this.dbgEq);
            List<DataTable> dts = new List<DataTable> { null };
            string[] p = { "" };

            //ֻ�ܴ�ѭ�����ȸ���һ��λ��ֵ
            p = EqTypeMgr.GetProperties(list[0]);
            dts[0] = DgvMgr.GetScTableInType(this.dbgEq, p, list[0].ToString());

            for (int i = 1; i < list.Count; i++)
            {
                p = EqTypeMgr.GetProperties(list[i]);
                dts.Add(DgvMgr.GetScTableInType(this.dbgEq, p, list[i].ToString()));
            }
            ExportToExcelInType(dts, list);
        }

        /// <summary>
        /// ���뵼��ѡ���ʲ�����
        /// </summary>
        private void SelectedExcel()
        {
            DataTable dt = DgvMgr.GetSelectedTable(this.dbgEq);
            ExportToExcel(dt, "ѡ���ʲ�����");       
        }

        /// <summary>
        /// ϵͳ��ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Sys_Init_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("���棺���ݳ�ʼ����������ݶ�ʧ����ȷ��Ҫ��ʼ���𣿣�", "����", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (untCommon.QuestionMsg("�ڳ�ʼ��֮ǰ�����ó��׼�����Ƿ�Ҫ�������ݣ�"))
                {
                    frmBackup backup = new frmBackup();
                    backup.ShowDialog();
                    if (SysMgr.SysInit())
                    {

                        untCommon.InfoMsg("ϵͳ��ʼ���ɹ���");
                    }
                    else
                    {

                        untCommon.InfoMsg("ϵͳ��ʼ��ʧ�ܡ�");
                    }


                }
                else
                {
                    if (SysMgr.SysInit())
                    {

                        untCommon.InfoMsg("ϵͳ��ʼ���ɹ���");
                    }
                    else
                    {

                        untCommon.InfoMsg("ϵͳ��ʼ��ʧ�ܡ�");
                    }
                    

                }
            }
        }
        /// <summary>
        /// �õ���Ϣ����ҳ��
        /// </summary>
        /// <returns></returns>
        private int getTotalPage()
        {
            int result = EqMgr.EqCount();
            int Total;
            if (result != 0)
            {
                int count = EqMgr.EqCount() % pageCount;
                if (count == 0)
                    Total = EqMgr.EqCount() / pageCount;
                else
                    Total = EqMgr.EqCount() / pageCount + 1;
            }
            else
                Total = 0;
            return Total;

        }
        /// <summary>
        /// ��ʼ���ʲ���
        /// </summary>
        private void InitDbgEq()
        {
            curPage = 1;
            DataTable dat = EqMgr.getEqList(0, pageCount, _departId, _power);
            if (dat != null)
            {
                this.dbgEqSet();
                

                //������

                dbgEq.DataSource = dat.DefaultView;
                AvailableColumns.Clear();
                foreach (DataGridViewColumn c in dbgEq.Columns)
                {
                    if (!c.Visible) continue;
                    AvailableColumns.Add(c.HeaderText);
                    SelectedColumns.Add(c.HeaderText);
                }
                dbgEq.ScrollBars = ScrollBars.Both;
                this.dbgFrozen();
            }
        }
        /// <summary>
        /// �����ʲ������һ��Ϊ������ʽ
        /// </summary>
        private void dbgEqSet()
        {
            //
            DataGridViewLinkColumn colEqNo = new DataGridViewLinkColumn();
            colEqNo.MinimumWidth = 100;
            colEqNo.DataPropertyName = "�ʲ����";
            colEqNo.HeaderText = "�ʲ����";
            colEqNo.LinkBehavior = LinkBehavior.AlwaysUnderline;
            colEqNo.LinkBehavior = LinkBehavior.SystemDefault;
            colEqNo.Name = "�ʲ����";
            colEqNo.SortMode = DataGridViewColumnSortMode.Automatic;
            dbgEq.Columns.Add(colEqNo);
            
            // �����������ӵ� Click �¼���
            // ���ڳ������Ӳ�û���¼�����˱���ʹ�� DataGridView.CellContentClick ������֮��
            // ��ʵ�� DataGridViewLinkColumn ������ģʽ�ǳ������� DataGridViewButtonColumn��
            // ����ֻ����۲�ͬ��

            
            dbgEq.CellContentClick += new DataGridViewCellEventHandler(colEqNo_CellContentClick);
           
        }

        /// <summary>
        /// ����ǰ����
        /// </summary>
        private void dbgFrozen()
        {
            this.dbgEq.Columns[1].Frozen = true;//�ڶ���ǰ���ж�������
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {

            curPage = 1;
            DataTable dat = EqMgr.getEqList(0, pageCount, _departId, _power);
            if (dat != null)
            {


                //������

                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";

        }
        /// <summary>
        /// ��һҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {


            if (curPage < TotalPage)
            {
                curPage++;
            }
            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {

                //������
                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";


        }
        /// <summary>
        /// ��һҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (curPage > 1)
                curPage--;
            else
                curPage = 1;

            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {
                //������
                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";


        }

        /// <summary>
        /// βҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            curPage = TotalPage;

            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {


                //������

                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";


        }
        /// <summary>
        /// ˢ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {
                TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��

                //������
                dbgEq.DataSource = dat.DefaultView;
                AvailableColumns.Clear();
                foreach (DataGridViewColumn c in dbgEq.Columns)
                {
                    if (!c.Visible) continue;
                    AvailableColumns.Add(c.HeaderText);
                }
                foreach (string field in AvailableColumns)
                {
                    if (!SelectedColumns.Contains(field))
                        dbgEq.Columns.Remove(field);
                }
                List<string> SelectedItem = new List<string>();
                foreach (string key in Sorts.Keys)
                {
                    SelectedItem.Add(key);
                }
                foreach (string field in SelectedItem)
                {
                    Sorts[field] = null;
                    SortsString[field] = null;
                    sortButtons[field].sortHelper = new ZCGridSortHelper();
                }
                Sorts.Clear();
                SortsString.Clear();
            }
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";
            
        }
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            this.DataRefresh();
            AvailableColumns.Clear();
            foreach (DataGridViewColumn c in dbgEq.Columns)
            {
                if (!c.Visible) continue;
                AvailableColumns.Add(c.HeaderText);
                SelectedColumns.Add(c.HeaderText);
            }
        }
        /// <summary>
        /// ˢ������
        /// </summary>
        private void DataRefresh()
        {
            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {
                TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��

                //������
                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";
        }
        /// <summary>
        /// ��ѯָ��ҳ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtPage.Text.Trim() == "")
            {
                untCommon.InfoMsg("��������Ҫ��ѯ��ҳ����");
                return;
            }
            try
            {
                curPage = int.Parse(this.txtPage.Text);
            }
            catch (FormatException)
            {
                untCommon.InfoMsg("��Ҫ��ѯ��ҳ�����������֡�");
                return;
            }
            if (curPage > TotalPage || curPage < 1)
            {
                untCommon.InfoMsg("û������Ҫ��ѯ��ҳ����");
                return;
            }

            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {


                //������

                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";

        }
        /// <summary>
        /// ���ò˵������������Ƿ�ɼ�
        /// </summary>
        /// <param name="visibled">true���ɼ�;false�����ɼ�</param>
        private void isVisibleAllMenu(bool visibled)
        {
            for (int i = 0; i < this.menuEqMgr.Items.Count; i++)
            {
                for (int j = 0; j < ((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems.Count; j++)
                {
                    if (((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems[j].Tag != null)
                    {
                        //�ָ����ɼ�
                        if (((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems[j].Tag.ToString() == "s")
                        {
                            continue;

                        }

                    }
                    else
                    {
                        if (((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems[j].Text == "ϵͳ�˳�" || ((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems[j].Text == "ϵͳע��")
                        {
                            continue;
                        }
                        else
                        {
                            ToolStripMenuItem subitem = (ToolStripMenuItem)menuEqMgr.Items[i];
                            subitem.DropDownItems[j].Visible = visibled;
                        }
                    }
                }

            }
        }


        /// <summary>
        /// �����û�����ʹ��ϵͳ�˵�
        /// </summary>
        private void initMenu()
        {

            if (MenuList != null)
            {
                this.isVisibleAllMenu(false); //�������Ӳ˵�ȫ����ʹ��Ϊ���ɼ�

                for (int i = 0; i < menuEqMgr.Items.Count; i++)
                {
                    for (int j = 0; j < ((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems.Count; j++)
                    {
                        ToolStripMenuItem subitem = (ToolStripMenuItem)menuEqMgr.Items[i];
                        for (int index = 0; index < MenuList.Count; index++)
                        {
                            if (subitem.DropDownItems[j].Name == MenuList[index].ToString())
                            {
                                subitem.DropDownItems[j].Visible = true;
                                break;
                            }


                        }


                    }

                }


            }

        }


        /// <summary>
        /// ���ù����������Ƿ�ɼ�
        /// </summary>
        /// <param name="visibled">true���ɼ�;false�����ɼ�</param>
        private void isVisibleAllToolBar(bool visibled)
        {
            for (int i = 0; i < toolMgr.Items.Count; i++)
            {
                if (toolMgr.Items[i].Tag != null)
                {
                    //�ָ����ɼ�
                    if (toolMgr.Items[i].Text == "ϵͳ�˳�" || toolMgr.Items[i].Text == "ϵͳע��" || toolMgr.Items[i].Tag.ToString() == "s")
                        continue;
                    else
                        toolMgr.Items[i].Visible = visibled;
                }


            }
        }
        /// <summary>
        /// ��ʼ���ʲ������Ĺ�����
        /// </summary>
        private void initToolBar()
        {
            isVisibleAllToolBar(false);

            // ArrayList MenuList = SysUserMgr.GetPower(this._loginname);
            for (int i = 0; i < toolMgr.Items.Count; i++)
            {

                for (int index = 0; index < MenuList.Count; index++)
                {
                    if (toolMgr.Items[i].Tag != null)
                    {
                        if (toolMgr.Items[i].Tag.ToString() == MenuList[index].ToString())
                        {
                            toolMgr.Items[i].Visible = true;

                        }
                    }
                }

            }
        }

       
        /// <summary>
        /// �������ӱ���
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ExcelName"></param>
        private void ExportToExcel(DataTable dt,string ExcelName)
        {
            string filePath = string.Empty;
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");//��ȡ��ǰʱ����Ϊ�ļ�����һ����
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "��ѡ����ӱ��񱣴�λ��";

            if (BrowDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = BrowDialog.SelectedPath;//������ǵ��ѡ���ļ��е�·��
                filePath = filePath + "\\"+ExcelName + nowTime + ".xlsx";
                if (ExcelMgr.ExportExcel(dt, filePath))
                {
                    untCommon.InfoMsg("�����ɹ�");
                }
                else
                {
                    untCommon.InfoMsg("����ʧ��");
                }
            }
        }

        /// <summary>
        /// ����𵼳����ӱ���
        /// </summary>
        /// <param name="dts">DataTable�б�</param>
        /// <param name="ExcelNames">���ӱ�����������</param>
        private void ExportToExcelInType(List<DataTable> dts, List<string> ExcelNames)
        {
            string filePath = string.Empty;
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");//��ȡ��ǰʱ����Ϊ�ļ�����һ����
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "��ѡ����ӱ��񱣴�λ��";
            if (BrowDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = BrowDialog.SelectedPath; //������ǵ��ѡ���ļ��е�·��
                
                DirectoryInfo dir = new DirectoryInfo(filePath);
                dir.CreateSubdirectory("���ʲ���𵼳�"+nowTime);
                filePath = filePath + "\\" + "���ʲ���𵼳�" + nowTime;
                for (int i = 0; i < ExcelNames.Count; i++)
                {
                    if (ExcelMgr.ExportExcel(dts[i],(filePath+"\\"+ExcelNames[i]+".xlsx")))
                    {
                        untCommon.InfoMsg("����"+  ExcelNames[i] +"�ɹ�");
                    }
                    else
                    {
                        untCommon.InfoMsg("����" + ExcelNames[i] + "ʧ��");
                    }
                }
            }
        }


        private void menu_EqMgr_BaseInfo_Click(object sender, EventArgs e)
        {
            frmBaseInfo fb = new frmBaseInfo();
            fb.ShowDialog();
        }

        private void menu_Emp_depart_Click(object sender, EventArgs e)
        {
            frmDepart fd = new frmDepart();
            fd.ShowDialog();
        }

        private void meun_emp_emp_Click(object sender, EventArgs e)
        {
            frmEmployee fe = new frmEmployee();
            fe.ShowDialog();
        }

        private void Menu_Eq_Add_Click(object sender, EventArgs e)
        {
            frmEqAdd frmadd = new frmEqAdd();
            frmadd.Sysuser = this._user;
            frmadd.Loginid = this._loginid;
            if (frmadd.ShowDialog() == DialogResult.Cancel)
            {
                this.DataRefresh();
            }
        }

        private void Menu_BaseInfo_Keeper_Click(object sender, EventArgs e)
        {
            frmKeeper fk = new frmKeeper();
            fk.ShowDialog();
        }

        private void Menu_Eq_Update_Click(object sender, EventArgs e)
        {
            this.UpdateEnter();
           

        }
       
        private void Menu_Eq_Boroow_Click(object sender, EventArgs e)
        {
            this.BoroowEnter();
 
        }
        
        private void Menu_Eq_Clear_Click(object sender, EventArgs e)
        {
            this.ClearEnter();
            
            
        }
        

        private void Menu_Eq_Return_Click(object sender, EventArgs e)
        {
            frmReturn frmreturn = new frmReturn();
            frmreturn.txtbooker.Text = this._user;
            frmreturn.ShowDialog();
        }

        private void Menu_Eq_BorrowLook_Click(object sender, EventArgs e)
        {
            frmBorrowLook fbl = new frmBorrowLook();
            fbl.User = this._user;
            fbl.ShowDialog();
            
        }

        private void Menu_MyInfo_Click(object sender, EventArgs e)
        {
            frmConpanyInfo fc = new frmConpanyInfo();
            fc.ShowDialog();
        }

        private void Menu_Eq_ClearLook_Click(object sender, EventArgs e)
        {
            frmClearLook fcl = new frmClearLook();
            fcl.ShowDialog();
        }

        private void Menu_Data_backup_Click(object sender, EventArgs e)
        {
            frmBackup backup = new frmBackup();
            backup.ShowDialog();
        }
        
       

       

        private void toolbtnBaiseInfo_Click(object sender, EventArgs e)
        {
            frmBaseInfo fb = new frmBaseInfo();
            fb.ShowDialog();

        }

        private void toolEqAdd_Click(object sender, EventArgs e)
        {
            frmEqAdd frmadd = new frmEqAdd();
            frmadd.Sysuser = this._user;
            frmadd.Loginid = this._loginid;
            if (frmadd.ShowDialog() == DialogResult.Cancel)
            {
                this.DataRefresh();
            }

        }

        private void toolEqClear_Click(object sender, EventArgs e)
        {
            this.ClearEnter();

        }

        private void toolEqBorrow_Click(object sender, EventArgs e)
        {
            this.BoroowEnter();
        }

        private void toolbtnReturn_Click(object sender, EventArgs e)
        {
            frmReturn fr = new frmReturn();
            fr.txtbooker.Text = this._user;
            fr.ShowDialog();
        }

        private void Menu_Eq_Import_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_Sys_UserAdd_Click(object sender, EventArgs e)
        {
            frmsysUser user = new frmsysUser();
            user.LoginId = this._loginid;
            user.ShowDialog();
        }

        private void Menu_Sys_Update_Click(object sender, EventArgs e)
        {
            frmUpdateSysUserInfo update = new frmUpdateSysUserInfo();
            update.LoginId = this._loginid;
           
            update.ShowDialog();
        }
        /// <summary>
        /// �������±�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Tool_Notepad_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
            
        }
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Tool_Calc_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }
        /// <summary>
        /// �˳�ϵͳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Sys_Exit_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("��ȷ��Ҫ�˳�ϵͳ��"))
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// ϵͳע��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Sys_AppRestart_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("��ȷ��Ҫע��ϵͳ��"))
            {
                Application.Restart();
            }
        }

        private void toolbtnAppRestat_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("��ȷ��Ҫע��ϵͳ��"))
            {
                Application.Restart();
            }
        }

        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("��ȷ��Ҫ�˳�ϵͳ��"))
            {
                Application.Exit();
            }
        }

        private void toolbtnImport_Click(object sender, EventArgs e)
        {

            frmImport frimport = new frmImport();
            frimport.ShowDialog();

        }

        private void Menu_Eq_ReturnLook_Click(object sender, EventArgs e)
        {
            frmReturnLook frl = new frmReturnLook();
            frl.ShowDialog();
        }
        /// <summary>
        /// ����ѯ���Ľ������ΪExel����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            CurrentExcel();       
        }


        private void Menu_Sy_PowerSet_Click(object sender, EventArgs e)
        {
            frmPowerSet power = new frmPowerSet();
            power.LoginName = this._loginid;
            power.ShowDialog();
        }
  

        private void toolbtnExcel_Click(object sender, EventArgs e)
        {
            SelectedExcel();

        }

        private void Menu_Excel_Current_Click(object sender, EventArgs e)
        {
            CurrentExcel();
        }

        private void Menu_Excel_Selected_Click(object sender, EventArgs e)
        {
            SelectedExcel();
        }

        private void Menu_Excel_Type_Click(object sender, EventArgs e)
        {
            CurrentExcelInType();
        }

        private void Menu_Excel_ScType_Click(object sender, EventArgs e)
        {
            ScExcelInType();
        }

        private void toolbtnScExcel_Click(object sender, EventArgs e)
        {
            ScExcelInType();
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            if (!query_flag)
            {
                query_flag = true;

                DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId,_power);

                if (dat != null)
                {
                    TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��

                    //������
                    dbgEq.DataSource = dat.DefaultView;
                    AvailableColumns.Clear();
                    foreach (DataGridViewColumn c in dbgEq.Columns)
                    {
                        if (!c.Visible) continue;
                        AvailableColumns.Add(c.HeaderText);
                    }
                    foreach (string field in AvailableColumns)
                    {
                        if (!SelectedColumns.Contains(field))
                            dbgEq.Columns.Remove(field);
                    }
                    List<string> SelectedItem = new List<string>();
                    foreach (string key in Sorts.Keys)
                    {
                        SelectedItem.Add(key);
                    }
                    foreach (string field in SelectedItem)
                    {
                        Sorts[field] = null;
                        SortsString[field] = null;
                        sortButtons[field].sortHelper = new ZCGridSortHelper();
                    }
                    Sorts.Clear();
                    SortsString.Clear();
                }
                this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
                this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";

                ZCGridColumnSortButton btnSort = null;
                foreach (DataGridViewColumn c in dbgEq.Columns)
                {
                    if (!c.Visible) continue;
                    if (sortButtons.ContainsKey(c.HeaderText)) continue;
                    btnSort = new ZCGridColumnSortButton();
                    btnSort.Text = ".";
                    btnSort.Click += btnSort_Click;
                    btnSort.Size = new Size(16, 16);
                    btnSort.MinimumSize = btnSort.Size;
                    btnSort.sortHelper = new ZCGridSortHelper();
                    this.sortButtons.Add(c.HeaderText, btnSort);
                    this.dbgEq.Controls.Add(btnSort);
                    btnSort.Visible = true;
                    btnSort = this.sortButtons[c.HeaderText];
                    btnSort.Column = dbgEq.Columns[c.Index];
                    
                }
                SetupControlsPosition();
                this.toolStripButton2.Enabled = false;
                this.toolbtnSearchAll.Enabled = false;
            }
            else
            {
                query_flag = false;
                if (this.frmSort != null)
                    frmSort.Close();
                foreach (string key in sortButtons.Keys)
                {
                    sortButtons[key].Dispose();
                }
                sortButtons.Clear();
                List<string> SelectedItem = new List<string>();
                foreach (string key in Sorts.Keys)
                {
                    SelectedItem.Add(key);
                }
                foreach (string field in SelectedItem)
                {
                    Sorts[field] = null;
                    SortsString[field] = null;
                }
                Sorts.Clear();
                SortsString.Clear();
                this.toolStripButton2.Enabled = true;
                this.toolbtnSearchAll.Enabled = true;
            }

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (!(this.dbgEq.DataSource is DataView))
            {
                MessageBox.Show("��Ҫ��ZCGrid.DataSource���ó�DataView");
                return;
            }
            ZCGridColumnSortButton btn = sender as ZCGridColumnSortButton;
            btn.Checked = !btn.Checked;
            if (frmSort == null || frmSort.IsDisposed)
            {
                frmSort = new ZCGridSortForm(btn, sortButtons, this.Sorts, dbgEq, SortsString);
            }
            if (btn.Checked)
            {
                frmSort.ResetShow(btn);
            }
            else
            {
                frmSort.Visible = false;
            }
        }
        private void SetupControlsPosition()
        {
            SetupSortButtonsPosition();
            RefreshControls();
        }
        private void SetupSortButtonsPosition()
        {
            foreach (string columnName in SelectedColumns)
            {
                if (this.dbgEq.Columns.Contains(columnName) == false || this.sortButtons.ContainsKey(columnName) == false) continue;
                DataGridViewColumn col = this.dbgEq.Columns[columnName];

                ZCGridColumnSortButton btnSort = this.sortButtons[columnName];
                Rectangle r = this.dbgEq.GetCellDisplayRectangle(col.DisplayIndex, -1, false);
                btnSort.Left = r.Right - btnSort.Width - 2;
                btnSort.Top = r.Bottom - btnSort.Height - 2;
            }
        }
        private void RefreshControls()
        {
            foreach (Control c in this.Controls)
                c.Refresh();
        }
        private void HideSortForm()
        {
            if (this.frmSort != null && this.frmSort.IsDisposed == false && this.frmSort.Visible)
                this.frmSort.Visible = false;
        }
        private void dbgEq_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SetupControlsPosition();
        }

        private void dbgEq_Scroll(object sender, ScrollEventArgs e)
        {
            SetupControlsPosition();
        }

        private void dbgEq_SizeChanged(object sender, EventArgs e)
        {
            SetupControlsPosition();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {
                TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��

                //������
                dbgEq.DataSource = dat.DefaultView;
                AvailableColumns.Clear();
                foreach (DataGridViewColumn c in dbgEq.Columns)
                {
                    if (!c.Visible) continue;
                    AvailableColumns.Add(c.HeaderText);
                }
                foreach (string field in AvailableColumns)
                {
                    if(!SelectedColumns.Contains(field))
                        dbgEq.Columns.Remove(field);
                }
                List<string> SelectedItem = new List<string>();
                foreach (string key in Sorts.Keys)
                {
                    SelectedItem.Add(key);
                }
                foreach (string field in SelectedItem)
                {
                    Sorts[field] = null;
                    SortsString[field] = null;
                    sortButtons[field].sortHelper = new ZCGridSortHelper();
                }
                Sorts.Clear();
                SortsString.Clear();
            }
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";
        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            this.DataRefresh();
            frmSelectItem dlg = new frmSelectItem(AvailableColumns, SelectedColumns, dbgEq);
            dlg.ShowDialog();
        }
        private void Print_button_Click(object sender, EventArgs e)
        {
            frmPrintOptions dlg = new frmPrintOptions(dbgEq);
            dlg.ShowDialog();
        }

        private void toolbtnAudit_Click(object sender, EventArgs e)
        {
            frmAudit dlg = new frmAudit(_user, _loginid, _departId, _power);
            dlg.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmPrintOptions dlg = new frmPrintOptions(dbgEq);
            dlg.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.DataRefresh();
            frmSelectItem dlg = new frmSelectItem(AvailableColumns, SelectedColumns, dbgEq);
            dlg.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmAudit dlg = new frmAudit(_user, _loginid, _departId, _power);
            dlg.ShowDialog();
        }    
    }
}