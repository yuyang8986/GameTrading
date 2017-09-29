using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace GameTrading.Models
{
    public class GamesInitializer: DropCreateDatabaseAlways <GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            //make some seed data
            var gamesList = new List<GamesData>
            {
                new GamesData { GameName = "FIFA 18", GameID = 1, Platform = "PS4, XBOX, PC, NS", GameDescription = "FIFA 18"},
                new GamesData { GameName = "The Legend of Zelda", GameID = 2, Platform = "NS", GameDescription = "Zelda"}
            };

            foreach (var temp in gamesList)
            {
                context.games.Add(temp);
            }
            context.SaveChanges();
            // How to add game to a customer?
            var customerList = new List<Customer>
            {
                new Customer { CustomerName = "Lulu", CustomerID = 1, Address = "24 Koorine St, Ermington", Contact = "0430490668" },
                new Customer { CustomerName = "Yang", CustomerID = 2, Address = "2 Morton St, Parramatta" }

            };

            foreach (var temp in customerList)
            {
                context.customer.Add(temp);
            }
            context.SaveChanges();

            var customerGameList = new List<CustomerOwnGame>
            {
                new CustomerOwnGame { CustomerID = 1, GameID = 1 },
                new CustomerOwnGame { CustomerID = 2 , GameID =2 }

            };

            foreach (var temp in customerGameList)
            {
                context.customerOwnGame.Add(temp);
            }
            context.SaveChanges();

            var adList = new List<Ad>
            {
                new Ad { AdID = 1, CustomerID = 1, GameID = 1, GameName = "FIFA 18",AdCommenceDate = DateTime.Parse("2014/7/7"), Adexpirydate = DateTime.Parse("2014/1/2"), BOrSell = true, Price = 50,},
                new Ad { AdID = 2, CustomerID = 2, GameID = 2, GameName = "The Legend of Zelda", AdCommenceDate = DateTime.Parse("2014/7/7"), Adexpirydate = DateTime.Parse("2014/1/2"), BOrSell = false, Price = 60,},

            };

            foreach (var temp in adList)
            {
                context.ad.Add(temp);
            }
            context.SaveChanges();


        }
    }
}