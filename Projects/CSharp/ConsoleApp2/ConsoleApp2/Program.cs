using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInit
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Derived d = new Derived();
            Console.ReadLine();
        }
    }
    class Base
    {
        public Base()
        {
            Console.WriteLine("Base.Instance.Constructor");
            this.m_Field3 = new Tracker("Base.Instance.Field3");
            this.Virtual();
        }
        static Base()
        {
            Console.WriteLine("Base.Static.Constructor");
        }
        private Tracker m_Field1 = new Tracker("Base.Instance.Field1");
        private Tracker m_Field2 = new Tracker("Base.Instance.Field2");
        private Tracker m_Field3;
        static private Tracker s_Field1 = new Tracker("Base.Static.Field1");
        static private Tracker s_Field2 = new Tracker("Base.Static.Field2");
        virtual public void Virtual()
        {
            Console.WriteLine("Base.Instance.Virtual");
        }
    }
    class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("Derived.Instance.Constructor");
            this.m_Field3 = new Tracker("Derived.Instance.Field3");
        }
        static Derived()
        {
            Console.WriteLine("Derived.Static.Constructor");
        }
        private Tracker m_Field1 = new Tracker("Derived.Instance.Field1");
        private Tracker m_Field2 = new Tracker("Derived.Instance.Field2");
        private Tracker m_Field3;
        static private Tracker s_Field1 = new Tracker("Derived.Static.Field1");
        static private Tracker s_Field2 = new Tracker("Derived.Static.Field2");
        override public void Virtual()
        {
            Console.WriteLine("Derived.Instance.Virtual");
        }
    }
    class Tracker
    {
        public Tracker(string text)
        {
            Console.WriteLine(text);
        }
    }
}