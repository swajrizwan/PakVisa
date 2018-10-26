using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.Admin.ViewModels
{
    public class CityListViewModel
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }

    }
}
