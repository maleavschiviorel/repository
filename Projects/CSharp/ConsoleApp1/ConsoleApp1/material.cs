#define IEquatable
using System;
using System.Diagnostics;

namespace ConsoleApp1
{

    public abstract class material :
        IComparable
#if IEquatable
        , IEquatable<material>
#endif
    {
        public enum TypeOfObtain : byte { synthetic = 1, organic, chemical = 5 };

        static public double addCoef = 1;

        private string name = "";

        protected readonly double? buyprice = null;
        protected double? maxsellprice = null;
        protected double? sellprice = null;
        protected Log.Log log = Log.Log.GetTheLog();

        public const double SellKoef = 1.5;
        public TypeOfObtain MaterialIs
        {
            get;
            set;
        }
        public int CompareTo(object m)
        {
            if (m is material)
            {
                material m2 = m as material;
                if (this.Name.CompareTo(m2.Name) == 0 && this.Buyprice.HasValue && m2.Buyprice.HasValue)
                    return ((double)this.Buyprice).CompareTo((double)m2.Buyprice);
                else
                    return this.Name.CompareTo(m2.Name);
            }
            else
            {
                throw new Exception("not of type material");
            }
        }
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

        protected material(string Name, double buyprice)
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
        [Conditional("CompileCondition")]
        public abstract void Buy(int quantity);
        public abstract void Buy(int quantity, double custombuyprice);
        public abstract void Sell(int quantity);
        public abstract void Sell(int quantity, double? sellprice);

#if IEquatable
        public override bool Equals(object m)
        {
            if (m is material)
            {
                material m2 = m as material;
                if (this.Name.CompareTo(m2.Name) == 0 && this.Buyprice.HasValue && m2.Buyprice.HasValue)
                    return ((double)this.Buyprice) == ((double)m2.Buyprice);
                else
                    return this.Name.Equals(m2.Name);
            }
            else
            {
                throw new Exception("not of type material");
            }
            return false;
        }

        bool IEquatable<material>.Equals(material m)
        {

            material m2 = m as material;
            if (this.Name.CompareTo(m2.Name) == 0 && this.Buyprice.HasValue && m2.Buyprice.HasValue)
                return ((double)this.Buyprice) == ((double)m2.Buyprice);
            else
                return this.Name.Equals(m2.Name);

        }
#endif

    }
}