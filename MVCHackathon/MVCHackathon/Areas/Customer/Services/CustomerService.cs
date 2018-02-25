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
using MVCHackathon.Areas.Customer.Models;

namespace MVCHackathon.Areas.Customer.Services
{
    public class CustomerService
    {
        private static CustomerService _instance;

        public static CustomerService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CustomerService();
                return _instance;
            }
        }

        public CustomerService()
        {

        }

        public bool InsertRegister(CustomerModel model, UserSession UISssn)
        {
            bool bretval = false;
            Object oModel = new CustomerModel();

            MySqlConnection connection = new MySqlConnection(UISssn.ConnectionString);
            connection.Open();
            bool closeTransaction = false;
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sbsql = new StringBuilder(1024);
                sbsql.Append(" insert into register_user ");
                sbsql.Append(" values ( ");
                sbsql.Append(0);
                sbsql.Append(",");
                sbsql.Append("'" + model.UserRealName + "', ");
                sbsql.Append("'" + model.Mobile + "', ");
                sbsql.Append("'" + model.Email + "', ");
                sbsql.Append("'" + model.UserName + "', ");
                sbsql.Append("'" + model.Address + "', ");
                sbsql.Append("'" + model.City + "', ");
                sbsql.Append("'" + model.Pincode + "', ");
                sbsql.Append("'" + model.State + "', ");
                sbsql.Append("'" + model.Country + "', ");
                sbsql.Append("'" + model.Dateofbirth + "', ");
                sbsql.Append("'" + model.Gender + "', ");
                sbsql.Append("'" + model.Password + "', ");
                sbsql.Append(model.InsertByUserId + ",");
                sbsql.Append("Now()");
                sbsql.Append(" ) ");
                sbsql.Append(" ; ");

              
               
               
              
                sbsql.Append(" insert into tbmuser ");
                sbsql.Append(" values ( ");
                sbsql.Append(0);
                sbsql.Append(",");
                sbsql.Append("'" + model.UserName + "', ");
                sbsql.Append("'" + model.Password + "', ");
                sbsql.Append("'" + model.UserRealName + "', ");              
                sbsql.Append("'" + model.Email + "', ");                          
                sbsql.Append(1);
                sbsql.Append(",");
                sbsql.Append(2);               
                sbsql.Append(" ) ");
                sbsql.Append(" ; ");

                cmd.CommandText = sbsql.ToString();
                int resultCount = cmd.ExecuteNonQuery();    





                                 
                
                if (resultCount == 1)
                {
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
    }
}