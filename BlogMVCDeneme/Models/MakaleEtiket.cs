﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVCDeneme.Models
{
    public class MakaleEtiket
    {
        public int Id { get; set; }
        public int MakaleId { get; set; }
        public int EtiketId { get; set; }
        public virtual Makale Makale { get; set; }
        public virtual Etiket Etiket{ get; set; }
    }
}