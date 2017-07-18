using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndEventsBeginning
{
    public class MyClass
    {
        public delegate string ConcatDel(string x1, string x2);



        public ConcatDel ConcatH;

        public event ConcatDel ConcatEvent;
        public string Concat(string s1, string s2)
        {
            string result = "";
            result = s1 ?? "" + s2 ?? "";
            return result;
        }

        public string ConcatWithSpace(string s1, string s2)
        {
            string result = "";
            result = (s1 ?? "") + " | " + (s2 ?? "");
            return result;
        }

        public void AssignMethodToDelegateVar(int funcIndex = 0)
        {
            if (funcIndex == 0)
            {
                ConcatH = Concat;

                ConcatEvent = Concat;

                ConcatEvent = null;
            }
            else
            {
                ConcatH = ConcatWithSpace;
                ConcatEvent = ConcatWithSpace;

                Delegate[] arrdel0 = ConcatH.GetInvocationList(); 
                Delegate[] arrdel = ConcatEvent.GetInvocationList();
            }

        }
        public string GenerateConcatEvent(string s1, string s2)
        {
            if (ConcatEvent != null)
                return ConcatEvent(s1, s2);
            return "";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClassObject = new MyClass();
            myClassObject.AssignMethodToDelegateVar(1);

            Delegate[] arrdel = myClassObject.ConcatH.GetInvocationList();
          

            // myClassObject.ConcatEvent. 
            // myClassObject.ConcatEvent = null;

            string resultFromDelegate = myClassObject.ConcatH(null, null);
            myClassObject.ConcatH = null;

            //string resultFromEvent = myClassObject.ConcatEvent(null, null);
            string resultFromEvent = myClassObject.GenerateConcatEvent("1111", "2222");

            myClassObject.ConcatEvent -= new MyClass.ConcatDel(myClassObject.ConcatWithSpace );

            resultFromEvent = myClassObject.GenerateConcatEvent("3333", "4444");

            Console.WriteLine(resultFromDelegate);
            Console.WriteLine(resultFromEvent);
            Console.ReadLine();
        }
    }
}
