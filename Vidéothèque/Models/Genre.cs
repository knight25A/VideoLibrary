using System.ComponentModel.DataAnnotations;

namespace Vidéothèque.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
}