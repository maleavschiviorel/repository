using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
