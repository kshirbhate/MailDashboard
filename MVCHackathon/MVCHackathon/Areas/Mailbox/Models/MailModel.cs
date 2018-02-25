using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHackathon.Areas.Mailbox.Models
{
    public class MailModel
    {
        private long _MailId;
        private string _To;
        private string _Cc;
        private string _Bcc;
        private string _From;
        private string _Subject;
        private string _Message;
        private string _Attachment;
        private long _Status;
        private System.Int64 _InsertByUserId;
        private System.DateTime _InsertTimeStamp = DateTime.Now;
        private List<MailModel> _List = null;
        private long _StatId;
        private long _SenderId;
        private long _ReceiverId;
        private long _IsInternal;
        private long _IsExternal;
        private string _AttachmentSize;
        private string _mailBoxSubTitle;
        private string _firstColumnName;
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

        public long Status
        {
            get
            {
                return _Status;
            }

            set
            {
                _Status = value;
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

        public string MailBoxSubTitle
        {
            get
            {
                return _mailBoxSubTitle;
            }

            set
            {
                _mailBoxSubTitle = value;
            }
        }

        public string FirstColumnName
        {
            get
            {
                return _firstColumnName;
            }

            set
            {
                _firstColumnName = value;
            }
        }

        public long StatId
        {
            get
            {
                return _StatId;
            }

            set
            {
                _StatId = value;
            }
        }

        public long SenderId
        {
            get
            {
                return _SenderId;
            }

            set
            {
                _SenderId = value;
            }
        }

        

        public long IsInternal
        {
            get
            {
                return _IsInternal;
            }

            set
            {
                _IsInternal = value;
            }
        }

        public long IsExternal
        {
            get
            {
                return _IsExternal;
            }

            set
            {
                _IsExternal = value;
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

        public long ReceiverId
        {
            get
            {
                return _ReceiverId;
            }

            set
            {
                _ReceiverId = value;
            }
        }

        public List<MailModel> List
        {
            get
            {
                if (_List == null) _List = new List<MailModel>();
                return _List;
            }

            set
            {
                _List = value;
            }
        }
    }
}