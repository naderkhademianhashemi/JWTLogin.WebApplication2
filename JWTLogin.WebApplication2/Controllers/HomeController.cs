using JWTLogin.WebApplication2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

namespace JWTLogin.WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Auth"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["Auth"] = null;

            return RedirectToAction("Login");
        }
        
       

        

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password, string redirect)
        {
            #warning Login
            try
            {
                var result = IsAuth(username, password);
                if (!result)
                {

                    ViewBag.err = "Error Pass";
                    return View();
                }
                Session["Auth"] = true;
                Auth.CreateAuthentication("LoginToken");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
                return View();
            }
        }

        private bool IsAuth(string username, string password)
        {
            if (true)
                return true;
        }
    }
}