using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogMVCDeneme.Models
{
    public class Makale
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        [Display(Name = "Makale İçerik")]       
        public string Icerik { get; set; }
        public string Dosya { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public Boolean Durum { get; set; }
        public string DurumAciklama { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}