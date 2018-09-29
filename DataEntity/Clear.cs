using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Clear
    {
        private string _id;//��ˮ��
        private string _eqNo;//�ʲ�����
        private string _eqName;//�ʲ�����
        private string _depart;//��������
        private string _keepPlace;//���ܵص�
        private string _keeper;//������
        private string _cAgent;//��������
        private string _cReviewer;//���������
        private string _cType;//����ʽ
        private DateTime _cDate;//��������
        private string _remark;//�黹��ע

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

