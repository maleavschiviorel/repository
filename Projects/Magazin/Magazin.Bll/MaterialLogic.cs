using System;
using Magazin.Bll.Interfaces;
using Magazin.Domain;
using Magazin.Dal.Interfaces;

namespace Magazin.Bll
{
    public class MaterialLogic : IMaterialLogic
    {
        IRepository<Material> _materialRepozitory;

        public MaterialLogic(IRepository<Material> materialRepozitory)
        {
            _materialRepozitory = materialRepozitory;
        }

        public void Buy(Material material, int quantity)
        {
            _materialRepozitory.Update(material);
            throw new NotImplementedException();
        }

        public void Buy(Material material, int quantity, double custombuyprice)
        {
            throw new NotImplementedException();
        }

        public void Sell(Material material, int quantity)
        {
            throw new NotImplementedException();
        }

        public void Sell(Material material, int quantity, double? sellprice)
        {
            throw new NotImplementedException();
        }
    }
}
