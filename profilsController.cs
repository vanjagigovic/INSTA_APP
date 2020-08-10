using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INSTA_APP.Models;
using INSTA_APP.Models.ViewModel;

namespace INSTA_APP.Controllers
{
    public class profilsController : Controller
    {
        private INSTA_APPEntities db = new INSTA_APPEntities();
        private ProfilViewModel db1 = new ProfilViewModel();

        // GET: profils
        public ActionResult Index()
        {
            var profils = db.profils.Include(p => p.kategorija);
            return View(profils.ToList());
        }

        // GET: profils/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profil profil = db.profils.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // GET: profils/Create
        public ActionResult Create()
        {
            ViewBag.IDkategorija = new SelectList(db.kategorijas, "IDkategorija", "naziv");
            return View();
        }

        // POST: profils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDkorisnicko_ime,IDkategorija,ime,prezime,website,email,pol,telefon,broj_pratilaca")] profil profil)
        {
            if (ModelState.IsValid)
            {
                db.profils.Add(profil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDkategorija = new SelectList(db.kategorijas, "IDkategorija", "naziv", profil.IDkategorija);
            return View(profil);
        }

        // GET: profils/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profil profil = db.profils.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDkategorija = new SelectList(db.kategorijas, "IDkategorija", "naziv", profil.IDkategorija);
            return View(profil);
        }

        // POST: profils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDkorisnicko_ime,IDkategorija,ime,prezime,website,email,pol,telefon,broj_pratilaca")] profil profil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDkategorija = new SelectList(db.kategorijas, "IDkategorija", "naziv", profil.IDkategorija);
            return View(profil);
        }

        // GET: profils/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profil profil = db.profils.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // POST: profils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            profil profil = db.profils.Find(id);
            db.profils.Remove(profil);
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
