using System;
using System.Collections.Generic;

namespace ProxyPattern
{
    public interface IExchange
    {
        DateTime CurrencyDate { get; set; }

        List<string> GetAllCurrenciesCode();
        Valute GetValutaByCode(string CharCode);
    }
}