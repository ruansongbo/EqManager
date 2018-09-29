using System;
using System.Collections.Generic;
using System.Text;


namespace DataEntity
{
    public class Employee
    {
        private string _empId;
        private string _sex;
        private string _departid;
        private string _name;
        private string _tel;

        
        private string _email;
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

        public string EmpId
        {
            set
            {
                this._empId = value;
            }
            get
            {
                return this._empId;
            }
        }
        public string departId
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

        public string Tel
        {
            set 
            { 
                this._tel = value; 
            }
            get
            {
                return this._tel;
            }
        }

        public string Email
        {
            set
            {
                this._email = value;
            }
            get
            {
                return this._email;
            }
        }
    }
}
