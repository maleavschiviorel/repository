using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.Model
{
  public  class ClientModel: PersonModel
    {
        public virtual string TypeOfClient { get; set; }
    }
}
