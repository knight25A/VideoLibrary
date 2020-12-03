using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidéothèque.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        public int IdFilm { get; set; }
        //public Movie Movie { get; set; }
        [Required]
        public string IdUser { get; set; }
        //public ApplicationUser User { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateLocation { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float TotalPrice { get; set; }
    }
}