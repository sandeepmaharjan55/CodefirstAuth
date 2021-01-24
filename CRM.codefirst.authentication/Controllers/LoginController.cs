using CRM.codefirst.authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRM.codefirst.authentication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel lvm, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(lvm.UserName, lvm.Password)) {

                    FormsAuthentication.SetAuthCookie(lvm.UserName, true);
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    return Redirect("~/home");
                }
            }
            return View(lvm);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Login");
        }
    }
}