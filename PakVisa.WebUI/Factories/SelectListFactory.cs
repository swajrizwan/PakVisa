using Microsoft.AspNetCore.Mvc.Rendering;
using PakVisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.WebUI.Factories
{
    public class SelectListFactory
    {
        public static SelectListItem Get(Country Entity)
        {
            return new SelectListItem()
            {
                Value = Entity.CountryId.ToString(),
                Text = Entity.Description
            };
        }
    }
}
