namespace WorkwithArrays
{
    public class MyList<T>
    {
        private T[] arr;
        public T[] Arr { get { return arr; } }
        public MyList(T[] arr)
        {
            this.arr = arr;
        }
        public MyList(MyList<T> t) : this(t.Arr)
        {
        }
        public MyList()
        {
            T[] arr = new T[] { };
        }
        public void AssignToMyList(T[] arr)
        {
            this.arr = arr;
        }
        public T[] MakeCopy()
        {
            T[] t = null;
            if (Length() == 0)
                t = new T[] { };
            else
            {
                t = new T[Length()];
                for (int i = 0; i < Length(); i++)
                    t[i] = arr[i];
            }
            return t;
        }
        public T[] RemoveAt(int index)
        {
            T[] t = new T[Length() - 1];
            for (int i = 0; i < Length(); i++)
                if (i < index)
                    t[i] = arr[i];
                else if (i > index)
                    t[i - 1] = arr[i];
            arr = t;
            return t;
        }
        public T[] AddAt(int index, T toadd)
        {
            T[] t = new T[Length() + 1];
            if (Length() == 0)
                t[0] = toadd;
            else
            {
                for (int i = 0; i < Length(); i++)
                    if (i < index)
                        t[i] = arr[i];
                    else if (i == index)
                    {
                        t[i] = toadd;
                        t[i + 1] = arr[i];
                    }
                    else if (i > index)
                        t[i + 1] = arr[i];

                if (index >= Length())
                    t[t.Length - 1] = toadd;
            }
            arr = t;

            return t;
        }

        public int Length()
        {
            if (arr == null)
                return 0;
            return arr.Length;
        }
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }

        }
    }

}
