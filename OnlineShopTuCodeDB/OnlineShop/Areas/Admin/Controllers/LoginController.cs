﻿using Models;
using Models.Model;
using OnlineShop.Areas.Admin.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.userName, model.password);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { userName = model.userName });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Error");
            }
            return View(model);
        }
    }
}