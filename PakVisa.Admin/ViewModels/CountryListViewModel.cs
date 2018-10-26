using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.Admin.ViewModels
{
    public class CountryListViewModel
    {
        public int CountryId { get; set; }
        public string Description { get; set; }
    }
}
