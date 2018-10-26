using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.WebUI.Areas.Admin.Models
{
    public class FranchiseViewModel
    {
        public string Name { get; set; }
        public string FranchiseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IFormFile Logo { get; set; }

        public IFormFile IATALicense { get; set; }


        public IFormFile DTSLicense { get; set; }


        public IFormFile NTNCertificate { get; set; }


        public IFormFile CNICPassport { get; set; }

        [Required]
        public double Phone { get; set; }

        public double Phone2 { get; set; }

        [Required]
        public double Landline { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        public IFormFile Agreement { get; set; }

        [Required]
        public double Fax { get; set; }

        [Required]
        public bool IsRestrict { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        public int UserloginId { get; set; }
    }
}
