namespace Domain.Domain
{
    public class Supplier : Person
    {
        public virtual string Brend { get; set; }
        public override Entity Asign(Entity from)
        {
            Supplier from1 = (Supplier)from;
            this.Brend = from1.Brend;
            return base.Asign(from1);
        }
    }
}
