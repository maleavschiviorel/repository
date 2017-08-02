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
            GenericRepository<Entity> gr = new GenericRepository<Entity>();
            MaterialActionsProcess.MateriaActionsProcessor materiaActionsProcessor = new MaterialActionsProcess.MateriaActionsProcessor();
            MaterialActionsProcess.MaterialActionFileWrite materialActionFileWriter = new MaterialActionsProcess.MaterialActionFileWrite(materiaActionsProcessor);
            Material.SetMaterialActionsProcessor(materiaActionsProcessor);

            var m3 = new SolidMaterial("sugar", 100);
            m3.Id = 3; 
            m3.Buy(1, 200);

            m3.Buy(2, 10);
            m3.Sell(2);

            System.Diagnostics.Debug.WriteLine("weght for {0} is {1}", m3.Name, m3.Weight);

            Console.WriteLine();

            SolidMaterial m2 = new SolidMaterial("sugar", 200);
            m2.Id = 2;
            m2.Buy(2, 300);
            m2.Buy(3, 150);
            m2.Sell(2);
            Console.WriteLine();

            materialActionFileWriter = null;
            //materialActionFileWriter.UnregisterOperationHandler(materiaActionsProcessor);
            GC.Collect(); 

            Material m1 = new LiquidMaterial("water", 100);
            m1.Id = 1; 
            m1.Buy(2, 90);
            m1.Buy(3, 80);
            m1.Buy(1);
            gr.Add(m3);
            gr.Add(m2);
            gr.Add(m1);
            Material r = new SolidMaterial("sugar2", 111);
            r.Id = 4;
            gr.Update(r);

            Console.ReadLine(); 
        }
    }
}
