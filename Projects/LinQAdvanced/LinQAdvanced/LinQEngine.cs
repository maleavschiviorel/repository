using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQAdvanced
{
    public class LinQEngine<T, U> where T : class where U : IEquatable<U>, IComparable<U>, T
    {
        private static LinQEngine<T, U> linqEngine = null;

        private static object ob = new object();

        protected LinQEngine()
        { }

        public LinQEngine<T, U> LinqEngine
        {
            get { return GetLinqEngine(); }
        }

        public static LinQEngine<T, U> GetLinqEngine()
        {
            if (linqEngine == null)
            {
                lock (ob)
                {
                    if (linqEngine == null)
                        linqEngine = new LinQEngine<T, U>();
                }
            }
            return linqEngine;
        }

        public IEnumerable<U> Filter(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            IEnumerable<U> q = null;
            //Func<U, bool> f = (x) => { return x.Equals(co.compareToObject); };
            //Func<U, bool> f = delegate (U x) { return x.Equals(co.compareToObject); };
            if (co.F1 != null)
                q = toprocess.Where(co.F1);
            else if (co.F2 != null)
                q = toprocess.Where(co.F2);
            else
                q = toprocess.Where(x => x.Equals(co.CompareToObject));
            return q;
        }


        public IEnumerable<U> Take(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            var result = toprocess.Take(co.SkipCount);
            return result;
        }

        public IEnumerable<U> Skip(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            var result = toprocess.Skip(co.SkipCount); ;
            return result;
        }
        public IEnumerable<U> TakeWhile(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            IEnumerable<U> q = null;
            if (co.F1 != null)
                q = toprocess.TakeWhile(co.F1);
            else if (co.F2 != null)
                q = toprocess.TakeWhile(co.F2);
            else
                q = toprocess.TakeWhile(x => x.Equals(co.CompareToObject));
            return q;
        }
        public IEnumerable<U> SkipWhile(IEnumerable<U> toprocess, ConditionToCompare<U> co)
        {
            IEnumerable<U> q = null;
            if (co.F1 != null)
                q = toprocess.SkipWhile(co.F1);
            else if (co.F2 != null)
                q = toprocess.SkipWhile(co.F2);
            else
                q = toprocess.SkipWhile(x => x.Equals(co.CompareToObject));
            return q;
        }
        public IEnumerable<U> Distinct(IEnumerable<U> toprocess, ConditionToCompare<U> co = null)
        {
            IEnumerable<U> q = null;
            q = toprocess.Distinct();
            return q;
        }
        public IEnumerable<U> OrderBy(IEnumerable<U> toprocess, ConditionToCompare<U> co = null)
        {
            IEnumerable<U> q = null;
            q = toprocess.OrderBy(x => x);
            return q;
        }
        public IEnumerable<U> OrderByDescending(IEnumerable<U> toprocess, ConditionToCompare<U> co = null)
        {
            IEnumerable<U> q = null;
            q = toprocess.OrderByDescending(x => x);
            return q;
        }
        public IEnumerable<U> Reverse(IEnumerable<U> toprocess, ConditionToCompare<U> co = null)
        {
            var result = toprocess.Reverse();
            return result;
        }
        public IEnumerable<U> Concat(IEnumerable<U> toprocess1, IEnumerable<U> toprocess2, ConditionToCompare<U> co = null)
        {
            var result = toprocess1.Concat(toprocess2);
            return result;
        }
        public IEnumerable<U> Union(IEnumerable<U> toprocess1, IEnumerable<U> toprocess2, ConditionToCompare<U> co = null)
        {
            var result = co != null ? toprocess1.Union(toprocess2, co) : toprocess1.Union(toprocess2);
            return result;
        }
        public IEnumerable<U> Intersect(IEnumerable<U> toprocess1, IEnumerable<U> toprocess2, ConditionToCompare<U> co = null)
        {
            var result = co != null ? toprocess1.Intersect(toprocess2, co) : toprocess1.Intersect(toprocess2);
            return result;
        }
        public IEnumerable<U> Except(IEnumerable<U> toprocess1, IEnumerable<U> toprocess2, ConditionToCompare<U> co = null)
        {
            var result = co != null ? toprocess1.Except(toprocess2, co) : toprocess1.Except(toprocess2);
            return result;
        }
    }
}
