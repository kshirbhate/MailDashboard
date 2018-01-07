using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCHackathon.Models;

namespace MVCHackathon.utilities
{
    public class SessionController : Controller
    {
        public UserSession UserSession
        {
            get
            {
                if (HttpContext.Session["UserSession"] == null)
                    HttpContext.Session["UserSession"] = new UserSession();

                return (UserSession)HttpContext.Session["UserSession"];
            }
            set
            {
                HttpContext.Session["UserSession"] = value;
            }
        }

        protected void setupSession()
        {
            ViewBag.UserId = UserSession.LoggedInUserId;
            ViewBag.UserRoleId = UserSession.UserRoleId;
            ViewBag.UserRealName = UserSession.UserRealName;
            ViewBag.Email = UserSession.Email;
            ViewBag.UnitId = UserSession.UnitId;
            ViewBag.UnitName = UserSession.UnitName;

        }
    }
}