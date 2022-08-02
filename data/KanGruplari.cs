using System;
using System.Collections.Generic;

#nullable disable

namespace data
{
    public partial class KanGruplari
    {
        public KanGruplari()
        {
            Ilanlars = new HashSet<Ilanlar>();
        }

        public int KanGrubuId { get; set; }
        public string KanGrubu { get; set; }

        public virtual ICollection<Ilanlar> Ilanlars { get; set; }
    }
}
