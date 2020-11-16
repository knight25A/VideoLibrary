using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidéothèque.Models
{
    public class MovieModels
    {   
        private String name { get; set; }
        private List<String> categories { get; set; }
        private String director { get; set; }
        private List<String> actors { get; set; }
        private String synopsis { get; set; }
        private DateTime date { get; set; }
        private float duration { get; set; }
        private float price { get; set; }
        private int quantity { get; set; }
        private String poster { get; set; }
        private String cover { get; set; }

    }
}