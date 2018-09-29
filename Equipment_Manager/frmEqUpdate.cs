using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using DataBusiness;
using DataEntity;
using DataAccess;

using Spire.Doc;


namespace Equipment_Manager
{
    public partial class frmEqUpdate : Form
    {
        private string _loginid;
        private string _user;
        private string _power;
        private string eqno;//资产编码
        private int count = 1;
        private string photoPath = "";//图片路径
        private bool photo_flag = false;//用于标记图片是否更改

        private List<string> eqnoList = new List<string>();
        
        private string asset;//单号

        //mode=1，直接进行更改
        //mode=2，直接批量更改
        //mode=3，从新增审核处进行更改
        //mode=4，从更新审核处进行更改
        private int mode = 1;
        
        public frmEqUpdate()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
        /// <summary>
        /// 按单号初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public frmEqUpdate(string _user, string Asset,string power,int update_mode)
        {
            InitializeComponent();
            this.asset = Asset;
            if (update_mode == 2)
            {
                DataTable dt = EqMgr.GetAssetInfo(Asset);
                this.eqno = dt.Rows[0]["资产编码"].ToString();
            }
            else
                this.eqno = Asset.Replace('A', 'E');
            this._user = _user;
            this._power = power;
            this.mode = update_mode;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
        /// <summary>
        /// 按编码初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public frmEqUpdate(string _user, List<string> EqnoList,string Power,int update_mode)
        {
            InitializeComponent();
            this.eqnoList = EqnoList;
            this.eqno = EqnoList[0];
            this._user = _user;
            this._power = Power;
            this.mode = update_mode;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
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
        
        public string Eqno
        {
            get { return eqno; }
            set { eqno = value; }
        }

        public string Asset
        {
            get { return asset; }
            set { asset = value; }
        }

        public string Loginid
        {
            get { return _loginid; }
            set { _loginid = value; }
        }

        public string Sysuser
        {
            set
            {
                _user = value;
            }
            get
            {
                return this._user;
            }

        }
        public string Power
        {
            set
            {
                _power = value;
            }
            get
            {
                return this._power;
            }

        }





        private void frmEqUpdate_Load(object sender, EventArgs e)
        {
            //初始化combobox数据源
            initcbx(this.cbxFunds, "Funds");
            initcbx(this.cbxPriceType, "PriceType");
            initcbx(this.cbxUsage, "Usage");
            initcbx(this.cbxDirection, "Direction");
            initcbx(this.cbxBuyWay, "BuyWay");
            initcbx(this.cbxGetWay, "GetWay");
            initcbx(this.cbxCarUse, "CarUse");
            initcbx(this.cbxCarBP, "CarBP");
            initcbx(this.cbxFormation, "Formation");
            initcbx(this.cbxPR, "Pr");
            initcbx(this.cbxCertNature, "CertNature");
            initcbx(this.cbxStructure, "Structure");
            initcbx(this.cbxUnit, "Unit");
            initcbx(this.cbxKeepPlace, "KeepPlace");
            initcbx(this.cbxRelicLv, "RelicLv");
            initcbx(this.cbxCampus, "Campus");
            initcbxEmployee(this.cbxEqKeeper);
            initcbxEmployee(this.cbxPurchaser);

            //根据eqno初始化窗口
            if (this.eqno != "")
            {
                this.DataLoad(); //查出该资产的信息放在相应的控件中
            }
            else
            {
                this.toolEqUpdate.Enabled = false;
                for (int index = 0; index < this.panel1.Controls.Count; index++)
                {
                    this.panel1.Controls[index].Enabled = false;
                }

            }

        }

        /// <summary>
        /// 初始化资产信息表
        /// </summary>
        private void DataLoad()
        {
            DataTable dt = EqMgr.GetOneEqInfo(this.eqno);

            if (dt != null && dt.Rows.Count != 0)
            {

                this.txtEqNo.Text = this.eqno;
                this.txtEqName.Text = dt.Rows[0][1].ToString();
                this.txtEduNo.Text = dt.Rows[0][2].ToString();
                this.txtAssetNo.Text = dt.Rows[0][3].ToString();
                this.cbxEqType.Text = dt.Rows[0][4].ToString();
                this.txtGB.Text = dt.Rows[0][5].ToString();
                this.cbxCampus.Text = dt.Rows[0][28].ToString();
                DataTable Depdt = DepartMgr.GetAllDepartment();
                this.txtDepartment.Text = this.ID2name(Depdt, dt.Rows[0][26].ToString(), "id");
                //第8位是部门的id，这里不显示
                this.cbxKeepPlace.Text = dt.Rows[0][29].ToString();
                this.cbxEqKeeper.Text = dt.Rows[0][25].ToString();
                this.cbxPurchaser.Text = dt.Rows[0][13].ToString();
                this.txtAgent.Text = dt.Rows[0][14].ToString();
                this.cbxUnit.Text = dt.Rows[0][7].ToString();
                this.cbxFunds.Text = dt.Rows[0][32].ToString();
                this.cbxPriceType.Text = dt.Rows[0][22].ToString();
                this.txtPrice.Text = dt.Rows[0][23].ToString();
                this.txtUSDPrice.Text = dt.Rows[0][24].ToString();
                this.txtBrand.Text = dt.Rows[0][15].ToString();
                this.txtModel.Text = dt.Rows[0][16].ToString();
                this.txtCountry.Text = dt.Rows[0][17].ToString();
                this.txtMfrs.Text = dt.Rows[0][18].ToString();
                this.txtProductNo.Text = dt.Rows[0][19].ToString();
                this.txtSupplier.Text = dt.Rows[0][21].ToString();
                this.cbxUsage.Text = dt.Rows[0][6].ToString();
                this.cbxDirection.Text = dt.Rows[0][8].ToString();
                this.cbxBuyWay.Text = dt.Rows[0][9].ToString();
                this.cbxGetWay.Text = dt.Rows[0][10].ToString();
                this.txtCN.Text = dt.Rows[0][30].ToString();
                this.txtInvNo.Text = dt.Rows[0][31].ToString();
                this.cbxRelicLv.Text = dt.Rows[0][33].ToString();
                this.txtRegAuz.Text = dt.Rows[0][34].ToString();
                this.txtPatNo.Text = dt.Rows[0][36].ToString();
                this.txtApvNo.Text = dt.Rows[0][37].ToString();
                this.txtMgtAgency.Text = dt.Rows[0][38].ToString();
                this.cbxCarUse.Text = dt.Rows[0][39].ToString();
                this.cbxCarBP.Text = dt.Rows[0][40].ToString();
                this.txtLicNo.Text = dt.Rows[0][41].ToString();
                this.txtDSPL.Text = dt.Rows[0][42].ToString();
                this.txtEngNo.Text = dt.Rows[0][43].ToString();
                this.cbxFormation.Text = dt.Rows[0][44].ToString();
                this.txtArea.Text = dt.Rows[0][45].ToString();
                this.cbxPR.Text = dt.Rows[0][46].ToString();
                this.txtCertNo.Text = dt.Rows[0][47].ToString();
                this.txtCertLim.Text = dt.Rows[0][49].ToString();
                this.txtCertProve.Text = dt.Rows[0][50].ToString();
                this.txtAddress.Text = dt.Rows[0][51].ToString();
                this.cbxCertNature.Text = dt.Rows[0][52].ToString();
                this.txtTenuArea.Text = dt.Rows[0][53].ToString();
                this.txtTenuPrice.Text = dt.Rows[0][54].ToString();
                this.cbxStructure.Text = dt.Rows[0][55].ToString();
                this.txtBelongTo.Text = dt.Rows[0][56].ToString();
                //57是图片
                this.txtRemark.Text = dt.Rows[0][59].ToString();

                if (dt.Rows[0][11].ToString() != "")
                {
                    this.dtpGetDate.Value = DateTime.Parse(dt.Rows[0][11].ToString());
                    this.dtpGetDate.Checked = true;
                }
                if (dt.Rows[0][12].ToString() != "")
                {
                    this.dtpAddDate.Value = DateTime.Parse(dt.Rows[0][12].ToString());
                    this.dtpAddDate.Checked = true;
                }
                if (dt.Rows[0][20].ToString() != "")
                {
                    this.dtpBirthday.Value = DateTime.Parse(dt.Rows[0][20].ToString());
                    this.dtpBirthday.Checked = true;
                }
                if (dt.Rows[0][27].ToString() != "")
                {
                    this.dtpSvcDate.Value = DateTime.Parse(dt.Rows[0][27].ToString());
                    this.dtpSvcDate.Checked = true;
                }
                if (dt.Rows[0][35].ToString() != "")
                {
                    this.dtpRegTime.Value = DateTime.Parse(dt.Rows[0][35].ToString());
                    this.dtpRegTime.Checked = true;
                }
                if (dt.Rows[0][48].ToString() != "")
                {
                    this.dtpIssueDate.Value = DateTime.Parse(dt.Rows[0][48].ToString());
                    this.dtpIssueDate.Checked = true;
                }

            }

            DataTable dtPhoto = EqMgr.GetPhoto(this.eqno);
            MemoryStream photoStream;

            if (dtPhoto != null)
            {
                if (!(dtPhoto.Rows[0][0] is DBNull))
                {
                    byte[] imageBytes = (byte[])(dtPhoto.Rows[0][0]);

                    if (imageBytes == null || imageBytes.Length == 0)
                    {
                        return;
                    }




                    photoStream = new MemoryStream(imageBytes, 0, imageBytes.Length);


                    this.pbPhoto.Image = Image.FromStream(photoStream);
                }
                else
                {
                    this.pbPhoto.Image = null;

                }
            }
            else
            {
                this.pbPhoto.Image = null;
            }
        }
        /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        private string ID2name(DataTable dt, string value, string column)
        {
            dt.PrimaryKey = new System.Data.DataColumn[] { dt.Columns[column] };
            System.Data.DataRow row = dt.Rows.Find(value);
            return row.ItemArray[0].ToString();
        }
        public DataTable GetData(string sql)
        {

            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        private void initcbx(ComboBox cbx, string dbtable)
        {
            string sql = string.Format("select * from {0}", dbtable);
            DataTable dt = GetData(sql);
            cbx.DataSource = dt;
            cbx.DisplayMember = dt.Columns[1].ToString();
            cbx.ValueMember = dt.Columns[1].ToString();
            cbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbx.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbx.Text = "";
        }

        private void initcbxEmployee(ComboBox cbx)
        {
            string sql = "select * from Employee";
            DataTable dt = GetData(sql);
            cbx.DataSource = dt;
            cbx.DisplayMember = dt.Columns[1].ToString();
            cbx.ValueMember = dt.Columns[0].ToString();
            cbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbx.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbx.Text = "";
        }

        //根据资产类别的不同锁定不同区域
        private void cbxEqType_SelectedValueChanged(object sender, System.EventArgs e)
        {
            
            switch (this.cbxEqType.Text)
            {
                case "土地、房屋及构筑物":
                    this.cbxRelicLv.Enabled = false;
                    this.gbCar.Enabled = false;
                    this.gbEstate.Enabled = true;
                    this.gbIAsset.Enabled = false;
                    break;
                case "通用设备(车辆)":
                    this.cbxRelicLv.Enabled = false;
                    this.gbCar.Enabled = true;
                    this.gbEstate.Enabled = false;
                    this.gbIAsset.Enabled = false;
                    break;
                case "文物和陈列品": 
                    this.cbxRelicLv.Enabled = true;
                    this.gbCar.Enabled = false;
                    this.gbEstate.Enabled = false;
                    this.gbIAsset.Enabled = false;
                    break;
                case "无形资产":
                    this.cbxRelicLv.Enabled = false;
                    this.gbCar.Enabled = false;
                    this.gbEstate.Enabled = false;
                    this.gbIAsset.Enabled = true;
                    break;
                default:
                    this.cbxRelicLv.Enabled =false;
                    this.gbCar.Enabled = false;
                    this.gbEstate.Enabled = false;
                    this.gbIAsset.Enabled = false;
                    break;

            }
        
        }



        

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg|图片文件(*.gif)|*.gif|图片文件(*.bmp)|*.bmp|图片文件(*.png)|*.png";//“文本文件(*.txt)|*.txt|所有文件(*.*)|*.*”

            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                photoPath = openFileDialog1.FileName;
                long lSize = new FileInfo(photoPath).Length;
                if (lSize < 204800)
                {
                    this.pbPhoto.Image = Image.FromFile(photoPath);
                    photo_flag = true;
                }
                else
                    untCommon.ErrorMsg("选择的图片大于200KB");
            }
        }

        private void btnDelPhoto_Click(object sender, EventArgs e)
        {
            this.pbPhoto.Image = null;
            photo_flag = true;
        }


        //保存修改的信息
        private void toolEqUpdate_Click(object sender, EventArgs e)
        {
            if (this.checkInput())
            {
                Equipment eq = new Equipment();
                eq.EqNo = this.txtEqNo.Text;
                eq.EqName = this.txtEqName.Text;
                eq.AssetNo = this.txtAssetNo.Text;
                eq.EduNo = this.txtEduNo.Text;
                eq.EqType = this.cbxEqType.Text;
                eq.Gb = this.txtGB.Text;
                eq.Usage = this.cbxUsage.Text;
                eq.Unit = this.cbxUnit.Text;
                eq.Direction = this.cbxDirection.Text;
                eq.BuyWay = this.cbxBuyWay.Text;
                eq.GetWay = this.cbxGetWay.Text;
                eq.Purchaser = this.cbxPurchaser.Text;
                eq.Agent = this.txtAgent.Text;
                eq.Brand = this.txtBrand.Text;
                eq.Model = this.txtModel.Text;
                eq.Country = this.txtCountry.Text;
                eq.Mfrs = this.txtMfrs.Text;
                eq.ProductNo = this.txtProductNo.Text;
                eq.Supplier = this.txtSupplier.Text;
                eq.PriceType = this.cbxPriceType.Text;
                eq.EqKeeper = this.cbxEqKeeper.Text;
                eq.Department = DepartMgr.GetIdFromName(this.txtDepartment.Text);
                eq.Campus = this.cbxCampus.Text;
                eq.KeepPlace = this.cbxKeepPlace.Text;
                eq.Cn = this.txtCN.Text;
                eq.InvNo = this.txtInvNo.Text;
                eq.Funds = this.cbxFunds.Text;
                eq.BelongTo = "";
                eq.Photo = "";
                eq.Remark = this.txtRemark.Text;

                eq.Photo = this.getPhotoPath();
                

                if (this.dtpGetDate.Checked == true)
                    eq.GetDate = this.dtpGetDate.Value.ToShortDateString();
                else
                    eq.GetDate = "";

                if (dtpAddDate.Checked == true)
                    eq.AddDate = this.dtpAddDate.Value.ToShortDateString();
                else
                    eq.AddDate = "";

                if (this.dtpBirthday.Checked == true)
                    eq.Birthday = this.dtpBirthday.Value.ToShortDateString();
                else
                    eq.Birthday = "";

                if (this.dtpSvcDate.Checked == true)
                    eq.SvcDate = this.dtpSvcDate.Value.ToShortDateString();
                else
                    eq.SvcDate = "";
                /*****************************根据资产类别判断所要填的项********************************************/
                //资产类别为“土地、房屋及构筑物”时
                if (eq.EqType == "土地、房屋及构筑物")
                {
                    eq.Pr = this.cbxPR.Text;
                    eq.Address = this.txtAddress.Text;
                    eq.CertNature = this.cbxCertNature.Text;
                    eq.Structure = this.cbxStructure.Text;

                    //有产权时以下四项才可以被填写
                    if (eq.Pr == "有产权")
                    {

                        if (this.txtCertNo.Text.Trim() == "")
                        {
                            untCommon.InfoMsg("请输入权属证号");
                            return;
                        }
                        else
                            eq.CertNo = this.txtCertNo.Text;

                        if (this.dtpIssueDate.Checked == false)
                        {
                            untCommon.InfoMsg("请选择发证日期");
                            return;
                        }
                        else
                            eq.IssueDate = this.dtpIssueDate.Value.ToShortDateString();

                        if (this.txtCertProve.Text.Trim() == "")
                        {
                            untCommon.InfoMsg("请输入权属证明");
                            return;
                        }
                        else
                            eq.CertProve = this.txtCertProve.Text;

                        try
                        {
                            eq.CertLim = int.Parse(this.txtCertLim.Text);
                        }
                        catch (FormatException)
                        {
                            untCommon.ErrorMsg("权属年限请输入数字。");
                            return;

                        }
                    }
                    else
                    {
                        eq.CertNo = "";
                        eq.IssueDate = "";
                        eq.CertProve = "";
                        eq.CertLim = 0;
                    }
                    try
                    {

                        eq.Area = double.Parse(this.txtArea.Text);

                    }
                    catch (FormatException)
                    {
                        untCommon.ErrorMsg("建筑/土地面积请输入数字。");
                        return;

                    }

                    try
                    {

                        eq.TenuArea = double.Parse(this.txtTenuArea.Text);
                    }
                    catch (FormatException)
                    {
                        untCommon.ErrorMsg("自用面积请输入数字。");
                        return;

                    }

                    try
                    {
                        eq.TenuPrice = double.Parse(this.txtTenuPrice.Text);
                    }
                    catch (FormatException)
                    {
                        untCommon.ErrorMsg("自用价值请输入数字。");
                        return;

                    }


                }
                else
                {
                    eq.Pr = "";
                    eq.CertNo = "";
                    eq.IssueDate = "";
                    eq.CertProve = "";
                    eq.Address = "";
                    eq.CertNature = "";
                    eq.Structure = "";
                    eq.Area = 0;
                    eq.TenuArea = 0;
                    eq.TenuPrice = 0;
                    eq.CertLim = 0;
                }

                //资产类别为"通用设备(车辆)"
                if (eq.EqType == "通用设备(车辆)")
                {
                    eq.CarUse = this.cbxCarUse.Text;
                    eq.CarBP = this.cbxCarBP.Text;
                    eq.LicNo = this.txtLicNo.Text;
                    eq.Dspl = this.txtDSPL.Text;
                    eq.EngNo = this.txtEngNo.Text;
                    eq.Formation = this.cbxFormation.Text;
                }
                else
                {
                    eq.CarUse = "";
                    eq.CarBP = "";
                    eq.LicNo = "";
                    eq.Dspl = "";
                    eq.EngNo = "";
                    eq.Formation = "";
                }

                //资产类别为"无形资产"
                if (eq.EqType == "无形资产")
                {
                    eq.RegAuz = this.txtRegAuz.Text;
                    eq.PatNo = this.txtPatNo.Text;
                    eq.ApvNo = this.txtApvNo.Text;
                    eq.MgtAgency = this.txtMgtAgency.Text;

                    if (this.dtpRegTime.Checked == true)
                        eq.RegTime = this.dtpRegTime.Value.ToShortDateString();
                    else
                        eq.RegTime = "";
                }
                else
                {
                    eq.RegAuz = "";
                    eq.RegTime = "";
                    eq.PatNo = "";
                    eq.ApvNo = "";
                    eq.MgtAgency = "";
                }
                //资产类别为"文物和陈列品"
                if (eq.EqType == "文物和陈列品")
                {
                    eq.RelicLv = this.cbxRelicLv.Text;
                }
                else
                {
                    eq.RelicLv = "";
                }


                /*************************************判断结束******************************************************/
                try
                {

                    count = int.Parse(this.txtCount.Text);
                }
                catch (FormatException)
                {
                    untCommon.ErrorMsg("数量请输入数字。");
                    return;

                }
                try
                {

                    eq.Price = double.Parse(this.txtPrice.Text);
                }
                catch (FormatException)
                {
                    untCommon.ErrorMsg("价值请输入数字。");
                    return;
                }

                try
                {
                    if (this.txtUSDPrice.Text.Trim() != "")
                        eq.UsdPrice = double.Parse(this.txtUSDPrice.Text);
                    else
                        eq.UsdPrice = 0;
                }
                catch (FormatException)
                {
                    untCommon.ErrorMsg("美金单价请输入数字。");
                    return;

                }

                //判断更新模式
                switch (this.mode)
                {
                    //直接修改
                    case 1:
                            {
                                int error = 0;
                                //0级和1级用户直接更新
                                if (_power == "0" || _power == "1")
                                {
                                    
                                    foreach (string field in eqnoList)
                                    {
                                        eq.EqNo = field;
                                        eq.State = "入库";
                                        if (EqMgr.Update(eq))
                                        {
                                            //
                                        }
                                        else
                                        {
                                            error++;
                                        }

                                    }
                                    if (error == 0)
                                    {
                                        untCommon.InfoMsg("更新成功");
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        untCommon.InfoMsg("操作失败，失败数目为：" + error.ToString());
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    DataTable Empdt = EmployeeMgr.GetAllName();
                                    foreach (string field in eqnoList)
                                    {
                                        eq.EqNo = "U" + this.name2ID(Empdt, this._user, "name") + DateTime.Now.ToString("yyyyMMddHHmmss") + field;
                                        eq.State = "更新待审核";
                                        if (EqMgr.Add(eq))
                                        {
                                            //

                                        }
                                        else
                                        {
                                            error++;
                                        }
                                    }
                                    if (error == 0)
                                    {
                                        untCommon.InfoMsg("更新成功,请等待审核");
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        untCommon.InfoMsg("操作失败，失败数目为：" + error.ToString());
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                }

                                break;
                            }


                    //直接批量修改
                    case 2:
                            {
                                string question = "确定要更改这单数量为: ";
                                question += EqMgr.AssetCount(this.asset).ToString() + " 的资产吗?";
                                if (untCommon.QuestionMsg(question))
                                {
                                    if (_power == "0" || _power == "1")
                                    {
                                        eq.State = "入库";

                                        if (EqMgr.UpdateByAsset(eq, asset))
                                        {
                                            untCommon.InfoMsg("更新成功");
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                        else
                                        {
                                            untCommon.InfoMsg("更新失败。");
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }

                                    }
                                    else
                                    {

                                        List<string> list = EqMgr.GetEqNoByAssetNo(this.asset);
                                        DataTable Empdt = EmployeeMgr.GetAllName();
                                        int error = 0;
                                        if(list!=null)
                                            foreach (string field in list)
                                            {
                                                eq.EqNo = "U" + this.name2ID(Empdt, this._user, "name") + DateTime.Now.ToString("yyyyMMddHHmmss") + field;
                                                eq.State = "更新待审核";
                                                if (EqMgr.Add(eq))
                                                {


                                                }
                                                else
                                                {
                                                    error++;
                                                }
                                            }
                                        if (error == 0)
                                        {
                                            untCommon.InfoMsg("更新信息提交成功，请等待审核");
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                        else
                                        {
                                            untCommon.InfoMsg("更新信息发生错误\n" + "失败数为: " + error.ToString());
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                    }
                                }

                                
                                break;
                            }
                    //从新增审核处修改
                    case 3:
                            {
                                eq.State = "新增待审核";
                                if (EqMgr.UpdateByAsset(eq, asset))
                                {
                                    untCommon.InfoMsg("更新信息提交成功，请等待审核");
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    untCommon.InfoMsg("更新失败。");
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                break;
                            }
                    //从更新审核处修改
                    case 4:
                            {
                                int error = 0;
                                DataTable Empdt = EmployeeMgr.GetAllName();
                                foreach (string field in eqnoList)
                                {                                                                        
                                    eq.EqNo = field;
                                    eq.State = "更新待审核";
                                    if (EqMgr.Update(eq))
                                    {
                                        //

                                    }
                                    else
                                    {
                                        error++;
                                    }
                                    
                                }

                                if (error == 0)
                                {
                                    untCommon.InfoMsg("更新成功,请等待审核");
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    untCommon.InfoMsg("操作失败，失败数目为：" + error.ToString());
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                break;
                            }
                        
                }
                    
                
            }
        }


        /*******下面是全部dateTimerPicker控件的ValueChanged事件,在选择日期时触发*************************************/
        private void dtpRegTime_ValueChanged(object sender, EventArgs e)
        {
            this.dtpRegTime.Format = DateTimePickerFormat.Long;
            this.dtpRegTime.CustomFormat = null;
        }
        private void dtpGetDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpGetDate.Format = DateTimePickerFormat.Long;
            this.dtpGetDate.CustomFormat = null;
        }
        private void dtpAddDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpAddDate.Format = DateTimePickerFormat.Long;
            this.dtpAddDate.CustomFormat = null;
        }
        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            this.dtpBirthday.Format = DateTimePickerFormat.Long;
            this.dtpBirthday.CustomFormat = null;
        }
        private void dtpSvcDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpSvcDate.Format = DateTimePickerFormat.Long;
            this.dtpSvcDate.CustomFormat = null;
        }
        private void dtpIssueDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpIssueDate.Format = DateTimePickerFormat.Long;
            this.dtpIssueDate.CustomFormat = null;
        }

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
        /// 检查输入是否合法
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtEqName.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入资产名称");
                return false;
            }
            if (this.cbxEqType.Text.Trim() == "")
            {
                untCommon.InfoMsg("请选择资产类别");
                return false;
            }
            if (this.txtGB.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入国标码");
                return false;
            }
            if (this.txtCount.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入资产的数量。");
                return false;
            }
            if (this.txtPrice.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入资产的价值。");
                return false;
            }

            if (this.txtDepartment.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入部门名称");
                return false;
            }
            else
            {
                string depart = DepartMgr.GetIdFromName(this.txtDepartment.Text);
                if (depart == "")
                {
                    untCommon.InfoMsg("没有这个部门");
                    return false;
                }
            }
            
            if (double.Parse(this.txtPrice.Text) <= 0)
            {
                untCommon.InfoMsg("价值请输入大于零的数字");
                return false;
            }
            if (int.Parse(this.txtCount.Text) <= 0)
            {
                untCommon.InfoMsg("价值请输入大于零的数字");
                return false;
            }


            if (this.txtUSDPrice.Text.Trim()!="" && double.Parse(this.txtUSDPrice.Text) <= 0)
            {
                untCommon.InfoMsg("美金单价请输入大于零的数字");
                return false;
            }

            if (this.txtArea.Text.Trim() != "" && double.Parse(this.txtArea.Text) <= 0)
            {
                untCommon.InfoMsg("土地/建筑面积请输入大于零的数字");
                return false;
            }
            if (this.txtTenuArea.Text.Trim() != "" && double.Parse(this.txtTenuArea.Text) <= 0)
            {
                untCommon.InfoMsg("自用面积请输入大于零的数字");
                return false;
            }
            if (this.txtTenuPrice.Text.Trim() != "" && double.Parse(this.txtTenuPrice.Text) <= 0)
            {
                untCommon.InfoMsg("自用价值请输入大于零的数字");
                return false;
            }
            if (this.txtCertLim.Text.Trim() != "" && double.Parse(this.txtCertLim.Text) <= 0)
            {
                untCommon.InfoMsg("权属年限请输入大于零的数字");
                return false;
            }

            return true;
        
        }


        //返回图片路径
        private string getPhotoPath()
        {
            //如果图片未修改
            if (!photo_flag)
            {
                photoPath = "Photo" + this.eqno;
                
            }
            return photoPath;
        }
        

        private void toolCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void toolEqAdd_Click(object sender, EventArgs e)
        {
            frmEqAdd frmadd = new frmEqAdd();
            frmadd.Sysuser = this._user;
            frmadd.Power = this._power;
            frmadd.ShowDialog();
            this.Close();
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            //Create word document
            Document document = new Document();

            //Load the document from disk.
            document.LoadFromFile(@".\ww.docx");

            //Replace text
            document.Replace("<#1>", " ", false, true);
            document.Replace("<#2>", this.txtDepartment.Text, false, true);
            document.Replace("<#3>", this.dtpAddDate.Text, false, true);
            document.Replace("<#4>", " ", false, true);
            document.Replace("<#5>", this.txtEqName.Text, false, true);
            document.Replace("<#6>", this.txtPrice.Text, false, true);
            document.Replace("<#7>", this.cbxEqKeeper.Text, false, true);
            document.Replace("<#8>", this.txtModel.Text, false, true);
            document.Replace("<#9>", this.txtUSDPrice.Text, false, true);
            document.Replace("<#10>", " ", false, true);
            document.Replace("<#11>", " ", false, true);
            document.Replace("<#12>", this.cbxFunds.Text, false, true);
            document.Replace("<#13>", " ", false, true);
            document.Replace("<#14>", this.txtCountry.Text, false, true);
            document.Replace("<#15>", " ", false, true);
            document.Replace("<#16>", this.txtInvNo.Text, false, true);
            document.Replace("<#17>", " ", false, true);
            document.Replace("<#18>", " ", false, true);
            document.Replace("<#19>", " ", false, true);
            document.Replace("<#20>", " ", false, true);
            document.Replace("<#21>", " ", false, true);
            document.Replace("<#22>", " ", false, true);
            document.Replace("<#23>", " ", false, true);
            document.Replace("<#24>", " ", false, true);
            document.Replace("<#25>", " ", false, true);
            document.Replace("<#26>", " ", false, true);
            document.Replace("<#27>", " ", false, true);
            document.Replace("<#28>", " ", false, true);
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "请选择网页保存位置";
            DialogResult result = BrowDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Save doc file.
                document.SaveToFile(BrowDialog.SelectedPath + "\\" + this.txtEqName.Text + ".docx", FileFormat.Docx);
                Form1 dlg = new Form1(BrowDialog.SelectedPath + "\\" + this.txtEqName.Text + ".docx");
                dlg.ShowDialog();
            }
        }

        private void btnEduNo_Click(object sender, EventArgs e)
        {
            OpenTree(this.txtEduNo, "EduNo", "EduName");
        }

        private void btnGB_Click(object sender, EventArgs e)
        {
            OpenTree(this.txtGB, "Gb", "GbName");
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            OpenTree(this.txtDepartment, "Department", "departName");
        }

        private void OpenTree(TextBox txt, string dbtable, string key)
        {
            frmTree ftree = new frmTree();
            ftree.Dbtable = dbtable;
            ftree.Key = key;
            ftree.frmTree_Load();
            ftree.ShowDialog();
            if (ftree.DialogResult == DialogResult.OK)
                txt.Text = ftree.NodeNum;
        }

    }

    
}
