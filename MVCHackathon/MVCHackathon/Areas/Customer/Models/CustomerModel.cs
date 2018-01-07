using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHackathon.Areas.Customer.Models
{
    public class CustomerModel 
    {
        private long _CustomerId;
        private string _CustomerName;
        private string _Mobile;
        private string _Email;
        private string _Password;
        private System.Int64 _InsertByUserId;
        private System.DateTime _InsertTimeStamp = DateTime.Now;

        public long CustomerId
        {
            get
            {
                return _CustomerId;
            }

            set
            {
                _CustomerId = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }

            set
            {
                _CustomerName = value;
            }
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