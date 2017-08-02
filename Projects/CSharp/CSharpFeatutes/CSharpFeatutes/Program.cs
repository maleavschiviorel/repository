using System;
using static System.Console;
namespace CSharpFeatutes
{
    class Program
    {
        public class TestClass
        {
            public string Field1 { get; set; }
            public int? Field2 { get; set; }
            public string Field1Field2() => (Field1 ?? "null " + Field2.ToString());
            public Tuple<string, int> TupleField1Field2() => (new Tuple<string, int>(Field1, Field2.Value));
        }
        public class ClassFeature
        {
            public void TestDefaultParam(TestClass testClass, string str1 = "qqq")
            {
                WriteLine("{0}={1}", nameof(testClass), testClass?.Field1 ?? "null");
            }

            public void TestNullable(int? intObj, string str2 = "qqq")
            {
                Console.WriteLine($"intObj={intObj ?? -1},str2={str2}");
            }
            public void ShowField1Field2(TestClass testClass)
            {
                WriteLine("{0}={1}", nameof(testClass), testClass.Field1Field2());
            }
            public void ShowTupleField1Field2(TestClass testClass)
            {
                WriteLine("{0}=Tuple=Item1={1},Item2={2}", nameof(testClass), testClass.TupleField1Field2().Item1, testClass.TupleField1Field2().Item2);
            }
            public bool TestOut(out int intOut, string str1)
            {
                intOut = 10;

                return true;
            }
        }
        static void Main(string[] args)
        {
            ClassFeature classFeature = new ClassFeature();
            classFeature.TestDefaultParam(null);
            classFeature.TestDefaultParam(new TestClass() { Field1 = "aaa" });
            if (classFeature.TestOut(out int newInt, ""))
                WriteLine($"newInt={newInt}");

            dynamic classFeature1 = new ClassFeature();
            classFeature1.TestNullable(null, null);
            classFeature1.TestNullable(str2: "bbb", intObj: 200);

            classFeature1.ShowField1Field2(new TestClass() { Field1 = null });
            classFeature1.ShowTupleField1Field2(new TestClass() { Field1 = "eee", Field2 = 40 });

            //C# 7 trebuie de vazut

            Console.ReadLine();
        }
    }
}
