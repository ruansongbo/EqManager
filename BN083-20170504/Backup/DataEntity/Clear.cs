using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Clear
    {
        private int _id;
        private string  _eqNo;
        private int _count;
        private string _clearType;
        private string _clearer;
        private string _clearDate;
        private string _mark;
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
        public string ClearType
        {
            get
            {
                return this._clearType;
            }
            set
            {
                this._clearType=value;
            }
        }
        public string Clearer
        {
            get
            {
                return this._clearer;
            }
            set
            {
                this._clearer = value;
            }
        }

        public string ClearDate
        {
            get
            {
                return this._clearDate;
            }
            set
            {
                this._clearDate=value;
            }
        }
        public string Mark
        {
            get
            {
                return this._mark;
            }
            set
            {
                this._mark=value;
            }
        }

    }
}

