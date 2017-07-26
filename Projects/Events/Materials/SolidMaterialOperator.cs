using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materials
{
    public class SolidMaterialOperator:MaterialOperator 
    {
        public override void Buy(Material material, int quantity)
        {
            SolidMaterial solidMaterial = material as SolidMaterial;
            if (solidMaterial == null) return;

            if (quantity <= 0)
                throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
            solidMaterial.Weight = solidMaterial.Weight + quantity;

            Console.WriteLine("buy SolidMaterial  quantity =" + quantity.ToString() + " with price " + solidMaterial.Buyprice.ToString());


            if (Map != null)
                Map.GenerateMaterialOperationEvent(material.Id, material.Name, "SolidMaterial", MaterialActionsProcess.Operation.Buy, quantity);
        }
        public override void Buy(Material material, int quantity, double custombuyprice)
        {
            SolidMaterial solidMaterial = material as SolidMaterial;
            if (solidMaterial == null) return;

            if (quantity <= 0)
                throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));

            solidMaterial.Weight = solidMaterial.Weight + quantity;

            if (solidMaterial.Buyprice >= custombuyprice)
                Console.WriteLine("buy SolidMaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());
            else
                //throw new Exception("custom buy price is more then default buy price");
                Console.WriteLine("custom buy price is more then default buy price");


            if (Map != null)
                Map.GenerateMaterialOperationEvent(material.Id, material.Name, "SolidMaterial", MaterialActionsProcess.Operation.Buy, quantity);
        }
        public override void Sell(Material material, int quantity, double? sellprice)
        {
            SolidMaterial solidMaterial = material as SolidMaterial;
            if (solidMaterial == null) return;

            if (quantity > solidMaterial.Weight)
                throw new SellQuatityMoreThenInStock(String.Format("in stock is {0} quantity but is trying to sell {1} quantity of  {2}", solidMaterial.Weight, quantity, solidMaterial.Name));

            solidMaterial.Weight = solidMaterial.Weight - quantity;

            solidMaterial.Maxsellprice = sellprice ?? solidMaterial.Sellprice;
            Console.WriteLine("sell SolidMaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());


            if (Map != null)
                Map.GenerateMaterialOperationEvent(material.Id, material.Name, "SolidMaterial", MaterialActionsProcess.Operation.Sell, quantity);
        }

        public override void Sell(Material material, int quantity)
        {
            Sell(material,quantity, null);
        }
    }
}
