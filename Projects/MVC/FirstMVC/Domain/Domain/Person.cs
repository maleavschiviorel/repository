using System;

namespace Domain.Domain
{
    public class Person:Entity 
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }

        public override Entity Asign(Entity from)
        {
            Person  from1 = (Person)from;
            this.FirstName  = from1.FirstName;
            this.LastName  = from1.LastName;
            this.BirthDate  = from1.BirthDate;
            return base.Asign(from1);
        }
    }
}