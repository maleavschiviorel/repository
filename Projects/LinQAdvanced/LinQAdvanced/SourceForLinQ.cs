using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQAdvanced
{
   public  class SourceForLinQ
    {
        public IEnumerable<string> GetSource()
        {
            string[] dir = System.IO.Directory.GetDirectories("D:\\");
            var q= System.IO.Directory.GetDirectories(@"D:\localrepo").SelectMany (x => System.IO.Directory.GetFiles(x));
            return q;
           // new string[] { "first", "second", "third" };
        }
        public IEnumerable<string[]> GetSource1()
        {
            string[] dir = System.IO.Directory.GetDirectories("D:\\");
            var q = System.IO.Directory.GetDirectories(@"D:\localrepo").Select(x => System.IO.Directory.GetFiles(x));
            return q;
            // new string[] { "first", "second", "third" };
        }
    }
}
