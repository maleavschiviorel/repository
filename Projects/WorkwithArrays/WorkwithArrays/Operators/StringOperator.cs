using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithArrays
{
    //    1.	insert character<x> after every occurrence of character<y>; 
    //2.	mix up the first character with the second one, the third character with the fourth one etc.
    //3.	find, which of two indicated characters is occurred in the string more often; 
    //4.	count full number of occurrences of<x> and<y> characters; 
    //5.	+count number of different characters in the string; 
    //6.	find out if the string has two adjacent identical characters; 
    //7.	delete the middle character if string length is odd or two middle characters if string length is even; 
    //8.	double every occurrence of the indicated character<x>; 
    //9.	delete all occurrences of  the character<x>; 
    //10.	delete all occurrences of the substring<substr>; 
    //11.	+replace all occurrences of the substring<substr1> on the substring<substr2>; 
    //12.	count the sum of all numbers occurred in the string; 
    //13.	count the sum of all digits occurred in the string; 
    //14.	find indexes of the first and the last occurrences of the character<x>; 
    //15.	replace all groups of adjacent dots with ellipsis; 
    //16.	display all characters before the first colon occurrence in the string; 
    //17.	display all characters after the first colon occurrence in the string; 
    //18.	delete all characters inside the parenthesize.
    //19.	delete all characters inside the curly braces; 
    //20.	count and display statistics of character occurrences in the string. 

    public class StringOperator : IStringOperator
    {

        /// <summary>
        /// 1. insert character<x> after every occurrence of character<y>
        /// </summary>
        /// <returns></returns>
        public string InsertXafterEachY(string str, char tofind, char toadd)
        {
            if (str == null)
                return "";
            return str.Replace(tofind.ToString(), tofind.ToString() + toadd.ToString());
        }

        //2.	mix up the first character with the second one, the third character with the fourth one etc. 
        public string MixUp(string str)
        {
            if (str == null)
                return "";
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i += 2)
            {
                if (i + 1 <= str.Length - 1)
                    result.Append(new char[] { str[i + 1], str[i] });
                else
                    result.Append(str[i]);

            }
            return result.ToString();
        }


        /// <summary>
        /// 3. find, which of two indicated characters is occurred in the string more often; 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tofind"></param>
        /// <param name="toadd"></param>
        /// <returns></returns>
        public int MoreOften(string str, char c1, char c2)
        {
            if (str == null)
                return -1;
            if (str.Replace(c1.ToString(), "").Length < str.Replace(c2.ToString(), "").Length)
                return 0;
            else if (str.Replace(c1.ToString(), "").Length > str.Replace(c2.ToString(), "").Length)
                return 1;
            else
                return -1;

        }

        /// <summary>
        /// 4.	count full number of occurrences of<x> and<y> characters;
        /// </summary>
        /// <param name="str"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int CountFull(string str, char x, char y)
        {
            if (str == null)
                return 0;
            return str.Length - str.Replace(x.ToString(), "").Length + str.Length - str.Replace(y.ToString(), "").Length;
        }


        /// <summary>
        /// 5. count number of different characters in the string; 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int CountDifferent(string str)
        {
            string strb = "";
            if (str == null)
                return 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (strb.IndexOf(str[i]) == -1)
                { strb = strb + str[i]; }

            }
            return strb.Length;
        }


        /// <summary>
        /// 6.	find out if the string has two adjacent identical characters; 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Hasadjacentcaracters(string str)
        {
            int index = -1;
            if (str == null)
                return false;
            for (int i = 0; i < str.Length - 1; i++)
            {
                index = str.IndexOf(str[i], i + 1);
                if (index != -1 && index - i == 1)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 7.	delete the middle character if string length is odd or two middle characters if string length is even; 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DeleteMiddle(string str)
        {
            int index = -1;
            if (str == null)
                return "";
            if (str.Length > 0)
            {
                if (str.Length % 2 == 0)
                {
                    return str.Remove((str.Length / 2) - 1, 2);

                }
                else
                {
                    return str.Remove((str.Length / 2), 1);
                }
            }
            return str;
        }
        /// <summary>
        ///  8.	double every occurrence of the indicated character<x>; 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public string DoubleX(string str, char x)
        {
            if (str == null)
                return "";
            return str.Replace(x.ToString(), x.ToString() + x.ToString());
        }
        /// <summary>
        /// 9. delete all occurrences of  the character<x>; 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public string DeleteX(string str, char x)
        {
            if (str == null)
                return "";
            return str.Replace(x.ToString(), "");
        }

        /// <summary>
        /// 10.	delete all occurrences of the substring<substr>; 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="substr"></param>
        /// <returns></returns>
        public string DeleteSustr(string str, string substr)
        {
            if (str == null)
                return "";
            return str.Replace(substr, "");
        }

        /// <summary>
        /// 11.	+replace all occurrences of the substring<substr1> on the substring<substr2>; 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="substr1"></param>
        /// <param name="substr2"></param>
        /// <returns></returns>
        public string ReplaceSubstr1WithSubstr2(string str, string substr1, string substr2)
        {
            if (str == null)
                return "";
            return str.Replace(substr1, substr2);
        }
        /// <summary>
        /// 12.	count the sum of all numbers occurred in the string; 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public double CountSumOfNumbers(string str)
        {
            double t = 0;
            if (str == null)
                return 0;
            for (int i = 0; i < str.Length; i++)
                if (!char.IsNumber(str[i]))
                {
                    str = str.Replace(str[i].ToString(), "|");
                }

            string[] numbers = str.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                t += double.Parse(numbers[i]);
            }

            return t;
        }
        /// <summary>
        /// 13.	count the sum of all digits occurred in the string; 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public long CountSumOfDigits(string str)
        {
            long t = 0;
            if (str == null)
                return 0;
            for (int i = 0; i < str.Length; i++)
                if (char.IsNumber(str[i]))
                {
                    t += int.Parse(str[i].ToString());
                }

            return t;
        }
        /// <summary>
        /// 14.	find indexes of the first and the last occurrences of the character<x>; 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="x"></param>
        /// <param name="f"></param>
        /// <param name="l"></param>
        public void FirstAndLast(string str, char x, out int f, out int l)
        {
            if (str == null)
                str = "";
            f = str.IndexOf(x);
            l = str.LastIndexOf(x);
        }
        /// <summary>
        /// 15.	replace all groups of adjacent dots with ellipsis; 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="substr"></param>
        /// <returns></returns>
        public string ReplaceAdjacentDotsWith(string str, string substr)
        {
            int l = -1;
            int r = -1;
            if (str == null)
                return "";
            StringBuilder stb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.')
                {
                    l = i;
                    r = i;
                    for (; r < str.Length - 1 && str[r] == '.'; r++)
                        ;
                    if (r - l > 1)
                    {
                        stb.Append("...");
                        i = r - 1;
                        continue;
                    }
                }
                stb.Append(str[i]);
            }
            return stb.ToString();
        }

        /// <summary>
        /// 16.	display all characters before the first colon occurrence in the string; 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DisplayCharsB(string str)
        {
            if (str == null)
                return "";
            if (str.Length > 0 && str.IndexOf(":") != -1)
            {
                return str.Substring(0, str.IndexOf(":"));
            }
            else
                return "";
        }

        /// <summary>
        /// 17.	display all characters after the first colon occurrence in the string; 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DisplayCharsA(string str)
        {
            if (str == null)
                return "";

            int i = str.IndexOf(":");


            if (str.Length > 0 && i != -1 && i < str.Length - 1)
            {
                return str.Substring(i + 1, str.Length - 1 - i);
            }
            else
                return "";

        }
        private string DeleteFrom(string str, char c1, char c2)
        {
            if (str == null)
                return "";
            int l = -1;
            int r = -1;
            l = str.IndexOf(c1);
            r = str.LastIndexOf(c2);
            if (l > -1 && r > l)
            {
                return str.Substring(0, l + 1) + str.Substring(r, str.Length - r);
            }
            else
                return str;
        }


        /// <summary>
        /// 18.	delete all characters inside the parenthesize. 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DeleteFromParanthesize(string str)
        {
            if (str == null)
                return "";
            return DeleteFrom(str, '(', ')');
        }

        /// <summary>
        /// 19.	delete all characters inside the curly braces; 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DeleteFromCurlyBraces(string str)
        {
            if (str == null)
                return "";
            return DeleteFrom(str, '{', '}');
        }


        /// <summary>
        /// 20.	count and display statistics of character occurrences in the string. 
        /// </summary>
        /// <param name="str"></param>
        public void DisplayStatstics(string str)
        {
            if (str == null)
                str = "";
            Dictionary<char, int> stat = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!stat.ContainsKey(str[i]))
                {
                    stat.Add(str[i], 1);
                }
                else
                {
                    stat[str[i]] = stat[str[i]] + 1;
                }
            }
            foreach (char c in stat.Keys)
            {
                Console.WriteLine("count('{0}')={1}", c, stat[c]);
            }
        }
      
    }

}

