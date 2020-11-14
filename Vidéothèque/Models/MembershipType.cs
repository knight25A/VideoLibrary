using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidéothèque.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //values that are static in the code/DB
        //but need to be associated with a name to be readable for the developper
        //the ID is going to be used with the name specified here throught the code

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Trimesterly = 3;
        public static readonly byte Yearly = 4;


    }
}