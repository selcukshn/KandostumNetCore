using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Data.Abstract
{
    public interface IlanlarInterface : InterfaceRepository<Ilanlar>
    {
        List<Ilanlar> TumIlanar(int pageSize, int page);
        int TumIlanarCount();

        List<Ilanlar> IlanlarBySehir(int pageSize, int page, string sehir);
        int IlanlarBySehirCount(string sehir);

        List<Ilanlar> IlanlarByKanGrubu(int pageSize, int page, int? kangrubuid);
        int IlanlarByKanGrubuCount(int? kangrubuid);

        List<Ilanlar> IlanlarBySehir_KanGrubu(int pageSize, int page, string sehir, int? kangrubuid);
        int IlanlarBySehir_KanGrubuCount(string sehir, int? kangrubuid);

        List<Ilanlar> IlanlarBySehir_Ilce(int pageSize, int page, string sehir, string ilce);
        int IlanlarBySehir_IlceCount(string sehir, string ilce);

        List<Ilanlar> IlanlarBySehir_Ilce_KanGrubu(int pageSize, int page, string sehir, string ilce, int? kangrubuid);
        int IlanlarBySehir_Ilce_KanGrubuCount(string sehir, string ilce, int? kangrubuid);

        List<Ilanlar> SonIlanlar(int adet);
        Ilanlar IlanGetir(int id);
        string SonIlanSehir(int? sonilanhastane);
    }
}