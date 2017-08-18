using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;

namespace NHibernate
{
    public class SupplierMap : SubclassMap<Supplier>
    {
        public SupplierMap()
        {
            Map(x => x.Brend);
        }
    }
}
