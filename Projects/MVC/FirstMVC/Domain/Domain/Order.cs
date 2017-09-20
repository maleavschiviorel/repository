using System;

namespace Domain.Domain
{
    public class Order:Entity 
    {
        public virtual string Material { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual Client Client { get; set; }

        public override Entity Asign(Entity from)
        {
            Order from1 = (Order)from;
            this.Material = from1.Material;
            this.UnitPrice = from1.UnitPrice;
            this.Quantity = from1.Quantity;
            this.Client = from1.Client;
            return base.Asign(from1);
        }
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