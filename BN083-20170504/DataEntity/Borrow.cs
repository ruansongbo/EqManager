using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Borrow
    {
        private int _id;
        private string _eqNo;
        private string _depart;
        private int _borrower;
        private DateTime _date;
        private string _unit;
        private int _count;
        private string _booker;

        public int ID
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

        public string depart
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
        public int Borrower
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
        
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count=value;
            }
        }
        public string Unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                this._unit=value;
            }
        }
 
       
        public string Booker
        {
            get
            {
                return this._booker;
            }
            set
            {
                this._booker=value;
            }
        }
        public DateTime Date
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date=value;
            }
        }
    }
}
