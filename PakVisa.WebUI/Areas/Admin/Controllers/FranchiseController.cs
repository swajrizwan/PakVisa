using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PakVisa.Models;
using PakVisa.Repository;
using PakVisa.WebUI.Areas.Admin.Models;

namespace PakVisa.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FranchiseController : BaseController
    {
        private IPakVisaRepository _repository;

        public FranchiseController(IPakVisaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(FranchiseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signUp = new Userlogin()
                {
                    Name = model.Name,
                    Username = model.Username,
                    Password = model.Password,
                    IsUserClient = true,
                    IsUserAdmin = false,
                    IsUserVisitor = false
                };
                await _repository.Add(signUp);
                await _repository.Save();
                var user = _repository.ClientSignIn(signUp.Username, signUp.Password);
                if (user != null)
                {
                    var franchise = new Franchise()
                    {
                        Address = model.Address,
                        Date = DateTime.Now,
                        Fax = model.Fax,
                        IsApproved = model.IsApproved,
                        IsRestrict = model.IsRestrict,
                        Landline = model.Landline,
                        Name = model.FranchiseName,
                        Phone = model.Phone,
                        Phone2 = model.Phone2,
                        UserloginId = user.UserloginId,

                    };
                    var stream = new MemoryStream();
                    using (stream)
                    {
                        await model.Agreement.CopyToAsync(stream);
                        franchise.Agreement = stream.ToArray();
                        stream.Flush();
                        await model.CNICPassport.CopyToAsync(stream);
                        franchise.CNICPassport = stream.ToArray();
                        stream.Flush();
                        await model.DTSLicense.CopyToAsync(stream);
                        franchise.DTSLicense = stream.ToArray();
                        stream.Flush();
                        await model.IATALicense.CopyToAsync(stream);
                        franchise.IATALicense = stream.ToArray();
                        stream.Flush();
                        await model.Logo.CopyToAsync(stream);
                        franchise.Logo = stream.ToArray();
                        stream.Flush();
                        await model.NTNCertificate.CopyToAsync(stream);
                        franchise.NTNCertificate = stream.ToArray();
                    }
                    await _repository.Add(franchise);
                }
                await _repository.Save();
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetAllFranchises()
        {
            var franchises = _repository.GetAllFranchises();
            foreach (var item in franchises)
            {
                
            }
            return View(franchises);
        }
    }

}
