using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.Write( a.ToString()+" ~ "); 
            }
            Console.WriteLine();  
        }

    }
}
