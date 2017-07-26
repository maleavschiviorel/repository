using Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Magazin
{
    class Program
    {
        static void Main(string[] args)
        {
            MaterialFactory materialFactory = MaterialFactory.GetMaterialFactory;
            GenericRepository<Entity> gr = GenericRepository<Entity>.Repository;
            MaterialActionsProcess.MateriaActionsProcessor materiaActionsProcessor = new MaterialActionsProcess.MateriaActionsProcessor();
            MaterialActionsProcess.MaterialActionFileWrite materialActionFileWriter = new MaterialActionsProcess.MaterialActionFileWrite(materiaActionsProcessor);
            MaterialOperator.SetMaterialActionsProcessor(materiaActionsProcessor);

            SolidMaterialOperator solidMaterialOperator = new SolidMaterialOperator();
            LiquidMaterialOperator liquidMaterialOperator = new LiquidMaterialOperator();

            var m3 = materialFactory.GetNewSolidMaterial( 3, "sugar", 100);

            solidMaterialOperator.Buy(m3, 1, 200);
            solidMaterialOperator.Buy(m3, 2, 10);
            solidMaterialOperator.Sell(m3, 2);

            if (m3 is SolidMaterial)
                System.Diagnostics.Debug.WriteLine("weght for {0} is {1}", m3.Name, ((SolidMaterial)m3).Weight);

            SolidMaterial m2 = materialFactory.GetNewSolidMaterial( 2, "sugar", 200);
            solidMaterialOperator.Buy(m2, 2, 300);
            solidMaterialOperator.Buy(m2, 3, 150);
            solidMaterialOperator.Sell(m2, 2);
            Console.WriteLine();

            materialActionFileWriter = null;
            //materialActionFileWriter.UnregisterOperationHandler(materiaActionsProcessor);
            GC.Collect();

            LiquidMaterial m1 = materialFactory.GetNewLiquidMaterial(1, "water", 100);
            liquidMaterialOperator.Buy(m1, 2, 90);
            liquidMaterialOperator.Buy(m1, 3, 80);
            liquidMaterialOperator.Buy(m1, 1);

            gr.Add(m3);
            gr.Add(m2);
            gr.Add(m1);
            SolidMaterial r = new SolidMaterial(2, "sugar2", 111);
            gr.Update(r);

            Console.ReadLine();
        }
    }
}
