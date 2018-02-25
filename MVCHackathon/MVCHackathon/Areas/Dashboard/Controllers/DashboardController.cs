using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHackathon.utilities;
using MVCHackathon.Areas.Dashboard.Models;
using MVCHackathon.Areas.Mailbox.Models;
using MVCHackathon.Areas.Dashboard.Services;
using MVCHackathon.utilities;

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
            OutgoingExternalList.Daily = DashboardService.Instance.GetOutgoingToExternalCount("daily", UserSession);
            OutgoingExternalList.Weekly = DashboardService.Instance.GetOutgoingToExternalCount("weekly", UserSession);
            OutgoingExternalList.Monthly = DashboardService.Instance.GetOutgoingToExternalCount("monthly", UserSession);
            OutgoingExternalList.Yearly = DashboardService.Instance.GetOutgoingToExternalCount("yearly", UserSession);

            model.OutgoingExternalList.Add(OutgoingExternalList);

            DashboardModel OutgoingInternalList = new DashboardModel();
            OutgoingInternalList.Daily = DashboardService.Instance.GetOutgoingToInternalCount("daily", UserSession);
            OutgoingInternalList.Weekly = DashboardService.Instance.GetOutgoingToInternalCount("weekly", UserSession);
            OutgoingInternalList.Monthly = DashboardService.Instance.GetOutgoingToInternalCount("monthly", UserSession);
            OutgoingInternalList.Yearly = DashboardService.Instance.GetOutgoingToInternalCount("yearly", UserSession);
            model.OutgoingInternalList.Add(OutgoingInternalList);

            DashboardModel IncomingExternalList = new DashboardModel();
            IncomingExternalList.Daily = DashboardService.Instance.GetIncomingFromExternalCount("daily", UserSession);
            IncomingExternalList.Weekly = DashboardService.Instance.GetIncomingFromExternalCount("weekly", UserSession);
            IncomingExternalList.Monthly = DashboardService.Instance.GetIncomingFromExternalCount("monthly", UserSession);
            IncomingExternalList.Yearly = DashboardService.Instance.GetIncomingFromExternalCount("yearly", UserSession);
            model.IncomingExternalList.Add(IncomingExternalList);

            DashboardModel IncomingInternalList = new DashboardModel();
            IncomingInternalList.Daily = DashboardService.Instance.GetIncomingFromInternalCount("daily", UserSession);
            IncomingInternalList.Weekly = DashboardService.Instance.GetIncomingFromInternalCount("weekly", UserSession);
            IncomingInternalList.Monthly = DashboardService.Instance.GetIncomingFromInternalCount("monthly", UserSession);
            IncomingInternalList.Yearly = DashboardService.Instance.GetIncomingFromInternalCount("yearly", UserSession);
            model.IncomingInternalList.Add(IncomingInternalList);

            return View(model);
        }

        public ActionResult OutgoingInternalReport()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailyList = DashboardService.Instance.GetOutgoingInternalTop10List("daily", UserSession);
            model.WeeklyList = DashboardService.Instance.GetOutgoingInternalTop10List("weekly", UserSession);
            model.MonthlyList = DashboardService.Instance.GetOutgoingInternalTop10List("monthly", UserSession);
            model.YearlyList = DashboardService.Instance.GetOutgoingInternalTop10List("yearly", UserSession);
            return View(model);
        }

        public ActionResult OutgoingExternalReport()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailyList = DashboardService.Instance.GetOutgoingExternalTop10List("daily", UserSession);
            model.WeeklyList = DashboardService.Instance.GetOutgoingExternalTop10List("weekly", UserSession);
            model.MonthlyList = DashboardService.Instance.GetOutgoingExternalTop10List("monthly", UserSession);
            model.YearlyList = DashboardService.Instance.GetOutgoingExternalTop10List("yearly", UserSession);
            return View(model);
        }

        public ActionResult IncomingInternalReport()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailyList = DashboardService.Instance.GetIncomingInternalTop10List("daily", UserSession);
            model.WeeklyList = DashboardService.Instance.GetIncomingInternalTop10List("weekly", UserSession);
            model.MonthlyList = DashboardService.Instance.GetIncomingInternalTop10List("monthly", UserSession);
            model.YearlyList = DashboardService.Instance.GetIncomingInternalTop10List("yearly", UserSession);
            return View(model);
        }

        public ActionResult IncomingExternalReport()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailyList = DashboardService.Instance.GetIncomingExternalTop10List("daily", UserSession);
            model.WeeklyList = DashboardService.Instance.GetIncomingExternalTop10List("weekly", UserSession);
            model.MonthlyList = DashboardService.Instance.GetIncomingExternalTop10List("monthly", UserSession);
            model.YearlyList = DashboardService.Instance.GetIncomingExternalTop10List("yearly", UserSession);
            return View(model);
        }

        public ActionResult OutgoingInternalTop10Ids()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("daily","receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult OutgoingExternalTop10Ids()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult IncomingInternalTop10Ids()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetIncomingInternalTop10IdsList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetIncomingInternalTop10IdsList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetIncomingInternalTop10IdsList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetIncomingInternalTop10IdsList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetIncomingInternalTop10IdsList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetIncomingInternalTop10IdsList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetIncomingInternalTop10IdsList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetIncomingInternalTop10IdsList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult IncomingExternalTop10Ids()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetIncomingExternalTop10IdsList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetIncomingExternalTop10IdsList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetIncomingExternalTop10IdsList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetIncomingExternalTop10IdsList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetIncomingExternalTop10IdsList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetIncomingExternalTop10IdsList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetIncomingExternalTop10IdsList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetIncomingExternalTop10IdsList("yearly", "receiver", UserSession);

            return View(model);
        }

    }
}