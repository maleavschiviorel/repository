using System;
using System.Linq;

namespace LinQAdvanced
{
    public class Vendor:IComparable<Vendor> ,IEquatable<Vendor> 
    {
        public string Name { get; set; }

        public int CompareTo(Vendor obj)
        {
           return this.Name.CompareTo(obj.Name );
        }

        public bool Equals(Vendor other)
        {
            return this.Name.Equals(other.Name );
        }
    }

    public class Material
    {
        public string Name { get; set; }

        public Vendor Vendor { get; set; }

        public string VendorName { get; set; }
    }
    public class TestLinQEngine
    {
        private SourceForLinQ src;

        private LinQEngine<string, string> linqEngine = LinQEngine<string, string>.GetLinqEngine();

        private ConditionToCompare<string> condition = null;

        private Output<string> outs = new Output<string>();

        public TestLinQEngine()
        {
            src = new SourceForLinQ();
        }

        public delegate bool ContainsDelegate(string x);
        public bool ContainsMethod(string x)
        {
            return x.Contains(condition.CompareToObject);
        }
        public void FilterWithDelegate()
        {
            outs.SendToOutPut("------FilterWithDelegate");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = ContainsMethod;
            var filtrationResult = linqEngine.Filter(src.GetSource(), condition);
            outs.SendToOutPut(filtrationResult);
        }
        public void FilterWithAnonymousFunction()
        {
            outs.SendToOutPut("------FilterWithAnonymousFunction");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = delegate(string x) { return x.Contains(condition.CompareToObject); };
            var filtrationResult = linqEngine.Filter(src.GetSource(), condition);
            outs.SendToOutPut(filtrationResult);
        }
        public void FilterWithAnonymousFunction1()
        {
            outs.SendToOutPut("------FilterWithAnonymousFunction");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = (string x)=> { return x.Contains(condition.CompareToObject); };
            var filtrationResult = linqEngine.Filter(src.GetSource(), condition);
            outs.SendToOutPut(filtrationResult);
        }
        public void FilterWithLamdaExpression()
        {
            outs.SendToOutPut("------FilterWithLamdaExpression");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = (x) => { return x.Contains(condition.CompareToObject); };
            var filtrationResult = linqEngine.Filter(src.GetSource(), condition);
            outs.SendToOutPut(filtrationResult);
        }
        public void FilterWithLamdaExpression1()
        {
            outs.SendToOutPut("------FilterWithLamdaExpression");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = (x) => x.Contains(condition.CompareToObject);
            var filtrationResult = linqEngine.Filter(src.GetSource(), condition);
            outs.SendToOutPut(filtrationResult);
        }
        public void FilterWithQuery()
        {
            outs.SendToOutPut("------FilterWithQuery");
            condition = new ConditionToCompare<string>("it");
            var filtrationResult = from  x in src.GetSource()
                                   where x.Contains( condition.CompareToObject)
                                   select x;
            outs.SendToOutPut(filtrationResult);
        }
        public void FilterWithExtention()
        {
            outs.SendToOutPut("------FilterWithExtention");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = (x) => x.Contains(condition.CompareToObject);
            var filtrationResult = (src.GetSource()).FilterExt(condition);
            outs.SendToOutPut(filtrationResult);
        }
        public void Filter()
        {
            outs.SendToOutPut("------Filter");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = (x) => { return x.Contains(condition.CompareToObject); };
            var filtrationResult = linqEngine.Filter(src.GetSource(), condition);
            outs.SendToOutPut(filtrationResult);
        }
        public void Take()
        {
            outs.SendToOutPut("------Take");
            condition = new ConditionToCompare<string>(2);
            var res = linqEngine.Take(src.GetSource(), condition);
            outs.SendToOutPut(res);
        }
        public void Skip()
        {
            outs.SendToOutPut("------Skip");
            condition = new ConditionToCompare<string>(3);
            var res = linqEngine.Skip(src.GetSource(), condition);
            outs.SendToOutPut(res);
        }
        public void TakeWhile()
        {
            outs.SendToOutPut("------TakeWhile");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = (x) => { return x.Contains(condition.CompareToObject); };
            var res = linqEngine.TakeWhile(src.GetSource(), condition);
            outs.SendToOutPut(res);
        }
        public void SkipWhile()
        {
            outs.SendToOutPut("------SkipWhile");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = (x) => { return x.Contains(condition.CompareToObject); };
            var res = linqEngine.SkipWhile(src.GetSource(), condition);
            outs.SendToOutPut(res);
        }
        public void Distict()
        {
            outs.SendToOutPut("------Distict");

            var res = linqEngine.Distinct(src.GetSource(), null);
            outs.SendToOutPut(res);
        }
        public void Join()
        {
            var vendors = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors[2], VendorName = "Zorile" } };
            var res = vendors.Join(matetials, vendor => vendor.Name, material => material.VendorName,
                (vendor, material) =>
                    new { VendorName = vendor.Name, MaterialName = material.Name });

