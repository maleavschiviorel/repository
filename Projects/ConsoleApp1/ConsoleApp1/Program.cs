using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyListGeneric;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MaterialEqualityComparer mec = new MaterialEqualityComparer();
            MaterialPriaorityComparer mpc = new MaterialPriaorityComparer(); 
            solidmaterial m3 = new solidmaterial("sugar",100);
            m3.Buy(1, 200);
            m3.Buy(2, 10);
            m3.Sell(2);
            Console.WriteLine();

            solidmaterial m2 = new solidmaterial("sugar", 200);
            m2.Buy(2, 300);
            m2.Buy(3, 150);
            m2.Sell(2);
            Console.WriteLine();

            material m1 = new liquidmaterial("water",100);
            m1.Buy(2, 90);
            m1.Buy(3, 80);

            Dictionary<material, string> d = new Dictionary<material, string>(mec);
            d.Add(m2, "sugar quality 1");
            d.Add(m1, "water Distilled");

            //d.Add(m3, "sugar quality 2");
            MyList<material> mylist = new MyList<material>();
            List<material> list = new List<material>();
            list.Add(m2);
            list.Add(m1);
            list.Add(m3);
            list.Sort(mpc);


            Console.ReadLine();
        }
    }
}
