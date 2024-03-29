﻿using Client.Common.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.DBO.Models
{
    [Table("ClientsEmail")]
    public class CustomerEmails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClientEmail { get; set; }

        [Required]
        [ForeignKey("Clients")]
        public int IdClient { get; set; }
        public virtual RegisteredCustomer Clients { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public TypePriority Priority { get; set; }

        [Required]
        public TypeEmail TypeEmail { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
