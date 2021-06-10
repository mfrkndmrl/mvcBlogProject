using BlogMVCDeneme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogMVCDeneme.Controllers
{
    public class KategorilerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var kategoriListe = db.Kategoris.ToList();
            return View(kategoriListe);
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            Kategori vtKategori = new Kategori();
            vtKategori.KategoriAd = kategori.KategoriAd;
            db.Kategoris.Add(vtKategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var düzenlenecekKategori = db.Kategoris.Where(k => k.Id == id).FirstOrDefault();
            //var düzenlenecekKategori1 = db.Kategoris.Find(id);
            
            if (düzenlenecekKategori == null)
            {
                return HttpNotFound();
            }
            return View(düzenlenecekKategori);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriAd")] Kategori gKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //if (ModelState.IsValid)
            //{
            //    Kategori DBKategori = new Kategori();
            //    DBKategori.Id = gKategori.Id;
            //    DBKategori.KategoriAd = gKategori.KategoriAd;
            //    db.Kategoris.Add(DBKategori);
            //    db.SaveChanges();               

            //}
            
            return View(gKategori);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var silKategori = db.Kategoris.Where(k => k.Id == id).FirstOrDefault();
            var silKategori1 = db.Kategoris.Find(id);
            
            if (silKategori1 == null)
            {
                return HttpNotFound();
            }
            return View(silKategori1);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var silinecekKategori = db.Kategoris.Where(p => p.Id == id).FirstOrDefault();
            db.Kategoris.Remove(silinecekKategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var detayKategori = db.Kategoris.Where(k => k.Id == id).FirstOrDefault();
            var detayKategori1 = db.Kategoris.Find(id);

            if (detayKategori1 == null)
            {
                return HttpNotFound();
            }
            return View(detayKategori1);
        }
    }
}