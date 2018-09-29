using System;
using System.Collections.Generic;
using System.Text;





namespace DataEntity
{
    public class Equipment
    {
        private string _eqNo="";
        private string _eqName = "";
        private string _eduNo = "";
        private string _assetNo = "";
        private string _eqType = "";
        private string _gb = "";
        private string _usage = "";
        private string _unit = "";
        private string _direction = "";
        private string _buyWay = "";
        private string _getWay = "";
        private string _getDate = "";
        private string _addDate = "";
        private string _purchaser = "";
        private string _agent = "";
        private string _brand = "";
        private string _model = "";
        private string _country = "";
        private string _mfrs = "";
        private string _productNo = "";
        private string _birthday = "";
        private string _supplier = "";
        private string _priceType = "";
        private double _price = 0;
        private double _usdPrice = 0;
        private string _eqKeeper = "";
        private string _department = "";
        private string _svcDate = "";
        private string _campus = "";
        private string _keepPlace = "";
        private string _cn = "";
        private string _invNo = "";
        private string _funds = "";
        private string _relicLv = "";
        private string _regAuz = "";
        private string _regTime = "";
        private string _patNo = "";
        private string _apvNo = "";
        private string _mgtAgency = "";
        private string _carUse = "";
        private string _carBP = "";
        private string _licNo = "";
        private string _dspl = "";
        private string _engNo = "";
        private string _formation = "";       
        private double _area;
        private string _pr = "";
        private string _certNo = "";
        private string _issueDate = "";
        private int _certLim = 0;
        private string _certProve = "";
        private string _address = "";
        private string _certNature = "";
        private double _tenuArea = 0;
        private double _tenuPrice = 0;
        private string _structure = "";
        private string _belongTo = "";
        private string _photo = "";
        private string _state = "";
        private string _remark = "";

        


        public string EqNo
        {
            get { return _eqNo; }
            set { _eqNo = value; }
        }

        public string EqName
        {
            get { return _eqName; }
            set { _eqName = value; }
        }

        public string EduNo
        {
            get { return _eduNo; }
            set { _eduNo = value; }
        }


        public string AssetNo
        {
            get { return _assetNo; }
            set { _assetNo = value; }
        }

        public string EqType
        {
            get { return _eqType; }
            set { _eqType = value; }
        }

        public string Gb
        {
            get { return _gb; }
            set { _gb = value; }
        }

        public string Usage
        {
            get { return _usage; }
            set { _usage = value; }
        }


        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public string Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public string BuyWay
        {
            get { return _buyWay; }
            set { _buyWay = value; }
        }

        public string GetWay
        {
            get { return _getWay; }
            set { _getWay = value; }
        }

        public string GetDate
        {
            get { return _getDate; }
            set { _getDate = value; }
        }

        public string AddDate
        {
            get { return _addDate; }
            set { _addDate = value; }
        }

        public string Purchaser
        {
            get { return _purchaser; }
            set { _purchaser = value; }
        }

        public string Agent
        {
            get { return _agent; }
            set { _agent = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Mfrs
        {
            get { return _mfrs; }
            set { _mfrs = value; }
        }

        public string ProductNo
        {
            get { return _productNo; }
            set { _productNo = value; }
        }

        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }

        public string PriceType
        {
            get { return _priceType; }
            set { _priceType = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public double UsdPrice
        {
            get { return _usdPrice; }
            set { _usdPrice = value; }
        }

        public string EqKeeper
        {
            get { return _eqKeeper; }
            set { _eqKeeper = value; }
        }


        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string SvcDate
        {
            get { return _svcDate; }
            set { _svcDate = value; }
        }

        public string Campus
        {
            get { return _campus; }
            set { _campus = value; }
        }

        public string KeepPlace
        {
            get { return _keepPlace; }
            set { _keepPlace = value; }
        }

        public string Cn
        {
            get { return _cn; }
            set { _cn = value; }
        }

        public string InvNo
        {
            get { return _invNo; }
            set { _invNo = value; }
        }

        public string Funds
        {
            get { return _funds; }
            set { _funds = value; }
        }

        public string RelicLv
        {
            get { return _relicLv; }
            set { _relicLv = value; }
        }

        public string RegAuz
        {
            get { return _regAuz; }
            set { _regAuz = value; }
        }

        public string RegTime
        {
            get { return _regTime; }
            set { _regTime = value; }
        }

        public string PatNo
        {
            get { return _patNo; }
            set { _patNo = value; }
        }

        public string ApvNo
        {
            get { return _apvNo; }
            set { _apvNo = value; }
        }

        public string MgtAgency
        {
            get { return _mgtAgency; }
            set { _mgtAgency = value; }
        }

        public string CarUse
        {
            get { return _carUse; }
            set { _carUse = value; }
        }

        public string CarBP
        {
            get { return _carBP; }
            set { _carBP = value; }
        }

        public string LicNo
        {
            get { return _licNo; }
            set { _licNo = value; }
        }

        public string Dspl
        {
            get { return _dspl; }
            set { _dspl = value; }
        }

        public string EngNo
        {
            get { return _engNo; }
            set { _engNo = value; }
        }

        public string Formation
        {
            get { return _formation; }
            set { _formation = value; }
        }

        public double Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public string Pr
        {
            get { return _pr; }
            set { _pr = value; }
        }

        public string CertNo
        {
            get { return _certNo; }
            set { _certNo = value; }
        }

        public string IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }
        }

        public int CertLim
        {
            get { return _certLim; }
            set { _certLim = value; }
        }

        public string CertProve
        {
            get { return _certProve; }
            set { _certProve = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string CertNature
        {
            get { return _certNature; }
            set { _certNature = value; }
        }

        public double TenuArea
        {
            get { return _tenuArea; }
            set { _tenuArea = value; }
        }

        public double TenuPrice
        {
            get { return _tenuPrice; }
            set { _tenuPrice = value; }
        }

        public string Structure
        {
            get { return _structure; }
            set { _structure = value; }
        }

        public string BelongTo
        {
            get { return _belongTo; }
            set { _belongTo = value; }
        }


        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }


        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
