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
        [Display(Name = "Customer Number")]
        public int CustomerID { get; set; }
        [Display(Name ="Customer Name")]
        public string CustomerName { get;set; }
        public int GameID { get; set; }
        [Required (ErrorMessage = "Game Name is required!")]
        [MaxLength(50)]
        [Display(Name = "Game Name")]
        public string GameName { get; set; }
        [Display(Name = "Game Description")]
        public string GameDescription { get; set; }
        [Required]
        public int Price { get; set; }
        [Display(Name = "Ad Commence Date")]
        [DisplayFormat (DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime AdCommenceDate { get; set; }
        [Display(Name = "Ad Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Adexpirydate { get; set; }
        [Display(Name = "Swap")]
        public Boolean Swap { get; set; }
        [Timestamp]
        public byte[] stamp { get; set; }
        public virtual GamesData games { get; set; }
        public virtual Customer customer { get; set; }

    }
}