using Domain.Domain;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class SupplierMap : SubclassMap<Supplier>
    {
        public SupplierMap()
        {
            Map(x => x.Brend);
        }
    }
}
