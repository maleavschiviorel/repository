using System.Collections.Generic;
using System;
namespace MyListGeneric

{
    public class MyList<T> where T : class, IComparable   //,IEquatable<T>
    {
        /// <summary>
        /// length of array filled by items
        /// </summary>
        private int length = 0;
        private static int additemscount = 4;
        private T[] arr = new T[additemscount];
        public T[] Arr
        {
            get
            {

                T[] t = null;
                if (length > 0)
                    t = new T[length];
                else
                    t = new T[] { };

                for (int i = 0; i < length; i++)
                    t[i] = arr[i];
                return t;
            }
        }
        public MyList(T[] arr)
        {
            if (Length() < arr.Length)
                this.arr = new T[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                this.arr[i] = arr[i];

            length = arr.Length;
        }
        public MyList(MyList<T> t)
        {
            if (Length() < t.Length())
                this.arr = new T[t.Length()];

            for (int i = 0; i < t.Length(); i++)
                this.arr[i] = t[i];

            this.length = t.Length();
        }
        public MyList()
        {
            T[] arr = new T[additemscount];
            this.length = 0;
        }
        public void AssignToMyList(T[] arr)
        {
            if (Length() < arr.Length)
                this.arr = new T[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                this.arr[i] = arr[i];

            length = arr.Length;
        }

        public MyList<T> MakeCopy()
        {
            MyList<T> t = new MyList<T>(this);
            return t;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index <= Length() - 1)
            {
                for (int i = index; i < Length() - 1; i++)
                    arr[i] = arr[i + 1];

                length--;
            }
        }

        public void Add(T toadd)
        {
            this.AddAt(Length(), toadd);
        }
        public void AddAt(int index, T toadd)
        {

            if (arr.Length == length)
            {
                T[] t = new T[this.arr.Length + additemscount];

                for (int i = 0; i < length; i++)
                    t[i] = arr[i];
                arr = t;
            }

            T temp; T toassign = toadd;
            for (int i = index; i < Length(); i++)
            {
                temp = arr[i];
                arr[i] = toassign;
                toassign = temp;
            }
            arr[Length()] = toassign;
            length++;
        }

        public int Length()
        {
            if (arr == null)
                return 0;
            return length;
        }
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }

        }
    }
}
