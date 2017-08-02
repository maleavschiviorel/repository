using System;

namespace Magazin.Domain
{
    public class LiquidMaterial : Material
    {
        private double volume_m3 = 0;
        public double Volume_m3
        {
            get { return volume_m3; }

        }
        public override Entity Asign(Entity from)
        {
            base.Asign(from);
            if (from is LiquidMaterial)
            {
                volume_m3 = ((LiquidMaterial)from).volume_m3;
            }
            return this;
        }
        public LiquidMaterial(string Name, double buyprice) : base(Name, buyprice, buyprice * 5 * SellKoef)
        {
            Console.WriteLine(string.Format("Init LiquidMaterial with buyprice= {0} and sellprice={1}", buyprice, this.Sellprice));
        }
        public override void Sell(int quantity)
        {
            Console.WriteLine("sell LiquidMaterial quantity =" + quantity.ToString() + " with price " + Sellprice.ToString());
        }
        public override void Sell(int quantity, double? sellprice)
        {
            try
            {
                if (quantity > volume_m3)
                    throw new SellQuatityMoreThenInStock(String.Format("in stock is {0} quantity but is trying to sell {1} quantity of  {2}", volume_m3, quantity, Name));

                volume_m3 = volume_m3 - quantity;

                if (sellprice.HasValue)
                    maxsellprice = sellprice; ;

                Console.WriteLine("sell LiquidMaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());

                log.WriteSucces("sell LiquidMaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());

                if (Map != null)
                    Map.GenerateMaterialOperationEvent(Id, Name, "LiquidMaterial", MaterialActionsProcess.Operation.Sell , quantity);
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
       
        public override void Buy(int quantity)
        {
            try
            {
                if (quantity <= 0)
                    throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
                volume_m3 = volume_m3 + quantity;
                Console.WriteLine("buy LiquidMaterial  quantity =" + quantity.ToString() + " with price " + buyprice.ToString());



                log.WriteSucces("buy LiquidMaterial  quantity =" + quantity.ToString() + " with price " + buyprice.ToString());

                if (Map != null)
                    Map.GenerateMaterialOperationEvent(Id, Name, "LiquidMaterial", MaterialActionsProcess.Operation.Buy, quantity);
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
        public override void Buy(int quantity, double custombuyprice)
        {
            try
            {
                if (quantity <= 0)
                    throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
                volume_m3 = volume_m3 + quantity;
                Console.WriteLine("buy LiquidMaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());

                log.WriteSucces("buy LiquidMaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());


                if (Map != null)
                    Map.GenerateMaterialOperationEvent(Id, Name, "LiquidMaterial", MaterialActionsProcess.Operation.Buy, quantity);
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