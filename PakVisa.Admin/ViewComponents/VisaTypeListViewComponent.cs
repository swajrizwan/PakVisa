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
    public class VisaTypeListViewComponent : ViewComponent
    {
        private IPakVisaRepository _repository;

        public VisaTypeListViewComponent(IPakVisaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await GetItemsAsync();
            return View(result);
        }

        private async Task<List<VisaTypeListViewModel>> GetItemsAsync()
        {
            List<VisaTypeListViewModel> list = _repository.GetVisaTypes()
                                              .Select(p => ModelFactory.Create(p))
                                              .ToList();
            return list;
        }
    }
}
