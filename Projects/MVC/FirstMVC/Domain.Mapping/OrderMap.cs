using Domain.Domain;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id);
            Map(x => x.Material);
            Map(x => x.Quantity);
            Map(x => x.UnitPrice);
            References(x => x.Client);
        }
    }
}