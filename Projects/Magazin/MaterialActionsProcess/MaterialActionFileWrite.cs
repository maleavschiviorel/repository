using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;  

namespace MaterialActionsProcess
{
    public class MaterialActionFileWrite
    {
        private string path = System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ,"OperationsMade.txt");
        private System.IO.StreamWriter st;
        public MaterialActionFileWrite(MateriaActionsProcessor map)
        {
            st = new System.IO.StreamWriter(path, true);
            map.MaterialOperationEvent += MaterialOperationHandler;
           // System.Windows.WeakEventManager<MateriaActionsProcessor, MaterialActionArgs>.AddHandler(map, "MaterialOperationEvent", MaterialOperationHandler); 
        }

        protected virtual void MaterialOperationHandler(object sender, MaterialActionArgs e)
        {
            st.WriteLine("{0}--was made an operation of type '{1}' on material with id ={2}, material name '{3}' of type '{4}', quantity {5}", DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss fff"), e.MadeOperation.ToString(), e.Id, e.MaterialName,e.MateriaType ,e.Count);
            st.Flush();
        }
        public void UnregisterOperationHandler(MateriaActionsProcessor map)
        {
             map.MaterialOperationEvent -= MaterialOperationHandler;
            //System.Windows.WeakEventManager<MateriaActionsProcessor, MaterialActionArgs>.RemoveHandler(map, "MaterialOperationEvent", MaterialOperationHandler);
           
        }

         ~MaterialActionFileWrite()
        {
            Console.WriteLine("was destroyed");
        }

    }
}