            foreach (var a in res)
            {
                Console.WriteLine("Vendor={0},Material={1}", a.VendorName, a.MaterialName);
            }
        }
        public void GroupJoin()
        {
            var vendors = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors[2], VendorName = "Zorile" } };
            var res = vendors.GroupJoin(matetials, vendor =>
                vendor.Name, material => material.VendorName, (vendor, materialCollection) =>
                    new { VendorName = vendor.Name, Materials = materialCollection.Select(material => material.Name) });

            foreach (var a in res)
            {
                Console.WriteLine("Vendor={0}", a.VendorName);
                foreach (var material in a.Materials)
                { Console.WriteLine("      Material={0}", material); }
            }
        }
        public void Zip()
        {
            Vendor[] vendors = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            Material[] matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors[2], VendorName = "Zorile" } };
            var res = vendors.Zip(matetials, (vendor, material) => vendor.Name + " " + material.Name);
            foreach (var a in res)
            {
                Console.WriteLine(a);
            }
        }
        public void OrderBy()
        {
            outs.SendToOutPut("------OrderBy");
            outs.SendToOutPut(src.GetSource());
            var res = linqEngine.OrderBy(src.GetSource());
            outs.SendToOutPut(res);
        }
        public void ThenBy()
        {
            Vendor[] vendors = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            Material[] matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors[2], VendorName = "Zorile" } };
            var res = vendors.Join(matetials, vendor => vendor.Name, material => material.VendorName, (vendor, material) => new { VendorName = vendor.Name, MaterialName = material.Name });
            var res1 = res.OrderBy(x => x.VendorName).ThenBy(x => x.MaterialName);
            foreach (var a in res)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("-------------------------------------------");
            foreach (var a in res1)
            {
                Console.WriteLine("Vendor={0},Material={1}", a.VendorName, a.MaterialName);
            }
        }

        public void OrderByDescending()
        {
            outs.SendToOutPut("------OrderByDescending");
            outs.SendToOutPut(src.GetSource());
            var result = linqEngine.OrderByDescending(src.GetSource());
            outs.SendToOutPut(result);
        }

        public void ThenByDescending()
        {
            Vendor[] vendors = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            Material[] matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors[2], VendorName = "Zorile" } };
            var res = vendors.Join(matetials, vendor => vendor.Name, material => material.VendorName, (vendor, material) => new { VendorName = vendor.Name, MaterialName = material.Name });
            var res1 = res.OrderByDescending(x => x.VendorName).ThenByDescending(x => x.MaterialName);
            foreach (var a in res)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("-------------------------------------------");
            foreach (var a in res1)
            {
                Console.WriteLine("Vendor={0},Material={1}", a.VendorName, a.MaterialName);
            }
        }

        public void Reverse()
        {
            outs.SendToOutPut("------Reverse");
            outs.SendToOutPut(src.GetSource());
            var res = linqEngine.Reverse(src.GetSource());
            outs.SendToOutPut(res);
        }

        public void GroupBy()
        {
            condition = new ConditionToCompare<string>();
            var vendors = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors[2], VendorName = "Zorile" } };
            var res = vendors.Join(matetials, vendor => vendor.Name, material => material.VendorName,
                (vendor, material) =>
                    new { VendorName = vendor.Name, MaterialName = material.Name }).GroupBy(vendor => vendor.VendorName, condition);

            foreach (var a in res)
            {
                Console.WriteLine("Vendor={0}", a.Key);
                foreach (var b in a)
                {
                    Console.WriteLine("-----Vendor={0}", b.MaterialName);
                }
            }
        }

        public void Concat()
        {
            LinQEngine<Vendor, Vendor> linqEngine1 = LinQEngine<Vendor, Vendor>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }};
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" } };
            var res = linqEngine1.Concat( vendors1, vendors2);

            foreach (var a in res)
            {
                Console.WriteLine("Vendor={0}", a.Name );
            }
        }

    }
}
