using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidéothèque.Models;

namespace Vidéothèque.ViewModels
{
    public class AllRentsViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Rent> Rents { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }


    }
}