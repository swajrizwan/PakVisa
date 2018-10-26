using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PakVisa.Models
{
    [Table("Country", Schema = "Catalog")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [Required]
        [StringLength(40)]
        public string Description { get; set; }
    }
}