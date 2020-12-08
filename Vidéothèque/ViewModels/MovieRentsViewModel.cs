using System.Collections.Generic;
using Vidéothèque.Models;

namespace Vidéothèque.ViewModels
{
    public class MovieRentsViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Rent> Rents { get; set; }
    }
}