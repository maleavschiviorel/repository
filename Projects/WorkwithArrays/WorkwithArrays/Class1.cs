using System;
using MyListGeneric;

namespace WorkwithArrays
{
    public class Class1
    {
        /// <summary>
        /// Enter elements in array
        /// </summary>
        /// <returns></returns>
        public static int[] EnterArray()
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
            return arr.Arr;
        }
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
}



