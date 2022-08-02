using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.EntityFrameworkCore;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class IlanlarRepository : GenericRepository<Ilanlar, KanBagisDbContext>, IlanlarInterface
    {
        public List<Ilanlar> SonIlanlar(int adet)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Include(i => i.Hastane)
                .Include(i => i.KanGrubu)
                .OrderByDescending(o => o.IlanTarihi)
                .Take(adet)
                .ToList();
            }
        }

        public Ilanlar IlanGetir(int id)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Include(i => i.Hastane)
                .Include(i => i.KanGrubu)
                .Where(w => w.IlanId == id)
                .FirstOrDefault();
            }
        }

        public List<Ilanlar> TumIlanar(int pageSize, int page)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Include(i => i.Hastane)
                .Include(i => i.KanGrubu)
                .OrderByDescending(o => o.IlanTarihi)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList(); ;
            }
        }

        public int TumIlanarCount()
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Count();
            }
        }

        public List<Ilanlar> IlanlarBySehir(int pageSize, int page, string sehir)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Include(i => i.Hastane)
                .Include(i => i.KanGrubu)
                .Where(w => w.Hastane.Sehir == sehir)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(o => o.IlanTarihi)
                .ToList();
            }
        }
        public int IlanlarBySehirCount(string sehir)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                 .Where(w => w.Hastane.Sehir == sehir)
                 .Count();
            }
        }
        public List<Ilanlar> IlanlarBySehir_Ilce(int pageSize, int page, string sehir, string ilce)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Include(i => i.Hastane)
                .Include(i => i.KanGrubu)
                .Where(w => w.Hastane.Sehir == sehir && w.Hastane.Ilce == ilce)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(o => o.IlanTarihi)
                .ToList();
            }
        }
        public int IlanlarBySehir_IlceCount(string sehir, string ilce)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Where(w => w.Hastane.Sehir == sehir && w.Hastane.Ilce == ilce)
                .Count();
            }
        }
        public List<Ilanlar> IlanlarByKanGrubu(int pageSize, int page, int? kangrubuid)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Include(i => i.Hastane)
                .Include(i => i.KanGrubu)
                .Where(w => w.KanGrubuId == kangrubuid)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(o => o.IlanTarihi)
                .ToList();
            }
        }
        public int IlanlarByKanGrubuCount(int? kangrubuid)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Where(w => w.KanGrubuId == kangrubuid)
                .Count();
            }
        }
        public List<Ilanlar> IlanlarBySehir_KanGrubu(int pageSize, int page, string sehir, int? kangrubuid)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Include(i => i.Hastane)
                .Include(i => i.KanGrubu)
                .Where(w => w.Hastane.Sehir == sehir && w.KanGrubuId == kangrubuid)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(o => o.IlanTarihi)
                .ToList();
            }
        }
        public int IlanlarBySehir_KanGrubuCount(string sehir, int? kangrubuid)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Where(w => w.Hastane.Sehir == sehir && w.KanGrubuId == kangrubuid)
                .Count();
            }
        }
        public List<Ilanlar> IlanlarBySehir_Ilce_KanGrubu(int pageSize, int page, string sehir, string ilce, int? kangrubuid)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Include(i => i.Hastane)
                .Include(i => i.KanGrubu)
                .Where(w => w.Hastane.Sehir == sehir && w.Hastane.Ilce == ilce && w.KanGrubuId == kangrubuid)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(o => o.IlanTarihi)
                .ToList();
            }
        }
        public int IlanlarBySehir_Ilce_KanGrubuCount(string sehir, string ilce, int? kangrubuid)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilanlars
                .Where(w => w.Hastane.Sehir == sehir && w.Hastane.Ilce == ilce && w.KanGrubuId == kangrubuid)
                .Count();
            }
        }

        public string SonIlanSehir(int? sonilanhastane)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Hastanelers
                .Where(w => w.HastaneId == sonilanhastane)
                .Select(s => s.Sehir)
                .FirstOrDefault();
            }
        }
    }
}