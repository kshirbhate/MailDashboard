using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCHackathon.Models;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using MVCHackathon.utilities;

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

    }
}