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

        public Genre MovieGenre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        //public object Genre { get; internal set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }
        [Column(TypeName = "datetime2")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 150)]
        [RegularExpression("[0-9]+", ErrorMessage = "Entered Stock Number format is not valid. Please chose an Integer. ")]        //[CheckIfIntegerFormField]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

    }
}
