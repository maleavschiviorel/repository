namespace Domain.DomainUtils
{
   public interface IPageData
   {
      #region Public members

      /// <summary>
      ///     Current grid page, 0 based index.
      /// </summary>
      int Page { get; set; }

      /// <summary>
      ///     Rows per page
      /// </summary>
      int PageSize { get; set; }

      /// <summary>
      ///     Total page count
      /// </summary>
      int Pages { get; }


      /// <summary>
      ///     Total rows count
      /// </summary>
      long TotalRows { get; set; }


      /// <summary>
      ///     Sort column
      /// </summary>
      string SortBy { get; set; }

      /// <summary>
      ///     Specifies whether it should be sorted ascending.
      /// </summary>
      bool SortAsc { get; set; }

      #endregion
   }
}