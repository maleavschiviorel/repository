using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.Model
{
   public class OrderModel
    {
        public virtual int Id { get; set; }
        public virtual string Material { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual ClientModel Client { get; set; }

        public virtual int ClientId { get; set; }
        public virtual IList<ClientModel> AllClients { get; set; }
    }
}
