using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidéothèque.Models
{
    public class RentModel
    {
        private DateTime date { get; set; }
        private DateTime expectedReturnDate { get; set; }
        private DateTime returnDate { get; set; }
        private int idUser { get; set; }
        private String status { get; set; }
    }
}