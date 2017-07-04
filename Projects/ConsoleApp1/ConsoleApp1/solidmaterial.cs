using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class solidmaterial : material
    {
        static public double addCoef1 = 1;
        public double weight
        {
            get;
            set;
        }
        static solidmaterial()
        {
           // solidmaterial.addCoef = 3.5;
            Console.WriteLine("Init solidmaterial static constractor ");
        }
        public solidmaterial(double buyprice) : base(buyprice, buyprice * solidmaterial.addCoef)
        {
            Console.WriteLine(string.Format("Init solidmaterial with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        public solidmaterial(double buyprice, double sellprice) : base(buyprice, sellprice)
        {
            Console.WriteLine(string.Format("Init solidmaterial with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        public override void Buy(int quantity, double custombuyprice)
        {
            if (buyprice >= custombuyprice)
                Console.WriteLine("buy solidmaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());
            else
                //throw new Exception("custom buy price is more then default buy price");
                Console.WriteLine("custom buy price is more then default buy price");
        }
        public override void Sell(int quantity)
        {
            Console.WriteLine("sell solidmaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());
        }
    }

}