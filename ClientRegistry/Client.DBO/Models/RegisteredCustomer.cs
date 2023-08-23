using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.DBO.Models
{
    [Table("Clients")]
    public class RegisteredCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCustomer { get; set; }

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

        // Navigation properties for related entities
        public virtual ICollection<CustomerAdresses> CustomerAdresses { get; set; }
        public virtual ICollection<CustomerEmails> CustomerEmails { get; set; }
        public virtual ICollection<CustomerPhoneNumbers> CustomerPhoneNumbers { get; set; }
    }
}
