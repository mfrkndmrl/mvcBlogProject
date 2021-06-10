using BlogMVCDeneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;
using System.IO;

namespace BlogMVCDeneme.Controllers
{
    [Authorize]
    public class YazarController : Controller
    {
        // GET: Yazar
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YazarSayfa()
        {
            string id = User.Identity.GetUserId();
            var makaleler = db.Makales.Where(m => m.UserId == id).ToList();
            
            return View(makaleler.OrderByDescending(m => m.EklenmeTarihi));
        }
        public ActionResult MakaleYaz()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "KategoriAd");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MakaleYaz(System.Web.HttpPostedFileBase yuklenecekDosya,Makale makale, FormCollection form)
        {
            if (yuklenecekDosya != null)
            {
                string dosyaYolu = Path.GetFileName(yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Dosyalar"), dosyaYolu);
                yuklenecekDosya.SaveAs(yuklemeYeri);
                string id = User.Identity.GetUserId();
                Makale myMakale = new Makale();
                myMakale.Baslik = makale.Baslik;
                myMakale.Icerik = makale.Icerik;
                myMakale.EklenmeTarihi = DateTime.Now;
                myMakale.UserId = id;
                myMakale.Durum = false;
                myMakale.Dosya = Path.GetFileName(yuklenecekDosya.FileName);
                myMakale.DurumAciklama = "Henüz Yayınlanmadı";
                db.Makales.Add(myMakale);
                db.SaveChanges();
                Etiket myEtiket = new Etiket();
                myEtiket.EtiketAd = form["etiket"];
                db.Etikets.Add(myEtiket);
                db.SaveChanges();
                MakaleEtiket myMakeleEt = new MakaleEtiket();
                myMakeleEt.EtiketId = myEtiket.Id;
                myMakeleEt.MakaleId = myMakale.Id;
                db.MakaleEtikets.Add(myMakeleEt);
                db.SaveChanges();
                return RedirectToAction("YazarSayfa");
            }
            else
            {
                string id = User.Identity.GetUserId();
                Makale myMakale = new Makale();
                myMakale.Baslik = makale.Baslik;
                myMakale.Icerik = makale.Icerik;
                myMakale.EklenmeTarihi = DateTime.Now;
                myMakale.UserId = id;
                myMakale.Durum = false;
                myMakale.DurumAciklama = "Henüz Yayınlanmadı";
                db.Makales.Add(myMakale);
                db.SaveChanges();
                Etiket myEtiket = new Etiket();
                myEtiket.EtiketAd = form["etiket"];
                db.Etikets.Add(myEtiket);
                db.SaveChanges();
                MakaleEtiket myMakeleEt = new MakaleEtiket();
                myMakeleEt.EtiketId = myEtiket.Id;
                myMakeleEt.MakaleId = myMakale.Id;
                db.MakaleEtikets.Add(myMakeleEt);
                db.SaveChanges();
                return RedirectToAction("YazarSayfa");

            }
            
        }
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var dznMakale = db.Makales.Where(m => m.Id == id).FirstOrDefault();

        //    if (dznMakale == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "KategoriAd");
        //    return View(dznMakale);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Makale gMakale, FormCollection form)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string id = User.Identity.GetUserId();
        //        Makale vtMakale = new Makale();
        //        vtMakale.Id = gMakale.Id;
        //        vtMakale.MakaleBaslik = gMakale.MakaleBaslik;
        //        vtMakale.Icerik = gMakale.Icerik;
        //        vtMakale.Durum = false;
        //        vtMakale.DurumAciklama = "Henüz Yayınlanmadı";
        //        vtMakale.UserId = id;
        //        Etiket myEtiket = new Etiket();
        //        myEtiket.EtiketAd = form["etiket"];
        //        db.Etikets.Add(myEtiket);
        //        db.SaveChanges();
        //        db.Kategoris.Add(vtMakale);
        //        db.SaveChanges();

        //    }

        //    return View(vtMakale);
        //}
    }
}