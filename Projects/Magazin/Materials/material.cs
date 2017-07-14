#define IEquatable
using System;
using System.Diagnostics;
using MaterialActionsProcess;

namespace Materials
{

    public abstract class Material : Entity,
        IComparable
#if IEquatable
        , IEquatable<Material>
#endif
    {
        public enum TypeOfObtain : byte { synthetic = 1, organic, chemical = 5 };

        static public double addCoef = 1;

        private static MateriaActionsProcessor _map;
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
        protected MateriaActionsProcessor Map
        {
            get { return _map; }
        }
        public int CompareTo(object m)
        {
            if (m is Material)
            {
                Material m2 = m as Material;
                if (Id > -1 && Id == m2.Id)
                    return 0;
                else if (this.Name.CompareTo(m2.Name) == 0 && this.Buyprice.HasValue && m2.Buyprice.HasValue)
                    return ((double)this.Buyprice).CompareTo((double)m2.Buyprice);
                else
                    return this.Name.CompareTo(m2.Name);
            }
            else
            {
                throw new Exception("not of type Material");
            }
        }
        public override Entity Asign(Entity from)
        {
            base.Asign(from);
            if (from is Entity)
            {
                Material from1 = from as Material;
                this.name = from1.name;
                //buyprice = from.buyprice;
                this.sellprice = from1.sellprice;
                this.maxsellprice = from1.maxsellprice;
            }
            return this;
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

        static Material()
        {

            addCoef = 2.5;
            Console.WriteLine("Init Material static constractor ");
        }

        protected Material(string Name, double buyprice)
        {
            name = Name;
            this.buyprice = buyprice;
            this.Sellprice = buyprice * SellKoef;

            Console.WriteLine(string.Format("Init Material with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        protected Material(string Name, double buyprice, double sellprice)
        {
            name = Name;
            this.buyprice = buyprice;
            if (buyprice > 0 && buyprice > sellprice)
                this.Sellprice = buyprice * SellKoef;
            this.Sellprice = sellprice;

            Console.WriteLine(string.Format("Init Material with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        [Conditional("CompileCondition")]
        public abstract void Buy(int quantity);
        public abstract void Buy(int quantity, double custombuyprice);
        public abstract void Sell(int quantity);
        public abstract void Sell(int quantity, double? sellprice);

        public static void SetMaterialActionsProcessor(MateriaActionsProcessor map)
        {
            _map = map;
        }
#if IEquatable
        public override bool Equals(object m)
        {
            if (m is Material)
            {
                Material m2 = m as Material;
                if (Id > -1 && Id == m2.Id)
                    return true;
                else if (this.Name.CompareTo(m2.Name) == 0 && this.Buyprice.HasValue && m2.Buyprice.HasValue)
                    return ((double)this.Buyprice) == ((double)m2.Buyprice);
                else
                    return this.Name.Equals(m2.Name);
            }
            else
            {
                throw new Exception("not of type Material");
            }
            return false;
        }

        bool IEquatable<Material>.Equals(Material m)
        {

            Material m2 = m as Material;
            if (Id > -1 && Id == m2.Id)
                return true;
            if (this.Name.CompareTo(m2.Name) == 0 && this.Buyprice.HasValue && m2.Buyprice.HasValue)
                return ((double)this.Buyprice) == ((double)m2.Buyprice);
            else
                return this.Name.Equals(m2.Name);

        }
#endif

    }
}