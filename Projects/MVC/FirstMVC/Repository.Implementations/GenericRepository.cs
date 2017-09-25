using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Domain;
using Repository.Interfaces;
using NHibernate;
using Domain.DomainUtils;
using Repository.Implementations.Paging;
using NHibernate.Criterion;

namespace Repository.Implementations
{

    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly ISession _session;// = SessionGenerator.Instance.GetSession();

        public GenericRepository(ISession session)
        {
            _session = session;
        }
        public IList<T> All => throw new NotImplementedException();


        #region Non-public members
        public IPagedList<M> GetPaged<M>(IPageData page) where M : class
        {

            return GetPaged<M>(_session.QueryOver<M>(), page);
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
        public void Update<M>(T entity) where M : T
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                T t = _session.Load<M>(entity.Id);
                t.Asign(entity);
                //if (t.Id == entity.Id  )
                //    _session.Evict(t);
                try
                {
                    _session.SaveOrUpdate(t);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public T FindById(int Id)
        {
            return _session.Get<T>(Id);
        }
        public T FindById<M>(int Id) where M : T
        {
            return (T)_session.Get<M>(Id);
        }

    }
}
