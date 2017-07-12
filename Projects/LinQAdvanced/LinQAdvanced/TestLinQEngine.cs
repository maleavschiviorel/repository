using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQAdvanced
{
    public class TestLinQEngine
    {
        private SourceForLinQ src;
        private LinQEngine<string, string> linqeng = LinQEngine<string, string>.GetLinqEngine();
        private ConditionToCompare<string> cp = null;
        private Output<string> outs = new Output<string>();
        public TestLinQEngine()
        {
            src = new SourceForLinQ();
        }
        public void Filter()
        {
            cp = new ConditionToCompare<string>("d");
            cp.f1 = (x) => { return x.Contains(cp.compareToObject); };
            var res = linqeng.Filter(src.GetSource(), cp);
            outs.SendToOutPut(res);
        }
    }
}
