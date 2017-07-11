//#define CompileCondition 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyListGeneric;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Log log = Log.Log.GetTheLog();
            try
            {
                log.WriteSucces("Programm was started!");
                MaterialEqualityComparer mec = new MaterialEqualityComparer();
                MaterialPriaorityComparer mpc = new MaterialPriaorityComparer();
                var m3 = new solidmaterial("sugar", 100);
                m3.Buy(1, 200);

                m3.Buy(2, 10);
                m3.Sell(2);
                System.Diagnostics.Debug.WriteLine("weght for {0} is {1}", m3.Name, m3.Weight);
                Debugger.Break();
                //EventInstance ei = new EventInstance(1, 0);
                // System.Diagnostics.EventLog.WriteEvent("Console1", ei);
                //Process p=System.Diagnostics.Process.GetCurrentProcess();   
                Console.WriteLine();

                solidmaterial m2 = new solidmaterial("sugar", 200);
                m2.Buy(2, 300);
                m2.Buy(3, 150);
                m2.Sell(2);
                Console.WriteLine();

                material m1 = new liquidmaterial("water", 100);
                m1.Buy(2, 90);
                m1.Buy(3, 80);
                m1.Buy(1);
                System.Diagnostics.Debug.WriteLine("Volume_m3 for {0} is {1}", m1.Name, ((liquidmaterial)m1).Volume_m3);
                //m1.Sell(10, 80);



                Dictionary<material, string> d = new Dictionary<material, string>(mec);
                d.Add(m2, "sugar quality 1");
                d.Add(m1, "water Distilled");

                //d.Add(m3, "sugar quality 2");

               // MyList<int> mylist1 = new MyList<int>();
               // mylist1.AddAt(0,1);
               // mylist1.AddAt(-1, 1);


                 //MyList<material> list = new MyList<material>();
                List<material> list = new List<material>();
                list.Add(m2);
                list.Add(m1);
                list.Add(m3);
                //list.Sort(mpc);
                list.Sort();  

                Console.ReadLine();

                log.WriteSucces("Programm was ended with succes");
            }
            catch (Exception ex)
            {
                log.WriteError("Programm was ended with error");
            }
            finally
            {


            }
        }
    }
}
