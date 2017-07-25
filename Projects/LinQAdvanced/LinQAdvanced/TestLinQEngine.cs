#define VisualStudio2017
using System;
using System.Linq;
using LinQAdvanced.ClassesAndStructs;
using System.Collections.Generic;

namespace LinQAdvanced
{

    public class TestLinQEngine
    {
        private SourceForLinQ src;

        private LinQEngine<string, string> linqEngine = LinQEngine<string, string>.GetLinqEngine();

        private ConditionToCompare<string> condition = null;

        private Output<object> outs = new Output<object>();

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
            condition.F1 = delegate (string x) { return x.Contains(condition.CompareToObject); };
            var filtrationResult = linqEngine.Filter(src.GetSource(), condition);
            outs.SendToOutPut(filtrationResult);
        }
        public void FilterWithAnonymousFunction1()
        {
            outs.SendToOutPut("------FilterWithAnonymousFunction");
            condition = new ConditionToCompare<string>("it");
            condition.F1 = (string x) => { return x.Contains(condition.CompareToObject); };
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
            var filtrationResult = from x in src.GetSource()
                                   where x.Contains(condition.CompareToObject)
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
            outs.SendToOutPut("------GroupBy");
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
                    Console.WriteLine("-----Material Name={0}", b.MaterialName);
                }
            }
        }

        public void Concat()
        {
            outs.SendToOutPut("------Concat");
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            var res = linqEngine1.Concat(vendors1, vendors2).Concat(matetials);
            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
            outs.SendToOutPut("--------------------");
            res = linqEngine1.Concat(vendors1, vendors2).Concat(matetials).OrderBy(x => x.ToString());

            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
        }
        public void Union()
        {
            outs.SendToOutPut("------Union");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            var res = linqEngine1.Union(vendors1, vendors2, condition1).Union(matetials, condition1);
            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
            outs.SendToOutPut("--------------------");
            res = linqEngine1.Union(vendors1, vendors2, condition1).Union(matetials, condition1).OrderBy(x => x.ToString());

            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
        }

        public void Intersect()
        {
            outs.SendToOutPut("------Intersect");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());

            var res = linqEngine1.Intersect(vendors1, vendors2, condition1);
            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
        }
        public void Except()
        {
            outs.SendToOutPut("------Except");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());

            var res = linqEngine1.Except(vendors1, vendors2, condition1);
            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
        }

        public void OfType()
        {
            outs.SendToOutPut("------OfType");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
            outs.SendToOutPut("-------------------------------------");
            res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).OfType<Vendor>();
            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
        }

        public void Cast()
        {
            outs.SendToOutPut("------Cast");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
            foreach (var a in res)
            {
                Console.WriteLine("obj={0}", a.ToString());
            }
            outs.SendToOutPut("-------------------------------------");
            res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Cast<Vendor>();//nu face aici casting dar in foreach la parcurgere
            try
            {
                foreach (var a in res)
                {
                    Console.WriteLine("obj={0}", a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }
        public void ToArrayTolist()
        {
            outs.SendToOutPut("------ToArrayTolist");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            //var res  nu poate fi declarat pentru ca mai jos la res se atribuie List ansa el deja este privit ca Array 
            dynamic res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).ToArray();
            foreach (var a in res)
            {
                Console.WriteLine("typeof({0}), obj={1}", a.GetType(), a.ToString());
            }
            outs.SendToOutPut("-------------------------------------");
            res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).ToList();
            foreach (var a in res)
            {
                Console.WriteLine("typeof({0}), obj={1}", a.GetType(), a.ToString());
            }
        }

        public void ToDictionary()
        {
            outs.SendToOutPut("------ToDictionary");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            var res = linqEngine1.Union(vendors1, vendors2, condition1).Union(matetials).ToDictionary(x => x.ToString());
            foreach (var key in res.Keys)
            {
                Console.WriteLine("typeof({0}), obj={1}", res[key].GetType().ToString().Split(new char[] { '.' }).Last(), res[key].ToString());
            }
        }

        public void ToLookUp()
        {
            outs.SendToOutPut("------ToLookUp");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());


            var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).ToLookup(x => x.ToString());
            foreach (var group in res)
            {
                Console.WriteLine("key={0}", group.Key);
                foreach (var entity in group)
                {
                    Console.WriteLine("       obj={0}", entity.ToString());

                }
            }
        }
        public void AsEnumerable()
        {
            outs.SendToOutPut("------AsEnumerable");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).AsEnumerable();
            foreach (var a in res)
            {
                Console.WriteLine("typeof({0}), obj={1}", a.GetType(), a.ToString());
            }
        }

        public void AsQueryable()
        {
            outs.SendToOutPut("------AsQueryable");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).AsQueryable();
            foreach (var a in res)
            {
                Console.WriteLine("typeof({0}), obj={1}", a.GetType(), a.ToString());
            }
        }

        public void FirstFirstOrDefault()
        {
            outs.SendToOutPut("------FirstFirstOrDefault");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            //var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).First(x => x.Id > 0);//daca nu este da eroare
            var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).FirstOrDefault(x => x.Id > 0);//daca nu este intoarce null
