using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PakVisa.Models
{
    [Table("Franchise", Schema = "Catalog")]
    public class Franchise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FranchiseId { get; set; }

        [Required]
        public string Name { get; set; }

        public Byte[] Logo { get; set; }

        public Byte[] IATALicense { get; set; }


        public Byte[] DTSLicense { get; set; }


        public Byte[] NTNCertificate { get; set; }


        public Byte[] CNICPassport { get; set; }

        [Required]
        public double Phone { get; set; }

        public double Phone2 { get; set; }

        [Required]
        public double Landline { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        public Byte[] Agreement { get; set; }

        [Required]
        public double Fax { get; set; }

        [Required]
        public bool IsRestrict { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Userlogin")]
        public int UserloginId { get; set; }
        public Userlogin Userlogin { get; set; }
    }
}
