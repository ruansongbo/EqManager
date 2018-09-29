using System;
using System.Collections.Generic;
using System.Text;


namespace DataEntity
{
    public class Employee
    {
        private int _empNo;
        private string _sex;
        private int _departid;
        private string _name;
        public string Sex
        {
            set
            {
                this._sex = value;
            }
            get
            {
                return this._sex;
            }
        }

        public int EmpNo
        {
            set
            {
                this._empNo = value;
            }
            get
            {
                return this._empNo;
            }
        }
        public int departId
        {
            set
            {
                this._departid = value;
            }
            get
            {
                return this._departid;
            }
        }
        public string Name
        {
            set
            {
                this._name = value;
            }
            get
            {
                return this._name;
            }
        }



    }
}
