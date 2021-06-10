using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVCDeneme.Models
{
    public class MakaleKategori
    {
        public int Id { get; set; }
        public int MakaleId { get; set; }
        public int KategoriId { get; set; }
        public virtual Makale Makale { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}