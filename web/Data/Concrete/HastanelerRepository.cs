using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.EntityFrameworkCore;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class HastanelerRepository : GenericRepository<Hastaneler, KanBagisDbContext>, HastanelerInterface
    {
        public List<Hastaneler> HastaneleriGetir(int SehirId, int IlceId)
        {
            using (var db = new KanBagisDbContext())
            {
                string SehirAd = db.Sehirlers.Where(w => w.SehirId == SehirId).Select(s => s.SehirAd).FirstOrDefault();
                string IlceAd = db.Ilcelers.Where(w => w.IlceId == IlceId).Select(s => s.IlceAd).FirstOrDefault();
                return db.Hastanelers.Where(f => f.Sehir == SehirAd && f.Ilce == IlceAd).ToList();
            }
        }
    }
}