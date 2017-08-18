using System;

namespace NHibernate
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual string Material { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual Client Client { get; set; }
    }

    public class OrderDe
    {
        public virtual int Id { get; set; }
        public virtual string Material { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual string TypeOfClient { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }
    }
}