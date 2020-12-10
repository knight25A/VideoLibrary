using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidéothèque.Dtos
{
    public class RentDto
    {
        public int Id { get; set; }

        //public Invoice Invoice { get; set; }

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