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
            //tlinq.Filter();
            //tlinq.Take();
            //tlinq.Skip();
            //tlinq.TakeWhile();
            //tlinq.SkipWhile();
            //tlinq.Distict();
            //tlinq.Join();
            //tlinq.GroupJoin ();
            //tlinq.Zip();
            // tlinq.OrderBy();
            //tlinq.ThenBy();
            //tlinq.OrderByDescending();
            //tlinq.ThenByDescending();
            tlinq.Reverse();  
            Console.ReadLine();
        }
    }
}
