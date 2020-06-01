using Models;
using Models.Model;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var res = new AccountModel().Login(model.userName, model.password);
            if (res && ModelState.IsValid)
            {
                var session = new UserLogin() 
                {
                    userName=model.userName
                };
                Session.Add(CommonConstants.UserSession, session);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("","Đăng nhập thất bại!");
            }
            return View(model);
        }
    }
}