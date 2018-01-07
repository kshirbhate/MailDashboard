using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            bool closeTransaction = false;
            try
            {
                
                model.InsertByUserId = UISssn.LoggedInUserId;
                
                bretval = true;
            }
            catch (Exception)
            {
                bretval = false;
                
            }
            finally
            {
                
            }
            return bretval;
        }
    }
}