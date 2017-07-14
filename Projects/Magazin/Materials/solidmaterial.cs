using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Materials
{
    public class SolidMaterial : Material
    {
        static public double addCoef1 = 1;

        private double weight = 0;

        public double Weight
        {
            get { return weight; }
        }
        static SolidMaterial()
        {
            // SolidMaterial.addCoef = 3.5;
            Console.WriteLine("Init SolidMaterial static constractor ");
        }
        public SolidMaterial(string Name, double buyprice) : base(Name, buyprice, buyprice * SolidMaterial.addCoef)
        {
            Console.WriteLine(string.Format("Init SolidMaterial with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }

        public SolidMaterial(string Name, double buyprice, double sellprice) : base(Name, buyprice, sellprice)
        {
            Console.WriteLine(string.Format("Init SolidMaterial with buyprice= {0} and sellprice={1}", buyprice, this.sellprice));
        }
        public override Entity Asign(Entity from)
        {
            base.Asign(from);
            if (from is SolidMaterial)
            {
                weight = ((SolidMaterial)from).weight;
            }
            return this;
        }
        public override void Buy(int quantity)
        {
            if (quantity <= 0)
                throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
            weight = weight + quantity;

            Console.WriteLine("buy SolidMaterial  quantity =" + quantity.ToString() + " with price " + buyprice.ToString());


            if (Map != null)
                Map.GenerateMaterialOperationEvent(Id, Name, "SolidMaterial", MaterialActionsProcess.Operation.Buy, quantity);
        }
        public override void Buy(int quantity, double custombuyprice)
        {
            if (quantity <= 0)
                throw new BuyQuatityLessOrEqualToZero(String.Format("Could not buy negative quantity"));
            weight  = weight + quantity;

            if (buyprice >= custombuyprice)
                Console.WriteLine("buy SolidMaterial quantity =" + quantity.ToString() + " with price " + custombuyprice.ToString());
            else
                //throw new Exception("custom buy price is more then default buy price");
                Console.WriteLine("custom buy price is more then default buy price");


            if (Map != null)
                Map.GenerateMaterialOperationEvent(Id, Name, "SolidMaterial", MaterialActionsProcess.Operation.Buy, quantity);
        }
        public override void Sell(int quantity, double? selprice)
        {
            if (quantity > weight)
                throw new SellQuatityMoreThenInStock(String.Format("in stock is {0} quantity but is trying to sell {1} quantity of  {2}", weight, quantity, Name));

            weight = weight - quantity;

            maxsellprice = selprice ?? this.sellprice;
            Console.WriteLine("sell SolidMaterial quantity =" + quantity.ToString() + " with price " + sellprice.ToString());


            if (Map != null)
                Map.GenerateMaterialOperationEvent(Id, Name, "SolidMaterial",  MaterialActionsProcess.Operation.Sell , quantity);
        }
      
        public override void Sell(int quantity)
        {
            Sell(quantity, null);
        }
    }

}