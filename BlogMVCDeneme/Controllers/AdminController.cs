using BlogMVCDeneme.Models;
using BlogMVCDeneme.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVCDeneme.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KullaniciListe()
        {
            var kullanicilar = db.Users.Select(u => new Kullanici
            {
                Id = u.Id,
                Ad = u.Ad,
                Soyad = u.Soyad
            }).ToList();
            return View(kullanicilar);
        }
        public ActionResult RolEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RolEkle(RolView model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole rol = new IdentityRole
                {
                    Name = model.Rol
                };
                db.Roles.Add(rol);
                db.SaveChanges();
            }
            return View();
        }
        

    }
}