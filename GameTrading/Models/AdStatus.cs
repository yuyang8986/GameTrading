using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameTrading.Models
{
    public class AdStatus: Status
    {
        public List<Status> adstatus { get; set; }
        public virtual Ad ads { get; set; }

    }
}