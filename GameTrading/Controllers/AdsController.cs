using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameTrading.Models;

namespace GameTrading.Controllers
{
    public class AdsController : Controller
    {
        private GamesContext db = new GamesContext();

        public ActionResult Search(string SearchBox)
        {
            var ads = from t in db.ad select t;
            DateTime searchDate;
            if (!String.IsNullOrEmpty(SearchBox))
            {
                bool isDateSearch = DateTime.TryParse(SearchBox, out searchDate);
                if (isDateSearch)
                {
                    ads = ads.Where(s => s.AdCommenceDate.Equals(searchDate));
                }
                else
                {
                    ads = from t in db.ad
                          where t.GameName.Contains(SearchBox)
                         || t.GameDescription.Contains(SearchBox)
                         ||t.CustomerName.Contains(SearchBox)
                          select t;
                }

            }
            return View("Index", ads.ToList());
        }
        // GET: Ads
        public ActionResult Index()
        {
            var ad = db.ad.Include(a => a.customer).Include(a => a.games);
            return View(ad.ToList());
        }

        // GET: Ads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.ad.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // GET: Ads/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.customer, "CustomerID", "CustomerName");
            ViewBag.GameID = new SelectList(db.games, "GameID", "GameName");
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdID,CustomerID,GameID,GameName, GameDescription, Price,AdCommenceDate,Adexpirydate,BOrSell")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.ad.Add(ad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.customer, "CustomerID", "CustomerName", ad.CustomerID);
            ViewBag.GameID = new SelectList(db.games, "GameID", "GameName" , ad.GameID);
            return View(ad);
        }

        // GET: Ads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.ad.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.customer, "CustomerID", "CustomerName", ad.CustomerID);
            ViewBag.GameID = new SelectList(db.games, "GameID", "GameName", ad.GameID);
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdID,CustomerID,GameID,GameName, GameDescription, Price,AdCommenceDate,Adexpirydate,BOrSell")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.customer, "CustomerID", "CustomerName", ad.CustomerID);
            ViewBag.GameID = new SelectList(db.games, "GameID", "GameName", ad.GameID);
            return View(ad);
        }

        // GET: Ads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.ad.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ad ad = db.ad.Find(id);
            db.ad.Remove(ad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
