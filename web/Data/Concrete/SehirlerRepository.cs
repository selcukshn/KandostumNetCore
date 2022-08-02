using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class SehirlerRepository : GenericRepository<Sehirler, KanBagisDbContext>, SehirlerInterface
    {


    }
}