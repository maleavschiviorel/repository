using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain;
using Repository.Interfaces;
using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Domain.DomainUtils;
using NHibernate.Transform;
using Repository.Implementations.Paging;
using NHibernate.Criterion;

namespace Repository.Implementations
{

    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly ISession _session = SessionGenerator.Instance.GetSession();

        public IList<T> All => throw new NotImplementedException();


        #region Non-public members
        public IPagedList<M> GetPaged<M>(IPageData page) where M :class
        {

            return GetPaged<M>(_session.QueryOver<M>() , page);  
        }

        protected IPagedList<TQuery> GetPaged<TQuery>(IQueryOver<TQuery> queryOver, IPageData page)
        {
            return GetPaged<TQuery>(queryOver.UnderlyingCriteria,
               page);
        }

        protected IPagedList<TModel> GetPaged<TModel>(ICriteria criteria, IPageData page)
        {
            string parentCriteriaAlias = $"{criteria.Alias}.Id";

            return GetPaged<TModel>(criteria, parentCriteriaAlias, page);
        }

        protected IPagedList<TModel> GetPaged<TModel>(ICriteria criteria, string countByAlias, IPageData page)
        {
            IEnumerable<TModel> results = criteria.Future<TModel>();

            ICriteria countCriteria = CriteriaTransformer.Clone(criteria);
            if (page != null)
            {
                if (page.Page > 0)
                    criteria.SetFirstResult(page.Page * page.PageSize);

                if (page.PageSize > 0)
                    criteria.SetMaxResults(page.PageSize);

                if (!string.IsNullOrEmpty(page.SortBy))
                    criteria.AddOrder(page.SortAsc ? NHibernate.Criterion.Order.Asc(page.SortBy) : NHibernate.Criterion.Order.Desc(page.SortBy));

                page.TotalRows =
                   countCriteria.SetProjection(Projections.CountDistinct(countByAlias))
                   .UniqueResult<int>();
            }
            return new PagedList<TModel>(page, results.ToList());
        }

        #endregion
        public void Add(T entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }
        public void Delete(T entity) 
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  
                }
            }
        }
        public void Update<M>(T entity) where M:T
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                T t = _session.Load<M>(entity.Id);
                t.Asign(entity);
                //if (t.Id == entity.Id  )
                //    _session.Evict(t);

                _session.SaveOrUpdate(t);
                transaction.Commit();
            }
        }
        public T FindById(int Id)
        {
            return _session.Get<T>(Id);
        }
        public T FindById<M>(int Id)where M :T
        {
            return (T)_session.Get<M>(Id);
        }

        #region List   
        //private List<T> _storage;
        //public GenericRepository()
        //{
        //    _storage = new List<T>();
        //}

        //public IList<T> All
        //{
        //    get
        //    {
        //        return _storage;
        //    }
        //}
        //public void Add(T entity)
        //{
        //    _storage.Add(entity);
        //}
        //public void Delete(T entity)
        //{
        //    _storage.Remove(entity);
        //}
        //public void Update(T entity)
        //{
        //    int index = _storage.FindIndex(x =>  x.GetType() == entity.GetType()  && x.Id == entity.Id);
        //    if (index != -1)
        //    {
        //        _storage[index].Asign ( entity);
        //    }
        //}
        //public T FindById(int Id)
        //{
        //    var result = _storage.FirstOrDefault(x => x.Id == Id);
        //    return result;
        //}
        //public T FindById<M>(int Id)
        //{
        //    var result = _storage.FirstOrDefault(x =>x.GetType()==typeof(M)&&  x.Id == Id);
        //    return result;
        //}
        #endregion
    }
}
