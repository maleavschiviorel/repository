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
        public const double SellKoef = 1.5;

      
        public TypeOfObtain MaterialIs
        {
            get; set;
        }
        public string Name
        {
            get; private set;
        }
        public double Maxsellprice
        {
            get; set;
        }
        public double Sellprice
        {
            get; set;
        }
        public double Buyprice
        {
            get; set;
        }

        public string Vendor
        {
            get; set;
        }

        static Material()
        {

            addCoef = 2.5;
            Console.WriteLine("Init Material static constractor ");
        }

        protected Material(int id,string name, double buyprice):base(id)
        {
            Name = name;
            this.Buyprice = buyprice;
            this.Sellprice = buyprice * SellKoef;

            Console.WriteLine(string.Format("Init Material with buyprice= {0} and sellprice={1}", buyprice, this.Sellprice));
        }
        protected Material(int id, string name, double buyprice, double sellprice):base(id)
        {
            Name= name ;
            this.Buyprice = buyprice;
            if (buyprice > 0 && buyprice > sellprice)
                this.Sellprice = buyprice * SellKoef;
            this.Sellprice = sellprice;

            Console.WriteLine(string.Format("Init Material with buyprice= {0} and sellprice={1}", buyprice, this.Sellprice));
        }


        public int CompareTo(object m)
        {
            if (m is Material)
            {
                Material m2 = m as Material;
                if (Id > -1 && Id == m2.Id)
                    return 0;
                else if (this.Name.CompareTo(m2.Name) == 0 )
                    return (this.Buyprice).CompareTo(m2.Buyprice);
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
                this.Name = from1.Name;
                //buyprice = from.buyprice;
                this.Sellprice = from1.Sellprice;
                this.Maxsellprice = from1.Maxsellprice;
            }
            return this;
        }

#if IEquatable
        public override bool Equals(object m)
        {
            if (m is Material)
            {
                Material m2 = m as Material;
                if (Id > -1 && Id == m2.Id)
                    return true;
                else if (this.Name.CompareTo(m2.Name) == 0)
                    return (this.Buyprice) == (m2.Buyprice);
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
            if (this.Name.CompareTo(m2.Name) == 0 )
                return (this.Buyprice) == (m2.Buyprice);
            else
                return this.Name.Equals(m2.Name);

        }
#endif

    }
}