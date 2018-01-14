using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHackathon.Areas.Customer.Models;

namespace MVCHackathon.Areas.Dashboard.Models
{
    public class DashboardModel : CustomerModel
    {
        private long _Daily;
        private long _Weekly;
        private long _Monthly;
        private long _Yearly;
        private List<DashboardModel> _OutgoingExternalList = new List<DashboardModel>();
        private List<DashboardModel> _OutgoingInternalList = new List<DashboardModel>();
        private List<DashboardModel> _IncomingExternalList = new List<DashboardModel>();
        private List<DashboardModel> _IncomingInternalList = new List<DashboardModel>();
        private List<DashboardModel> _List = null;

        public long Daily
        {
            get
            {
                return _Daily;
            }

            set
            {
                _Daily = value;
            }
        }

        public List<DashboardModel> List
        {
            get
            {
                if (_List == null) _List = new List<DashboardModel>();
                return _List;
            }

            set
            {
                _List = value;
            }
        }

        public long Weekly
        {
            get
            {
                return _Weekly;
            }

            set
            {
                _Weekly = value;
            }
        }

        public long Monthly
        {
            get
            {
                return _Monthly;
            }

            set
            {
                _Monthly = value;
            }
        }

        public long Yearly
        {
            get
            {
                return _Yearly;
            }

            set
            {
                _Yearly = value;
            }
        }

        public List<DashboardModel> OutgoingExternalList
        {
            get
            {
                if (_OutgoingExternalList == null) _OutgoingExternalList = new List<DashboardModel>();
                return _OutgoingExternalList;
            }

            set
            {
                _OutgoingExternalList = value;
            }
        }

        public List<DashboardModel> OutgoingInternalList
        {
            get
            {
                if (_OutgoingInternalList == null) _OutgoingInternalList = new List<DashboardModel>();
                return _OutgoingInternalList;
            }

            set
            {
                _OutgoingInternalList = value;
            }
        }

        public List<DashboardModel> IncomingExternalList
        {
            get
            {
                if (_IncomingExternalList == null) _IncomingExternalList = new List<DashboardModel>();
                return _IncomingExternalList;
            }

            set
            {
                _IncomingExternalList = value;
            }
        }

        public List<DashboardModel> IncomingInternalList
        {
            get
            {
                if (_IncomingInternalList == null) _IncomingInternalList = new List<DashboardModel>();
                return _IncomingInternalList;
            }

            set
            {
                _IncomingInternalList = value;
            }
        }
    }
}