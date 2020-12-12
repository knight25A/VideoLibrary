using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidéothèque.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        //public Movie Movie { get; set; }

        [Required]
        public int IdFilm { get; set; }
        //public ApplicationUser User { get; set; }

        [Required]
        public string IdUser { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateLocation { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float TotalPrice { get; set; }
    }
}