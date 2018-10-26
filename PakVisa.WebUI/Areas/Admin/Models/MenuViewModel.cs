using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.WebUI.Areas.Admin.Models
{
    public class MenuViewModel
    {
        public string VisaTypeName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}

