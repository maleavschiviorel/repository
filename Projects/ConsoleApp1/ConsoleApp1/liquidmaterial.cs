using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class liquidmaterial : material
    {
        public double volume_m3
        {
            get;
            set;
        }

        public liquidmaterial(double buyprice) : base(buyprice, buyprice * 5 * SellKoef)
        {
            Console.WriteLine(string.Format("Init liquidmaterial with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        public override void Sell(int quantity)
        {
            Console.WriteLine("sell liquidmaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());
        }
    }
}