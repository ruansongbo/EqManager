using System;
using System.Collections.Generic;
using System.Text;





namespace DataEntity
{
    public class Equipment
    {
        private int _id;
        private string  _eqNo;
        private string  _type;
        private string _name;
        private string _model;
        private string _plus;
        private int _count;
        private string _unit;
        private double _price;
        private string _maker;
        private string _birthday;
        private string _addType;
        private string _keepPlace;
        private int _keeper;
        private int _useTime;//预计使用期限
        private string _booker;
        private string _bookDate;
        private string _lable;
        private string _photo;


        public string Photo
        {
            set
            {
                this._photo = value;
            }
            get
            {
                return this._photo;
            }
        }

        public string Lable
        {
            get
            {
                return this._lable;
            }
            set
            {
                this._lable = value;
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
        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type=value;
            }
        }
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name=value;
            }
        }
        public string Model
        {
            get
            {
                return this._model;
            }
            set
            {
                this._model=value;
            }
        }
        public string Plus
        {
            get
            {
                return this._plus;
            }
            set
            {
                this._plus=value;
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
        public double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price=value;
            }
        }
        public string Maker
        {
            get
            {
                return this._maker;
            }
            set
            {
                this._maker=value;
            }
        }
        public string Birthday
        {
            get
            {
                return this._birthday;
            }
            set
            {
                this._birthday=value;
            }
        }
        public string AddType
        {
            get
            {
                return this._addType;
            }
            set
            {
                this._addType=value;
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
                this._keepPlace=value;
            }
        }
        public int Keeper
        {
            get
            {
                return this._keeper;
            }
            set
            {
                this._keeper=value;
            }
        }
        public int UseTime
        {
            get
            {
                return this._useTime;
            }
            set
            {
                this._useTime=value;
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
        public string BookDate
        {
            get
            {
                return this._bookDate;
            }
            set
            {
                this._bookDate=value;
            }
        }

    }
}
