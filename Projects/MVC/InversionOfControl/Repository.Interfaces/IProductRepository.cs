namespace Repository.Interfaces
{
   using System.Collections.Generic;
   using Domain.Domain;
   using Domain.DomainUtils;
   using Domain.Dto;

   public interface IProductRepository : IRepository
   {
      #region Public members

      void ModifyProductName(long id, string name);

      IList<Product> FindPopularProducts(int ranking);
      IList<Product> FindProductsByPriceOrRanking(int price, int ranking);

      IList<Product> FindProductsByProductCategoryName(string productCategoryName);

      Product FindMostPopularProductInCategory(long productCategoryId);
      IList<ProductManageDto> GetProductsToManage(
            ProductFilter productFilter);

      IPagedList<ProductDetailsDto> GetProductDetails(IPageData pageData);

      #endregion
   }
}