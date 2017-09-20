namespace Domain.Mapping
{
   using Domain;

   public class ProductMap : EntityMap<Product>
   {
      #region Public members

      public ProductMap()
      {
         DiscriminateSubClassesOnColumn("ProductType");
         Map(x => x.Name).Not.Nullable();
         Map(x => x.Price).Not.Nullable();
         Map(x => x.Ranking).Not.Nullable();
         Map(x => x.Description).Not.Nullable();
         Map(x => x.CategoryCount).Formula(@"(Select COUNT(*) from ProductCategory where ProductCategory.Product_id = Id)");
         HasMany(x => x.ProductCategorys).Cascade.SaveUpdate().Inverse()
            .ForeignKeyCascadeOnDelete();
      }

      #endregion
   }
}