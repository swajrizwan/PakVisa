using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PakVisa.Models
{
    [Table("Advertisement", Schema = "Catalog")]
    public class Advertisement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdvertismentId { get; set; }

        [Required]
        public Byte[] MainImage { get; set; }
        public Byte[] Image2 { get; set; }
        public Byte[] Image3 { get; set; }
        public Byte[] Image4 { get; set; }
        public Byte[] Image5 { get; set; }

        [Required]
        public string VisaTitle { get; set; }
        public VisaType VisaType { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }

        [Required]
        public double VisaPrice { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public DateTime Time { get; set; }
        public Byte[] Logo { get; set; }
        public string Status { get; set; }

        [ForeignKey("Franchise")]
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
