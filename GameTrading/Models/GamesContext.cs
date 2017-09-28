using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GameTrading.Models
{
    public class GamesContext: DbContext
    {
        //CRUD enabled
        public DbSet<GamesData> games { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Ad> ad { get; set; }
        public DbSet<CustomerOwnGame> customerOwnGame { get; set; }

        //make database table singular
      
    }
}