using Client.Common.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.DBO.Models
{
    [Table("ClientAddress")]
    public class ClientsAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClientAddress { get; set; }

        [Required]
        [ForeignKey("Clients")]
        public int IdClient { get; set; }
        public virtual Clients Clients { get; set; }

        [Required]
        public TypePriority Priority { get; set; }

        [Required]
        public TypeAddress TypeAddress { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
