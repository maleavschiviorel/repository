using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covariant
{
    public class Person : IPerson
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "Code=" + Code + ", Name=" + Name + ", Age=" + Age.ToString();
        }
        public  string ToString1(string str)
        {
            return str??""+", Code=" + Code + ", Name=" + Name + ", Age=" + Age.ToString();
        }
    }
}
