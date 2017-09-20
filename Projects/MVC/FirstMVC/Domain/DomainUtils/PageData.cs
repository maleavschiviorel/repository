using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainUtils
{
   public class PageData : IPageData
   {
      #region IPageData Members

      public string SortBy { get; set; }
      public bool SortAsc { get; set; }
      public int Page { get; set; }
      public int PageSize { get; set; }

      public int Pages => (int)Math.Ceiling(TotalRows / (float)PageSize);

      public long TotalRows { get; set; }

      #endregion
   }
}
