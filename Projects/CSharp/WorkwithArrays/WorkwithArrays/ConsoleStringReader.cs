using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithArrays
{
    class ConsoleStringReader : IStringReader
    {
        public string Read()
        {
            Console.WriteLine("Enter a text ending with enter!");
            string str = Console.ReadLine();
            return str;
        }
    }
}
