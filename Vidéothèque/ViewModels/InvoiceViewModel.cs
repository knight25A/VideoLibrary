using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidéothèque.Models;

namespace Vidéothèque.ViewModels
{
    public class InvoiceViewModel
    {
        public ApplicationUser User { get; set; }
        public Invoice Invoice { get; set; }
        public Movie Movie { get; set; }
    }
}