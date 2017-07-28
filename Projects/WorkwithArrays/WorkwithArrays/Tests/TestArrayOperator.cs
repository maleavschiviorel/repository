using System;

namespace WorkwithArrays
{
    public class TestArrayOperator
    {
        public static ArrayOfInt EnterElements()
        {
            ArrayOfInt arr = new ArrayOfInt(ArrayOperator.EnterArray());
            Console.WriteLine("\r\nShow numbers of array!");
            ArrayOperator.ShowElements(arr.Arr);
            return arr;
        }
        public static ArrayOfInt DeleteEvenNumbers()
        {
            ////Deleted even  numbers of array!
            ArrayOfInt arr = EnterElements();
            ArrayOfInt arr1 = new ArrayOfInt(arr.MakeCopy());
            arr1 = new ArrayOfInt(ArrayOperator.deleteEvenNumbers(arr1.Arr));

            Console.WriteLine("\r\nDeleted even  numbers of array!");
            ArrayOperator.ShowElements(arr1.Arr);
            return arr1;
        }
        public static ArrayOfInt InsertNewElement()
        {
            //Insert new element after all elements beginning with the indicated digit. 
            string str;
            int n = 0;
            ArrayOfInt arr = EnterElements();
            Console.WriteLine("Insert new element after all elements beginning with the indicated digit. \r\nEnter digit that will be verigied!");
            char c = (char)Console.Read();
            Console.WriteLine("\r\nInsert the element!");
            str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("\r\nInsert a valid element!");
                str = Console.ReadLine();
            }


            ArrayOfInt arr2 = new ArrayOfInt(arr.MakeCopy());

            arr2 = new ArrayOfInt(ArrayOperator.InsertAfter(arr2.Arr, c, n));
            Console.WriteLine("\r\nResult array!");
            ArrayOperator.ShowElements(arr2.Arr);
            return arr2;
        }
        public static ArrayOfInt InsertNewElement1()
        {
            //Insert new element between all element pairs with different signs.  
            string str;
            int n = 0;
            ArrayOfInt arr = EnterElements();
            Console.WriteLine("\r\nInsert new element between all element pairs with different signs. !");
            Console.WriteLine("\r\nInsert the element!");
            str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("\r\nInsert a valid element!");
                str = Console.ReadLine();
            }
            ArrayOfInt arr3 = new ArrayOfInt(arr.MakeCopy());
            arr3 = new ArrayOfInt(ArrayOperator.InsertBetweenPairs(arr3.Arr, n));
            Console.WriteLine("\r\nResult array!");
            ArrayOperator.ShowElements(arr3.Arr);
            return arr3;
        }
        public static ArrayOfInt Compress()
        {
            //Compress array by deleting all zero-value elements.
            ArrayOfInt arr = EnterElements();
            ArrayOfInt arr4 = new ArrayOfInt(arr.MakeCopy());

            arr4 = new ArrayOfInt(ArrayOperator.CompressDeleteZeroValue(arr4.Arr));
            Console.WriteLine("\r\nResult array!");
            ArrayOperator.ShowElements(arr4.Arr);
            return arr4;
        }
    }

}

