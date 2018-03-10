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
using MVCHackathon.Areas.Mailbox.Models;
namespace MVCHackathon.Areas.Mailbox.Services
{
    public class MailboxService
    {
        private static MailboxService _instance;

        public static MailboxService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MailboxService();
                return _instance;
            }
        }

        public MailboxService()
        {

        }
        public bool SendMessage(ref MailModel model, UserSession UISssn)
        {
            bool bretval = false;
            Object oModel = new MailModel();

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            bool closeTransaction = false;
            try
            {                
                model.InsertByUserId = UISssn.LoggedInUserId;
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Append(" insert into mailbox ");
                sbsql.Append(" values ( ");
                sbsql.Append(0);
                sbsql.Append(",");
                sbsql.Append("'"+model.To+"', ");
                sbsql.Append("'" + model.Cc + "', ");
                sbsql.Append("'" + model.Bcc + "', ");
                sbsql.Append("'" + model.From + "', ");
                sbsql.Append("'" + model.Subject + "', ");
                sbsql.Append("'" + model.Message + "', ");
                sbsql.Append("'" + model.Attachment + "', ");
                sbsql.Append(model.Status + ",");
                sbsql.Append(model.InsertByUserId + ",");
                sbsql.Append("Now()");
                sbsql.Append(" ) ");
                sbsql.Append(" ; ");                 

                cmd.CommandText = sbsql.ToString();

                int resultCount = cmd.ExecuteNonQuery();

                if(resultCount == 1)
                {
                    bretval = true;
                    model.MailId = GetLastId("mailbox", "MailId", UISssn);
                }
            }
            catch (Exception)
            {
                bretval = false;
            }
            finally
            {
                connection.Close();
            }


            return bretval;
        }

        public long GetLastId(string tablaName, string columnName, UserSession UISssn)
        {
            long id = 0;
            bool bretval = false;
            Object oModel = new MailModel();
            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            bool closeTransaction = false;
            DbDataReader reader = null;

            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Clear();
                sbsql.Append(" SELECT ");
                sbsql.Append(" MAX(a. ");
                sbsql.Append(columnName);
                sbsql.Append(" ) AS MailId FROM  ");
                sbsql.Append(tablaName);
                sbsql.Append(" AS a ");
                sbsql.Append(" ; ");
                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                MailModel temp = new MailModel();
                temp = (MailModel)oModel;
                id = temp.MailId;

                bretval = true;
            }
            catch (Exception)
            {
                bretval = false;
            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }

            return id;
        }

        public bool checkInternal(string from, string to)
        {
            bool bRetval = false;
            string [] Str1= new string[100];
            string[] Str2 = new string[100];
            Str1 = from.Split('@');
            Str2 = to.Split('@');

            if(Str1[1] == Str2[1])
            {
                bRetval = true;
            }
            return bRetval;
        }
        public long getUserIdByEMail(String EmailId, UserSession UISssn)
        {
            long UserId = 0;
            bool bretval = false;
            Object oModel = new UserModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();

                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Clear();
                sbsql.Append(" SELECT * FROM tbmuser where Email =  ");
                sbsql.Append("'"+EmailId+"'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                UserModel userModel = new UserModel();
                userModel = (UserModel)oModel;
                UserId = userModel.UserId;
                
            }
            catch (Exception)
            {
                bretval = false;
            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }
            return UserId;
        }

        public bool InsertStatistics(MailModel model, UserSession UISssn)
        {
            bool bretval = false;
            Object oModel = new MailModel();

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            bool closeTransaction = false;
            try
            {
                model.InsertByUserId = UISssn.LoggedInUserId;
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);              

                sbsql.Append(" insert into statistics ");
                sbsql.Append(" values ( ");
                sbsql.Append(0);
                sbsql.Append(",");
                sbsql.Append("'" + model.MailId + "', ");
                sbsql.Append("'" + model.SenderId + "', ");
                sbsql.Append("'" + model.ReceiverId + "', ");
                sbsql.Append("'" + model.IsInternal + "', ");
                sbsql.Append("'" + model.IsExternal + "', ");
                sbsql.Append("'" + model.AttachmentSize + "', ");
                sbsql.Append(model.InsertByUserId + ",");
                sbsql.Append("Now()");
                sbsql.Append(" ) ");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();

                int resultCount = cmd.ExecuteNonQuery();

                if (resultCount == 1)
                {
                    bretval = true;
                }
            }
            catch (Exception e)
            {
                bretval = false;
            }
            finally
            {
                connection.Close();
            }


            return bretval;
        }

        public List<MailModel> GetInboxList(MailModel model, UserSession UISssn)
        {
            List<MailModel> SelectedList = new List<MailModel>();
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
                sbsql.Append(" SELECT a.* FROM mailbox as a ");
                sbsql.Append(" where a.To = ");
                sbsql.Append("'" + UISssn.Email + "'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectedList = (List<MailModel>)list;

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

        public List<MailModel> GetSentMailList(MailModel model, UserSession UISssn)
        {
            List<MailModel> SelectedList = new List<MailModel>();
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
                sbsql.Append(" SELECT a.* FROM mailbox as a ");
                sbsql.Append(" where a.From = ");
                sbsql.Append("'" + UISssn.Email + "'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectedList = (List<MailModel>)list;

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

        public List<MailModel> GetDraftMailList(MailModel model, UserSession UISssn)
        {
            List<MailModel> SelectedList = new List<MailModel>();
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
                sbsql.Append(" SELECT a.* FROM mailbox as a ");
                sbsql.Append(" where a.From = ");
                sbsql.Append("'" + UISssn.Email + "'");
                sbsql.Append(" and a.Status!=1 ");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectedList = (List<MailModel>)list;

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

        public MailModel getMailById(long MailId, UserSession UISssn)
        {
            MailModel model = new MailModel();
            Object oModel = new MailModel();
            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();

                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Clear();
                sbsql.Append(" SELECT * FROM mailbox where MailId =  ");
                sbsql.Append("'" + MailId + "'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                model = (MailModel)oModel;

            }
            catch (Exception)
            {
            }
            finally
            {
                reader = Common.Instance.CloseReader(reader);
                connection.Close();
            }
            return model;
        }


        public List<MailModel> updateTimes(MailModel model, UserSession UISssn)
        {
            List<MailModel> SelectedList = new List<MailModel>();
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
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();

                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref list, reader, listitem);
                }

                SelectedList = (List<MailModel>)list;

                
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

        public bool UpdateMailTime(MailModel model, UserSession UISssn)
        {
            bool bretval = false;
            Object oModel = new MailModel();

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            bool closeTransaction = false;
            try
            {
                model.InsertByUserId = UISssn.LoggedInUserId;
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);

                sbsql.Clear();
                sbsql.Append(" Update mailbox ");
                sbsql.Append(" set InsertTimeStamp = ");
                sbsql.Append("'" + Convert.ToDateTime(model.InsertTimeStamp) + "' ");
                sbsql.Append(" where MailId = ");
                sbsql.Append(model.MailId);
                sbsql.Append(" ; ");
                cmd.CommandText = sbsql.ToString();

                int resultCount = cmd.ExecuteNonQuery();
                bretval = true;
                
            }
            catch (Exception e)
            {
                bretval = false;
            }
            finally
            {
                connection.Close();
            }


            return bretval;
        }
    }
}