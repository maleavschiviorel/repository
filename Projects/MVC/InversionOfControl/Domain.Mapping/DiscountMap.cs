using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
   using Domain;
   using FluentNHibernate.Mapping;

   public class DiscountMap:SubclassMap<DiscountProduct>
   {
      public DiscountMap()
      {
         DiscriminatorValue("DiscountProduct");
         Map(x => x.Discount);
      }
   }
}
