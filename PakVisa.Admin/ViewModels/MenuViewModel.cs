using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.Admin.ViewModels
{
    public class MenuViewModel
    {
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

    }
}
