using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHackathon.utilities;
using MVCHackathon.Areas.Dashboard.Models;

namespace MVCHackathon.Areas.Dashboard.Controllers
{
    public class DashboardController : SessionController
    {
        // GET: Dashboard/Dashboard
        public ActionResult Index()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            DashboardModel OutgoingExternalList = new DashboardModel();
            OutgoingExternalList.Daily = 4;
            OutgoingExternalList.Weekly = 13;
            OutgoingExternalList.Monthly = 56;
            OutgoingExternalList.Yearly = 100;

            model.OutgoingExternalList.Add(OutgoingExternalList);

            DashboardModel OutgoingInternalList = new DashboardModel();
            OutgoingInternalList.Daily = 11;
            OutgoingInternalList.Weekly = 23;
            OutgoingInternalList.Monthly = 66;
            OutgoingInternalList.Yearly = 260;
            model.OutgoingInternalList.Add(OutgoingInternalList);

            DashboardModel IncomingExternalList = new DashboardModel();
            IncomingExternalList.Daily = 34;
            IncomingExternalList.Weekly = 67;
            IncomingExternalList.Monthly = 100;
            IncomingExternalList.Yearly = 647;
            model.IncomingExternalList.Add(IncomingExternalList);

            DashboardModel IncomingInternalList = new DashboardModel();
            IncomingInternalList.Daily = 62;
            IncomingInternalList.Weekly = 240;
            IncomingInternalList.Monthly = 567;
            IncomingInternalList.Yearly = 890;
            model.IncomingInternalList.Add(IncomingInternalList);

            return View(model);
        }
    }
}