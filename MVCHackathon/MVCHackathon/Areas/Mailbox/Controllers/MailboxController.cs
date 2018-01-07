using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHackathon.utilities;

namespace MVCHackathon.Areas.Mailbox.Controllers
{
    public class MailboxController : SessionController
    {
        // GET: Mailbox/Mailbox
        public ActionResult Index()
        {
            setupSession();
            return View();
        }

        public ActionResult ComposeMail()
        {
            setupSession();
            return View();
        }
    }
}