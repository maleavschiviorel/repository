using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithArrays
{
    class Program
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

        public class MyMatrix<T>
        {
            private MyList<MyList<T>> arr;
            public MyList<MyList<T>> Arr { get { return arr; } }
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
        public class ArrOfInt : MyList<int>
        {
            public ArrOfInt(int[] arr) : base(arr)
            { }
            public ArrOfInt() : base()
            { }
            public int IndexOf(int tofind)
            {
                for (int i = 0; i < this.Arr.Length; i++)
                    if (this.Arr[i] == tofind)
                        return i;
                return -1;
            }
            public int IndexOf(int fromindex, int tofind)
            {
                for (int i = fromindex; i < this.Arr.Length; i++)
                    if (this.Arr[i] == tofind)
                        return i;
                return -1;
            }
        }
        #region 1.	In one-dimensional array of integers perform the following operations: 
        public class Class1
        {
            /// <summary>
            /// Delete all even numbers. 
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static int[] deleteEvenNumbers(int[] arr)
            {
                MyList<int> arr1 = new MyList<int>(arr);
                for (int i = 0; i < arr1.Length(); i++)
                {
                    if (arr1[i] % 2 == 0)
                    {
                        arr1.RemoveAt(i);
                        i--;
                    }
                }
                return arr1.Arr;
            }
            /// <summary>
            /// Insert new element after all elements beginning with the indicated digit. 
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="digit"></param>
            /// <param name="t"></param>
            /// <returns></returns>
            public static int[] InsertAfter(int[] arr, char digit, int t)
            {
                MyList<int> arr1 = new MyList<int>(arr);

                for (int i = 0; i < arr1.Length(); i++)
                {
                    if (arr1[i].ToString()[0] == digit)
                    {
                        arr1.AddAt(i + 1, t);
                        i++;
                    }
                }
                return arr1.Arr;
            }

            /// <summary>
            /// Delete from array all repeating elements except of their first occurrence. 
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static int[] DeleteExceptFirst(int[] arr)
            {
                ArrOfInt arr1 = new ArrOfInt(arr);
                for (int i = 0; i < arr1.Length(); i++)
                {
                    if (arr1.IndexOf(i + 1, arr1[i]) != -1)
                        arr1.RemoveAt(i + 1);
                }
                return arr1.Arr;
            }

            /// <summary>
            /// Insert new element between all element pairs with different signs. 
            /// </summary>
            /// <returns></returns>
            public static int[] InsertBetweenPairs(int[] arr, int toadd)
            {
                ArrOfInt arr1 = new ArrOfInt(arr);
                for (int i = 0; i < arr1.Length() - 1; i++)
                {
                    if (arr1[i] < 0 && arr1[i + 1] == 0 || arr1[i] == 0 && arr1[i + 1] < 0 || arr1[i] != 0 && arr1[i + 1] != 0 && arr1[i] / (Math.Abs(arr1[i])) * arr1[i + 1] / (Math.Abs(arr1[i + 1])) < 0)
                    {
                        arr1.AddAt(i + 1, toadd);
                        i++;
                    }
                }
                return arr1.Arr;
            }

            /// <summary>
            /// Compress array by deleting all zero-value elements. 
            /// </summary>
            /// <returns></returns>
            public static int[] CompressDeleteZeroValue(int[] arr)
            {
                ArrOfInt arr1 = new ArrOfInt(arr);
                for (int i = 0; i < arr1.Length(); i++)
                {
                    if (arr1[i] == 0)
                    {
                        arr1.RemoveAt(i);
                        i--;
                    }
                }
                return arr1.Arr;
            }

            public static void ShowElements(int[] arr)
            {
                ArrOfInt arr1 = new ArrOfInt(arr);
                for (int i = 0; i < arr1.Length(); i++)
                {
                    Console.Write(arr[i]);
                    if (i < arr1.Length() - 1)
                        Console.Write(" ~ ");
                    else
                        Console.WriteLine("");
                }
            }
        }
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers of array, first occurance of literall will finish entering elements!");
            ArrOfInt arr = new ArrOfInt();
            string str = Console.ReadLine();
            int n = 0;
            while (int.TryParse(str, out n))
            {
                arr.AddAt(arr.Length(), n);
                str = Console.ReadLine();
            }

            Console.WriteLine("\r\nShow numbers of array!");
            Class1.ShowElements(arr.Arr);

            ////Deleted even  numbers of array!
            //ArrOfInt arr1 = new ArrOfInt(arr.MakeCopy());
            //arr1= new ArrOfInt(  Class1.deleteEvenNumbers(arr1.Arr));

            //Console.WriteLine("\r\nDeleted even  numbers of array!");
            //Class1.ShowElements(arr1.Arr);
            //----------------------------------------------------------------------------
            ////Insert new element after all elements beginning with the indicated digit. 
            //Console.WriteLine("Insert new element after all elements beginning with the indicated digit. \r\nEnter digit that will be verigied!");
            //char c=(char)Console.Read();
            //Console.WriteLine("\r\nInsert the element!");
            //str = Console.ReadLine();
            //while (!int.TryParse(str, out n))
            //{
            //    Console.WriteLine("\r\nInsert a valid element!");
            //    str = Console.ReadLine();
            //}


            //ArrOfInt arr2 = new ArrOfInt(arr.MakeCopy());

            //arr2 = new ArrOfInt(Class1.InsertAfter(arr2.Arr,c,n));
            //Console.WriteLine("\r\nResult array!");
            //Class1.ShowElements(arr2.Arr);

            ////----------------------------------------------------------------------------
            ////Insert new element between all element pairs with different signs.  
            //Console.WriteLine("\r\nInsert new element between all element pairs with different signs. !");
            //Console.WriteLine("\r\nInsert the element!");
            //str = Console.ReadLine();
            //while (!int.TryParse(str, out n))
            //{
            //    Console.WriteLine("\r\nInsert a valid element!");
            //    str = Console.ReadLine();
            //}


            //ArrOfInt arr3 = new ArrOfInt(arr.MakeCopy());

            //arr3 = new ArrOfInt(Class1.InsertBetweenPairs(arr3.Arr, n));
            //Console.WriteLine("\r\nResult array!");
            //Class1.ShowElements(arr3.Arr);


            //----------------------------------------------------------------------------
            //Compress array by deleting all zero-value elements.
            ArrOfInt arr4 = new ArrOfInt(arr.MakeCopy());

            arr4 = new ArrOfInt(Class1.CompressDeleteZeroValue(arr4.Arr));
            Console.WriteLine("\r\nResult array!");
            Class1.ShowElements(arr4.Arr);
            Console.ReadLine();

        }

    }
}
