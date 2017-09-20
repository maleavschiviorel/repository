namespace Repository.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using Domain.Domain;
   using Domain.DomainUtils;
   using Infrastructure;
   using Interfaces;
   using NHibernate;
   using NHibernate.Criterion;
   using NHibernate.Transform;
   using Paging;

   public abstract class Repository : IRepository
   {
      #region IRepository Members

      public void Save<TEntity>(TEntity entity) where TEntity : Entity
      {
         using (ITransaction transaction = _session.BeginTransaction())
         {
            _session.SaveOrUpdate(entity);
            transaction.Commit();
         }
      }

      public void Delete<TEntity>(TEntity entity) where TEntity : Entity
      {
         using (ITransaction transaction = _session.BeginTransaction())
         {
            _session.Delete(entity);
            transaction.Commit();
         }
      }

      public TEntity Get<TEntity>(long id) where TEntity : Entity
      {
         return _session.Get<TEntity>(id);
      }

      #endregion

      #region Non-public members

      protected readonly ISession _session = SessionGenerator.Instance.GetSession();

      protected IPagedList<TModel> GetPaged<TModel, TQuery>(IQueryOver<TQuery, TQuery> queryOver, IPageData page)
      {
         return GetPaged<TModel>(queryOver.TransformUsing(Transformers.AliasToBean<TModel>()).UnderlyingCriteria,
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
               criteria.SetFirstResult(page.Page*page.PageSize);

            if (page.PageSize > 0)
               criteria.SetMaxResults(page.PageSize);

            if (!string.IsNullOrEmpty(page.SortBy))
               criteria.AddOrder(page.SortAsc ? Order.Asc(page.SortBy) : Order.Desc(page.SortBy));

            page.TotalRows =
               countCriteria.SetProjection(Projections.CountDistinct(countByAlias))
               .UniqueResult<int>();
         }
         return new PagedList<TModel>(page, results.ToList());
      }

      #endregion
   }
}