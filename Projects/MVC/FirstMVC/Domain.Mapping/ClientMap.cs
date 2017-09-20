using Domain.Domain;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class ClientMap : SubclassMap<Client>
    {
        public ClientMap()
        {
            Table("Client");
            KeyColumn("ClientId");
            Map(x => x.TypeOfClient);
           // References(x => x.Id);
            HasMany(x => x.Orders).Cascade.AllDeleteOrphan();
        }
    }
}