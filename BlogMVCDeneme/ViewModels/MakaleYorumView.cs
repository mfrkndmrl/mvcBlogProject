using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogMVCDeneme.Models;

namespace BlogMVCDeneme.ViewModels
{
    public class MakaleYorumView
    {
        public int Id { get; set; }
        public Makale Makale { get; set; }
        public List<Yorum> Yorumlar { get; set; }
    }
}