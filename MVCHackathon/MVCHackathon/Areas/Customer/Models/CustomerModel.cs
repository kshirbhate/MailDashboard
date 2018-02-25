using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHackathon.Areas.Customer.Models
{
    public class CustomerModel 
    {
        private long _UserId;      
        private string _UserRealName;        
        private string _Mobile;
        private string _Email;
        private string _UserName;
        private string _Address;
        private string _City;
        private string _Pincode;
        private string _State;
        private string _Country;
        private string _Dateofbirth;
        private string _Gender;        
        private long _Active;
        private long _UserRoleId;         
        private string _Password;
        private System.Int64 _InsertByUserId;
        private System.DateTime _InsertTimeStamp = DateTime.Now;

        public long UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public string UserRealName
        {
            get { return _UserRealName; }
            set { _UserRealName = value; }
        }
        public string Mobile
        {
            get
            {
                return _Mobile;
            }

            set
            {
                _Mobile = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }
        public string UserName
{
  get { return _UserName; }
  set { _UserName = value; }
}

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string Pincode
        {
            get { return _Pincode; }
            set { _Pincode = value; }
        }
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        public string Dateofbirth
        {
            get { return _Dateofbirth; }
            set { _Dateofbirth = value; }
        }
        public string Gender
        {
            get
            {
                return _Gender;
            }

            set
            {
                _Gender = value;
            }
        }

        public long Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public long UserRoleId
        {
            get { return _UserRoleId; }
            set { _UserRoleId = value; }
        } 

        public long InsertByUserId
        {
            get
            {
                return _InsertByUserId;
            }

            set
            {
                _InsertByUserId = value;
            }
        }

        public DateTime InsertTimeStamp
        {
            get
            {
                return _InsertTimeStamp;
            }

            set
            {
                _InsertTimeStamp = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

       
    }
}