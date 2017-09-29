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
        [Required(ErrorMessage ="Game Name is required!")]
        [Display(Name = "Game Name")]
        public string GameName { get; set; }
        [Required(ErrorMessage = "Platform is required!")]
        public string Platform { get; set; }
        [Display(Name = "Game Description")]
        public string GameDescription { get; set; }
        public virtual ICollection<Customer> customer { get; set; }
        

    }
}