using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHackathon.utilities;

namespace MVCHackathon.Areas.Dashboard.Controllers
{
    public class DashboardController : SessionController
    {
        // GET: Dashboard/Dashboard
        public ActionResult Index()
        {
            setupSession();
            return View();
        }
    }
}