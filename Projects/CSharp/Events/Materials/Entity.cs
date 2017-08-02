namespace Materials

{
    public class Entity
    {
        public int Id
        {
            get;
            private set;
        }
        public Entity(int id)
        { Id = id; }
        public virtual Entity Asign(Entity from)
        {
            this.Id = from.Id;
            return this;
        }
    }
}
