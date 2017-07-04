using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            solidmaterial m2 = new solidmaterial(200);
            m2.Buy(2, 300);
            m2.Buy(3, 150);
            m2.Sell(2);
            Console.WriteLine();
            
            material m1 = new liquidmaterial(100);
            m1.Buy(2, 90);
            m1.Buy(3, 80);



            Console.ReadLine();
        }
    }
}
