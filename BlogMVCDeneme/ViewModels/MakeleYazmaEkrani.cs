using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogMVCDeneme.Models;

namespace BlogMVCDeneme.ViewModels
{
    public class MakeleYazmaEkrani
    {
        public Makale Makale { get; set; }
        public Kategori Kategori { get; set; }
    }
}