using System;

namespace WorkwithArrays
{
    public class MatrixOperator
    {
        /// <summary>
        /// Enter elements in matrix
        /// </summary>
        /// <returns></returns>
        public static int[][] EnterMatrix()
        {
            Console.WriteLine("Enter numbers of lines in matrix!");
            int m = 0;
            string str = Console.ReadLine();
            while (!int.TryParse(str, out m))
            {
                Console.WriteLine("Enter a valid number!");
                str = Console.ReadLine();
            }
            Console.WriteLine("Enter numbers of columns in matrix!");
            int n = 0;
            str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("Enter a valid number!");
                str = Console.ReadLine();
            }
            int[][] arr = new int[m][];
            for (int i = 0; i < m; i++)
            {
                arr[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Enter element in row {0} and column {1}!", i, j);
                    int elem = 0;
                    str = Console.ReadLine();
                    while (!int.TryParse(str, out elem))
                    {
                        Console.WriteLine("Enter a valid number!");
                        str = Console.ReadLine();
                    }
                    arr[i][j] = elem;
                }
            }
            return arr;
        }
        /// <summary>
        /// Insert new line after line containing the first occurrence of the minimal element. 
        /// </summary>
        /// <returns></returns>
        public static int[][] InsertNewLine(int[][] arr)
        {
            MyMatrix<int> m = new MyMatrix<int>(arr);
            int min = int.MaxValue;
            int firstoccurance = -1;
            for (int i = 0; i < m.Length(0); i++)
            {
                for (int j = 0; j < m.Length(1); j++)
                {
                    if (m[i, j] < min)
                    {
                        min = m[i, j];
                        firstoccurance = i;
                    }
                }
            }
            m.AddLine(firstoccurance + 1, 0);
            return m.GetAsArrayOfArrays();
        }


        /// <summary>
        ///	Insert new column before all columns containing the indicated number. 
        /// </summary>
        /// <returns></returns>
        public static int[][] InsertNewColumn(int[][] arr, int n)
        {
            MyMatrix<int> m = new MyMatrix<int>(arr);
            for (int j = 0; j < m.Length(1); j++)
            {
                bool found = false;
                for (int i = 0; i < m.Length(0); i++)
                {
                    if (m[i, j] == n)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    m.AddColumn(j, 0);
                    j++;
                }
            }

            return m.GetAsArrayOfArrays();
        }

        /// <summary>
        /// Delete all lines, containing only even number elements. 
        /// </summary>
        /// <returns></returns>
        public static int[][] DeleteLinesWithEven(int[][] arr)
        {
            MyMatrix<int> m = new MyMatrix<int>(arr);
            for (int i = 0; i < m.Length(0); i++)
            {
                bool iseven = true;
                for (int j = 0; j < m.Length(1); j++)
                {
                    if (m[i, j] % 2 != 0)
                    {
                        iseven = false;
                        break;
                    }
                }
                if (iseven)
                {
                    m.RemoveLine(i);
                    i--;
                }
            }

            return m.GetAsArrayOfArrays();
        }

        /// <summary>
        /// Delete all columns, containing only positive elements. 
        /// </summary>
        /// <returns></returns>
        public static int[][] DeleteColumnsPositive(int[][] arr)
        {
            MyMatrix<int> m = new MyMatrix<int>(arr);
            for (int j = 0; j < m.Length(1); j++)
            {
                bool ispositive = true;
                for (int i = 0; i < m.Length(0); i++)
                {
                    if (m[i, j] < 0)
                    {
                        ispositive = false;
                        break;
                    }
                }
                if (ispositive)
                {
                    m.RemoveColumn(j);
                    j--;
                }
            }

            return m.GetAsArrayOfArrays();
        }

        /// <summary>
        ///Delete from array the k-th line and the j-th column if their values coincide.
        /// </summary>
        /// <returns></returns>
        public static int[][] DeleteLinesColumnsEqual(int[][] arr)
        {
            MyMatrix<int> m = new MyMatrix<int>(arr);
            if (m.Length(0) == m.Length(1))
            {
                for (int i = 0; i < m.Length(0); i++)
                {
                    for (int j = 0; j < m.Length(1); j++)
                    {
                        bool isequal = true;
                        for (int i1 = 0; i1 < m.Length(0); i1++)
                        {
                            if (m[i, i1] != m[i1, j])
                            {
                                isequal = false;
                                break;
                            }
                        }

                        if (isequal)
                        {
                            m.RemoveLine(i);
                            i--;
                            m.RemoveColumn(j);
                            j--;
                            break;
                        }
                    }

                }
            }
            return m.GetAsArrayOfArrays();
        }

        /// <summary>
        /// Compress array by deleting all only zero-value lines and columns
        /// </summary>
        /// <returns></returns>
        public static int[][] Compress(int[][] arr)
        {
            MyMatrix<int> m = new MyMatrix<int>(arr);

            bool isZero = true;
            for (int i = 0; i < m.Length(0); i++)
            {
                isZero = true;
                for (int j = 0; j < m.Length(1); j++)
                {
                    if (m[i, j] != 0)
                    {
                        isZero = false;
                        break;
                    }
                }
                if (isZero)
                {
                    m.RemoveLine(i);
                    i--;
                }
            }
            for (int j = 0; j < m.Length(1); j++)
            {
                isZero = true;
                for (int i = 0; i < m.Length(0); i++)
                {
                    if (m[i, j] != 0)
                    {
                        isZero = false;
                        break;
                    }
                }
                if (isZero)
                {
                    m.RemoveColumn(j);
                    j--;
                }
            }

            return m.GetAsArrayOfArrays();
        }
        public static void ShowElements(int[][] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    Console.Write(arr[i][j]);
                    if (j < arr[i].Length - 1)
                        Console.Write(" ~ ");
                    else
                        Console.WriteLine("");
                }
            }
            
        }
    }

}

