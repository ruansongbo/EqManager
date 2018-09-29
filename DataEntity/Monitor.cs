using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Monitor
    {
        private int _mtNo;
        private string _place;
        private int _doNo;
        private string _ip;
        private string _status;

        public int MtNo
        {
            get
            {
                return this._mtNo;
            }
            set
            {
                this._mtNo = value;
            }
        }

        public string Place
        {
            get
            {
                return this._place;
            }
            set
            {
                this._place = value;
            }
        }

        public int DoNo
        {
            get
            {
                return this._doNo;
            }
            set
            {
                this._doNo = value;
            }
        }

        public string IP
        {
            get
            {
                return this._ip;
            }
            set
            {
                this._ip = value;
            }
        }

        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
    }
}
