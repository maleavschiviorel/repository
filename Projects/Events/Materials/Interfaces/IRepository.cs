using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materials.Interfaces
{
    public interface IRepository<T> where T : Entity
    {

        IList<T> All { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);

    }
}
