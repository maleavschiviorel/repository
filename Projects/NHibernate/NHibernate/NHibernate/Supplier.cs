using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate
{
    public class Supplier : Person
    {
        public virtual string Brend { get; set; }
    }
}
