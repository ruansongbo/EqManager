using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Returns
    {
        private int _id;
        private string _eqNo;
        private string _date;
        private int _count;
        private string _booker;
        private int _borrower;
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

        public int ID
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
        
        

        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
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
                this._booker = value;
            }
        }
        public string Date
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }
    }
}

