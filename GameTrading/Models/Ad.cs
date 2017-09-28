using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTrading.Models
{
    
    public class Ad
    {
        [Key]
        public int AdID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public int Price { get; set; }
        public DateTime AdCommenceDate { get; set; }
        public DateTime Adexpirydate { get; set; }
        public Boolean BOrSell { get; set; }
        public virtual GamesData games { get; set; }
        public virtual Customer customer { get; set; }

    }
}