using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Vidéothèque.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Synopsis { get; set; }

        public string Director { get; set; }

        public string Actors { get; set; }

        public Genre MovieGenre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        //public object Genre { get; internal set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 150)]
        [RegularExpression("[0-9]+", ErrorMessage = "Entered Stock Number format is not valid. Please chose an Integer. ")] 
        public int NumberInStock { get; set; }

        public string ImagePath { get; set; }
        public string ImagePoster { get; set; }

        [Required]
        [Range(0, 10)]
        public int DurationHours { get; set; }
        [Required]
        [Range(0, 59)]
        public int DurationMinutes { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

        public int NbRent { get; set; }

    }
}
