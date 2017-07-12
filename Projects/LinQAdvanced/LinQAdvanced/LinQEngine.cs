using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQAdvanced
{
    public class LinQEngine<T, U> where T : class where U : IEquatable<U>, IComparable<U>, T
    {
        private static LinQEngine<T, U> linqEngine = null;
        private LinQEngine()
        { }
        public LinQEngine<T, U> LinqEngine
        {
            get { return GetLinqEngine(); }
        }
        public static LinQEngine<T, U> GetLinqEngine()
        {
            if (linqEngine == null)
            {
                linqEngine = new LinQEngine<T, U>();
            }
            return linqEngine;
        }
        public IEnumerable<U> Filter(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            IEnumerable<U> q = null;
            //Func<U, bool> f = (x) => { return x.Equals(co.compareToObject); };
            //Func<U, bool> f = delegate (U x) { return x.Equals(co.compareToObject); };
            if (co.f1 != null)
                q = toprocess.Where(co.f1);
            else if (co.f2 != null)
                q = toprocess.Where(co.f2);
            else
                q = toprocess.Where(x => x.Equals(co.compareToObject));
            return q;
        }


    }
}
