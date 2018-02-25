using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHackathon.Areas.Customer.Models;
using MVCHackathon.Areas.Mailbox.Models;

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

        private List<DashboardModel> _DailyList = new List<DashboardModel>();
        private List<DashboardModel> _WeeklyList = new List<DashboardModel>();
        private List<DashboardModel> _MonthlyList = new List<DashboardModel>();
        private List<DashboardModel> _YearlyList = new List<DashboardModel>();
        private long _Count;

        private long _MailId;
        private string _To;
        private string _Cc;
        private string _Bcc;
        private string _From;
        private string _Subject;
        private string _Message;
        private string _Attachment;

        private string _AttachmentSize;

        private List<DashboardModel> _DailySenderList = new List<DashboardModel>();
        private List<DashboardModel> _DailyReceiverList = new List<DashboardModel>();

        private List<DashboardModel> _MonthlySenderList = new List<DashboardModel>();
        private List<DashboardModel> _MonthlyReceiverList = new List<DashboardModel>();

        private List<DashboardModel> _WeeklySenderList = new List<DashboardModel>();
        private List<DashboardModel> _WeeklyReceiverList = new List<DashboardModel>();

        private List<DashboardModel> _YearlySenderList = new List<DashboardModel>();
        private List<DashboardModel> _YearlyReceiverList = new List<DashboardModel>();
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

        public long Count
        {
            get
            {
                return _Count;
            }

            set
            {
                _Count = value;
            }
        }

        public List<DashboardModel> DailyList
        {
            get
            {
                if (_DailyList == null) _DailyList = new List<DashboardModel>();
                return _DailyList;
            }

            set
            {
                _DailyList = value;
            }
        }

        public List<DashboardModel> WeeklyList
        {
            get
            {
                if (_WeeklyList == null) _WeeklyList = new List<DashboardModel>();
                return _WeeklyList;
            }

            set
            {
                _WeeklyList = value;
            }
        }

        public List<DashboardModel> MonthlyList
        {
            get
            {
                if (_MonthlyList == null) _MonthlyList = new List<DashboardModel>();
                return _MonthlyList;
            }

            set
            {
                _MonthlyList = value;
            }
        }

        public List<DashboardModel> YearlyList
        {
            get
            {
                if (_YearlyList == null) _YearlyList = new List<DashboardModel>();
                return _YearlyList;
            }

            set
            {
                _YearlyList = value;
            }
        }

        public long MailId
        {
            get
            {
                return _MailId;
            }

            set
            {
                _MailId = value;
            }
        }

        public string To
        {
            get
            {
                return _To;
            }

            set
            {
                _To = value;
            }
        }

        public string Cc
        {
            get
            {
                return _Cc;
            }

            set
            {
                _Cc = value;
            }
        }

        public string Bcc
        {
            get
            {
                return _Bcc;
            }

            set
            {
                _Bcc = value;
            }
        }

        public string From
        {
            get
            {
                return _From;
            }

            set
            {
                _From = value;
            }
        }

        public string Subject
        {
            get
            {
                return _Subject;
            }

            set
            {
                _Subject = value;
            }
        }

        public string Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message = value;
            }
        }

        public string Attachment
        {
            get
            {
                return _Attachment;
            }

            set
            {
                _Attachment = value;
            }
        }

        public List<DashboardModel> DailySenderList
        {
            get
            {
                if (_DailySenderList == null) _DailySenderList = new List<DashboardModel>();
                return _DailySenderList;
            }

            set
            {
                _DailySenderList = value;
            }
        }

        public List<DashboardModel> DailyReceiverList
        {
            get
            {
                if (_DailyReceiverList == null) _DailyReceiverList = new List<DashboardModel>();
                return _DailyReceiverList;
            }

            set
            {
                _DailyReceiverList = value;
            }
        }

        public List<DashboardModel> MonthlySenderList
        {
            get
            {
                if (_MonthlySenderList == null) _MonthlySenderList = new List<DashboardModel>();
                return _MonthlySenderList;
            }

            set
            {
                _MonthlySenderList = value;
            }
        }

        public List<DashboardModel> MonthlyReceiverList
        {
            get
            {
                if (_MonthlyReceiverList == null) _MonthlyReceiverList = new List<DashboardModel>();
                return _MonthlyReceiverList;
            }

            set
            {
                _MonthlyReceiverList = value;
            }
        }

        public List<DashboardModel> WeeklySenderList
        {
            get
            {
                if (_WeeklySenderList == null) _WeeklySenderList = new List<DashboardModel>();
                return _WeeklySenderList;
            }

            set
            {
                _WeeklySenderList = value;
            }
        }

        public List<DashboardModel> WeeklyReceiverList
        {
            get
            {
                if (_WeeklyReceiverList == null) _WeeklyReceiverList = new List<DashboardModel>();
                return _WeeklyReceiverList;
            }

            set
            {
                _WeeklyReceiverList = value;
            }
        }

        public List<DashboardModel> YearlySenderList
        {
            get
            {
                if (_YearlySenderList == null) _YearlySenderList = new List<DashboardModel>();
                return _YearlySenderList;
            }

            set
            {
                _YearlySenderList = value;
            }
        }

        public List<DashboardModel> YearlyReceiverList
        {
            get
            {
                if (_YearlyReceiverList == null) _YearlyReceiverList = new List<DashboardModel>();
                return _YearlyReceiverList;
            }

            set
            {
                _YearlyReceiverList = value;
            }
        }

        public string AttachmentSize
        {
            get
            {
                return _AttachmentSize;
            }

            set
            {
                _AttachmentSize = value;
            }
        }
    }
}