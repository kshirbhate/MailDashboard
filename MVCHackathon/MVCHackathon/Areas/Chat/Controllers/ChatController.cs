using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHackathon.utilities;

namespace MVCHackathon.Areas.Chat.Controllers
{
    public class ChatController : SessionController
    {
        // GET: Chat/Chat
        public ActionResult Index()
        {
            setupSession();
            return View();
        }
    }
}