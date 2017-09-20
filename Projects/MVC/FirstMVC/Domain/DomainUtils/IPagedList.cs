using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainUtils
{
   public interface IPagedList<T> : IList<T>
   {
      #region Public members

      /// <summary>
      /// Page Info
      /// </summary>
      IPageData Page { get; set; }

      #endregion
   }
}
