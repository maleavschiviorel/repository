using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MaterialEqualityComparer:IEqualityComparer<material> 
    {
        public bool Equals(material m1,  material m2)
        {
            if (m1.Name.Equals(m2.Name))
                return true;
            else
                return false;
        }

        public int GetHashCode(material m)
        {
            return m.Name.GetHashCode();  
        }
    }
    public class MaterialPriaorityComparer : Comparer<material>
    {
        public override int Compare(material m1, material m2)
        {
            if (m1.Name.CompareTo(m2.Name) == 0 && m1.Buyprice.HasValue && m2.Buyprice.HasValue)
                return ((double)m1.Buyprice).CompareTo((double)m2.Buyprice);
            else
              return  m1.Name.CompareTo(m2.Name);
        }
    }
     
}
