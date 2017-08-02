using MaterialActionsProcess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materials
{
   public abstract class MaterialOperator
    {

        private static MateriaActionsProcessor _map;
        protected MateriaActionsProcessor Map
        {
            get { return _map; }
        }
        protected Log.Log log = Log.Log.GetTheLog();

        [Conditional("CompileCondition")]
        public abstract void Buy(Material material,int quantity);
        public abstract void Buy(Material material, int quantity, double custombuyprice);
        public abstract void Sell(Material material, int quantity);
        public abstract void Sell(Material material, int quantity, double? sellprice);
        public static void SetMaterialActionsProcessor(MateriaActionsProcessor map)
        {
            _map = map;
        }
    }
}
