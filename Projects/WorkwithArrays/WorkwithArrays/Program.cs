using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithArrays
{
    class Program
    {
        public static void Main(string[] args)
        {
            //// 1.  + Delete all even numbers.
            ////2.  + Insert new element after all elements beginning with the indicated digit. 
            ////3.  + Delete from array all repeating elements except of their first occurrence. 
            ////4.Insert new element between all element pairs with different signs.
            ////5.  + Compress array by deleting all zero - value elements.

            //TestArrayOperator.EnterElements();
            ////----------------------------------------------------------------------------
            //TestArrayOperator.DeleteEvenNumbers();
            ////----------------------------------------------------------------------------
            //TestArrayOperator.InsertNewElement();
            //////----------------------------------------------------------------------------
            //TestArrayOperator.InsertNewElement1();
            ////----------------------------------------------------------------------------
            //TestArrayOperator.Compress();

            //1.  + Insert new line after line containing the first occurrence of the minimal element. 
            //2.Insert new column before all columns containing the indicated number.
            //3.Delete all lines, containing only even number elements. 
            //4.  + Delete all columns, containing only positive elements.
            //5.Delete from array the k - th line and the j-th column if their values coincide.
            //6.  + Compress array by deleting all only zero-value lines and columns.

            //TestMatrixOperator.EnterElements();
            //----------------------------------------------------------------------------
            //TestMatrixOperator.InsertNewLine();
            ////----------------------------------------------------------------------------
            // TestMatrixOperator.InsertNewColumn();
            //////----------------------------------------------------------------------------
            //TestMatrixOperator.DeleteLinesWithEven();
            ////----------------------------------------------------------------------------
            //TestMatrixOperator.DeleteColumnsPositive();
            ////----------------------------------------------------------------------------
            // TestMatrixOperator.DeleteLinesColumnsEqual();
            ////----------------------------------------------------------------------------
            //TestMatrixOperator.Compress();
            TestMatrixOperator.WorkWithMultidimensionalArray(); 

            //--------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------
            var stringReader = new ConsoleStringReader();
            var stringOperator = new StringOperator();
            var operatorObj = new TestStringOperator(stringReader, stringOperator);

            // operatorObj.CountDifferent();
            // operatorObj.CountFull();
            // operatorObj.CountSumOfDigits();
            // operatorObj.CountSumOfNumbers();  
            // operatorObj.DeleteFromCurlyBraces();  
            // operatorObj.DeleteFromParanthesize();  
            // operatorObj.DeleteMiddle();
            // operatorObj.DeleteSustr(); 
            // operatorObj.DeleteX();
            // operatorObj.DisplayCharsA();
            // operatorObj.DisplayCharsB();
            // operatorObj.DisplayStatstics();
            // operatorObj.DoubleX();
            // operatorObj.FirstAndLast();
            // operatorObj.Hasadjacentcaracters();
            // operatorObj.InsertXafterEachY();
            // operatorObj.MixUp();  
            // operatorObj.MoreOften();  
            // operatorObj.ReplaceAdjacentDotsWith();
             //operatorObj.ReplaceSubstr1WithSubstr2();
            operatorObj.ReplaceSubstr1WithSubstr2UsingStrinBuilder();

            Console.ReadLine();
        }
    }
}

