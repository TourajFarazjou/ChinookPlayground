using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChinookPlayground.WebMvc.Controllers
{
    /// <summary>
    /// https://www.c-sharpcorner.com/article/custom-authentication-with-asp-net-mvc/
    /// </summary>
    public class AccountController : Controller
    {

        //public AccountController()
        //{

        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                //return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            throw new NotImplementedException();
            //HttpCookie cookie = new HttpCookie("Cookie1", "");
            //cookie.Expires = DateTime.Now.AddYears(-1);
            //Response.Cookies.Add(cookie);
            //
            //FormsAuthentication.SignOut();
            //return RedirectToAction("Login", "Account", null);
        }

    }
}