namespace Magazin.Domain

{
    public class Entity
    {
        private int id = -1;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public virtual Entity Asign(Entity  from)
        {
            this.Id = from.Id;
            return this;
        }
    }
}
