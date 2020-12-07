using System.Collections.Generic;
using Vidéothèque.Models;

namespace Vidéothèque.ViewModels
{
    public class UserRentsViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<Rent> Rents { get; set; }
    }
}