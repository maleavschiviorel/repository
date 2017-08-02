using Magazin.Domain;
using System.Collections.Generic;

namespace Magazin.Dal.Interfaces
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
