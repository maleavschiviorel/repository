using FluentNHibernate.Mapping;

namespace NHibernate
{
    public class ClientMap : SubclassMap<Client>
    {
        public ClientMap()
        {
            Table("Client");
            KeyColumn("ClientId");
            Map(x => x.TypeOfClient);
           // References(x => x.Id);
            HasMany(x => x.Orders).Inverse().Cascade.SaveUpdate();
        }
    }
}