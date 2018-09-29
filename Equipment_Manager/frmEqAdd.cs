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


namespace Equipment_Manager
{
    public partial class frmEqAdd : Form
    {
        private string _loginid;
        private string _user;
        private string _power;
        private int count = 1;
        private string random = "";//随机序列号
        private string photoPath = "";//图片路径
        public frmEqAdd()
        {
            InitializeComponent();
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

        private void frmEqAdd_Load(object sender, EventArgs e)
        {
            initcbx(this.cbxFunds,"Funds");
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

            this.txtDepartment.Text = SysUserMgr.GetDepartmentIDByUser(this._user);
            this.txtDepartment.Text = DepartMgr.GetNameFromId(this.txtDepartment.Text);
            this.dtpAddDate.Text = DateTime.Now.ToShortDateString();
            this.txtAgent.Text = this._user;
            //cbxEqKeeper的初始化与其他不同，其ValueMember和DisplayMember是不一样的
            initcbxEmployee(this.cbxEqKeeper);
            initcbxEmployee(this.cbxPurchaser);
        }



        private void initcbx(ComboBox cbx,string dbtable)
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


        

        /// <summary>
        /// 自动生成资产编码
        /// </summary>
        private void SetNo()
        {
            string time=DateTime.Now.ToString("yyyyMMddHHmmss");
            random = _loginid + time;

        }

        /// <summary>
        /// 添加资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolEqAdd_Click(object sender, EventArgs e)
        {
            if (this.checkInput())
            {
                this.SetNo();//生成随机编号
                int error = 0;//错误标志
                Equipment eq = new Equipment();
                eq.EqName = this.txtEqName.Text;
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
                eq.Photo = this.photoPath;               
                eq.Remark = this.txtRemark.Text;

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

            if (_power == "0" || _power == "1")
            {
                int tempCount = EqMgr.getTempAssetCount();
                int allCount = EqMgr.getAllAssetCount();
                int eqCount = EqMgr.getAllEqCount();
                int assetCount = allCount - tempCount + 1;
                eq.State = "入库";
                for (int j = 1; j <= count; j++)
                {
                    eq.EqNo = DateTime.Now.Year.ToString() + string.Format("{0:D6}", eqCount + j);
                    eq.AssetNo = SysUserMgr.GetDepartmentIDByUser(this._user) + DateTime.Now.Year.ToString() + string.Format("{0:D4}", assetCount);
                    if (EqMgr.Add(eq))
                    {
                        /*if (!SqlFileMgr.PhotoAdd(eq.EqNo, photoPath))
                            error++;
                        if (!WriteAttachment(eq.EqNo))
                            error++;*/
                    }
                    else
                    {
                        error++;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= count; i++)
                {
                    
                    eq.EqNo = "TE" + random + string.Format("{0:000}", i);
                    eq.AssetNo = "TA" + random + string.Format("{0:000}", count);
                    eq.State = "新增待审核";
                    //if (this.pbPhoto.Image != null)
                    //photoPath = this.pbPhoto.ImageLocation;
                    if (EqMgr.Add(eq))
                    {
                        /*if (!SqlFileMgr.PhotoAdd(eq.EqNo, photoPath))
                            error++;
                        if (!WriteAttachment(eq.EqNo))
                            error++;*/
                    }
                    else
                    {
                        error++;
                    }
                }
            }

            if (error == 0)
            {
                untCommon.InfoMsg("添加成功");
                ClearInput();
                this.SetNo();
                this.Close();
            }
            else
            {
                untCommon.InfoMsg("错误数目："+error.ToString());
                this.SetNo();
            }
        }

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

        /// <summary>
        /// 清空控件内容
        /// </summary>
        private void ClearInput()
        {
            for (int index = 0; index< this.panel1.Controls.Count; index++)
            {
                Clear(this.panel1.Controls[index]);
            }

            this.dtpAddDate.Checked = false;
            this.dtpBirthday.Checked = false;
            this.dtpGetDate.Checked = false;
            this.dtpIssueDate.Checked = false;
            this.dtpRegTime.Checked = false;
            this.dtpSvcDate.Checked = false;

            this.pbPhoto.Image = null;


            this.txtCount.Text ="1";
            this.txtAgent.Text = this._user;
        }

        private void Clear(Control c)
        {
            foreach (Control ctr in c.Controls)
            {
                if (ctr is TextBox)//考虑是文本框的话
                {
                    ((TextBox)ctr).Text = String.Empty;
                }
                if (ctr is ComboBox)//下拉框
                {
                    ((ComboBox)ctr).Text = String.Empty;
                }
                if (ctr is DateTimePicker)
                {
                    ((DateTimePicker)ctr).Value = DateTime.Now;
                    
                }
            }
        }
        private void toolClearAll_Click(object sender, EventArgs e)
        {
            ClearInput();
            SetNo();
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        //根据资产类别的选项不同锁上不同的区域
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

        public string Loginid
        {
            get { return _loginid; }
            set { _loginid = value; }
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

        private void OpenTree(TextBox txt,string dbtable, string key)
        {
            frmTree ftree = new frmTree();
            ftree.Dbtable = dbtable;
            ftree.Key = key;
            ftree.frmTree_Load();
            ftree.ShowDialog();
            if (ftree.DialogResult == DialogResult.OK)
                txt.Text = ftree.NodeNum;
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
                    this.pbPhoto.Image = Image.FromFile(photoPath);
                else
                    untCommon.ErrorMsg("选择的图片大于200KB");
            }
            
   
        }

        private void btnDelPhoto_Click(object sender, EventArgs e)
        {
            this.pbPhoto.Image = null;
        }


        

        //根据文件扩展名获取图片标签，图片列表在ilFile控件中设置
        private int GetImageIndex(string extension)
        {
            switch (extension)
            {
                case ".doc":  return 0;
                case ".docx": return 0;
                case ".pdf":  return 1;
                case ".xls":  return 2;
                case ".xlsx": return 2;
                case ".jpg":  return 3;
                case ".png":  return 4;
                case ".ppt":  return 5;
                case ".pptx": return 5;
                case ".mp3":  return 6;
                case ".mp4":  return 7;
                default:     return 8;

            }
        }

        

        

    }

    
}
