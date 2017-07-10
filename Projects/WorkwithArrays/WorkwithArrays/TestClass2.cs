using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithArrays
{
    public class TestClass2
    {
        public static MatrixOfInt EnterElements()
        {
            MatrixOfInt mtx = new MatrixOfInt(Class2.EnterMatrix());
            Console.WriteLine("\r\nShow numbers of matrix!");
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt InsertNewLine()
        {
            //Insert new line after line containing the first occurrence of the minimal element. 
            MatrixOfInt mtx = new MatrixOfInt(Class2.EnterMatrix());

            Console.WriteLine("Insert new line after line containing the first occurrence of the minimal element. ");
            mtx = new MatrixOfInt(Class2.InsertNewLine(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt InsertNewColumn()
        {
            //Insert new column before all columns containing the indicated number.  
            MatrixOfInt mtx = new MatrixOfInt(Class2.EnterMatrix());

            Console.WriteLine("Insert new column before all columns containing the indicated number.");
            Console.WriteLine("\r\nInsert the number!");
            int n = 0;
            string str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("\r\nInsert a valid number!");
                str = Console.ReadLine();
            }

            mtx = new MatrixOfInt(Class2.InsertNewColumn(mtx.GetAsArrayOfArrays(), n));

            Console.WriteLine("\r\nResult matrix is!");
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt DeleteLinesWithEven()
        {
            //Delete all lines, containing only even number elements. 
            MatrixOfInt mtx = new MatrixOfInt(Class2.EnterMatrix());

            Console.WriteLine("Delete all lines, containing only even number elements. ");
            mtx = new MatrixOfInt(Class2.DeleteLinesWithEven(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt DeleteColumnsPositive()
        {
            //Delete all columns, containing only positive elements. 
            MatrixOfInt mtx = new MatrixOfInt(Class2.EnterMatrix());

            Class2.ShowElements(mtx.GetAsArrayOfArrays());

            Console.WriteLine("Delete all columns, containing only positive elements. ");
            mtx = new MatrixOfInt(Class2.DeleteColumnsPositive(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt Compress()
        {
            //Compress array by deleting all only zero-value lines and columns.
            MatrixOfInt mtx = new MatrixOfInt(Class2.EnterMatrix());
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            Console.WriteLine("Compress array by deleting all only zero-value lines and columns.");
            mtx = new MatrixOfInt(Class2.Compress(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt DeleteLinesColumnsEqual()
        {
            //Delete from array the k-th line and the j-th column if their values coincide.
            MatrixOfInt mtx = new MatrixOfInt(Class2.EnterMatrix());
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            Console.WriteLine("Delete from array the k-th line and the j-th column if their values coincide.");
            mtx = new MatrixOfInt(Class2.DeleteLinesColumnsEqual(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            Class2.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
    }
}
