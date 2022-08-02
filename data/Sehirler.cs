using System;
using System.Collections.Generic;

#nullable disable

namespace data
{
    public partial class Sehirler
    {
        public Sehirler()
        {
            Ilcelers = new HashSet<Ilceler>();
        }

        public int SehirId { get; set; }
        public string SehirAd { get; set; }

        public virtual ICollection<Ilceler> Ilcelers { get; set; }
    }
}
