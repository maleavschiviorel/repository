using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class Valute
    {
        public string CharCode;
        public int Nominal;
        public string Name;
        public double Value;
    }
    public class ValutaWithNumCode: Valute
    {
        public int NumCode;
    }
}
