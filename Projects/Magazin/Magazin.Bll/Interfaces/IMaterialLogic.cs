using Magazin.Domain;

namespace Magazin.Bll.Interfaces
{
    interface IMaterialLogic
    {
        void Buy(Material material, int quantity);

        void Buy(Material material, int quantity, double custombuyprice);

        void Sell(Material material, int quantity);

        void Sell(Material material, int quantity, double? sellprice);
    }
}
