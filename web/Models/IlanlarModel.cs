using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Models
{
    public class IlanlarModel
    {
        public int IlanId { get; set; }
        public string HastaAd { get; set; }
        public string HastaSehir { get; set; }
        public string HastaKanGrubu { get; set; }
        public string HastaIlce { get; set; }
        public string IlanOzet { get; set; }
        public DateTime IlanTarih { get; set; }
    }

    public class IlanlarPageModel
    {
        public List<IlanlarModel> Ilanlar { get; set; }
        public List<Sehirler> Sehirler { get; set; }
        public List<KanGruplari> KanGruplari { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}