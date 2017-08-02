using System.Collections.Generic;
using System.Linq;

namespace LinQAdvanced
{
    public static class LinqEngineForString
    {
        public static IEnumerable<string> FilterExt(this IEnumerable<string> toprocess, ConditionToCompare<string> co)
        {
            IEnumerable<string> q = null;
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
    }
}
