using System;

namespace WorkwithArrays
{
    public class TestClass1
    {
        public static ArrOfInt EnterElements()
        {
            ArrOfInt arr = new ArrOfInt(Class1.EnterArray());
            Console.WriteLine("\r\nShow numbers of array!");
            Class1.ShowElements(arr.Arr);
            return arr;
        }
        public static ArrOfInt DeleteEvenNumbers()
        {
            ////Deleted even  numbers of array!
            ArrOfInt arr = EnterElements();
            ArrOfInt arr1 = new ArrOfInt(arr.MakeCopy());
            arr1 = new ArrOfInt(Class1.deleteEvenNumbers(arr1.Arr));

            Console.WriteLine("\r\nDeleted even  numbers of array!");
            Class1.ShowElements(arr1.Arr);
            return arr1;
        }
        public static ArrOfInt InsertNewElement()
        {
            //Insert new element after all elements beginning with the indicated digit. 
            string str;
            int n = 0;
            ArrOfInt arr = EnterElements();
            Console.WriteLine("Insert new element after all elements beginning with the indicated digit. \r\nEnter digit that will be verigied!");
            char c = (char)Console.Read();
            Console.WriteLine("\r\nInsert the element!");
            str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("\r\nInsert a valid element!");
                str = Console.ReadLine();
            }


            ArrOfInt arr2 = new ArrOfInt(arr.MakeCopy());

            arr2 = new ArrOfInt(Class1.InsertAfter(arr2.Arr, c, n));
            Console.WriteLine("\r\nResult array!");
            Class1.ShowElements(arr2.Arr);
            return arr2;
        }
        public static ArrOfInt InsertNewElement1()
        {
            //Insert new element between all element pairs with different signs.  
            string str;
            int n = 0;
            ArrOfInt arr = EnterElements();
            Console.WriteLine("\r\nInsert new element between all element pairs with different signs. !");
            Console.WriteLine("\r\nInsert the element!");
            str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("\r\nInsert a valid element!");
                str = Console.ReadLine();
            }
            ArrOfInt arr3 = new ArrOfInt(arr.MakeCopy());
            arr3 = new ArrOfInt(Class1.InsertBetweenPairs(arr3.Arr, n));
            Console.WriteLine("\r\nResult array!");
            Class1.ShowElements(arr3.Arr);
            return arr3;
        }
        public static ArrOfInt Compress()
        {
            //Compress array by deleting all zero-value elements.
            ArrOfInt arr = EnterElements();
            ArrOfInt arr4 = new ArrOfInt(arr.MakeCopy());

            arr4 = new ArrOfInt(Class1.CompressDeleteZeroValue(arr4.Arr));
            Console.WriteLine("\r\nResult array!");
            Class1.ShowElements(arr4.Arr);
            return arr4;
        }
    }

}

