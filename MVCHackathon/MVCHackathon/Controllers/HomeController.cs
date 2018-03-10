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

        public ActionResult ForgetPassword()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "doSignIn")]
        public ActionResult doSignIn(UserModel model)
        {
            bool bretval = false;
            if(string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                return View();
            }
            else
            {
                bretval = UserService.Instance.doSignIn(model, UserSession);

                if (bretval)
                {
                    setupSession();
                    if (ViewBag.UserRoleId == Context.ADMIN)
                    {
                        return Redirect(Url.RouteUrl(new { Area = "Dashboard", Controller = "Dashboard", action = "Index" }));
                    }
                    else
                    {
                        return Redirect(Url.RouteUrl(new { Area = "Customer", Controller = "Customer", action = "Index" }));
                    }

                }

                return View("Index");
            }            
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "doSendOtp")]
        public ActionResult doSendOtp(UserModel model)
        {
            setupSession();
            bool bretval = false;
            bool isEmailExists = false;
            isEmailExists = UserService.Instance.checkEmailExists(model, UserSession);
            if (isEmailExists)
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                model.Token = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                bretval = UserService.Instance.SendOtp(model, UserSession);
                if (bretval)
                {
                    ViewBag.IsSuccess = true;
                    ViewBag.Message = "OTP has been sent your email id, Please Enter OTP here.";
                    ViewBag.IsOtpSend = true;
                    return View("ForgetPassword", model);
                }
            }
            else
            {
                ViewBag.IsError = true;
                ViewBag.Message = "Email does not exists.";
                return View("ForgetPassword", model);
            }
            return View("ForgetPassword", model);
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "doConfirmOtp")]
        public ActionResult doConfirmOtp(UserModel model)
        {
            setupSession();
            bool bretval = false;
            bool isOtpMatched = false;
            isOtpMatched = UserService.Instance.checkOTPinDb(model, UserSession);
            if (isOtpMatched)
            {
                ViewBag.ShowPasswordChange = true;
                return View("ForgetPassword", model);
            }
            else
            {
                ViewBag.IsError = true;
                ViewBag.IsOtpSend = false;
                ViewBag.Message = "Otp you entered is wrong.";
                return View("ForgetPassword", model);
            }
            return View("ForgetPassword");
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "doChangePassword")]
        public ActionResult doChangePassword(UserModel model)
        {
            setupSession();
            bool bretval = false;
            bool isPasswordMatched = false;
            if(model.Password == model.ConfirmPassword)
            {
                isPasswordMatched = true;
            }
            if (isPasswordMatched)
            {
                bretval = UserService.Instance.UpdatePassword(model,UserSession);
                ViewBag.IsSuccess = true;
                ViewBag.Message = "Password has been reseted. Login Again.";
                return View("Index");
            }
            else
            {
                ViewBag.ShowPasswordChange = true;
                ViewBag.IsError = true;
                ViewBag.Message = "Password does not matched.";
                return View("ForgetPassword", model);
            }
            return View("ForgetPassword");
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
            bool isEmailExists = false;
            bool isUsernameExists = false;
            UserModel userModel = new UserModel();
            userModel.Email = model.Email;
            userModel.UserName = model.UserName;
            isEmailExists = UserService.Instance.checkEmailExists(userModel, UserSession);
            isUsernameExists = UserService.Instance.checkUserNameExists(userModel, UserSession);

            if (isEmailExists)
            {
                ViewBag.IsError = true;
                ViewBag.Message = "Entered Email is already exists.";
                return View("Register", model);
            }
            if (isUsernameExists)
            {
                ViewBag.IsError = true;
                ViewBag.Message = "Entered User Name is already exists.";
                return View("Register", model);
            }

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

        public ActionResult ChangePassword()
        {
            setupSession();
            return View();
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "doChangeOldPassword")]
        public ActionResult doChangeOldPassword(UserModel model)
        {
            setupSession();
            bool bretval = false;
            bool isOldPasswordMatched = false;
            isOldPasswordMatched = UserService.Instance.checkOldPassword(model, UserSession);
            if (isOldPasswordMatched)
            {
                bool isPasswordMatched = false;
                if (model.Password == model.ConfirmPassword)
                {
                    isPasswordMatched = true;
                }
                if (isPasswordMatched)
                {
                    bretval = UserService.Instance.UpdatePassword(model, UserSession);
                    ViewBag.IsSuccess = true;
                    ViewBag.Message = "Password has been reseted. Login Again.";
                    return View("ChangePassword");
                }
                else
                {
                    ViewBag.IsError = true;
                    ViewBag.Message = "New and Confirm Password does not matched.";
                    return View("ChangePassword");
                }
            }
            else
            {
                ViewBag.IsError = true;
                ViewBag.Message = "Old Password does not matched.";
                return View("ChangePassword");
            }
            
        }

        public ActionResult EditProfile()
        {
            setupSession();
            CustomerModel model = new CustomerModel();
            model.UserId = UserSession.LoggedInUserId;
            model = UserService.Instance.getUserData(model, UserSession);
            return View(model);
        }

        [HttpPost]
        [ButtonActionNameSelector(ButtonName = "updateProfile")]
        public ActionResult updateProfile(CustomerModel model)
        {
            setupSession();
            bool bretval = false;
            bretval = CustomerService.Instance.UpdateRegister(model, UserSession);
            return RedirectToAction("Index");
        }
    }
}