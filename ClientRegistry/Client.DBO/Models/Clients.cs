using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.DBO.Models
{
    [Table("Clients")]
    public class Clients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(120)]
        public string LastName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }


    }
}
