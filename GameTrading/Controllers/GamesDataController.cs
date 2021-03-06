﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameTrading.Models;
using System.IO;

namespace GameTrading.Controllers
{
    [Authorize/*(Roles = "Admin")*/]
    public class GamesDataController : Controller
    {
        private GamesContext db = new GamesContext();

        public ActionResult Search(string SearchBox)
        {
            var games = (from s in db.games
                         where s.GameName.Contains(SearchBox)
                         select s).ToList();
            return View("Index", games);
        }

        // GET: GamesData
        public ActionResult Index()
        {
            return View(db.games.ToList());
        }

        // GET: GamesData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamesData games = db.games.Find(id);
            if (games == null)
            {
                throw new HttpException(404, "Course Id not Found!");
                //return HttpNotFound();
            }
            return View(games);
        }

        // GET: GamesData/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult GetImage(int id)
        {
            byte[] imageData = db.games.Find(id).Picture;
            return File(imageData, "image/jpeg");
        }

        // POST: GamesData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameID,GameName,GameDescription, Platform, ")] GamesData games, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string pic = System.IO.Path.GetFileName(ImageFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/profile"), pic);
                    ImageFile.SaveAs(path);

                    games.ImagePath = pic;
                   
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ImageFile.InputStream.CopyTo(ms);
                        games.Picture = ms.GetBuffer();

                    }

                }
                db.games.Add(games);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(games);
        }

        // GET: GamesData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamesData games = db.games.Find(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: GamesData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,GameName,GameDescription,Platform")] GamesData games)
        {
            if (ModelState.IsValid)
            {
                db.Entry(games).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(games);
        }

        // GET: GamesData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamesData games = db.games.Find(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: GamesData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GamesData games = db.games.Find(id);
            db.games.Remove(games);
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
