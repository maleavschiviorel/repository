using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
       
        public virtual Entity Asign(Entity from)
        {
            this.Id = from.Id;
            return this;
        }
    }
}
