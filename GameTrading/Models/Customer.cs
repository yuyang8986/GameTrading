using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTrading.Models
{
    
    public class Customer
    {
        [Key]
        [Display(Name = "Customer Number")]
        public int CustomerID { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public virtual ICollection<Ad> ad { get; set; }
        public virtual ICollection<GamesData> games { get; set; }
        
        
    }
}