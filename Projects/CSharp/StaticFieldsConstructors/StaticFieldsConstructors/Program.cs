using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticFieldsConstructors
{
    public class FieldClassA
    {
        public FieldClassA()
        {
            Console.WriteLine("FieldClassA");
        }
    }
    public class FieldClassB
    {
        public FieldClassB()
        {
            Console.WriteLine("FieldClassB");
        }
    }

    public class A
    {
        private static FieldClassA fieldClassA = new FieldClassA();
        static A()
        {
            Console.WriteLine("static A");
        }
        public A()
        {
            Console.WriteLine("A.");
        }
    }
    public class B : A
    {
        private static FieldClassB fieldClassB = new FieldClassB();
        static B()
        {
            Console.WriteLine("static B");
        }

        public B(int i)
        {
            Console.WriteLine("B.{0}", i);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           // var obj = new A();
            var obj1 = new B(10);

            Console.ReadLine();
        }
    }
}
