using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PakVisa.Models
{
    [Table("Userlogin", Schema = "Users")]
    public class Userlogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserloginId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        public bool IsUserAdmin { get; set; }
        public bool IsUserClient { get; set; }
        public bool IsUserVisitor { get; set; }
    }
}
