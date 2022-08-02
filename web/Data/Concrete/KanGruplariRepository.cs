using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class KanGruplariRepository : GenericRepository<KanGruplari, KanBagisDbContext>, KanGruplariInterface
    {
        public List<KanGruplari> TumKanGruplari()
        {
            using (var db = new KanBagisDbContext())
            {
                return db.KanGruplaris.ToList();
            }
        }
    }
}