#if VisualStudio2017
            Console.WriteLine("typeof({0}), obj={1}", res?.GetType().ToString() ?? "{is null}", res?.ToString() ?? "{is null}");
#endif
        }
        public void LastLastOrDefault()
        {
            outs.SendToOutPut("------LastLastOrDefault");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            //var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Last();//daca nu este da eroare
            var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).LastOrDefault(x => x.Id == 0);//daca nu este intoarce null
#if VisualStudio2017
            Console.WriteLine("typeof({0}), obj={1}", res?.GetType().ToString() ?? "{is null}", res?.ToString() ?? "{is null}");
#endif
        }
        public void SigleSingleOrDefault()
        {
            outs.SendToOutPut("------SigleSingleOrDefault");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            Entity res = null;
            try
            {
                res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Single(x => x.ToString().Contains("Anvelope"));//daca sunt mai multe elemente in rezultat da eroare,daca nu este nici unul da eroare
#if VisualStudio2017               
                Console.WriteLine("typeof({0}), obj={1}", res?.GetType().ToString() ?? "{is null}", res?.ToString() ?? "{is null}");
#endif
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).SingleOrDefault(x => x.ToString().Contains("Agurdino#"));//daca sunt mai multe elemente in rezultat da eroare, daca nu este nici unul da null
#if VisualStudio2017
                Console.WriteLine("typeof({0}), obj={1}", res?.GetType().ToString() ?? "{is null}", res?.ToString() ?? "{is null}");
#endif
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }

        public void ElementAtElementAtOrDefault()
        {
            outs.SendToOutPut("------SigleSingleOrDefault");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            Entity res = null;
            int index = 3;
            try
            {
                res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).ElementAt(index);//// daca indexul e mai mare decint numarul de lemente -1 atunci da eroare

#if VisualStudio2017
                Console.WriteLine("element at index={0}, typeof({1}), obj={2}", index, res?.GetType().ToString() ?? "{is null}", res?.ToString() ?? "{is null}");
#endif
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                index = 20;
                res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).ElementAtOrDefault(index);// daca indexul e mai mare decint numarul de lemente -1 atunci intoarce null
#if VisualStudio2017                
                Console.WriteLine("element at index={0}, typeof({1}), obj={2}", index, res?.GetType().ToString() ?? "{is null}", res?.ToString() ?? "{is null}");
