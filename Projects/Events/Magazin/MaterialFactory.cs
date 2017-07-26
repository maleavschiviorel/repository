using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Materials;

namespace Magazin
{
    public class MaterialFactory : IMaterialFactory
    {
        private static Lazy<MaterialFactory> _lazy = new Lazy<MaterialFactory>(() => new MaterialFactory());
        public static MaterialFactory GetMaterialFactory
        {
            get
            {
                return _lazy.Value;
            }
        }
        public SolidMaterial GetNewSolidMaterial(int id, string name, double buyprice)
        {
            var material = new SolidMaterial(id, name, buyprice);
            return material;
        }
        public LiquidMaterial GetNewLiquidMaterial( int id, string name, double buyprice)
        {
            var material = new LiquidMaterial(id, name, buyprice);
            return material;

        }
    }
}

