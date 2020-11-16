using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidéothèque.Models
{
    public class InvoiceModel
    {
        private int idFilm { get; set; }
        private int idUser { get; set; }
        private int idRent { get; set; }
        private DateTime date_rent { get; set; }
        private int quantity { get; set; }
        private float total_price { get; set; }
    }
}