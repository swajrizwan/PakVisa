using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PakVisa.Models
{
    [Table("VisaType", Schema = "Catalog")]
    public class VisaType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisaTypeId { get; set; }

        [Required]
        [StringLength(40)]
        public string Description { get; set; }
    }
}