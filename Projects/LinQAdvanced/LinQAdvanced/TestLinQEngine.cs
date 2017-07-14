using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQAdvanced
{
    public class Vendor
    {
        public string Name
        { get; set; }
    }

    public class Material
    {
        public string Name
        { get; set; }
        public Vendor Vendor
        { get; set; }
        public string VendorName
        { get; set; }
    }
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
            outs.SendToOutPut("------Filter");
            cp = new ConditionToCompare<string>("it");
            cp.f1 = (x) => { return x.Contains(cp.compareToObject); };
            var res = linqeng.Filter(src.GetSource(), cp);
            outs.SendToOutPut(res);
        }
        public void Take()
        {
            outs.SendToOutPut("------Take");
            cp = new ConditionToCompare<string>(2);
            var res = linqeng.Take(src.GetSource(), cp);
            outs.SendToOutPut(res);
        }
        public void Skip()
        {
            outs.SendToOutPut("------Skip");
            cp = new ConditionToCompare<string>(3);
            var res = linqeng.Skip(src.GetSource(), cp);
            outs.SendToOutPut(res);
        }
        public void TakeWhile()
        {
            outs.SendToOutPut("------TakeWhile");
            cp = new ConditionToCompare<string>("it");
            cp.f1 = (x) => { return x.Contains(cp.compareToObject); };
            var res = linqeng.TakeWhile(src.GetSource(), cp);
            outs.SendToOutPut(res);
        }
        public void SkipWhile()
        {
            outs.SendToOutPut("------SkipWhile");
            cp = new ConditionToCompare<string>("it");
            cp.f1 = (x) => { return x.Contains(cp.compareToObject); };
            var res = linqeng.SkipWhile(src.GetSource(), cp);
            outs.SendToOutPut(res);
        }
        public void Distict()
        {
            outs.SendToOutPut("------Distict");

            var res = linqeng.Distinct(src.GetSource(), null);
            outs.SendToOutPut(res);
        }
        public void Join()
        {
            Vendor[] vendors = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            Material[] matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors[2], VendorName = "Zorile" } };
            var res = vendors.Join(matetials, vendor => vendor.Name, material => material.VendorName, (vendor, material) => new { VendorName = vendor.Name, MaterialName = material.Name });
            foreach (var a in res)
            {
                Console.WriteLine("Vendor={0},Material={1}", a.VendorName, a.MaterialName);
            }
        }
    }
}
