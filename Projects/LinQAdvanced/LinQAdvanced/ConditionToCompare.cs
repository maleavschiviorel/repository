using System;

namespace LinQAdvanced
{
    public class ConditionToCompare<U> where U : IComparable<U>, IEquatable<U>
    {
        public int Skip_Count = 0;

        private U compareTo;

        public Func<U, bool> f1 = null;
        public Func<U, int, bool> f2 = null;
        public U compareToObject
        {
            get { return compareTo; }
        }
        public ConditionToCompare(U compareTo)
        {
            this.compareTo = compareTo;
        }
        public ConditionToCompare(int Count)
        {
            this.Skip_Count = Count;
        }
        int CompareTo(U tocompare)
        {
            return compareTo.CompareTo(tocompare);
        }

        bool Equal(U tocompare)
        {
            return compareTo.Equals(tocompare);
        }
    }
}
