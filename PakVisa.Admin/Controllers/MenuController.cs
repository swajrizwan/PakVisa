using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PakVisa.Admin.Factories;
using PakVisa.Admin.ViewModels;
using PakVisa.Models;
using PakVisa.Repository;

namespace PakVisa.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private IPakVisaRepository _repository;

        public MenuController(IPakVisaRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var model = new MenuViewModel()
            {
                Countries = _repository.GetCountries().Select(p => SelectListFactory.Get(p))
            };
            return View(model);
        }

        #region Country
        public IActionResult GetCountries()
        {
            return ViewComponent("CountryList");
        }
        public async Task<IActionResult> AddCountry(string country)
        {
            if (country != null)
            {
                var newCountry = new Country()
                {
                    Description = country
                };

                await _repository.Add(newCountry);
                if (await _repository.Save())
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(false);
        }
        public async Task<IActionResult> RemoveCountry(int Id)
        {
            if (Id > 0)
            {
                var countries = _repository.GetCountries();
                var toDelete = countries.Find(p => p.CountryId == Id);
                _repository.Remove(toDelete);
                if (await _repository.Save())
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(false);
        }

        #endregion

        #region Visa
        public IActionResult GetVisaTypes()
        {
            return ViewComponent("VisaTypeList");
        }
        public async Task<IActionResult> AddVisaType(string Visa)
        {
            if (Visa != null)
            {
                var newVisa = new VisaType()
                {
                    Description = Visa
                };
                await _repository.Add(newVisa);
                if (await _repository.Save())
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(false);
        }
        public async Task<IActionResult> RemoveVisaType(int Id)
        {
            if (Id > 0)
            {
                var Visatypes = _repository.GetVisaTypes();
                var toDelete = Visatypes.Find(p => p.VisaTypeId == Id);
                _repository.Remove(toDelete);
                if (await _repository.Save())
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(false);
        }
        #endregion

        #region City
        public IActionResult GetCities()
        {
            return ViewComponent("CityList");
        }
        public async Task<IActionResult> AddCity(string _city, int _countryId)
        {
            if (_city != null && _countryId > 0)
            {
                var city = new City()
                {
                    Description = _city,
                    CountryId = _countryId
                };
                await _repository.Add(city);
                if (await _repository.Save())
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(false);
        }
        public async Task<IActionResult> RemoveCity(int Id)
        {
            if (Id > 0)
            {
                var cities = _repository.GetCities();
                var toDelete = cities.Find(p => p.CityId == Id);
                _repository.Remove(toDelete);
                if (await _repository.Save())
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(false);
        }
        #endregion

    }
}