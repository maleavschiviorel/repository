using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.Model
{
    class SupplierModel:PersonModel
    {
        public virtual string Brend { get; set; }
    }
}
