using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidéothèque.Models
{
    public class Rent
    {

        public int Id { get; set; }

        [Required]
        public int IdInvoice { get; set; }
        [Required]
        public string IdUser { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateLocation { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ExpectedReturnDate { get; set; }
        
        public string Status { get; set; }
    }
}