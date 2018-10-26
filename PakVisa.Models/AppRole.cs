using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PakVisa.Models
{
    public class AppRole : IdentityRole
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
