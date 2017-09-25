using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class OrderDto
    {
        public virtual int Id { get; set; }
        public virtual string Material { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual ClientDto Client { get; set; }

        public virtual int ClientId { get; set; }
        public virtual IList<ClientDto> AllClients { get; set; }
    }
}
