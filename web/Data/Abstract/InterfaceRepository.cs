using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.Abstract
{
    public interface InterfaceRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}