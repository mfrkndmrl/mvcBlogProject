using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMVCDeneme.ViewModels
{
    public class KullanıcıEkle
    {
        public string Id { get; set; }
        [Required]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Fotograf { get; set; }
    
        public string Sifre { get; set; }
        [Compare("Sifre")]
        public string SifreTekari { get; set; }

    }
}