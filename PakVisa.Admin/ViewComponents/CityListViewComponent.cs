using Microsoft.AspNetCore.Mvc;
using PakVisa.Admin.Factories;
using PakVisa.Admin.ViewModels;
using PakVisa.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.Admin.ViewComponents
{
    public class CityListViewComponent : ViewComponent
    {
        private IPakVisaRepository _repository;

        public CityListViewComponent(IPakVisaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await GetItemsAsync();
            return View(result);
        }

        private async Task<List<CityListViewModel>> GetItemsAsync()
        {
            List<CityListViewModel> list = _repository.GetCities()
                                              .Select(p => ModelFactory.Create(p))
                                              .ToList();
            return list;
        }
    }
}
