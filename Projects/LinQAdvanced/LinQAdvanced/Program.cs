using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQAdvanced
{

    class Program
    {
        static void Main(string[] args)
        {
            TestLinQEngine tlinq = new TestLinQEngine();
            tlinq.Filter();

            Console.ReadLine();  
        }
    }
}
