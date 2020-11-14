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
    }
}