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
    public class CountryListViewComponent : ViewComponent
    {
        private IPakVisaRepository _repository;

        public CountryListViewComponent(IPakVisaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await GetItemsAsync();
            return View(result);
        }

        private async Task<List<CountryListViewModel>> GetItemsAsync()
        {
            List<CountryListViewModel> list = _repository.GetCountries()
                                              .Select(p => ModelFactory.Create(p))
                                              .ToList();
            return list;
        }
    }
}
