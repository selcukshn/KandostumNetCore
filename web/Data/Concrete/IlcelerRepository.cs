using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class IlcelerRepository : GenericRepository<Ilceler, KanBagisDbContext>, IlcelerInterface
    {
        public List<Ilceler> IlceleriGetir(int id)
        {
            using (var db = new KanBagisDbContext())
            {
                return db.Ilcelers.Where(w => w.SehirId == id).ToList();
            }
        }

    }
}