using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameTrading.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public List<string> Status { get; set; }
        

    }
}