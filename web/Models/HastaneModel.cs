using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Sehir
    {
        public int SehirId { get; set; }
        public string SehirAd { get; set; }

    }

    public class Ilce
    {
        public int IlceId { get; set; }
        public string IlceAd { get; set; }
        public int SehirId { get; set; }
    }

    public class Hastane
    {
        public int HastaneId { get; set; }
        public string HastaneAd { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
    }
}