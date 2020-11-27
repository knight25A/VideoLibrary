using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidéothèque.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string Synopsis { get; set; }

        public string Actors { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public GenreDto MovieGenre { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 150)]
        [RegularExpression("[0-9]+", ErrorMessage = "Entered Stock Number format is not valid. Please chose an Integer. ")]       
        public int NumberInStock { get; set; }

        public string ImagePath { get; set; }

        [Required]
        [Range(0, 10)]
        public int DurationHours { get; set; }
        [Required]
        [Range(0, 59)]
        public int DurationMinutes { get; set; }

        [Required]
        public float Price { get; set; }
    }
}