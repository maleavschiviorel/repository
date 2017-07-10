using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public abstract class material
    {
        public enum TypeOfObtain : byte { synthetic = 1, organic, chemical = 5 };
        public TypeOfObtain MaterialIs
        {
            get;
            set;
        }
        static public double addCoef = 1;
        public const double SellKoef = 1.5;
        protected readonly double? buyprice = null;
        protected double? maxsellprice = null;
        protected double? sellprice = null;
        private string name = "";
        public string Name
        {
            get { return name; }
        }
        public double? Maxsellprice
        {
            get { return maxsellprice; }
        }
        public double Sellprice
        {
            get;

        }
        public double? Buyprice
        {
            get { return buyprice; }

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

        protected material(string Name,double buyprice)
        {
            name = Name;
            this.buyprice = buyprice;
            this.Sellprice = buyprice * SellKoef;

            Console.WriteLine(string.Format("Init material with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        protected material(string Name, double buyprice, double sellprice)
        {
            name = Name;
            this.buyprice = buyprice;
            if (buyprice > 0 && buyprice > sellprice)
                this.Sellprice = buyprice * SellKoef;
            this.Sellprice = sellprice;

            Console.WriteLine(string.Format("Init material with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        public virtual void Buy(int quantity) { Console.WriteLine("buy material  quantity =" + quantity.ToString() + " with price " + buyprice.ToString()); }
        public virtual void Buy(int quantity, double custombuyprice) { Console.WriteLine("buy material quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString()); }
        public abstract void Sell(int quantity);
        public abstract void Sell(int quantity, double? sellprice);

    }
}