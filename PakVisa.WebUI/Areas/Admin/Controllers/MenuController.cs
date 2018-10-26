using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PakVisa.Models;
using PakVisa.Repository;
using PakVisa.WebUI.Areas.Admin.Models;
using PakVisa.WebUI.Factories;

namespace PakVisa.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : BaseController
    {
        private IPakVisaRepository _repository;

        public MenuController(IPakVisaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            MenuViewModel model = new MenuViewModel()
            {
                Countries = _repository.GetCountries().Select(p => SelectListFactory.Get(p))
            };
            return View(model);
        }


        public IActionResult GetCountries()
        {
            var countries = _repository.GetCountries().Select(p => SelectListFactory.Get(p));
            return Json(countries);
        }


        [HttpPost]
        public async Task<IActionResult> AddUpdateCountry(string GetCountry)
        {
            if (ModelState.IsValid)
            {
                var country = new Country()
                {
                    Description = GetCountry
                };
                await _repository.Add(country);
                await _repository.Save();
                ModelState.AddModelError("", "Country Added Successfully");
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdateVisaType(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var visaType = new VisaType()
                {
                    Description = model.VisaTypeName
                };
                await _repository.Add(visaType);
                await _repository.Save();
                ModelState.AddModelError("", "Visa Added Successfully");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddUpdateCity()
        {
            var model = new MenuViewModel()
            {
                Countries = _repository.GetCountries().Select(p => SelectListFactory.Get(p))
            };
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdateCity(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var city = new City()
                {
                    Description = model.CityName,
                    CountryId = model.CountryId
                };
                await _repository.Add(city);
                await _repository.Save();
                ModelState.AddModelError("", "City Added Successfully");
            }
            model.Countries = _repository.GetCountries().Select(p => SelectListFactory.Get(p));
            return View(model);
        }
    }
}