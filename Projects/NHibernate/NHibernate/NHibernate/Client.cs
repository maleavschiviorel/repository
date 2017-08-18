using System.Collections.Generic;

namespace NHibernate
{
    public class Client : Person
    {
        public virtual string TypeOfClient { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }
}