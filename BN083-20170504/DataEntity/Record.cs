using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class Record
    {
        private string _serialNo;
        private string _epc;
        private string _keepPlace;
        private string _mtNo;
        private string _time;
        private string _activity;
        private int _processor;
        private string _done;

        public string SerialNo
        {
            get
            {
                return this._serialNo;
            }
            set
            {
                this._serialNo = value;
            }
        }

        public string EPC
        {
            get
            {
                return this._epc;
            }
            set
            {
                this._epc = value;
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

        public string MtNo
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

        public string Time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }

        public string Activity
        {
            get
            {
                return this._activity;
            }
            set
            {
                this._activity = value;
            }
        }

        public int Processor
        {
            get
            {
                return this._processor;
            }
            set
            {
                this._processor = value;
            }
        }

        public string Done
        {
            get
            {
                return this._done;
            }
            set
            {
                this._done = value;
            }
        }
    }
        
}
