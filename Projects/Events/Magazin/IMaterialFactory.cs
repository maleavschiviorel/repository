using Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    public interface IMaterialFactory
    {
        SolidMaterial GetNewSolidMaterial(int id, string name, double buyprice);
        LiquidMaterial GetNewLiquidMaterial( int id, string name, double buyprice);
    }
}
