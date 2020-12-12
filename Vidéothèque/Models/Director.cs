using System.ComponentModel.DataAnnotations;

namespace Vidéothèque.Models
{
    public class Director
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}