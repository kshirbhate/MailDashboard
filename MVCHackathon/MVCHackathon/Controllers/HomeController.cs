using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHackathon.utilities;
using MVCHackathon.Models;
using MVCHackathon.Services;
using MVCHackathon.Areas.Customer.Models;
using MVCHackathon.Areas.Customer.Services;

namespace MVCHackathon.Controllers
{
    public class HomeController : SessionController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "doSignIn")]
        public ActionResult doSignIn(UserModel model)
        {
            bool bretval = false;
            bretval = UserService.Instance.doSignIn(model, UserSession);

            if (bretval)
            {
                setupSession();
                if(ViewBag.UserRoleId == Context.ADMIN)
                {
                    return Redirect(Url.RouteUrl(new { Area = "Dashboard", Controller = "Dashboard", action = "Index" }));
                }
                else
                {
                    return Redirect(Url.RouteUrl(new { Area = "Customer", Controller = "Customer", action = "Index" }));
                }
                
            }

            return View();
        }
        public virtual ActionResult Logout()
        {
            // Close the session ...
            Session.Abandon();
            return RedirectToAction("../Home/Index");
        }

        public ActionResult Register()
        {
            setupSession();
            CustomerModel model = new CustomerModel();
            return View(model);
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "register")]
        public ActionResult register(CustomerModel model)
        {
            setupSession();
            bool bretval = false;
            bretval = CustomerService.Instance.InsertRegister(model, UserSession);
            return RedirectToAction("Index");
        }

        public ActionResult ImportantLinks()
        {
            setupSession();
            return View();
        }

        public ActionResult Help()
        {
            setupSession();
            return View();
        }

        public ActionResult About()
        {
            setupSession();
            return View();
        }
    }
}