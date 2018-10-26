using PakVisa.Admin.ViewModels;
using PakVisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.Admin.Factories
{
    public class ModelFactory
    {
        public static CountryListViewModel Create(Country Entity)
        {
            return new CountryListViewModel()
            {
                CountryId = Entity.CountryId,
                Description = Entity.Description
            };
        }
        public static VisaTypeListViewModel Create(VisaType Entity)
        {
            return new VisaTypeListViewModel()
            {
                VisaTypeId = Entity.VisaTypeId,
                Description = Entity.Description
            };
        }

        public static CityListViewModel Create(City Entity)
        {
            return new CityListViewModel()
            {
                CityId = Entity.CityId,
                Description = Entity.Description,
                Country = Entity.Country.Description
            };
        }
    }
}
