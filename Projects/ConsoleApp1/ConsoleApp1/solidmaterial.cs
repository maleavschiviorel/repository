using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class solidmaterial : material
    {
        static public double addCoef1 = 1;

        private double weight = 0;

        public double Weight
        {
            get { return weight; }
        }
        static solidmaterial()
        {
            // solidmaterial.addCoef = 3.5;
            Console.WriteLine("Init solidmaterial static constractor ");
        }
        public solidmaterial(string Name, double buyprice) : base(Name, buyprice, buyprice * solidmaterial.addCoef)
        {
            Console.WriteLine(string.Format("Init solidmaterial with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }

        public solidmaterial(string Name, double buyprice, double sellprice) : base(Name, buyprice, sellprice)
        {
            Console.WriteLine(string.Format("Init solidmaterial with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
      
        public override void Buy(int quantity)
        {
            if (quantity <= 0)
                throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
            weight = weight + quantity;

            Console.WriteLine("buy solidmaterial  quantity =" + quantity.ToString() + " with price " + buyprice.ToString());
        }
        public override void Buy(int quantity, double custombuyprice)
        {
            if (quantity <= 0)
                throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
            weight  = weight + quantity;

            if (buyprice >= custombuyprice)
                Console.WriteLine("buy solidmaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());
            else
                //throw new Exception("custom buy price is more then default buy price");
                Console.WriteLine("custom buy price is more then default buy price");
        }
        public override void Sell(int quantity, double? selprice)
        {
            if (quantity > weight)
                throw new SellQuatityMoreThenInStock(String.Format("in stock is {0} quantity but is trying to sell {1} quantity of  {2}", weight, quantity, Name));

            weight = weight - quantity;

            maxsellprice = selprice ?? this.sellprice;
            Console.WriteLine("sell solidmaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());
        }
      
        public override void Sell(int quantity)
        {
            Sell(quantity, null);
        }
    }

}