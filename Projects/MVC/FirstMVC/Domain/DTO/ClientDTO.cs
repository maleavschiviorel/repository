﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
  public  class ClientDto: PersonDto
    {
        public virtual string TypeOfClient { get; set; }
    }
}
