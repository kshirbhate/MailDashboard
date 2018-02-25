using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using MVCHackathon.utilities;
using System.Text;
using System.Threading.Tasks;
using MVCHackathon.Models;
using MVCHackathon.Areas.Dashboard.Models;
using MVCHackathon.Areas.Mailbox.Models;

namespace MVCHackathon.Areas.Dashboard.Services
{
    public class DashboardService
    {
        private static DashboardService _instance;

        public static DashboardService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DashboardService();
                return _instance;
            }
        }

        public DashboardService()
        {

        }

        public long GetOutgoingToInternalCount(string type, UserSession UISssn)
        {
            long count = 0;
            Object oModel = new DashboardModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);

                sbsql.Clear();
                sbsql.Append(" SELECT count(StatId) As Count FROM statistics ");
                sbsql.Append(" where IsInternal=1 ");
                sbsql.Append(" ; ");

                if (type == "daily")
                {
                    string tempVar = "%Y-%m-%d";
                    if (type == "daily")
                    {
                        tempVar = "%Y-%m-%d";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select count(StatId) As Count from statistics ");
                    sbsql.Append(" where date_format(InsertTimeStamp, '" + tempVar + "') = date_format(now(), '" + tempVar + "') ");
                    sbsql.Append(" and IsInternal=1 ");
                    sbsql.Append(" ; ");
                }
                else
                {
                    string tempVar = "WEEK";
                    if (type == "weekly")
                    {
                        tempVar = "WEEK";
                    }
                    else if (type == "monthly")
                    {
                        tempVar = "MONTH";
                    }
                    else if (type == "yearly")
                    {
                        tempVar = "YEAR";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select count(StatId) As Count from statistics ");
                    sbsql.Append(" where InsertTimeStamp between date_sub(now(),INTERVAL 1 "+ tempVar + ") and now() ");
                    sbsql.Append(" and IsInternal=1 ");
                    sbsql.Append(" ; ");
                    
                }                

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                DashboardModel temp = new DashboardModel();
                temp = (DashboardModel)oModel;
                count = temp.Count;
            }
            catch (Exception)
            {

            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }

            return count;
        }

        public long GetOutgoingToExternalCount(string type, UserSession UISssn)
        {
            long count = 0;
            Object oModel = new DashboardModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);

                sbsql.Clear();
                sbsql.Append(" SELECT count(StatId) As Count FROM statistics ");
                sbsql.Append(" where IsExternal=1 ");
                sbsql.Append(" ; ");
                if (type == "daily")
                {
                    string tempVar = "%Y-%m-%d";
                    if (type == "daily")
                    {
                        tempVar = "%Y-%m-%d";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select count(StatId) As Count from statistics ");
                    sbsql.Append(" where date_format(InsertTimeStamp, '" + tempVar + "') = date_format(now(), '" + tempVar + "') ");
                    sbsql.Append(" and IsExternal=1 ");
                    sbsql.Append(" ; ");
                }
                else
                {
                    string tempVar = "WEEK";
                    if (type == "weekly")
                    {
                        tempVar = "WEEK";
                    }
                    else if (type == "monthly")
                    {
                        tempVar = "MONTH";
                    }
                    else if (type == "yearly")
                    {
                        tempVar = "YEAR";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select count(StatId) As Count from statistics ");
                    sbsql.Append(" where InsertTimeStamp between date_sub(now(),INTERVAL 1 " + tempVar + ") and now() ");
                    sbsql.Append(" and IsExternal=1 ");
                    sbsql.Append(" ; ");

                }                

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                DashboardModel temp = new DashboardModel();
                temp = (DashboardModel)oModel;
                count = temp.Count;
            }
            catch (Exception)
            {

            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }

            return count;
        }

        public long GetIncomingFromInternalCount(string type, UserSession UISssn)
        {
            long count = 0;
            Object oModel = new DashboardModel();
            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            DbDataReader reader = null;

            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);

                sbsql.Clear();
                sbsql.Append(" SELECT count(StatId) As Count FROM statistics ");
                sbsql.Append(" where IsInternal=1 ");
                sbsql.Append(" and ReceiverId !=0 ");
                sbsql.Append(" ; ");

                if (type == "daily")
                {
                    string tempVar = "%Y-%m-%d";
                    if (type == "daily")
                    {
                        tempVar = "%Y-%m-%d";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select count(StatId) As Count from statistics ");
                    sbsql.Append(" where date_format(InsertTimeStamp, '" + tempVar + "') = date_format(now(), '" + tempVar + "') ");
                    sbsql.Append(" and IsInternal=1 ");
                    sbsql.Append(" and ReceiverId !=0 ");
                    sbsql.Append(" ; ");
                }
                else
                {
                    string tempVar = "WEEK";
                    if (type == "weekly")
                    {
                        tempVar = "WEEK";
                    }
                    else if (type == "monthly")
                    {
                        tempVar = "MONTH";
                    }
                    else if (type == "yearly")
                    {
                        tempVar = "YEAR";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select count(StatId) As Count from statistics ");
                    sbsql.Append(" where InsertTimeStamp between date_sub(now(),INTERVAL 1 " + tempVar + ") and now() ");
                    sbsql.Append(" and IsInternal=1 ");
                    sbsql.Append(" and ReceiverId !=0 ");
                    sbsql.Append(" ; ");

                }               

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                DashboardModel temp = new DashboardModel();
                temp = (DashboardModel)oModel;
                count = temp.Count;
            }
            catch (Exception)
            {

            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }

            return count;
        }

        public long GetIncomingFromExternalCount(string type, UserSession UISssn)
        {
            long count = 0;
            Object oModel = new DashboardModel();
            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);

            DbDataReader reader = null;
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);

                sbsql.Clear();
                sbsql.Append(" SELECT count(StatId) As Count FROM statistics ");
                sbsql.Append(" where IsExternal=1 ");
                sbsql.Append(" and ReceiverId !=0 ");
                sbsql.Append(" ; ");
                if (type == "daily")
                {
                    string tempVar = "%Y-%m-%d";
                    if (type == "daily")
                    {
                        tempVar = "%Y-%m-%d";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select count(StatId) As Count from statistics ");
                    sbsql.Append(" where date_format(InsertTimeStamp, '" + tempVar + "') = date_format(now(), '" + tempVar + "') ");
                    sbsql.Append(" and IsExternal=1 ");
                    sbsql.Append(" and ReceiverId !=0 ");
                    sbsql.Append(" ; ");
                }
                else
                {
                    string tempVar = "WEEK";
                    if (type == "weekly")
                    {
                        tempVar = "WEEK";
                    }
                    else if (type == "monthly")
                    {
                        tempVar = "MONTH";
                    }
                    else if (type == "yearly")
                    {
                        tempVar = "YEAR";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select count(StatId) As Count from statistics ");
                    sbsql.Append(" where InsertTimeStamp between date_sub(now(),INTERVAL 1 " + tempVar + ") and now() ");
                    sbsql.Append(" and IsExternal=1 ");
                    sbsql.Append(" and ReceiverId !=0 ");
                    sbsql.Append(" ; ");

                }
                
                cmd.CommandText = sbsql.ToString();
                
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                DashboardModel temp = new DashboardModel();
                temp = (DashboardModel)oModel;
                count = temp.Count;
            }
            catch (Exception)
            {

            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }

            return count;
        }

        public List<MailModel> GetSampleList(UserSession UISssn)
        {
            List<MailModel> SelectListItem = new List<MailModel>();
            
            Object list = new List<MailModel>();
            Object listitem = new MailModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Clear();
                sbsql.Append(" SELECT a.* FROM statistics as a ");
                sbsql.Append(" where a.IsInternal=1 ");
                sbsql.Append(" ; ");

                
                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectListItem = (List<MailModel>)list;

            }
            catch (Exception)
            {
            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }
            return SelectListItem;
        }

        public List<DashboardModel> GetOutgoingInternalTop10List(string type, UserSession UISssn)
        {
            List<DashboardModel> SelectedList = new List<DashboardModel>();
            Object list = new List<DashboardModel>();
            Object listitem = new DashboardModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                if(type == "daily")
                {
                    string tempVar = "%Y-%m-%d";
                    if (type == "daily")
                    {
                        tempVar = "%Y-%m-%d";
                    }
                    
                    sbsql.Clear();
                    sbsql.Append(" select a.* from mailbox as a ");
                    sbsql.Append(" inner join  statistics as b on a.MailId = b.MailId ");
                    sbsql.Append(" where date_format(a.InsertTimeStamp, '" + tempVar + "') = date_format(now(), '" + tempVar + "') ");
                    sbsql.Append(" and b.IsInternal=1 ");
                    sbsql.Append(" order by a.InsertTimeStamp ASC ");
                    sbsql.Append(" Limit 10 ");
                    sbsql.Append(" ; ");
                }
                else
                {
                    string temp = "WEEK";
                    if (type == "weekly")
                    {
                        temp = "WEEK";
                    }
                    else if (type == "monthly")
                    {
                        temp = "MONTH";
                    }
                    else if (type == "yearly")
                    {
                        temp = "YEAR";
                    }
                    sbsql.Clear();
                    sbsql.Append(" select a.* from mailbox as a ");
                    sbsql.Append(" inner join  statistics as b on a.MailId = b.MailId ");
                    sbsql.Append(" where a.InsertTimeStamp between date_sub(now(),INTERVAL 1 "+ temp + ") and now() ");
                    sbsql.Append(" and b.IsInternal=1 ");
                    sbsql.Append(" order by a.InsertTimeStamp ASC ");
                    sbsql.Append(" Limit 10 ");
                    sbsql.Append(" ; ");
                }

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectedList = (List<DashboardModel>)list;

            }
            catch (Exception e)
            {
            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }
            return SelectedList;
        }

        public List<DashboardModel> GetOutgoingExternalTop10List(string type, UserSession UISssn)
        {
            List<DashboardModel> SelectedList = new List<DashboardModel>();
            Object list = new List<DashboardModel>();
            Object listitem = new DashboardModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                if (type == "daily")
                {
                    string tempVar = "%Y-%m-%d";
                    if (type == "daily")
                    {
                        tempVar = "%Y-%m-%d";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select a.* from mailbox as a ");
                    sbsql.Append(" inner join  statistics as b on a.MailId = b.MailId ");
                    sbsql.Append(" where date_format(a.InsertTimeStamp, '" + tempVar + "') = date_format(now(), '" + tempVar + "') ");
                    sbsql.Append(" and b.IsExternal=1 ");
                    sbsql.Append(" order by a.InsertTimeStamp ASC ");
                    sbsql.Append(" Limit 10 ");
                    sbsql.Append(" ; ");
                }
                else
                {
                    string temp = "WEEK";
                    if (type == "weekly")
                    {
                        temp = "WEEK";
                    }
                    else if (type == "monthly")
                    {
                        temp = "MONTH";
                    }
                    else if (type == "yearly")
                    {
                        temp = "YEAR";
                    }
                    sbsql.Clear();
                    sbsql.Append(" select a.* from mailbox as a ");
                    sbsql.Append(" inner join  statistics as b on a.MailId = b.MailId ");
                    sbsql.Append(" where a.InsertTimeStamp between date_sub(now(),INTERVAL 1 " + temp + ") and now() ");
                    sbsql.Append(" and b.IsExternal=1 ");
                    sbsql.Append(" order by a.InsertTimeStamp ASC ");
                    sbsql.Append(" Limit 10 ");
                    sbsql.Append(" ; ");
                }                

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectedList = (List<DashboardModel>)list;

            }
            catch (Exception e)
            {
            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }
            return SelectedList;
        }

        public List<DashboardModel> GetIncomingInternalTop10List(string type, UserSession UISssn)
        {
            List<DashboardModel> SelectedList = new List<DashboardModel>();
            Object list = new List<DashboardModel>();
            Object listitem = new DashboardModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);

                if (type == "daily")
                {
                    string tempVar = "%Y-%m-%d";
                    if (type == "daily")
                    {
                        tempVar = "%Y-%m-%d";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select a.* from mailbox as a ");
                    sbsql.Append(" inner join  statistics as b on a.MailId = b.MailId ");
                    sbsql.Append(" where date_format(a.InsertTimeStamp, '" + tempVar + "') = date_format(now(), '" + tempVar + "') ");
                    sbsql.Append(" and b.IsInternal=1 ");
                    sbsql.Append(" and b.ReceiverId !=0 ");
                    sbsql.Append(" order by a.InsertTimeStamp ASC ");
                    sbsql.Append(" Limit 10 ");
                    sbsql.Append(" ; ");
                }
                else
                {
                    string temp = "WEEK";
                    if (type == "weekly")
                    {
                        temp = "WEEK";
                    }
                    else if (type == "monthly")
                    {
                        temp = "MONTH";
                    }
                    else if (type == "yearly")
                    {
                        temp = "YEAR";
                    }
                    sbsql.Clear();
                    sbsql.Append(" select a.* from mailbox as a ");
                    sbsql.Append(" inner join  statistics as b on a.MailId = b.MailId ");
                    sbsql.Append(" where a.InsertTimeStamp between date_sub(now(),INTERVAL 1 " + temp + ") and now() ");
                    sbsql.Append(" and b.IsInternal=1 ");
                    sbsql.Append(" and b.ReceiverId !=0 ");
                    sbsql.Append(" order by a.InsertTimeStamp ASC ");
                    sbsql.Append(" Limit 10 ");
                    sbsql.Append(" ; ");
                }

                
                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectedList = (List<DashboardModel>)list;

            }
            catch (Exception e)
            {
            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }
            return SelectedList;
        }

        public List<DashboardModel> GetIncomingExternalTop10List(string type, UserSession UISssn)
        {
            List<DashboardModel> SelectedList = new List<DashboardModel>();
            Object list = new List<DashboardModel>();
            Object listitem = new DashboardModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                if (type == "daily")
                {
                    string tempVar = "%Y-%m-%d";
                    if (type == "daily")
                    {
                        tempVar = "%Y-%m-%d";
                    }

                    sbsql.Clear();
                    sbsql.Append(" select a.* from mailbox as a ");
                    sbsql.Append(" inner join  statistics as b on a.MailId = b.MailId ");
                    sbsql.Append(" where date_format(a.InsertTimeStamp, '" + tempVar + "') = date_format(now(), '" + tempVar + "') ");
                    sbsql.Append(" and b.IsExternal=1 ");
                    sbsql.Append(" and b.ReceiverId !=0 ");
                    sbsql.Append(" order by a.InsertTimeStamp ASC ");
                    sbsql.Append(" Limit 10 ");
                    sbsql.Append(" ; ");
                }
                else
                {
                    string temp = "WEEK";
                    if (type == "weekly")
                    {
                        temp = "WEEK";
                    }
                    else if (type == "monthly")
                    {
                        temp = "MONTH";
                    }
                    else if (type == "yearly")
                    {
                        temp = "YEAR";
                    }
                    sbsql.Clear();
                    sbsql.Append(" select a.* from mailbox as a ");
                    sbsql.Append(" inner join  statistics as b on a.MailId = b.MailId ");
                    sbsql.Append(" where a.InsertTimeStamp between date_sub(now(),INTERVAL 1 " + temp + ") and now() ");
                    sbsql.Append(" and b.IsExternal=1 ");
                    sbsql.Append(" and b.ReceiverId !=0 ");
                    sbsql.Append(" order by a.InsertTimeStamp ASC ");
                    sbsql.Append(" Limit 10 ");
                    sbsql.Append(" ; ");
                }

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectedList = (List<DashboardModel>)list;

            }
            catch (Exception e)
            {
            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }
            return SelectedList;
        }
    }
}