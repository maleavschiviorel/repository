namespace Domain.Domain
{
   using System;

   public class ProductCategory: Entity
   {
      #region Public members
      
      public virtual string Name { get; protected set; }
      public virtual Product Product { get; set; }

      public ProductCategory(string name)
      {
         if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("name is required.");
         Name = name;
      }

      #endregion

      #region Non-public members

      [Obsolete]
      protected ProductCategory()
      {
      }

      #endregion
   }
}