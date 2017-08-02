using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithArrays
{
    public class TestStringOperator
    {
        IStringReader _stringReader;
        IStringOperator _stringOperator;

        public TestStringOperator(IStringReader stringReader, IStringOperator stringOperator)
        {
            _stringReader = stringReader;
            _stringOperator = stringOperator;
        }

        public void CountDifferent()
        {
            var str = _stringReader.Read();
            int c = _stringOperator.CountDifferent(str);

            Console.WriteLine("Count number of different characters in the string\r\n{0}", c);
        }

        public void CountFull()
        {
            string str = _stringReader.Read();
            Console.WriteLine("Count full number of occurrences of <x> and <y> characters; ");
            Console.Write("Enter x="); char x = Console.ReadLine()[0]; Console.WriteLine();
            Console.Write("Enter y="); char y = Console.ReadLine()[0];
            int c = _stringOperator.CountFull(str, x, y);
            Console.WriteLine("full number of occurrences of <{0}> and <{1}> characters is {2}", x, y, c);
        }
        public void CountSumOfDigits()
        {
            string str = _stringReader.Read();
            Console.WriteLine("Count the sum of all digits occurred in the string; ");
            long c = _stringOperator.CountSumOfDigits(str);
            Console.WriteLine("Sum of all digits occurred in the string is {0}", c);
        }
        public void CountSumOfNumbers()
        {
            string str = _stringReader.Read();
            Console.WriteLine("Count the sum of all numbers occurred in the string");
            double c = _stringOperator.CountSumOfNumbers(str);
            Console.WriteLine("sum of all numbers occurred in the string is {0}", c);
        }
        public void DeleteFromCurlyBraces()
        {
            string str = _stringReader.Read();
            Console.WriteLine("Delete all characters inside the curly braces; ");
            str = _stringOperator.DeleteFromCurlyBraces(str);
            Console.WriteLine("Result string is = {0}", str);
        }
        public void DeleteFromParanthesize()
        {
            string str = _stringReader.Read();
            Console.WriteLine("Delete all characters inside the parenthesize.  ");
            str = _stringOperator.DeleteFromParanthesize(str);
            Console.WriteLine("Result string is = {0}", str);
        }
        public void DeleteMiddle()
        {
            string str = _stringReader.Read();
            Console.WriteLine("Delete the middle character if string length is odd or two middle characters if string length is even");
            str = _stringOperator.DeleteMiddle(str);
            Console.WriteLine("Result string is = {0}", str);
        }
        public void DeleteSustr()
        {
            Console.WriteLine("Delete all occurrences of the substring<substr>; ");
            string str = _stringReader.Read();
            Console.WriteLine("Enter substring");
            string substr = _stringReader.Read();
            str = _stringOperator.DeleteSustr(str, substr);
            Console.WriteLine("Result string is = {0}", str);
        }

        public void DeleteX()
        {
            Console.WriteLine("Delete all occurrences of  the character <x>; ");
            string str = _stringReader.Read();
            Console.Write("Enter x="); char c = (char)Console.Read(); Console.WriteLine();
            str = _stringOperator.DeleteX(str, c);
            Console.WriteLine("Result string is = {0}", str);
        }

        public void DisplayCharsB()
        {
            Console.WriteLine("Display all characters before the first colon occurrence in the string");
            string str = _stringReader.Read();
            str = _stringOperator.DisplayCharsB(str);
            Console.WriteLine("Result string is = {0}", str);
        }
        public void DisplayCharsA()
        {
            Console.WriteLine("Display all characters after the first colon occurrence in the string;  ");
            string str = _stringReader.Read();
            str = _stringOperator.DisplayCharsA(str);
            Console.WriteLine("Result string is = {0}", str);
        }

        public void DisplayStatstics()
        {
            Console.WriteLine("Count and display statistics of character occurrences in the string. ");
            string str = _stringReader.Read();
            _stringOperator.DisplayStatstics(str);
        }
        public void DoubleX()
        {
            Console.WriteLine("Double every occurrence of the indicated character <x>;");
            string str = _stringReader.Read();
            Console.Write("Enter x="); char x = (char)Console.Read(); Console.WriteLine();
            str = _stringOperator.DoubleX(str, x);
            Console.WriteLine("Result string is = {0}", str);
        }
        public void FirstAndLast()
        {
            Console.WriteLine("Find indexes of the first and the last occurrences of the character<x>; ");
            string str = _stringReader.Read();
            Console.Write("Enter x="); char x = (char)Console.Read(); Console.WriteLine();
            int f = -1; int l = -1;
            _stringOperator.FirstAndLast(str, x, out f, out l);
            Console.WriteLine("First and the last occurrences of the character<{0}> are f={1} and l={2}", x, f, l);
        }
        public void Hasadjacentcaracters()
        {
            Console.WriteLine("Find out if the string has two adjacent identical characters;  ");
            string str = _stringReader.Read();
            bool flag = _stringOperator.Hasadjacentcaracters(str);
            if (flag)
                Console.WriteLine("Has two adjacent identical characters");
            else
                Console.WriteLine("Has no adjacent identical characters");
        }

        public void InsertXafterEachY()
        {
            Console.WriteLine("Insert character<x> after every occurrence of character<y>");
            string str = _stringReader.Read();
            Console.Write("Enter x="); char x = (char)Console.ReadLine()[0]; Console.WriteLine();
            Console.Write("Enter y="); char y = (char)Console.ReadLine()[0];
            str = _stringOperator.InsertXafterEachY(str, y, x);
            Console.WriteLine("Result string is = {0}", str);
        }

        public void MixUp()
        {
            Console.WriteLine("Mix up the first character with the second one, the third character with the fourth one etc. ");
            string str = _stringReader.Read();
            str = _stringOperator.MixUp(str);
            Console.WriteLine("Result string is = {0}", str);
        }

        public void MoreOften()
        {
            Console.WriteLine("Find, which of two indicated characters is occurred in the string more often; ");
            string str = _stringReader.Read();
            Console.Write("Enter x="); char x = (char)Console.ReadLine()[0]; Console.WriteLine();
            Console.Write("Enter y="); char y = (char)Console.ReadLine()[0];
            int i = _stringOperator.MoreOften(str, x, y);
            if(i==0)
            Console.WriteLine("character {0} is more often",x);
            else
                 if (i == 1)
                Console.WriteLine("character {0} is more often", y);
            else
                Console.WriteLine("character {0} and {1} are equal often",x, y);

        }
        public void ReplaceAdjacentDotsWith()
        {
            Console.WriteLine("Replace all groups of adjacent dots with ellipsis;  ");
            string str = _stringReader.Read();
            str = _stringOperator.ReplaceAdjacentDotsWith(str, "...");
            Console.WriteLine("Result string is = {0}", str);
        }
        public void ReplaceSubstr1WithSubstr2()
        {
            Console.WriteLine("Replace Substr1 With Substr2");
            string str = _stringReader.Read();
            Console.WriteLine("Enter substring1");
            string substr1 = _stringReader.Read();
            Console.WriteLine("Enter substring2");
            string substr2 = _stringReader.Read();
            str = _stringOperator.ReplaceSubstr1WithSubstr2(str, substr1, substr2);
            Console.WriteLine("Result string is = {0}", str);
        }
        public void ReplaceSubstr1WithSubstr2UsingStrinBuilder()
        {
            Console.WriteLine("Replace Substr1 With Substr2");
            string str = _stringReader.Read();
            Console.WriteLine("Enter substring1");
            string substr1 = _stringReader.Read();
            Console.WriteLine("Enter substring2");
            string substr2 = _stringReader.Read();
            StringBuilder strBuilder = new StringBuilder(str); 
            str = strBuilder.Replace(substr1, substr2).ToString() ;
            Console.WriteLine("Result string is = {0}", str);

        }
    }
}
