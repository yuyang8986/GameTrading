using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTrading.Models
{
    
    public class GamesData
    {
        [Key]
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string Platform { get; set; }
        public string GameDescription { get; set; }
        public virtual ICollection<Customer> customer { get; set; }
        

    }
}