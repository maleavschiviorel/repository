using System;
using System.Collections.Generic;

namespace LinQAdvanced
{
    public  class Output<U>
    {
        public Output()
        { }

        public void SendToOutPut(IEnumerable<U> arr)
        {
            foreach (var a in arr)
            {
                Console.WriteLine( a.ToString()); 
            }
            Console.WriteLine("\r\n-----------------------------\r\n");  
        }

        public void SendToOutPut(string str)
        {
            Console.WriteLine("\r\n"+str);
        }
    }
}
