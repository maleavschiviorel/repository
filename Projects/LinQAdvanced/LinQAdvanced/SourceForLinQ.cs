using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LinQAdvanced
{
    public class SourceForLinQ
    {
        public IEnumerable<string> GetSource()
        {
            string[] directories = Directory.GetDirectories("D:\\");
            var fileNames = Directory.GetDirectories(@"D:\localrepo").SelectMany(Directory.GetFiles);
            return fileNames;
           // new string[] { "first", "second", "third" };
        }

        public IEnumerable<string[]> GetSource1()
        {
            string[] directories = Directory.GetDirectories("D:\\");
            var groupsOfFileNames = Directory.GetDirectories(@"D:\localrepo").Select(Directory.GetFiles);
            return groupsOfFileNames;
            // new string[] { "first", "second", "third" };
        }
    }
}
