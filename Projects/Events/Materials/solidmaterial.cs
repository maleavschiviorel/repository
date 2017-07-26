using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Materials
{
    public class SolidMaterial : Material
    {
        static public double addCoef1 = 1;
        public double Weight
        {
            get; set;
        }
        static SolidMaterial()
        {
            // SolidMaterial.addCoef = 3.5;
            Console.WriteLine("Init SolidMaterial static constractor ");
        }
        public SolidMaterial(int id,string Name, double buyprice) : base(id,Name, buyprice, buyprice * SolidMaterial.addCoef)
        {
            Console.WriteLine(string.Format("Init SolidMaterial with buyprice= {0} and sellprice={1}", buyprice, this.Sellprice));
        }

        public SolidMaterial(int id, string Name, double buyprice, double sellprice) : base( id,Name, buyprice, sellprice)
        {
            Console.WriteLine(string.Format("Init SolidMaterial with buyprice= {0} and sellprice={1}", buyprice, this.Sellprice));
        }
        public override Entity Asign(Entity from)
        {
            base.Asign(from);
            if (from is SolidMaterial)
            {
                Weight = ((SolidMaterial)from).Weight;
            }
            return this;
        }
 
    }

}