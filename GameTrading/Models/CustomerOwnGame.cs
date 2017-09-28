using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameTrading.Models
{
    //to be used to determine relationship between customer own games
    public class CustomerOwnGame
    {
        [Key]
        public int CustomerGameID { get; set; }
        public int CustomerID { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; }
        public virtual GamesData games { get; set; }
        public virtual Customer customer { get; set; }


    }
}