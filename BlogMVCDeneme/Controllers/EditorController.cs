using BlogMVCDeneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BlogMVCDeneme.ViewModels;

namespace BlogMVCDeneme.Controllers
{
    [Authorize(Roles = "Editör")]
    public class EditorController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var yayinlanacakMakale = _db.Makales.Where(m => m.Durum == false).ToList();
            return View(yayinlanacakMakale);
        }

        
        public ActionResult MakaleYayinla(int id)
        {
            var yayinMakale = _db.Makales.Where(m => m.Id == id).FirstOrDefault();

            return View(yayinMakale);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MakaleYayinla(int id,string ad)
        {
            var yMakale = _db.Makales.Where(m => m.Id == id).FirstOrDefault();
            //yMakale.Id = id;
            //yMakale.Icerik = form["Icerik"];
            //yMakale.Baslik = form["Baslik"];
            yMakale.Durum = true;
            yMakale.DurumAciklama = "Yayında";
            //yMakale.UserId = form["UserId"];
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult TümMakaleGör()
        {
            var tümMakale = _db.Makales.ToList();
            return View(tümMakale);
        }

    }
}