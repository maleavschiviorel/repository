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

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Entity other)
        {
           return MyCompareTo(other);
        }
        
        public bool Equals(Entity other)
        {
            return MyEquals(other);
        }

        public virtual bool MyEquals(Entity other)
        {
            return this.Id == other.Id;
        }

        public virtual int MyCompareTo(Entity other)
        {
            //if (this.GetType() != typeof(Entity))
            //   return CompareTo(other);
            //else
            {
                if (Id > other.Id)
                    return 1;
                else if (Id < other.Id)
                    return -1;
                else return 0;
            }

        }
        public override string ToString()
        {
            return "Entity {Id={" + Id + "}}";
        }

    }
}
