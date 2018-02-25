using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHackathon.Models;
using MVCHackathon.Services;
using System.Web.Mvc;
using MVCHackathon.Areas.Customer.Models;
using MVCHackathon.Areas.Customer.Services;
using MVCHackathon.utilities;

namespace MVCHackathon.Areas.Customer.Controllers
{
    public class CustomerController : SessionController
    {
        // GET: Customer/Customer
        public ActionResult Index()
        {
            setupSession();
            return View();
        }
        public ActionResult Register_user()
        {
            setupSession();
            CustomerModel model = new CustomerModel();
            return View(model);        
        }
         [HttpPost]
        [ButtonActionNameSelector(ButtonName = "Register")]
        public ActionResult Register_user(CustomerModel model)
        {
            setupSession();
            bool bretval = false;
            bretval = CustomerService.Instance.InsertRegister(model, UserSession);
            if (bretval)
            {
                ViewBag.Message = "Message has been sent succesfully.";
            }
            return RedirectToAction("ComposeMail");
        }
    }
}