using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations.Paging
{
   using Domain.DomainUtils;

   public class PagedList<T> : List<T>, IPagedList<T>
   {
      #region IPagedList<T> Members

      /// <summary>
      /// Page
      /// </summary>
      public IPageData Page { get; set; }

      #endregion

      #region Public members

      /// <summary>
      /// ctor with page only
      /// </summary>
      /// <param name="page">optional Page info</param>
      public PagedList(IPageData page)
      {
         Page = page;
      }

      /// <summary>
      /// ctor with page and collection
      /// </summary>
      /// <param name="page"></param>
      /// <param name="collection"></param>
      public PagedList(IPageData page, IEnumerable<T> collection)
          : this(page)
      {
         if (collection == null)
            throw new ArgumentNullException("adding null collection to a paged list is not allowed", "collection");

         AddRange(collection);
      }

      #endregion
   }
}
