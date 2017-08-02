using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materials
{
   public  class LiquidMaterialOperator: MaterialOperator
    {
        public override void Sell(Material material,  int quantity)
        {
            LiquidMaterial liquidMaterial = material as LiquidMaterial;
            if (liquidMaterial == null) return;

            Console.WriteLine("sell LiquidMaterial quantity =" + quantity.ToString() + " with price " + liquidMaterial.Sellprice.ToString());
        }
        public override void Sell(Material material, int quantity, double? sellprice)
        {
            try
            {
                LiquidMaterial liquidMaterial = material as LiquidMaterial;
                if (liquidMaterial == null) return;

                if (quantity > liquidMaterial.Volume_m3)
                    throw new SellQuatityMoreThenInStock(String.Format("in stock is {0} quantity but is trying to sell {1} quantity of  {2}", liquidMaterial.Volume_m3 , quantity, liquidMaterial.Name));

                liquidMaterial.Volume_m3  = liquidMaterial.Volume_m3 - quantity;

                if (sellprice.HasValue)
                    liquidMaterial.Maxsellprice = (double)sellprice; ;

                Console.WriteLine("sell LiquidMaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());

                log.WriteSucces("sell LiquidMaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());

                if (Map != null)
                    Map.GenerateMaterialOperationEvent(material.Id, material.Name, "LiquidMaterial", MaterialActionsProcess.Operation.Sell, quantity);
            }
            catch (SellQuatityMoreThenInStock ex)
            {
                log.WriteError(ex.Message + "\r\n" + ex.StackTrace);

                throw;

            }
            catch (Exception ex)
            {
                log.WriteError(ex.Message);
            }
            finally
            {

            }
        }

        public override void Buy(Material material, int quantity)
        {
            try
            {
                LiquidMaterial liquidMaterial = material as LiquidMaterial;
                if (liquidMaterial == null) return;

                if (quantity <= 0)
                    throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
                liquidMaterial.Volume_m3 = liquidMaterial.Volume_m3 + quantity;
                Console.WriteLine("buy LiquidMaterial  quantity =" + quantity.ToString() + " with price " + liquidMaterial.Buyprice.ToString());

                log.WriteSucces("buy LiquidMaterial  quantity =" + quantity.ToString() + " with price " + liquidMaterial.Buyprice.ToString());

                if (Map != null)
                    Map.GenerateMaterialOperationEvent(material.Id, material.Name, "LiquidMaterial", MaterialActionsProcess.Operation.Buy, quantity);
            }
            catch (BuyQuatityLessOrEqualToZero ex)
            {
                log.WriteError(ex.Message + "\r\n" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                log.WriteError(ex.Message);
            }
            finally
            {

            }

        }
        public override void Buy(Material material,int quantity, double custombuyprice)
        {
            try
            {
                LiquidMaterial liquidMaterial = material as LiquidMaterial;
                if (liquidMaterial == null) return;

                if (quantity <= 0)
                    throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
                liquidMaterial.Volume_m3 = liquidMaterial.Volume_m3 + quantity;
                Console.WriteLine("buy LiquidMaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());

                log.WriteSucces("buy LiquidMaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());

                if (Map != null)
                    Map.GenerateMaterialOperationEvent(material.Id, material.Name, "LiquidMaterial", MaterialActionsProcess.Operation.Buy, quantity);
            }
            catch (BuyQuatityLessOrEqualToZero ex)
            {
                log.WriteError(ex.Message + "\r\n" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                log.WriteError(ex.Message);
            }
            finally
            {

            }
        }
    }
}
