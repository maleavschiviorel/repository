namespace Domain.Dto
{
   public class ProductDetailsDto
   {
      #region Public members

      public long ProductId { get; set; }
      public string ProductName { get; set; }
      public string Popularity { get; set; }
      public string Description { get; set; }

      public long CategoryCount { get; set; }

      #endregion
   }
}