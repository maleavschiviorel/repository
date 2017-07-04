using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public abstract class material
    {
        static public double addCoef = 1;
        public const double SellKoef = 1.5;
        public readonly double buyprice = 0;
        public double sellprice
        {
            get;

        }

        public string Vendor
        {
            get;
            set;
        }

        static material()
        {
            addCoef = 2.5;
            Console.WriteLine("Init material static constractor ");
        }

        protected material(double buyprice)
        {
            this.buyprice = buyprice;
            this.sellprice = buyprice * SellKoef;

            Console.WriteLine(string.Format("Init material with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        protected material(double buyprice, double sellprice)
        {
            this.buyprice = buyprice;
            if (buyprice > 0 && buyprice > sellprice)
                this.sellprice = buyprice * SellKoef;
            this.sellprice = sellprice;

            Console.WriteLine(string.Format("Init material with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        public virtual void Buy(int quantity) { Console.WriteLine("buy material  quantity =" + quantity.ToString() + " with price " + buyprice.ToString()); }
        public virtual void Buy(int quantity, double custombuyprice) { Console.WriteLine("buy material quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString()); }
        public abstract void Sell(int quantity);
    }
}