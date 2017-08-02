using System;

namespace Magazin.Domain
{
    public class SellQuatityMoreThenInStock:Exception 
    {
        public SellQuatityMoreThenInStock(string text):base(text)
        {
        }
    }
    public class BuyQuatityLessOrEqualToZero : Exception
    {
        public BuyQuatityLessOrEqualToZero(string text) : base(text)
        {
        }
    }
}
