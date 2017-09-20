using System.Collections.Generic;

namespace Domain.Domain
{
    public class Client : Person
    {
        public virtual string TypeOfClient { get; set; }
        public virtual IList<Order> Orders { get; set; }

        public override Entity Asign(Entity from)
        {
            Client from1 = (Client)from;
            this.TypeOfClient  = from1.TypeOfClient;
            return base.Asign(from1);
        }
    }
}