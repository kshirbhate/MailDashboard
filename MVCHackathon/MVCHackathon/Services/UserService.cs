using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCHackathon.Models;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Data.Common;
using MySql.Data.MySqlClient;
using MVCHackathon.utilities;
using MVCHackathon.Areas.Customer.Models;
namespace MVCHackathon.Services
{
    public class UserService
    {
        private static UserService _instance;

        public static UserService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserService();
                return _instance;
            }
        }

        public UserService()
        {

        }

        public bool doSignIn(UserModel model, UserSession UISssn)
        {
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
                sbsql.Append(" SELECT ");
                sbsql.Append(" a.* FROM tbmuser AS a ");
                sbsql.Append(" WHERE a.`UserName`= ");
                sbsql.Append("'"+model.UserName+"'");
                sbsql.Append(" AND a.`Password`= ");
                sbsql.Append("'"+model.Password+"'");
                sbsql.Append(" AND a.`Active`= ");
                sbsql.Append(Context.ACTIVE);
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                UserModel userModel = new UserModel();
                userModel = (UserModel)oModel;
                
                if (model.UserName == userModel.UserName && model.Password == userModel.Password)
                {
                    bretval = true;
                    UISssn.LoggedInUserId = userModel.UserId;
                    UISssn.UserRoleId = userModel.UserRoleId;
                    UISssn.UserRealName = userModel.UserRealName;
                    UISssn.Email = userModel.Email;
                    UISssn.UnitId = userModel.UnitId;
                    UISssn.UnitName = userModel.UnitName;
                }
                else
                {
                    bretval = false;
                }
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
            return bretval;
        }

        public bool checkEmailExists(UserModel model, UserSession UISssn)
        {
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
                sbsql.Append(" SELECT ");
                sbsql.Append(" a.* FROM tbmuser AS a ");
                sbsql.Append(" WHERE a.`Email`= ");
                sbsql.Append("'" + model.Email + "'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                UserModel userModel = new UserModel();
                userModel = (UserModel)oModel;

                if (model.Email == userModel.Email)
                {
                    UISssn.Email = userModel.Email;
                    bretval = true;
                }
                else
                {
                    bretval = false;
                }
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
            return bretval;
        }

        public bool checkUserNameExists(UserModel model, UserSession UISssn)
        {
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
                sbsql.Append(" SELECT ");
                sbsql.Append(" a.* FROM tbmuser AS a ");
                sbsql.Append(" WHERE a.`UserName`= ");
                sbsql.Append("'" + model.UserName + "'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                UserModel userModel = new UserModel();
                userModel = (UserModel)oModel;

                if (model.UserName == userModel.UserName)
                {
                    bretval = true;
                }
                else
                {
                    bretval = false;
                }
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
            return bretval;
        }

        public bool checkOldPassword(UserModel model, UserSession UISssn)
        {
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
                sbsql.Append(" SELECT ");
                sbsql.Append(" a.* FROM tbmuser AS a ");
                sbsql.Append(" WHERE a.`Email`= ");
                sbsql.Append("'" + UISssn.Email + "'");
                sbsql.Append(" AND a.`Password`= ");
                sbsql.Append("'" + model.OldPassword + "'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                UserModel userModel = new UserModel();
                userModel = (UserModel)oModel;

                if (UISssn.Email == userModel.Email && model.OldPassword == userModel.Password)
                {
                    bretval = true;
                }
                else
                {
                    bretval = false;
                }
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
            return bretval;
        }

        public bool checkOTPinDb(UserModel model, UserSession UISssn)
        {
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
                sbsql.Append(" SELECT ");
                sbsql.Append(" a.* FROM otpcollection AS a ");
                sbsql.Append(" WHERE a.`Email`= ");
                sbsql.Append("'" + UISssn.Email + "'");
                sbsql.Append(" AND a.`Token`= ");
                sbsql.Append("'" + model.Token + "'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }

                UserModel userModel = new UserModel();
                userModel = (UserModel)oModel;
                model.Email = UISssn.Email;
                if (model.Email == userModel.Email && model.Token == userModel.Token)
                {
                    bretval = true;
                }
                else
                {
                    bretval = false;
                }
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
            return bretval;
        }

        public bool SendOtp(UserModel model, UserSession UISssn)
        {
            bool bretval = false;
            Object oModel = new UserModel();

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            bool closeTransaction = false;
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Append(" insert into otpcollection ");
                sbsql.Append(" values ( ");
                sbsql.Append(0);
                sbsql.Append(",");
                sbsql.Append("'" + model.Email + "', ");
                sbsql.Append("'" + model.Token + "'");
                sbsql.Append(" ) ");
                sbsql.Append(" ; ");


                cmd.CommandText = sbsql.ToString();
                int resultCount = cmd.ExecuteNonQuery();

                if (resultCount == 1)
                {
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("maildashboardgpa@gmail.com", "Gpaadmin!123");

                    string messageBody = "Please use following OTP for your forget password process. Your Token is "+model.Token+". Do not share this with anyone.";

                    MailMessage mm = new MailMessage(model.Email, model.Email, "OTP for Forget Password", messageBody);
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    client.Send(mm);
                    bretval = true;
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

        public bool UpdatePassword(UserModel model, UserSession UISssn)
        {
            bool bretval = false;
            Object oModel = new UserModel();

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            bool closeTransaction = false;
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Append(" UPDATE tbmuser ");
                sbsql.Append(" SET Password = ");
                sbsql.Append("'" + model.Password + "'");
                sbsql.Append(" WHERE Email = ");
                sbsql.Append("'" + UISssn.Email + "'");
                sbsql.Append(" ; ");


                cmd.CommandText = sbsql.ToString();
                int resultCount = cmd.ExecuteNonQuery();

                bretval = true;
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

        public CustomerModel getUserData(CustomerModel model, UserSession UISssn)
        {
            bool bretval = false;
            Object oModel = new CustomerModel();
            CustomerModel userModel = new CustomerModel();

            DbDataReader reader = null;

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();

                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Clear();
                sbsql.Append(" SELECT ");
                sbsql.Append(" a.* FROM register_user AS a ");
                sbsql.Append(" WHERE a.`Email`= ");
                sbsql.Append("'" + UISssn.Email + "'");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    Common.Instance.ConvertRsObj(ref oModel, reader);
                }


                userModel = (CustomerModel)oModel;

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
            return userModel;
        }
    }

}