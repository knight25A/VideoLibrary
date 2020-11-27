using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidéothèque.Models;

namespace Vidéothèque.ViewModels
{
    public class AllRentsViewModel
    {
        public IEnumerable<Rent> Rents { get; set; }

    }
}