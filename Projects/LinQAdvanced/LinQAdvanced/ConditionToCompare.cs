using System;
using System.Collections.Generic; 
namespace LinQAdvanced
{
    public class ConditionToCompare<U>:IEqualityComparer<U> where U : IComparable<U>, IEquatable<U>
    {
        private U _compareTo;

        public int SkipCount { get; private set; }
               
        public Func<U, bool> F1 { get; set; }

        public Func<U, int, bool> F2 { get; set; }

        public U CompareToObject
        {
            get { return _compareTo; }
        }
        public ConditionToCompare()
        {
        }
        public ConditionToCompare(U compareTo)
        {
            _compareTo = compareTo;
        }

        public ConditionToCompare(int count)
        {
            SkipCount = count;
        }

        private int CompareTo(U toCompare)
        {
            var comparationResult = _compareTo.CompareTo(toCompare);
            return comparationResult;
        }

        private bool Equal(U toCompare)
        {
            return _compareTo.Equals(toCompare);
        }

        public bool Equals(U x, U y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(U obj)
        {
            return obj.GetHashCode() ;
        }
    }
}
