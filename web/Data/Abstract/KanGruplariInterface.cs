using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Data.Abstract
{
    public interface KanGruplariInterface : InterfaceRepository<KanGruplari>
    {
        List<KanGruplari> TumKanGruplari();
    }
}