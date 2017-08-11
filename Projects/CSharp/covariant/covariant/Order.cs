using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covariant
{
    public class Order
    {
        private IPerson person;
        public Order()
        {
        }
        public Order(IPerson person)
        {
            this.person = person;
        }

        public override string ToString()
        {
            return "Order of " + person?.ToString();
        }
    }
}
