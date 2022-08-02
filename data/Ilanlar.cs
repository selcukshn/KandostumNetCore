using System;
using System.Collections.Generic;

#nullable disable

namespace data
{
    public partial class Ilanlar
    {
        public int IlanId { get; set; }
        public string UserId { get; set; }
        public string HastaTamAd { get; set; }
        public string HastaYas { get; set; }
        public string IletisimNumarasi1 { get; set; }
        public string IletisimNumarasi2 { get; set; }
        public int? HastaneId { get; set; }
        public int? KanGrubuId { get; set; }
        public string GerekliUnite { get; set; }
        public string IlanOzeti { get; set; }
        public DateTime IlanTarihi { get; set; }

        public virtual Hastaneler Hastane { get; set; }
        public virtual KanGruplari KanGrubu { get; set; }
    }
}
