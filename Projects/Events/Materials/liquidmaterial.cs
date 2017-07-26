using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Materials
{
    public class LiquidMaterial : Material
    {
        public double Volume_m3
        {
            get; set;

        }
        public override Entity Asign(Entity from)
        {
            base.Asign(from);
            if (from is LiquidMaterial)
            {
                Volume_m3 = ((LiquidMaterial)from).Volume_m3;
            }
            return this;
        }
        public LiquidMaterial(int id,string Name, double buyprice) : base(id,Name, buyprice, buyprice * 5 * SellKoef)
        {
            Console.WriteLine(string.Format("Init LiquidMaterial with buyprice= {0} and sellprice={1}", buyprice, this.Sellprice));
        }
     
    }
}