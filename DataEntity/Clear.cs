using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Clear
    {
        private string _id;//流水号
        private string _eqNo;//资产编码
        private string _eqName;//资产名称
        private string _depart;//所属部门
        private string _keepPlace;//保管地点
        private string _keeper;//保管人
        private string _cAgent;//清理经办人
        private string _cReviewer;//清理审核人
        private string _cType;//清理方式
        private DateTime _cDate;//清理日期
        private string _remark;//归还备注

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

        public string CAgent
        {
            get
            {
                return this._cAgent;
            }
            set
            {
                this._cAgent = value;
            }
        }
        public string CReviewer
        {
            get
            {
                return this._cReviewer;
            }
            set
            {
                this._cReviewer = value;
            }
        }
        public string CType
        {
            get
            {
                return this._cType;
            }
            set
            {
                this._cType = value;
            }
        }


        public DateTime CDate
        {
            get
            {
                return this._cDate;
            }
            set
            {
                this._cDate = value;
            }
        }

        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }

    }
}

