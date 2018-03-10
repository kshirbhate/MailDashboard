using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHackathon.Models;
using MVCHackathon.Services;
using System.Web.Mvc;
using System.IO;
 using MVCHackathon.Areas.Mailbox.Models;
using MVCHackathon.Areas.Mailbox.Services;
using MVCHackathon.utilities;

namespace MVCHackathon.Areas.Mailbox.Controllers
{
    public class MailboxController : SessionController
    {
        // GET: Mailbox/Mailbox
        [HttpGet]
        public ActionResult Index()
        {
            setupSession();
            MailModel model = new MailModel();
            model.MailBoxSubTitle = "Inbox";
            model.List = MailboxService.Instance.GetInboxList(model, UserSession);
            return View(model);
        }

        [HttpGet]
        public JsonResult GetMailList(long Id = 1)
        {
            setupSession();
            MailModel model = new MailModel();
            if (Id == 1)
            {
                model.MailBoxSubTitle = "Inbox";

            }
            else if (Id == 2)
            {
                model.MailBoxSubTitle = "Sent";
            }
            else if (Id == 3)
            {
                model.MailBoxSubTitle = "Draft";
            }
            else if (Id == 4)
            {
                model.MailBoxSubTitle = "Span";
            }
            return Json(Id, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ComposeMail()
        {
            setupSession();
            MailModel model = new MailModel();
            return View(model);
         
        }
        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "Send")]
        public ActionResult Send(MailModel model)
        {
            setupSession();
            bool bretval = false;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/FileUploads/Attachements/"), UserSession.LoggedInUserId + fileName);
                    file.SaveAs(path);
                    model.AttachmentSize = (file.ContentLength / 1024).ToString();
                    model.Attachment = "/FileUploads/Attachements/" + UserSession.LoggedInUserId + fileName;
                }
            }
            model.From = UserSession.Email;
            model.Status = 1;
            bretval = MailboxService.Instance.SendMessage(ref model, UserSession);
            bool isInternal = MailboxService.Instance.checkInternal(model.From, model.To);
            if (isInternal == true)
            {
                model.IsInternal = 1;
                model.IsExternal = 0;
            }
            else
            {
                model.IsInternal = 0;
                model.IsExternal = 1;
            }
            model.SenderId = UserSession.LoggedInUserId;
            model.ReceiverId = MailboxService.Instance.getUserIdByEMail(model.To, UserSession);
            bretval = MailboxService.Instance.InsertStatistics(model, UserSession);
            if (bretval)
            {
                ViewBag.IsSuccess = true;
                ViewBag.Message = "Message has been sent succesfully.";
            }
            model = new MailModel();
            return View("ComposeMail", model);
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "Save")]
        public ActionResult Save(MailModel model)
        {
            setupSession();
            bool bretval = false;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/FileUploads/Attachements/"), UserSession.LoggedInUserId + fileName);
                    file.SaveAs(path);
                    model.AttachmentSize = (file.ContentLength / 1024).ToString();
                    model.Attachment = "/FileUploads/Attachements/" + UserSession.LoggedInUserId + fileName;
                }
            }
            model.From = UserSession.Email;
            model.Status = 2;
            bretval = MailboxService.Instance.SendMessage(ref model, UserSession);
            bool isInternal = MailboxService.Instance.checkInternal(model.From, model.To);
            if (isInternal == true)
            {
                model.IsInternal = 1;
                model.IsExternal = 0;
            }
            else
            {
                model.IsInternal = 0;
                model.IsExternal = 1;
            }
            model.SenderId = UserSession.LoggedInUserId;
            model.ReceiverId = MailboxService.Instance.getUserIdByEMail(model.To, UserSession);
            bretval = MailboxService.Instance.InsertStatistics(model, UserSession);
            if (bretval)
            {
                ViewBag.IsSuccess = true;
                ViewBag.Message = "Message has been saved as a draft.";
            }
            model = new MailModel();
            return View("ComposeMail", model);
        }

        public ActionResult SentMail()
        {
            setupSession();
            MailModel model = new MailModel();
            model.MailBoxSubTitle = "Sent";
            model.List = MailboxService.Instance.GetSentMailList(model, UserSession);
            return View(model);

        }

        public ActionResult DraftMail()
        {
            setupSession();
            MailModel model = new MailModel();
            model.MailBoxSubTitle = "Drafts";
            model.List = MailboxService.Instance.GetDraftMailList(model, UserSession);
            return View(model);
        }

        public ActionResult SpamMail()
        {
            setupSession();
            MailModel model = new MailModel();
            model.MailBoxSubTitle = "Spams";
            return View(model);
        }

        public ActionResult DetailMail(long MailId)
        {
            setupSession();
            MailModel model = new MailModel();            
            model = MailboxService.Instance.getMailById(MailId, UserSession);
            model.MailBoxSubTitle = "Mail Details";
            return View(model);
        }

    }
}