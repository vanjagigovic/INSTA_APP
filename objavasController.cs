using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INSTA_APP.BLL;
using INSTA_APP.Models;
using INSTA_APP.Models.ViewModel;

namespace INSTA_APP.
    
    rollers
{
    public class objavas : Controller
    {
        private INSTA_APPEntities db = new INSTA_APPEntities();
        private PanelLogic BLL = new PanelLogic();

        // GET: objavas
        public ActionResult Index()
        {
            var objavas = db.objavas.Include(o => o.profil).AsEnumerable().Select(x => new ObjavaViewModel
            {
                datumStr = x.datum.HasValue ? x.datum.Value.ToString("dd.MM.yyyy") : null,
                opis = x.opis,
                total_coment = "Broj komenatara " + (x.total_coment ?? 0),
                total_like = x.total_like,
                IDkorisnicko_ime = x.IDkorisnicko_ime,
                ImeProfile = x.profil.ime
            });
            return View(objavas.ToList());
        }

        // GET: objavas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objava objava = db.objavas.Find(id);
            if (objava == null)
            {
                return HttpNotFound();
            }
            return View(objava);
        }

        // GET: objavas/Create
        public ActionResult Create()
        {
            ViewBag.IDkorisnicko_ime = new SelectList(db.profils, "IDkorisnicko_ime", "ime");
            return View();
        }

        // POST: objavas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDobjava,IDkorisnicko_ime,datum,opis,total_like,total_coment")] objava objava)
        {
            if (ModelState.IsValid)
            {
                BLL.SaveObjava(objava);
                return RedirectToAction("Index");
            }

            ViewBag.IDkorisnicko_ime = new SelectList(db.profils, "IDkorisnicko_ime", "ime", objava.IDkorisnicko_ime);
            return View(objava);
        }

        // GET: objavas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objava objava = db.objavas.Find(id);
            if (objava == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDkorisnicko_ime = new SelectList(db.profils, "IDkorisnicko_ime", "ime", objava.IDkorisnicko_ime);
            return View(objava);
        }

        // POST: objavas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDobjava,IDkorisnicko_ime,datum,opis,total_like,total_coment")] objava objava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDkorisnicko_ime = new SelectList(db.profils, "IDkorisnicko_ime", "ime", objava.IDkorisnicko_ime);
            return View(objava);
        }

        // GET: objavas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objava objava = db.objavas.Find(id);
            if (objava == null)
            {
                return HttpNotFound();
            }
            return View(objava);
        }

        // POST: objavas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            objava objava = db.objavas.Find(id);
            db.objavas.Remove(objava);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult GetKomentari(string pol)
        {
            var result = BLL.GetWebsites();
            if (pol == "musko" || pol == "zensko")
            {
                result = result.Where(x => x.Pol == pol).ToList();
            }
           
            return Json(result, JsonRequestBehavior.AllowGet);
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
