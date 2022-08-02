using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Data.Abstract
{
    public interface IlcelerInterface : InterfaceRepository<Ilceler>
    {
        List<Ilceler> IlceleriGetir(int id);
    }
}