using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithArrays
{
    public class TestMatrixOperator
    {
        public static MatrixOfInt EnterElements()
        {
            MatrixOfInt mtx = new MatrixOfInt(MatrixOperator.EnterMatrix());
            Console.WriteLine("\r\nShow numbers of matrix!");
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt InsertNewLine()
        {
            //Insert new line after line containing the first occurrence of the minimal element. 
            MatrixOfInt mtx = new MatrixOfInt(MatrixOperator.EnterMatrix());

            Console.WriteLine("Insert new line after line containing the first occurrence of the minimal element. ");
            mtx = new MatrixOfInt(MatrixOperator.InsertNewLine(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt InsertNewColumn()
        {
            //Insert new column before all columns containing the indicated number.  
            MatrixOfInt mtx = new MatrixOfInt(MatrixOperator.EnterMatrix());

            Console.WriteLine("Insert new column before all columns containing the indicated number.");
            Console.WriteLine("\r\nInsert the number!");
            int n = 0;
            string str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("\r\nInsert a valid number!");
                str = Console.ReadLine();
            }

            mtx = new MatrixOfInt(MatrixOperator.InsertNewColumn(mtx.GetAsArrayOfArrays(), n));

            Console.WriteLine("\r\nResult matrix is!");
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt DeleteLinesWithEven()
        {
            //Delete all lines, containing only even number elements. 
            MatrixOfInt mtx = new MatrixOfInt(MatrixOperator.EnterMatrix());

            Console.WriteLine("Delete all lines, containing only even number elements. ");
            mtx = new MatrixOfInt(MatrixOperator.DeleteLinesWithEven(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt DeleteColumnsPositive()
        {
            //Delete all columns, containing only positive elements. 
            MatrixOfInt mtx = new MatrixOfInt(MatrixOperator.EnterMatrix());

            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());

            Console.WriteLine("Delete all columns, containing only positive elements. ");
            mtx = new MatrixOfInt(MatrixOperator.DeleteColumnsPositive(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt Compress()
        {
            //Compress array by deleting all only zero-value lines and columns.
            MatrixOfInt mtx = new MatrixOfInt(MatrixOperator.EnterMatrix());
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            Console.WriteLine("Compress array by deleting all only zero-value lines and columns.");
            mtx = new MatrixOfInt(MatrixOperator.Compress(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static MatrixOfInt DeleteLinesColumnsEqual()
        {
            //Delete from array the k-th line and the j-th column if their values coincide.
            MatrixOfInt mtx = new MatrixOfInt(MatrixOperator.EnterMatrix());
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            Console.WriteLine("Delete from array the k-th line and the j-th column if their values coincide.");
            mtx = new MatrixOfInt(MatrixOperator.DeleteLinesColumnsEqual(mtx.GetAsArrayOfArrays()));

            Console.WriteLine("\r\nResult matrix is!");
            MatrixOperator.ShowElements(mtx.GetAsArrayOfArrays());
            return mtx;
        }
        public static void WorkWithMultidimensionalArray()
        {
            int[,] arrInt = new int[,] { { 1, 2 }, { 3, 4 },{5,6 } };
            int[] arrIntCopy = new int [6];
            int[,] arrIntCopy1 = null;
            int ncolumn= arrInt.GetLength(1);
            int totalelement = arrInt.Length ;
            arrInt.OfType<int>().ToArray<int>().CopyTo(arrIntCopy,0);//copyto merge numai cu array-uri unidimensionale, si array-ul de destinatie trebuie sa fie allocat 
            arrIntCopy1 = (int[,])arrInt.Clone();
            arrInt[1, 0] = 12;
        }
    }
}
