using System;
using MyListGeneric;

namespace WorkwithArrays
{
    public class MyMatrix<T>
    {
        private MyList<MyList<T>> arr;
        public MyList<MyList<T>> Arr { get { return arr; } }
        public T[][] GetAsArrayOfArrays()
        {
            T[][] t = null;
            if (arr.Length() == 0)
                t = new T[][] { };
            else
                t = new T[arr.Length()][];
            for (int i = 0; i < arr.Length(); i++)
            {
                t[i] = new T[arr[0].Length()];
                for (int j = 0; j < arr[i].Length(); j++)
                {
                    t[i][j] = arr[i][j];
                }
            }
            return t;
        }
        public MyMatrix(T[][] arr)
        {
            MyList<MyList<T>> t = new MyList<MyList<T>>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                t.AddAt(t.Length(), new MyList<T>(arr[i]));
            }
            this.arr = t;
        }
        public MyMatrix(MyList<MyList<T>> arr)
        {
            MyList<MyList<T>> t = new MyList<MyList<T>>();
            for (int i = 0; i < arr.Length(); i++)
            {
                t.AddAt(t.Length(), new MyList<T>(arr[i]));
            }
            this.arr = t;
        }
        public MyMatrix()
        {
            arr = new MyList<MyList<T>>();
        }
        public void AssignToMyList(MyList<MyList<T>> arr)
        {
            this.arr = arr;
        }
        public void AssignToMyList(T[][] arr)
        {
            this.arr = new MyMatrix<T>(arr).Arr;
        }

        public MyList<MyList<T>> MakeCopy()
        {
            MyList<MyList<T>> t = new MyList<MyList<T>>(this.Arr);
            return t;
        }
        public MyList<MyList<T>> RemoveAt(int i, int j)
        {
            MyList<MyList<T>> t = this.Arr;
            t[i].RemoveAt(j);
            return t;
        }
        public MyList<MyList<T>> RemoveColumn(int j)
        {
            MyList<MyList<T>> t = this.Arr;
            for (int i = 0; i < t.Length(); i++)
            {
                t.Arr[i].RemoveAt(j);
            }
            return t;
        }


        public MyList<MyList<T>> RemoveLine(int i)
        {
            MyList<MyList<T>> t = this.Arr;
            t.RemoveAt(i);
            return t;
        }

        public MyList<MyList<T>> AddColumn(int j, T n)
        {
            MyList<MyList<T>> t = this.Arr;
            for (int i = 0; i < t.Length(); i++)
            {
                t.Arr[i].AddAt(j, n);
            }
            return t;
        }


        public MyList<MyList<T>> AddLine(int i, T n)
        {
            MyList<MyList<T>> t = this.Arr;
            MyList<T> line = new MyList<T>();
            for (int j = 0; j < t[0].Length(); j++)
            {
                line.AddAt(line.Length(), n);
            }
            t.AddAt(i, line);
            return t;
        }
        public MyList<MyList<T>> AddAt(int i, int j, T toadd)
        {
            MyList<MyList<T>> t = this.Arr;
            t[i].AddAt(j, toadd);
            return t;
        }

        public int Length(int dimention)
        {
            MyList<MyList<T>> t = this.Arr;
            if (dimention == 0)
                return t.Length();
            else if (dimention == 1)
            {
                if (t.Length() == 0)
                    return 0;
                else
                    return t[0].Length();
            }
            else
                throw new Exception("Dimension out of range");

        }
        public T this[int i, int j]
        {

            get
            {
                MyList<MyList<T>> t = this.Arr;
                return t[i][j];
            }
            set
            {
                MyList<MyList<T>> t = this.Arr;
                t[i][j] = value;
            }

        }
    }


}
