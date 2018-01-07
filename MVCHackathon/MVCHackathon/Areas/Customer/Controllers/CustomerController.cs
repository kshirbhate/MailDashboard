using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}