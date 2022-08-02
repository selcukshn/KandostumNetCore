using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Data.Abstract
{
    public interface HastanelerInterface : InterfaceRepository<Hastaneler>
    {
        List<Hastaneler> HastaneleriGetir(int SehirId, int IlceId);

    }
}