namespace Domain.Domain
{
   using System;
   using System.Collections.Generic;
   using System.Linq;

   public class Product : Entity
   {
      #region Public members

      public virtual string Name { get; set; }
      public virtual string Description { get; protected set; }
      public virtual long Price { get; protected set; }
      public virtual long CategoryCount { get; protected set; }
      public virtual long Ranking { get; protected set; }
      public virtual IList<ProductCategory> ProductCategorys { get; protected set; }

      public Product(string name, string description, long price, long ranking, IList<string> categoryNames)
      {
         if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("name is required.");
         if (price <= 0)
            throw new ArgumentException("price must be positive.");
         if (!categoryNames.Any())
            throw new ArgumentException("Assign product to at least one category.");

         Name = name;
         Description = description;
         Price = price;
         Ranking = ranking;
         ProductCategorys = categoryNames.Select(x => new ProductCategory(x)).ToList();
      }

      public virtual void AddProductCategory(ProductCategory productCategory)
      {
         ProductCategorys.Add(productCategory);
         productCategory.Product = this;
      }

      #endregion

      #region Non-public members

      [Obsolete]
      protected Product()
      {
      }

      #endregion
   }

   public class DiscountProduct : Product
   {
      public virtual long Discount { get; protected set; }

      public DiscountProduct(long discount, string name, string description, long price, long ranking,
         IList<string> categoryNames) : base(name, description, price, ranking, categoryNames)
      {
         Discount = discount;
      }

      [Obsolete]
      protected DiscountProduct()
      {
      }
   }

   public interface IProductOptions
   {
      #region Public members

      IProductOptions WithDescrption(Func<string> desciptionDelegate);
      string GetDescription();

      #endregion
   }
}