using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHackathon.Models
{
    public class UserModel : Context
    {
        private string _Token;
        private string _UserName;
        private string _ConfirmPassword;
        private string _OldPassword;

        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {
                _UserName = value;
            }
        }

        private string _Password;
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

        public List<UserModel> List
        {
            get
            {
                if (_List == null) _List = new List<UserModel>();
                return _List;
            }

            set
            {
                _List = value;
            }
        }

        public int UserId
        {
            get
            {
                return _UserId;
            }

            set
            {
                _UserId = value;
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

        public int Active
        {
            get
            {
                return _Active;
            }

            set
            {
                _Active = value;
            }
        }

        public int UserRoleId
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

        public int UnitId
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

        public List<SelectListItem> UnitList
        {
            get
            {
                return _UnitList;
            }

            set
            {
                _UnitList = value;
            }
        }

        public string Token
        {
            get
            {
                return _Token;
            }

            set
            {
                _Token = value;
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return _ConfirmPassword;
            }

            set
            {
                _ConfirmPassword = value;
            }
        }

        public string OldPassword
        {
            get
            {
                return _OldPassword;
            }

            set
            {
                _OldPassword = value;
            }
        }

        private List<UserModel> _List = null;

        private int _UserId;

        private string _UserRealName;

        private string _Email;

        private int _Active;

        private int _UserRoleId;

        private int _UnitId;

        private string _UnitName;

        private List<SelectListItem> _UnitList = new List<SelectListItem>();

    }
}