using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity
{
    public class Fix
    {
        private string _id;//流水号
        private string _eqNo;//资产编码
        private string _eqName;//资产名称
        private string _depart;//所属部门
        private string _keepPlace;//保管地点
        private string _keeper;//保管人
        private string _maintainer;//维修商
        private string _mAgent;//送修经办人
        private string _mReviewer;//送修审核人
        private DateTime _mDate;//送修日期
        private string _rAgent;//归还经办人
        private string _rReviewer;//归还审核人
        private DateTime _rDate;//归还日期
        private string _mRemark;//借用备注
        private string _rRemark;//归还备注

        public string ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string EqNo
        {
            get
            {
                return this._eqNo;
            }
            set
            {
                this._eqNo = value;
            }
        }
        public string EqName
        {
            get
            {
                return this._eqName;
            }
            set
            {
                this._eqName = value;
            }
        }

        public string Department
        {
            get
            {
                return this._depart;
            }
            set
            {
                this._depart = value;
            }
        }
        public string KeepPlace
        {
            get
            {
                return this._keepPlace;
            }
            set
            {
                this._keepPlace = value;
            }
        }
        public string Keeper
        {
            get
            {
                return this._keeper;
            }
            set
            {
                this._keeper = value;
            }
        }
        public string Maintainer
        {
            get
            {
                return this._maintainer;
            }
            set
            {
                this._maintainer = value;
            }
        }

        public string MAgent
        {
            get
            {
                return this._mAgent;
            }
            set
            {
                this._mAgent = value;
            }
        }
        public string MReviewer
        {
            get
            {
                return this._mReviewer;
            }
            set
            {
                this._mReviewer = value;
            }
        }


        public DateTime MDate
        {
            get
            {
                return this._mDate;
            }
            set
            {
                this._mDate = value;
            }
        }

        public string RAgent
        {
            get
            {
                return this._rAgent;
            }
            set
            {
                this._rAgent = value;
            }
        }

        public string RReviewer
        {
            get
            {
                return this._rReviewer;
            }
            set
            {
                this._rReviewer = value;
            }
        }

        public DateTime RDate
        {
            get
            {
                return this._rDate;
            }
            set
            {
                this._rDate = value;
            }
        }
        public string mRemark
        {
            get
            {
                return this._mRemark;
            }
            set
            {
                this._mRemark = value;
            }
        }
        public string rRemark
        {
            get
            {
                return this._rRemark;
            }
            set
            {
                this._rRemark = value;
            }
        }
        
    }
}
