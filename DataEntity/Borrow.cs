using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Borrow
    {
        private string _id;//��ˮ��
        private string _eqNo;//�ʲ�����
        private string _eqName;//�ʲ�����
        private string _depart;//��������
        private string _keepPlace;//���ܵص�
        private string _keeper;//������
        private string _borrower;//������
        private string _bAgent;//��辭����
        private string _bReviewer;//��������
        private DateTime _bDate;//��������
        private string _rAgent;//�黹������
        private string _rReviewer;//�黹�����
        private DateTime _rDate;//�黹����
        private string _bRemark;//���ñ�ע
        private string _rRemark;//�黹��ע

        public string ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id=value;
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
                this._eqNo=value;
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
                this._depart=value;
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
        public string Borrower
        {
            get
            {
                return this._borrower;
            }
            set
            {
                this._borrower = value;
            }
        }

        public string BAgent
        {
            get
            {
                return this._bAgent;
            }
            set
            {
                this._bAgent = value;
            }
        }
        public string BReviewer
        {
            get
            {
                return this._bReviewer;
            }
            set
            {
                this._bReviewer = value;
            }
        }
 
       
        public DateTime BDate
        {
            get
            {
                return this._bDate;
            }
            set
            {
                this._bDate = value;
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
        public string bRemark
        {
            get
            {
                return this._bRemark;
            }
            set
            {
                this._bRemark = value;
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
