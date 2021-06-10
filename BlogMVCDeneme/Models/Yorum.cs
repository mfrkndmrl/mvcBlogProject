using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogMVCDeneme.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        public int UstId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]       
        public string YorumMetni { get; set; }
        public string Ad{ get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public DateTime YorumTarihi { get; set; }
        public int MakaleId { get; set; }

        
    }
}