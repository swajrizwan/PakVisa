using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PakVisa.Models;
using PakVisa.Repository;
using PakVisa.WebUI.Areas.Admin.Models;

namespace PakVisa.WebUI.Areas.Client.Controllers
{
    [Area("Admin")]
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
            if (HttpContext.Session.GetInt32("UserId").HasValue)
            {
                return RedirectToAction("Index", new { controller = "Dashboard", area = "Admin" });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SignIn(AdminSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Userlogin()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                var client = _repository.AdminSignIn(user.Username, user.Password);
                if (client != null)
                {
                    HttpContext.Session.SetInt32("UserId", client.UserloginId);
                    ViewBag.Name = client.Name;
                    return RedirectToAction("Index", new { controller = "Dashboard", area = "Admin" });
                }
            }
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("SignIn", new { controller = "Account", area = "Admin" });
        }
    }
}