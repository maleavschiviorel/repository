//#define CompileCondition1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class liquidmaterial : material
    {
        private double volume_m3 = 0;
        public double Volume_m3
        {
            get { return volume_m3; }

        }


        public liquidmaterial(string Name, double buyprice) : base(Name, buyprice, buyprice * 5 * SellKoef)
        {
            Console.WriteLine(string.Format("Init liquidmaterial with buyprice= {0} and sellprice={1}", buyprice, this.Sellprice));
        }
        public override void Sell(int quantity)
        {
            Console.WriteLine("sell liquidmaterial quantity =" + quantity.ToString() + " with price " + Sellprice.ToString());
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

                Console.WriteLine("sell liquidmaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());

                log.WriteSucces("sell liquidmaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());
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

        //#if   CompileCondition1

       
        public override void Buy(int quantity)
        {
            try
            {
                if (quantity <= 0)
                    throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
                volume_m3 = volume_m3 + quantity;
                Console.WriteLine("buy liquidmaterial  quantity =" + quantity.ToString() + " with price " + buyprice.ToString());

                log.WriteSucces("buy liquidmaterial  quantity =" + quantity.ToString() + " with price " + buyprice.ToString());
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
//#endif 
        public override void Buy(int quantity, double custombuyprice)
        {
            try
            {
                if (quantity <= 0)
                    throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
                volume_m3 = volume_m3 + quantity;
                Console.WriteLine("buy liquidmaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());

                log.WriteSucces("buy liquidmaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());
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