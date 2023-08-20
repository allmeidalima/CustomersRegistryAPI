using Client.Common.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.DBO.Models
{
    [Table("ClientsPhoneNumber")]
    public class ClientsPhoneNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPhoneNumber { get; set; }

        [Required]
        [ForeignKey("Clients")]
        public string IdClient { get; set; }
        public virtual Clients Clients { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public TypePriority Priority { get; set; }

        [Required]
        public TypePhoneNumber TypePhoneNumber { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
