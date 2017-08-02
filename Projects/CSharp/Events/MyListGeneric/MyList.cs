//#define useclass
#define IEquatable
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyListGeneric

{
    public class MyListEnumerable<T> : IEnumerable<T>
    {
        private MyList<T> mylist;
        public MyListEnumerable(MyList<T> mylist)
        {
            this.mylist = mylist;
        }

 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (((IEnumerable<T>)this).GetEnumerator());
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new MyListEnumerator<T>(mylist);
        }


    }
    public class MyListEnumerator<T> : IEnumerator<T>
    {
        private MyList<T> _sr;
        private int index = 0;
        public MyListEnumerator(MyList<T> mylist)
        {
            this._sr = mylist;
        }

        private T _current;
        // Implement the IEnumerator(T).Current publicly, but implement 
        // IEnumerator.Current, which is also required, privately.
        T IEnumerator<T>.Current
        {

            get
            {
                if (_sr == null || _current == null)
                {
                    return default(T);
                }

                return _current;
            }
        }

        private object Current1
        {

            get { return ((IEnumerator<T>)this).Current; }
        }

        object IEnumerator.Current
        {
            get { return Current1; }
        }


        // Implement MoveNext and Reset, which are required by IEnumerator.
        public bool MoveNext()
        {
           
            if (index < _sr.Length())
            {
                _current = _sr[index];
                index++;
                return true;
            }
            else
            {
                _current = default(T);
                index++;
                return false;
            }
           
        }

        public void Reset()
        {
            index = 0;
            _current = default(T);
        }

        // Implement IDisposable, which is also implemented by IEnumerator(T).
        private bool disposedValue = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose of managed resources.
                }
                _current = default(T);
            }

            this.disposedValue = true;
        }

        ~MyListEnumerator()
        {
            Dispose(false);
        }
    }


    public class MyList<T>
#if useclass        
        where T : class, IComparable
#if IEquatable
        , IEquatable<T>
#endif
#endif
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
        public IEnumerable<T> GetAsIEnumerable
        {
            get
            {
                var r= new MyListEnumerable<T>(this);
                return r;
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

        public MyList<T> MakeCopy()
        {
            MyList<T> t = new MyList<T>(this);
            return t;
        }

        public void AssignToMyList(T[] arr)
        {
            if (this.arr.Length < arr.Length)
                this.arr = new T[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                this.arr[i] = arr[i];

            length = arr.Length;
        }

        public int IndexOf(T tofind)
        {
            for (int i = 0; i < length; i++)
            {
                if (((IEquatable<T>)arr[i]).Equals(tofind))
                    //if (arr[i].Equals(tofind))
                    return i;
            }

            return -1;
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
        public void RemoveAt(int index)
        {
            if (index >= 0 && index <= Length() - 1)
            {
                for (int i = index; i < Length() - 1; i++)
                    arr[i] = arr[i + 1];

                length--;
            }
        }
        public void Remove(T toremove)
        {
            int i = this.IndexOf(toremove);
            if (i >= -1)
                this.RemoveAt(i);
        }
        public int Length()
        {
            if (arr == null)
                return 0;
            return length;
        }

        internal void Dispose()
        {
            arr = null;
        }

        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }

        }
        public void SaveChanges()
        { }
    }
}
