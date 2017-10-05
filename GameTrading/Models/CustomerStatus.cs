using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameTrading.Models
{
    public class CustomerStatus: Status
    {
        public List <Status> customerStatus { get; set; }
        public virtual Customer customer { get; set; }
    }
}