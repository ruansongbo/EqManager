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
using RedrawControl;

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
        public Dictionary<String, String> SortsString = new Dictionary<string, string>();
        public ZCGridSortForm frmSort;
        public string[] OrderByString = new string[1];
       
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
        /// �ʲ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">dbg</param>
        private void colEqNo_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)(sender);
            // ȷ���Ƿ�ȷʵ���ڡ��ʲ����롱�����е��еĳ��������ϰ�һ�¡�
            if (e.RowIndex >= 0 && e.ColumnIndex == grid.Columns["�ʲ�����"].Index)
            {
                List<string> EqnoList = new List<string>();
                EqnoList.Add(this.dbgEq.SelectedRows[0].Cells[0].Value.ToString());
                this.UpdateEnter(EqnoList);

            }
        }

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.MenuList = SysUserMgr.GetPower(_loginid);//�õ���¼�û���Ȩ�ޣ���ִ�еĲ�����
            this.initMenu();//���ز˵�
            this.initToolBar();//�����ʲ�����Ĺ�����
            this.InitDbgEq();//�����ʲ���

            this.BuilTree();//������
            this.tvwEqSeach.Nodes[0].Expand();//չ�����ĵ�һ��ڵ�

            this.InitStatusInfo();//����״̬��
            TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��
            this.lblTotalpage.Text = "��"+TotalPage.ToString()+"ҳ";

           

        }
        /// <summary>
        /// ��ӽڵ�
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


            this.BuildState(nodeAll);//����״̬�б�
            this.BuildType(nodeAll);//�����ʲ�����б�
            this.BuildDepart(nodeAll);//�����ʲ������б�
            this.BuildKeepPlace(nodeAll);//���ر���ص��б�
            this.BuildAddType(nodeAll);//����������ʽ�б�
            
        }

        /// <summary>
        /// ����״̬�ڵ�
        /// </summary>
        /// <param name="parent">���ڵ�</param>
        private void BuildState(TreeNode parent)
        {
            TreeNode State = new TreeNode();
            this.AddNode(State, "�ʲ�״̬", 11, parent);
            TreeNode StateIn = new TreeNode();
            TreeNode StateBorrow = new TreeNode();
            TreeNode StateFix = new TreeNode();
            TreeNode StateClear = new TreeNode();
            
            this.AddNode(StateIn, "���", 2, State);
            this.AddNode(StateBorrow, "���", 2, State);
            this.AddNode(StateFix, "ά��", 2, State);
            this.AddNode(StateClear, "ע��", 2, State);


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
        /// ����ʹ�ò��Žڵ�
        /// </summary>
        /// <param name="parent">���ڵ�</param>
        private void BuildDepart(TreeNode parent)
        {
            TreeNode Name = new TreeNode();
            this.AddNode(Name, "ʹ�ò���",5, parent);
            DataTable dt = DepartMgr.GetAll();
            
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
                        this.AddNode(type, dt.Rows[i][0].ToString(),2, Type);

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
                if (e.Node.Parent.Text == "�ʲ�����")
                {
                    this.SearchByEqno(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;
 
                }
                if (e.Node.Parent.Text == "�ʲ�״̬")
                {
                    this.SearchByState(e.Node.Text);
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
                if (e.Node.Parent.Text == "ʹ�ò���")
                {
                    this.SearchByDepart(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "������ʽ")
                {
                    this.searchByGetWay(e.Node.Text);
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
                if (e.Node.Parent.Text == "������")
                {
                    this.SearchByAgent(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
            }
           
        }


        /// <summary>
        /// �������˲���
        /// </summary>
        public void SearchByAgent(string agent)
        {
            DataTable dt = EqMgr.GetInfobyFactor("������",agent,this._departId,this._power);
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
        /// ����ŵص����
        /// </summary>
        private void SearchByKeepPlace(string place)
        {
            DataTable dt = EqMgr.GetInfobyFactor("��ŵص�", place, this._departId, this._power);
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
        /// ��ʹ�ò��Ų���
        /// </summary>
        private void SearchByDepart(string depart)
        {
            DataTable dt = EqMgr.GetInfobyFactor("ʹ�ò���", depart, this._departId, this._power);
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
        private void searchByGetWay(string getway)
        {
            DataTable dt = EqMgr.GetInfobyFactor("ȡ�÷�ʽ", getway, this._departId, this._power);
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
        /// ���ʲ�״̬��ѯ
        /// </summary>
        /// <param name="state"></param>
        private void SearchByState(string state)
        {
            DataTable dt = EqMgr.GetInfobyFactor("״̬", state, this._departId, this._power);
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
            DataTable dt = EqMgr.GetInfobyFactor("�ʲ����", type, this._departId, this._power);
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
        /// ���ʲ��������
        /// </summary>
        private void SearchByEqno(string eqno)
        {
            DataTable dt = EqMgr.GetInfobyFactor("�ʲ�����", eqno, this._departId, this._power);
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
                this.statusInfo.Items[2].Text = dt.Rows[0][1].ToString() + DepartMgr.GetNameFromId(this._departId);
                this.statusInfo.Items[3].Text = dt.Rows[0][3].ToString();
            }
            
            this.statusInfo.Items[0].Text = "����Ա��" +this._loginid+"  " +this._user;
            this.timer.Start();

        }


        /// <summary>
        /// �����ʲ����½���
        /// </summary>
        private void UpdateEnter(List<string> EqnoList)
        {
            
            frmEqUpdate frupdate = new frmEqUpdate(this._user, EqnoList,this._power,1);
            frupdate.Loginid = this._loginid;
            if (frupdate.ShowDialog() == DialogResult.OK)
            {
                this.DataRefresh();
            }
        }

        /// <summary>
        /// �����޸��ʲ�
        /// </summary>
        /// <param name="AssetNo"></param>
        private void UpdateAssetEnter(string AssetNo)
        {
            frmEqUpdate frupdate = new frmEqUpdate(this._user, AssetNo, this._power, 2);
            frupdate.Loginid = this._loginid;
            if (frupdate.ShowDialog() == DialogResult.OK)
            {
                this.DataRefresh();
            }
        }
        /// <summary>
        /// �����ʲ����ý���
        /// </summary>
        private void BoroowEnter()
        {
            if (IsEqAvailable())
            {
                frmBorrow boroow = new frmBorrow();
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
                boroow.Eqno = eqNo;
                boroow.User = this._user;
                boroow.Power = this._power;
                if (boroow.ShowDialog() == DialogResult.OK)
                {
                    DataRefreshBySQL();
                }
            }
            else
            {
                untCommon.InfoMsg("���ʲ�������ò�����");
            }

        }


        /// <summary>
        /// �����ʲ��黹����ά����ɽ��棬��״̬����
        /// </summary>
        private void ReturnEnter()
        {
            DataRow dr = (dbgEq.Rows[dbgEq.CurrentRow.Index].DataBoundItem as DataRowView).Row;
            string eqno = dr.ItemArray[0].ToString();
            string ID;
            string state = dr.ItemArray[59].ToString();
            switch (state)
            {
                case "���":
                    ID = BoroowMgr.GetIDFromEqNo(eqno);
                    if (BoroowMgr.GetStateFromSerialNo(ID).Equals("�ѽ��"))
                    {
                        frmBorrowReturn eqBReturn = new frmBorrowReturn();
                        eqBReturn.User = this._user;
                        eqBReturn.Power = this._power;
                        eqBReturn.ID = ID;
                        eqBReturn.ShowDialog();
                    }
                    else
                        untCommon.InfoMsg("�޷����иò�����");
                    break;
                case "ά��":
                    ID = FixMgr.GetIDFromEqNo(eqno);
                    if (FixMgr.GetStateFromSerialNo(ID).Equals("ά����"))
                    {
                        frmFixReturn eqFReturn = new frmFixReturn();
                        eqFReturn.User = this._user;
                        eqFReturn.Power = this._power;
                        eqFReturn.ID = ID;
                        eqFReturn.ShowDialog();
                    }
                    else
                        untCommon.InfoMsg("�޷����иò�����");
                    break;
                default:
                    untCommon.InfoMsg("�޷����иò�����");
                    break;
            }
        }
        /// <summary>
        /// ���������ʲ�����
        /// </summary>
        private void ClearEnter()
        {
            if (IsEqAvailable())
            {
                frmClear clear = new frmClear();
                //��ѡ�е��ʲ��Ƿ��ܹ�����
                if (this.dbgEq.Rows.Count != 0)//�ʲ��б���������
                {
                    string eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
                    //��������
                    clear.User = this._user;
                    clear.Power = this._power;
                    clear.Eqno = eqno;
                    if (clear.ShowDialog() == DialogResult.OK)
                    {
                        DataRefreshBySQL();
                    }

                }
                else
                {
                    untCommon.InfoMsg("û���ʲ��ɹ�����");
                }
            }
            else
            {
                untCommon.InfoMsg("���ʲ�������ò�����");
            }

        }
        /// <summary>
        /// ����ά���ʲ�����
        /// </summary>
        private void FixEnter()
        {
            if (IsEqAvailable())
            {

                frmFix fix = new frmFix();
                //��ѡ�е��ʲ��Ƿ��ܹ�����
                if (this.dbgEq.Rows.Count != 0)//�ʲ��б���������
                {
                    string eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
                    fix.User = this._user;
                    fix.Power = this._power;
                    fix.Eqno = eqno;
                    if (fix.ShowDialog() == DialogResult.OK)
                    {
                        DataRefreshBySQL();
                    }

                }
                else
                {
                    untCommon.InfoMsg("û���ʲ��ɹ�ά�ޡ�");
                }
            }
            else
            {
                untCommon.InfoMsg("���ʲ�������ò�����");
            }

        }
        /// <summary>
        /// �����ʲ����ý���
        /// </summary>
        private bool IsEqAvailable()
        {
            string eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
            DataTable dt = EqMgr.GetOneEqViewInfo(eqno);
            if (dt != null)
            {
                string status = dt.Rows[0]["״̬"].ToString();
                if (status.Equals("���"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// ��������ά������
        /// </summary>
        private void RemindEnter()
        {
            frmAudit dlg = new frmAudit(_user, _loginid, _departId, _power);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataRefreshBySQL();
            }
        }

        /// <summary>
        /// ���뵼��ȫ���ʲ�
        /// </summary>
        private void AllExcel()
        {
            DataTable dt = EqMgr.getAllEq(this._departId, this._power);
            ExportToExcel(dt, "ȫ���ʲ���Ϣ");
        }

        /// <summary>
        /// ���뵼����ǰ�ʲ����
        /// </summary>
        private void CurrentExcel()
        {
            DataTable dt = DgvMgr.GetTable(this.dbgEq);
            ExportToExcel(dt, "��ǰ�ʲ���Ϣ");
        }

        /// <summary>
        /// ���뵼��ѡ���ʲ����
        /// </summary>
        private void SelectedExcel()
        {
            DataTable dt = DgvMgr.GetSelectedTable(this.dbgEq);
            ExportToExcel(dt, "ѡ���ʲ����");
            
        }

        private void AllExcelInType()
        {
            DataTable dtsource = EqMgr.getAllEq(_departId, _power);
            //�ܱ���û��������һ��
            dtsource.Columns.Add("����");

            List<string> list = EqTypeMgr.GetEqTypes(dtsource);
            List<DataTable> dts = new List<DataTable> { null };
            List<string> headers;

            //ֻ�ܴ�ѭ�����ȸ���һ��λ��ֵ��ԭ���������ˣ���֮�����
            headers = EqTypeMgr.GetHeader(list[0]);
            dts[0] = DgvMgr.GetTable(dtsource, headers, list[0].ToString());

            for (int i = 1; i < list.Count; i++)
            {
                headers = EqTypeMgr.GetHeader(list[i]);
                dts.Add(DgvMgr.GetTable(dtsource, headers, list[i].ToString()));
            }
            ExportToExcelInType(dts, list);
        }

        /// <summary>
        /// ���밴���͵�����ǰ���
        /// </summary>
        private void CurrentExcelInType()
        {
            List<string> list = EqTypeMgr.GetEqTypes(this.dbgEq);
            List<DataTable> dts = new List<DataTable> { null };
            List<string> headers;

            //ֻ�ܴ�ѭ�����ȸ���һ��λ��ֵ��ԭ���������ˣ���֮�����
            headers = EqTypeMgr.GetHeader(list[0]);
            dts[0] = DgvMgr.GetTable(this.dbgEq, headers, list[0].ToString());

            for (int i = 1; i < list.Count; i++)
            {
                headers = EqTypeMgr.GetHeader(list[i]);
                dts.Add(DgvMgr.GetTable(this.dbgEq, headers, list[i].ToString()));                
            }
            ExportToExcelInType(dts, list);
        }

        /// <summary>
        /// ���밴���͵�����ѡ���
        /// </summary>
        private void ScExcelInType()
        {
            List<string> list = EqTypeMgr.GetScEqTypes(this.dbgEq);
            List<DataTable> dts = new List<DataTable> { null };
            List<string> headers = new List<string> { null};

            //ֻ�ܴ�ѭ�����ȸ���һ��λ��ֵ
            headers = EqTypeMgr.GetHeader(list[0]);
            dts[0] = DgvMgr.GetSelectedTable(this.dbgEq, headers, list[0].ToString());

            for (int i = 1; i < list.Count; i++)
            {
                headers = EqTypeMgr.GetHeader(list[i]);
                dts.Add(DgvMgr.GetSelectedTable(this.dbgEq, headers, list[i].ToString()));
            }
            ExportToExcelInType(dts, list);
        }

        

        /// <summary>
        /// ϵͳ��ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Sys_Init_Click(object sender, EventArgs e)
        {
            //ֻ�г����û�����ִ��
            if (this._power != "0")
                return;

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
        /// �����ʲ�������һ��Ϊ������ʽ
        /// </summary>
        private void dbgEqSet()
        {
            //
            DataGridViewLinkColumn colEqNo = new DataGridViewLinkColumn();
            colEqNo.MinimumWidth = 100;
            colEqNo.DataPropertyName = "�ʲ�����";
            colEqNo.HeaderText = "�ʲ�����";
            colEqNo.LinkBehavior = LinkBehavior.AlwaysUnderline;
            colEqNo.LinkBehavior = LinkBehavior.SystemDefault;
            colEqNo.Name = "�ʲ�����";
            colEqNo.SortMode = DataGridViewColumnSortMode.Automatic;
            dbgEq.Columns.Add(colEqNo);
            
            // ���������ӵ� Click �¼���
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
            if (!query_flag)
                DataRefreshBySQL();
            else
                DataRefreshBySQLSort();              
        }
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            this.DataRefresh();
            this.toolStrip3.Enabled = true;
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
        /// ��ʼ���ʲ�����Ĺ�����
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
        /// �������ӱ��
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ExcelName"></param>
        private void ExportToExcel(DataTable dt,string ExcelName)
        {
            string filePath = string.Empty;
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");//��ȡ��ǰʱ����Ϊ�ļ�����һ����
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "��ѡ����ӱ�񱣴�λ��";

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
        /// ����𵼳����ӱ��
        /// </summary>
        /// <param name="dts">DataTable�б�</param>
        /// <param name="ExcelNames">���ӱ����������</param>
        private void ExportToExcelInType(List<DataTable> dts, List<string> ExcelNames)
        {
            string filePath = string.Empty;
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");//��ȡ��ǰʱ����Ϊ�ļ�����һ����
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "��ѡ����ӱ�񱣴�λ��";
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
            frmadd.Power = this._power;
            if (frmadd.ShowDialog() == DialogResult.Cancel)
            {
                this.DataRefresh();
            }
        }

        private void Menu_BaseInfo_Keeper_Click(object sender, EventArgs e)
        {
            frmKeepPlace fk = new frmKeepPlace();
            fk.ShowDialog();
        }

        private void Menu_Eq_Update_Click(object sender, EventArgs e)
        {
            List<string> EqnoList = new List<string>();
            List<string> assertList = new List<string>();
            string assert;
            for (int i = 0; i < dbgEq.SelectedRows.Count; i++)
            {
                DataRow dr = (dbgEq.SelectedRows[i].DataBoundItem as DataRowView).Row;
                EqnoList.Add(dr.ItemArray[0].ToString());
                assertList.Add(dr.ItemArray[3].ToString());
            }
            assert = assertList[0];
            bool flag = true;
            foreach (string str in assertList)
            {
                if (!assert.Equals(str))
                    flag = false;
            }
            if (flag)
                this.UpdateEnter(EqnoList);
            else
                untCommon.InfoMsg("ѡ�����ݲ���ͬʱ�޸�");
           

        }

        private void Menu_Eq_Update_AssetNo_Click(object sender, EventArgs e)
        {
            string AssetNo = this.dbgEq.SelectedRows[0].Cells["����"].Value.ToString();
            this.UpdateAssetEnter(AssetNo);
        }
       
        private void Menu_Eq_Boroow_Click(object sender, EventArgs e)
        {
            this.BoroowEnter();
 
        }
        
        private void Menu_Eq_Clear_Click(object sender, EventArgs e)
        {
            this.ClearEnter();
            
            
        }
        

        private void Menu_Eq_Fix_Click(object sender, EventArgs e)
        {
            this.FixEnter();
        }

        private void Menu_Eq_BorrowLook_Click(object sender, EventArgs e)
        {
            frmBorrowLook fbl = new frmBorrowLook();
            fbl.Power = this._power;
            fbl.DepartId = this._departId;
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
            fcl.Power = this._power;
            fcl.DepartId = this._departId;
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
            frmadd.Power = this._power;
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

        private void toolbtnFix_Click(object sender, EventArgs e)
        {
            this.FixEnter();
        }

        private void Menu_Eq_Import_Click(object sender, EventArgs e)
        {
            frmImport fimport = new frmImport();
            fimport.ShowDialog();
            if (fimport.DialogResult == DialogResult.OK)
            {
                this.Refresh();
            }
        }

        private void Menu_Sys_UserAdd_Click(object sender, EventArgs e)
        {
            frmsysUser user = new frmsysUser();
            user.LoginId = this._loginid;
            user.ShowDialog();
        }

        private void Menu_Sys_Update_Click(object sender, EventArgs e)
        {
            frmUpdateSysUserInfo update = new frmUpdateSysUserInfo(this._loginid, false);
           
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

        private void Menu_Eq_FixLook_Click(object sender, EventArgs e)
        {
            frmFixLook frl = new frmFixLook();
            frl.Power = this._power;
            frl.DepartId = this._departId;
            frl.ShowDialog();
        }
        /// <summary>
        /// ����ѯ���Ľ������ΪExel���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            CurrentExcel();       
        }


        private void Menu_Sy_PowerSet_Click(object sender, EventArgs e)
        {
            frmPowerSet powerset = new frmPowerSet();
            powerset.LoginId = this._loginid;
            powerset.ShowDialog();
        }

        private void Menu_Excel_All_Click(object sender, EventArgs e)
        {
            AllExcel();
        }   


        private void Menu_Excel_Current_Click(object sender, EventArgs e)
        {
            CurrentExcel();
        }

        private void Menu_Excel_Selected_Click(object sender, EventArgs e)
        {
            SelectedExcel();
        }

        private void Menu_Excel_AType_Click(object sender, EventArgs e)
        {
            AllExcelInType();
        }

        private void Menu_Excel_CType_Click(object sender, EventArgs e)
        {
            CurrentExcelInType();
        }

        private void Menu_Excel_SType_Click(object sender, EventArgs e)
        {
            ScExcelInType();
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
                this.toolbtnSelectItem.Enabled = false;
                this.toolbtnSearchAll.Enabled = false;
                this.tvwEqSeach.Enabled = false;
                DataRefreshBySQL();
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
                SortsString.Clear();
                OrderByString[0] = "";
                this.toolbtnSelectItem.Enabled = true;
                this.toolbtnSearchAll.Enabled = true;
                this.tvwEqSeach.Enabled = true;
                DataRefreshBySQL();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //DataRefreshBySQL();
            ZCGridColumnSortButton btn = sender as ZCGridColumnSortButton;
            btn.Checked = !btn.Checked;
            if (frmSort == null || frmSort.IsDisposed)
            {
                frmSort = new ZCGridSortForm(this.dbgEq, this.SortsString, this.sortButtons, this.OrderByString);
                frmSort.UpdateEvent += new ZCGridSortForm.UpdateEventHandler(DataRefreshBySQLSort);
                frmSort.GetRowListEvent += new ZCGridSortForm.GetRowListEventHandler(GetRowListBySQL);
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



        /// <summary>
        /// ��ȡ���б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private List<string> GetRowListBySQL(string Column)
        {
            DataTable dat = EqMgr.getEqRowList(_departId, _power, Column, SortsString);
            List<string> result = new List<string>(); ;
            for (int i = 0; i < dat.Rows.Count; i++)
            {
                result.Add(dat.Rows[i][0].ToString());
            }
            return result;
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



        /// <summary>
        /// ˢ��ɸѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataRefreshBySQL()
        {
            DataTable dat = EqMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��
                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";

        }

        /// <summary>
        /// ˢ��ɸѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataRefreshBySQLSort()
        {
            DataTable dat = EqMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��
                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";
            SetupControlsPosition();
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

        private void toolbtnPrint_Click(object sender, EventArgs e)
        {
            frmPrintOptions dlg = new frmPrintOptions(dbgEq);
            dlg.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmSelectItem dlg = new frmSelectItem(AvailableColumns, SelectedColumns);
            dlg.UpdateEvent += new frmSelectItem.UpdateEventHandler(DataRefreshBySQL);
            dlg.ShowDialog();
        }



        private void Tool_Label_Selected_Click(object sender, EventArgs e)
        {
            frmLabel flabel = new frmLabel();
            flabel.ShowDialog();
            if ( flabel.DialogResult== DialogResult.OK)
            {
                DataTable dt = DgvMgr.GetSelectedTable(this.dbgEq);
                int count = flabel.Count;
                PrintMgr.PrintLabel(dt,count);
            }
        }

        private void Tool_Label_All_Click(object sender, EventArgs e)
        {
            frmLabel flabel = new frmLabel();
            flabel.ShowDialog();
            if (flabel.DialogResult == DialogResult.OK)
            {
                string assetno = this.dbgEq.SelectedRows[0].Cells["����"].Value.ToString();
                DataTable dt = EqMgr.GetAssetInfo(assetno);
                int count = flabel.Count;
                PrintMgr.PrintLabel(dt, count);
            }
        }

        private void Menu_BaseInfo_Maintainer_Click(object sender, EventArgs e)
        {
            frmMaintainer fm = new frmMaintainer();
            fm.ShowDialog();
        }

        private void toolbtnRemind_Click(object sender, EventArgs e)
        {
            this.RemindEnter();
        }

        private void Menu_Sy_Remind_Click(object sender, EventArgs e)
        {
            this.RemindEnter();
        }

        

        private void Menu_Eq_BorrowReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }
        private void toolbtnBorrowReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        private void Menu_Eq_FixReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        private void toolbtnFixReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        private void Tool_Print_Click(object sender, EventArgs e)
        {
            frmPrintOptions dlg = new frmPrintOptions(dbgEq);
            dlg.ShowDialog();
        }

        private void Tool_Excel_Selected_Click(object sender, EventArgs e)
        {
            SelectedExcel();
        }

        private void Tool_Excel_SType_Click(object sender, EventArgs e)
        {
            ScExcelInType();
        }


        /// <summary>
        /// �ʲ�����(�Ҽ�)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Tool_Update_Click(object sender, EventArgs e)
        {
            List<string> EqnoList = new List<string>();
            List<string> assertList = new List<string>();
            string assert;
            for (int i = 0; i < dbgEq.SelectedRows.Count; i++)
            {
                DataRow dr = (dbgEq.SelectedRows[i].DataBoundItem as DataRowView).Row;
                EqnoList.Add(dr.ItemArray[0].ToString());
                assertList.Add(dr.ItemArray[3].ToString());
            }
            assert = assertList[0];
            bool flag = true;
            foreach (string str in assertList)
            {
                if (!assert.Equals(str))
                    flag = false;
            }
            if (flag)
                this.UpdateEnter(EqnoList);
            else
                untCommon.InfoMsg("ѡ�����ݲ���ͬʱ�޸�");
        }

        /// <summary>
        /// �ʲ����£��Ҽ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Borrow_Click(object sender, EventArgs e)
        {
            this.BoroowEnter();
        }

        /// <summary>
        /// �ʲ��黹���Ҽ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Borrow_Return_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        /// <summary>
        /// �ʲ�ά��(�Ҽ�)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Fix_Click(object sender, EventArgs e)
        {
            FixEnter();
        }

        /// <summary>
        /// ά����ɣ��Ҽ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_FixReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        /// <summary>
        /// �ʲ�ע�����Ҽ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Clear_Click(object sender, EventArgs e)
        {
            this.ClearEnter();
        }

        private void Tool_Refresh_Click(object sender, EventArgs e)
        {
            if (!query_flag)
                DataRefreshBySQL();
            else
                DataRefreshBySQLSort();      
        }

    }

    
}