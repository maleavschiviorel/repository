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
            //tlinq.FilterWithDelegate();
            //tlinq.FilterWithAnonymousFunction();
            //tlinq.FilterWithAnonymousFunction1();
            //tlinq.FilterWithLamdaExpression();
            //tlinq.FilterWithLamdaExpression1();
            //tlinq.FilterWithQuery();
            //tlinq.FilterWithExtention();

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
            //tlinq.Reverse();
            //tlinq.GroupBy();
            //tlinq.Concat();  

            //tlinq.Union ();
            //tlinq.Intersect();
            //tlinq.Except();
            //tlinq.OfType();
            //tlinq.Cast();
            //tlinq.ToArrayTolist();
            //tlinq.ToDictionary();
            //tlinq.ToLookUp();
            //tlinq.AsEnumerable();
            //tlinq.AsQueryable();
            //tlinq.FirstFirstOrDefault();
            // tlinq.LastLastOrDefault ();
            // tlinq.SigleSingleOrDefault();
            // tlinq.ElementAtElementAtOrDefault();
            tlinq.DefaultIfEmpty();  
            Console.ReadLine();
        }
    }
}
