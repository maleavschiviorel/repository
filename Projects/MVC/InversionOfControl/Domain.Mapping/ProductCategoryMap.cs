namespace Domain.Mapping
{
   using Domain;
   using FluentNHibernate.Mapping;

   public class ProductCategoryMap : EntityMap<ProductCategory>
   {
      #region Public members

      public ProductCategoryMap()
      {
         Map(x => x.Name).Not.Nullable();
         References(x => x.Product).Not.Nullable();
      }

      #endregion
   }
}