using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQAdvanced.Classes
{
    public class Entity : IComparable<Entity>, IEquatable<Entity>, IComparable, IEquatable<object>
    {
        public int Id;

        public virtual int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public virtual int CompareTo(Entity other)
        {
            throw new NotImplementedException();
        }

        public virtual bool Equals(Entity other)
        {
            return this.ToString().Equals(other.ToString());
        }
        public override string ToString()
        {
            return "Entity {Id={"+ Id + "}}";
        }
    }
}
