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
        public IEnumerable<U> Take(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            IEnumerable<U> q = null;
            q = toprocess.Take(co.Skip_Count); ;
            return q;
        }
        public IEnumerable<U> Skip(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            IEnumerable<U> q = null;
            q = toprocess.Skip(co.Skip_Count); ;
            return q;
        }
        public IEnumerable<U> TakeWhile(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            IEnumerable<U> q = null;
            if (co.f1 != null)
                q = toprocess.TakeWhile(co.f1);
            else if (co.f2 != null)
                q = toprocess.TakeWhile(co.f2);
            else
                q = toprocess.TakeWhile(x => x.Equals(co.compareToObject));
            return q;
        }
        public IEnumerable<U> SkipWhile(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            IEnumerable<U> q = null;
            if (co.f1 != null)
                q = toprocess.SkipWhile(co.f1);
            else if (co.f2 != null)
                q = toprocess.SkipWhile(co.f2);
            else
                q = toprocess.SkipWhile(x => x.Equals(co.compareToObject));
            return q;
        }
        public IEnumerable<U> Distinct(IEnumerable<U> toprocess, ConditionToCompare<U> co=null)
        {
            IEnumerable<U> q = null;
            q = toprocess.Distinct(); 
            return q;
        }
       
    }
}
