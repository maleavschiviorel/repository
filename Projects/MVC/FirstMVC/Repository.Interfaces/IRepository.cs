using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.DomainUtils;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IPagedList<M> GetPaged<M>(IPageData page) where M : class;

        IList<T> All { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update<M>(T entity) where M : T;
        T FindById(int Id);
        T FindById<M>(int Id) where M : T;

    }
}
