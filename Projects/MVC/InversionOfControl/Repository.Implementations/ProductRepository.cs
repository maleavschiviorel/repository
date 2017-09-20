namespace Repository.Implementations
{
   using System.Collections.Generic;
   using Domain.Domain;
   using Domain.DomainUtils;
   using Domain.Dto;
   using Interfaces;
   using NHibernate;
   using NHibernate.Criterion;
   using NHibernate.Transform;

   internal class ProductRepository : Repository, IProductRepository
   {
      public void ModifyProductName(long id, string name)
      {
         using (ITransaction transaction = _session.BeginTransaction())
         {
            var product = _session.Load<Product>(id);
            product.Name = name;
            transaction.Commit();
         }
      }

      public IList<Product> FindPopularProducts(int ranking)
      {
         var products = _session.QueryOver<Product>()
                                .Where(x => x.Ranking > ranking)
                                .TransformUsing(Transformers.RootEntity)
                                .List();

         return products;
      }

      public IList<Product> FindProductsByPriceOrRanking(int price, int ranking)
      {
         return _session.QueryOver<Product>()
                        .Where(x => !(x.Ranking > ranking) && x.Price > price)
                        .List();
      }

      public IList<Product> FindProductsByProductCategoryName(string productCategoryName)
      {
         var productCategorySubquery = QueryOver.Of<ProductCategory>()
                                                .Where(x => x.Name == productCategoryName)
                                                .Select(x => x.Product.Id);

         return _session.QueryOver<Product>()
                        .WithSubquery.WhereProperty(x => x.Id).In(productCategorySubquery)
                        .List();
      }

      public Product FindMostPopularProductInCategory(long productCategoryId)
      {
         Product productAlias = null;
         ProductCategory productCategoryAlias = null;
         ProductCategory innerProductCategoryAlias = null;
         var a = QueryOver.Of<Product>()
                          .JoinAlias(x => x.ProductCategorys,
                             () => innerProductCategoryAlias)
                          .Where(
                             () =>
                                innerProductCategoryAlias.Id ==
                                   productCategoryAlias.Id)
                          .SelectList(
                             list => list.Select(x => x.Ranking))
                          .Take(1);

         Product mostPopularProduct =
            _session.QueryOver(() => productAlias)
                    .JoinAlias(() => productAlias.ProductCategorys, () => productCategoryAlias)
                    .Where(() => productCategoryAlias.Id == productCategoryId)
                    .WithSubquery.WhereAll(() => productAlias.Ranking >=
                       a
                                .As<long>())
                    .SingleOrDefault();

         return mostPopularProduct;
      }

      public IList<ProductManageDto> GetProductsToManage(
         ProductFilter productFilter)
      {
         ProductManageDto productManageDtoAlias = null;
         var productQuery = _session.QueryOver<Product>()
                                    .ApplyProductFilter(productFilter);

         IList<ProductManageDto> productManageDtos =
            productQuery
               .SelectList(list =>
                  list.Select(x => x.Id).WithAlias(() => productManageDtoAlias.ProductId)
                      .Select(x => x.Name).WithAlias(() => productManageDtoAlias.ProductName)
                      .Select(x => x.Ranking).WithAlias(() => productManageDtoAlias.Ranking))
               .TransformUsing(Transformers.AliasToBean<ProductManageDto>())
               .List<ProductManageDto>();

         return productManageDtos;
      }

      public IPagedList<ProductDetailsDto> GetProductDetails(IPageData pageData)
      {
         ProductDetailsDto productDetailsDto = null;
         Product productAlias = null;
         ProductCategory productCategoryAlias = null;

         var productQuery =
            _session.QueryOver(() => productAlias)
                    .SelectList(list => list
                       .Select(() => productAlias.Id).WithAlias(() => productDetailsDto.ProductId)
                       .Select(() => productAlias.Name).WithAlias(() => productDetailsDto.ProductName)
                       .Select(Projections.Conditional(Restrictions.Where<Product>(x => x.Ranking > 100)
                          , Projections.Constant("Popular", NHibernateUtil.String),
                          Projections.Constant("Low popularity", NHibernateUtil.String)))
                       .WithAlias(() => productDetailsDto.Popularity)
                       .SelectSubQuery(QueryOver
                          .Of(() => productCategoryAlias)
                          .Where(x => productCategoryAlias.Product.Id == productAlias.Id)
                          .SelectList(list2 => list2.SelectCount(() => productCategoryAlias.Id)))
                        .Select(Projections.SqlFunction("coalesce", NHibernateUtil.String,
                        Projections.Property<Product>(p=>p.Description), Projections.Constant("Not available")).WithAlias(()=>productDetailsDto.Description))
                       .WithAlias(() => productDetailsDto.CategoryCount));

         return GetPaged<ProductDetailsDto, Product>(productQuery, pageData);
      }

   }

   public static class ProductQueryOverExtensions
   {
      public static IQueryOver<Product, Product> ApplyProductFilter(
         this IQueryOver<Product, Product> productsQuery,
         ProductFilter productFilter)
      {

         if (productFilter == null)
            return productsQuery;

         ApplyRankingFilter(productsQuery, productFilter);
         ApplyCategoryCountFilter(productsQuery, productFilter);

         return productsQuery;
      }

      private static void ApplyRankingFilter(IQueryOver<Product, Product> productsQuery, ProductFilter productFilter)
      {
         if (productFilter.RankingHigher.HasValue)
         {
            productsQuery.Where(pr => pr.Ranking > productFilter.RankingHigher.Value);
         }
      }

      private static void ApplyCategoryCountFilter(IQueryOver<Product, Product> productsQuery,
                                                 ProductFilter productFilter)
      {
         if (productFilter.CategoryCountBigerThan.HasValue)
         {
            productsQuery.Where(pr => pr.CategoryCount > productFilter.CategoryCountBigerThan.Value);
         }
      }
   }
}