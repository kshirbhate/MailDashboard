using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using MVCHackathon.Models;

namespace MVCHackathon
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Session_Start(object sender, EventArgs e)
        {
            UserSession oUISession = new UserSession();

            oUISession.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseServer"].ConnectionString;

            oUISession.Today = DateTime.Now;

            Session["UserSession"] = oUISession;
        }
    }
}
