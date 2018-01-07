using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHackathon.Models
{
    public class UserSession
    {        
        public string SssnId { get; set; }

        private DateTime _Today;
        public DateTime Today
        {
            get { return _Today; }
            set
            {
                _Today = value;
            }
        }

        public long LoggedInUserId
        {
            get
            {
                return _LoggedInUserId;
            }

            set
            {
                _LoggedInUserId = value;
            }
        }

        public long UserRoleId
        {
            get
            {
                return _UserRoleId;
            }

            set
            {
                _UserRoleId = value;
            }
        }

        public string UserRealName
        {
            get
            {
                return _UserRealName;
            }

            set
            {
                _UserRealName = value;
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

        public long UnitId
        {
            get
            {
                return _UnitId;
            }

            set
            {
                _UnitId = value;
            }
        }

        public string UnitName
        {
            get
            {
                return _UnitName;
            }

            set
            {
                _UnitName = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }

            set
            {
                _ConnectionString = value;
            }
        }

        private long _LoggedInUserId;

        private long _UserRoleId;

        private string _UserRealName;

        private string _Email;

        private long _UnitId;

        private string _UnitName;

        private string _ConnectionString;
        public UserSession()
        {

        }        
    }
}