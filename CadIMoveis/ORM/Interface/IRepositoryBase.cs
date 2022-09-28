using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Interface
{
    public interface IRepositoryBase <T>where T : class
    {
        void Add(T Obj);
        void Update(T Obj);
        void Remove(T Obj);
        T GetById(int Id);
        IEnumerable<T> GetAll();
    }
}
