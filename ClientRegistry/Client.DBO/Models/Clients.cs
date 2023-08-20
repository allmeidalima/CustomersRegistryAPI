using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.DBO.Models
{
    [Table("Clients")]
    public class Clients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(120)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(120)]
        public string PhoneNumber { get; set; }
    }
}
