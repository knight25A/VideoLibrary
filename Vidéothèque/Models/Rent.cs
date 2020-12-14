using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidéothèque.Models
{
    public class Rent
    {
        public int Id { get; set; }

        public Invoice Invoice { get; set; }

        [Required]
        public int InvoiceId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateLocation { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ExpectedReturnDate { get; set; }
        
        public string Status { get; set; }
    }
}