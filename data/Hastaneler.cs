using System;
using System.Collections.Generic;

#nullable disable

namespace data
{
    public partial class Hastaneler
    {
        public Hastaneler()
        {
            Ilanlars = new HashSet<Ilanlar>();
        }

        public int HastaneId { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string UlasimNumarasi { get; set; }
        public string UlasimEposta { get; set; }
        public string Enlem { get; set; }
        public string Boylam { get; set; }

        public virtual ICollection<Ilanlar> Ilanlars { get; set; }
    }
}
