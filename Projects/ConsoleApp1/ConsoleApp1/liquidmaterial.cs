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

        public liquidmaterial(string Name,double buyprice) : base(Name,buyprice, buyprice * 5 * SellKoef)
        {
            Console.WriteLine(string.Format("Init liquidmaterial with buyprice= {0} and sellprice={1}", buyprice, this.Sellprice));
        }
        public override void Sell(int quantity)
        {
            Console.WriteLine("sell liquidmaterial quantity =" + quantity.ToString() + " with price " + Sellprice.ToString());
        }
        public override void Sell(int quantity, double ? sellprice)
        {
            if (sellprice.HasValue)
                maxsellprice  = sellprice; ;
            Console.WriteLine("sell liquidmaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());
        }
    }
}