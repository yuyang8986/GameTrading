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
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Ad> ad { get; set; }

        public System.Data.Entity.DbSet<GameTrading.Models.Status> Status { get; set; }
    }
}