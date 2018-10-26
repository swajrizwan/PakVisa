using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PakVisa.Admin.ViewModels;
using PakVisa.Models;
using PakVisa.Repository;

namespace PakVisa.Admin.Controllers
{
    public class AccountController : Controller
    {
        private IPakVisaRepository _repository;

        public AccountController(IPakVisaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            if (HttpContext.Session.GetInt32("loginId").HasValue)
            {
                return RedirectToAction("Index", new { area = "", controller = "Dashboard" });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Userlogin()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                var check = _repository.AdminSignIn(user.Username, user.Password);
                if (check != null)
                {
                    HttpContext.Session.SetInt32("loginId", check.UserloginId);
                    return RedirectToAction("Index", new { area = "", controller = "Dashboard" });
                }
            }
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("loginId");
            return RedirectToAction("SignIn", new { area = "", controller = "Account" });
        }
    }
}