#endif
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }
        public void DefaultIfEmpty()
        {
            outs.SendToOutPut("------SigleSingleOrDefault");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Where(x => x.Id == 0).DefaultIfEmpty(new Entity());//daca multimea e goala atunci se creaza un element default in multime si se intoarce
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }

        public void CountLongCount()
        {
            outs.SendToOutPut("------CountLongCount");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                var count = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Count();
                var countLong = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Distinct(condition1).LongCount(x => x.GetType().Equals(typeof(Vendor)));
                outs.SendToOutPut("Count:" + count);
                outs.SendToOutPut("LongCount of typeof(" + typeof(Vendor).ToString().Split(new char[] { '.' }).Last() + "):" + countLong);

            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }

        public void MinMax()
        {
            outs.SendToOutPut("------MinMax");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                var MinEntity = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Min<Entity>();
                var MaxEntity = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Max<Entity>();
                outs.SendToOutPut("MinEntity: " + MinEntity.ToString());
                outs.SendToOutPut("MaxEntity: " + MaxEntity.ToString());
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }

        public void SumAverage()
        {
            outs.SendToOutPut("------SumAverage");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                var MinEntity = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Sum<Entity>(x => x.GetHashCode());
                var MaxEntity = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Average<Entity>(x => x.GetHashCode());
                outs.SendToOutPut("Sum: " + MinEntity.ToString());
                outs.SendToOutPut("Average: " + MaxEntity.ToString("0.0000"));
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }
        public void Agregate()
        {
            outs.SendToOutPut("------Agregate");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Aggregate("", (allNames, entity) => allNames += ((allNames != "" ? ", " : "") + entity.ToString()));
                outs.SendToOutPut("allEntities: " + res);
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }
        public void Contains()
        {
            outs.SendToOutPut("------Contains");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                Entity entityObj = new Vendor { Name = "Agurdino" };
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Contains(entityObj);
                outs.SendToOutPut(string.Format("object {0} is contained: {1}", entityObj.ToString(), res));
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }
        public void Any()
        {
            outs.SendToOutPut("------Any");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                Entity entityObj = new Vendor { Name = "Agurdino" };
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Any(x => x.Equals(entityObj));
                outs.SendToOutPut(string.Format("object {0} satisfies condition of presence: {1}", entityObj.ToString(), res));
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }

        public void All()
        {
            outs.SendToOutPut("------All");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };
            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());

            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).Any(x => x.Id == 0);
                outs.SendToOutPut(string.Format("all entities have id==0: {0}", res));
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
        }
        public void SequanceEqual()
        {
            outs.SendToOutPut("------SequanceEqual");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };

            var vendors11 = new Vendor[] { new Vendor { Name = "Knauf" }, new Vendor { Name = "Micheline" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };

            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors11.ToList());

            try
            {
                var res = vendors1.SequenceEqual(vendors1, condition1);
                outs.SendToOutPut(string.Format("both sequance are equal: {0}", res));
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }

        }
        public void Empty()
        {
            outs.SendToOutPut("------Empty");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };


            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());
            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            outs.SendToOutPut("--------------------------------");
            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).
                    Aggregate(Enumerable.Empty<Entity>(), (reposit, entity) => entity?.Name.ToLower().Contains("i") ?? false ? reposit.Union(new List<Entity>() { entity }) : reposit);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }

        }
        public void Repeat()
        {
            outs.SendToOutPut("------Repeat");
            ConditionToCompare<Entity> condition1 = new ConditionToCompare<Entity>();
            LinQEngine<Entity, Entity> linqEngine1 = LinQEngine<Entity, Entity>.GetLinqEngine();
            var vendors1 = new Vendor[] { new Vendor { Name = "Micheline" }, new Vendor { Name = "Knauf" }, new Vendor { Name = "Zorile" }, new Vendor { Name = "Ionel" } };
            var vendors2 = new Vendor[] { new Vendor { Name = "Kama" }, new Vendor { Name = "Agurdino" }, new Vendor { Name = "Hincu" }, new Vendor { Name = "Ionel" } };
            var matetials = new Material[] { new Material { Name = "Anvelope", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" }, new Material { Name = "Vopsea", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Clei", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Lac", Vendor = vendors1[1], VendorName = "Knauf" }, new Material { Name = "Incaltaminte", Vendor = vendors1[2], VendorName = "Zorile" }, new Material { Name = "Couciuc", Vendor = vendors1[0], VendorName = "Micheline" } };


            outs.SendToOutPut(vendors1.ToList());
            outs.SendToOutPut(vendors2.ToList());
            outs.SendToOutPut(matetials.ToList());
            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }
            outs.SendToOutPut("--------------------------------");
            try
            {
                var res = linqEngine1.Concat(vendors1, vendors2, condition1).Concat(matetials).
                    Aggregate(Enumerable.Repeat<Entity>(new Vendor { Name = "Ionel" }, 3), (reposit, entity) => entity?.Name.Contains("i") ?? false ? reposit.Concat(new List<Entity>() { entity }) : reposit);
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }

        }
        public void Range()
        {
            outs.SendToOutPut("------Range");
            try
            {
                foreach (var a in Enumerable.Range(0, 10))
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }

        }
        public void Closure()
        {
            outs.SendToOutPut("------Closure");
            int mynum = 100;

            try
            {
                foreach (var a in Enumerable.Range(0, 10))
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }

            outs.SendToOutPut("--------------------------------");

            var res = Enumerable.Range(0, 10).Aggregate(Enumerable.Empty<int>(), (reposit, num) => num % 2 == 0 ? reposit.Concat(new List<int>() { num, mynum++ }) : reposit.Concat(new List<int>() { num }));
            try
            {
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }

        }
        public void Closure1()
        {
            outs.SendToOutPut("------Closure1");
            int mynum = 100;

            try
            {
                foreach (var a in Enumerable.Range(0, 10))
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }

            outs.SendToOutPut("--------------------------------");

            Func<IEnumerable<int>, int, IEnumerable<int>> myDelegateFunction;

            myDelegateFunction = (IEnumerable<int> reposit, int num) =>
            {
                if (num % 2 == 0)
                    return reposit.Concat(new List<int>() { num, mynum++ });
                return reposit.Concat(new List<int>() { num });
            };

            var res = Enumerable.Range(0, 10).Aggregate(Enumerable.Empty<int>(), myDelegateFunction);
            try
            {
                foreach (var a in res)
                {
                    Console.WriteLine("typeof({0}), obj={1}", a.GetType().ToString().Split(new char[] { '.' }).Last(), a.ToString());
                }
            }
            catch (Exception ex)
            {
                outs.SendToOutPut("Error:" + ex.Message);
            }

        }

    }
}
