using BlogMVCDeneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BlogMVCDeneme.ViewModels;
using System.IO;

namespace BlogMVCDeneme.Controllers
{
    public class HomeController : Controller 
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListeAcik()
        {
            var acikliste = db.Users.Select(k => new KullanıcıEkle
            {
                Id = k.Id,
                Ad = k.Ad,
                Soyad = k.Soyad,
                Email=k.Email,
                Fotograf=k.Fotograf,
            });
            return View(acikliste);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AnaSayfa()
        {
            var etiketler = db.MakaleEtikets.Where(x => x.Makale.Durum == true).ToList();
            return View(etiketler);
        }
        public ActionResult Makaleler(int id)
        {
            ViewBag.id = id;
            var makale = db.Makales.Where(x => x.Id == id).ToList();
            return View(makale);
        }

        public ActionResult Makale(int id, int? yorumid)
        {
           
            if (yorumid == null)
            {
                ViewBag.ustid = yorumid;
            }else
            {
                ViewBag.ustid = 0;
            }
            string userid = User.Identity.GetUserId();
            if (Request.IsAuthenticated)
            {

                var userBul = db.Users.First(x => x.Id == userid);
                ViewBag.Ad = userBul.Ad;
                ViewBag.Soyad = userBul.Soyad;
                ViewBag.Email = userBul.Email;
            }
          
            ViewBag.id = id;
            var makale = db.Makales.Where(m => m.Id == id).FirstOrDefault();
            ViewBag.dosya = makale.Dosya;
           var yorum = db.Yorums.Where(x => x.MakaleId==id).ToList();
            var viewModel = new MakaleYorumView()
            {
                Makale= makale,
                Yorumlar= yorum,
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult YorumYap(string ad,string soyad,string icerik,string email, int makaleid)
        {
            Yorum myYorum = new Yorum();
            myYorum.Ad = ad;
            myYorum.Soyad = soyad;
            myYorum.YorumMetni = icerik;
            myYorum.YorumTarihi = DateTime.Now;
            myYorum.Email = email;
            myYorum.MakaleId = makaleid;
            myYorum.UstId = 0;
            db.Yorums.Add(myYorum);
            db.SaveChanges();
            return RedirectToAction("../Home/Makale/"+makaleid);
        }
        public ActionResult YorumCevap(int id,int idd)
        {
            var yorumBul = db.Yorums.Find(id);
            string userid = User.Identity.GetUserId();
            if (Request.IsAuthenticated)
            {

                var userBul = db.Users.First(x => x.Id == userid);
                ViewBag.Ad = userBul.Ad;
                ViewBag.Soyad = userBul.Soyad;
                ViewBag.Email = userBul.Email;
            }
            ViewBag.id = idd;
            ViewBag.ustid = id;
            return View(yorumBul);
        }
        [HttpPost]
        public ActionResult YorumCevap(string ad, string soyad, string icerik, string email, int makaleid, int yorumid)
        {
            Yorum myYorum = new Yorum();
            myYorum.Ad = ad;
            myYorum.Soyad = soyad;
            myYorum.YorumMetni = icerik;
            myYorum.YorumTarihi = DateTime.Now;
            myYorum.Email = email;
            myYorum.MakaleId = makaleid;
            myYorum.UstId = yorumid;
            db.Yorums.Add(myYorum);
            db.SaveChanges();
            return RedirectToAction("../Home/Makale/" + makaleid);
        }
        //[HttpGet]
        public FileResult Download(string file)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Dosyalar/" + file + ""));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file);
        }
        
        

    }
}