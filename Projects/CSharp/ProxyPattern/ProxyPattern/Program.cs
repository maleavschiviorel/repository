using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IExchange  exchangeProxy = new BNMExchangeProxy();

            List<string> currencies = exchangeProxy.GetAllCurrenciesCode();
            Valute valuta = exchangeProxy.GetValutaByCode(currencies[1]);
           
            Console.ReadLine();  
        }
    }
}
