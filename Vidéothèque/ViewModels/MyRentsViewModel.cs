using System.Collections.Generic;
using Vidéothèque.Models;

namespace Vidéothèque.ViewModels
{
    public class MyRentsViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}