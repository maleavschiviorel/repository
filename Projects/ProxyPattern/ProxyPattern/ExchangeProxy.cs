using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class BNMExchangeProxy : IExchange
    {
        private BNMExchange _bnmExchange;
        public DateTime CurrencyDate { get => _bnmExchange.CurrencyDate; set => _bnmExchange.CurrencyDate = value; }

        public BNMExchangeProxy()
        { _bnmExchange = new BNMExchange(DateTime.Now); }
        public List<string> GetAllCurrenciesCode()
        {
            return _bnmExchange.GetAllCurrenciesCode();
        }
        public Valute GetValutaByCode(string CharCode)
        {
            return _bnmExchange.GetValutaByCode(CharCode);
        }
    }
}
