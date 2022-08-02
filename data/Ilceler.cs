using System;
using System.Collections.Generic;

#nullable disable

namespace data
{
    public partial class Ilceler
    {
        public int IlceId { get; set; }
        public string IlceAd { get; set; }
        public int SehirId { get; set; }

        public virtual Sehirler Sehir { get; set; }
    }
}
