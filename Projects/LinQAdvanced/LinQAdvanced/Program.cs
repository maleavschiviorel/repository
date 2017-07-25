using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinQAdvanced.ClassesAndStructs;
using System.Collections;

namespace LinQAdvanced
{
    public class WorkWithTypes
    {
        public void TryChangeValueTypes(int i, StructEntity structEntity)
        {
            i = 15;
            structEntity.Id = 10;
            structEntity.Name = "Struct Entity  NewName";
        }
        public void TryChangeValueTypesSentByRef(ref int i, ref StructEntity structEntity)
        {
            i = 15;
            structEntity.Id = 10;
            structEntity.Name = "Struct Entity  NewName";
        }
        public void TryChangeValueTypesSentByOut(out int i, out StructEntity structEntity)
        {
            //i = 15;
            //structEntity.Id = 10;// da eroare:  use of unassigned out parameter 'structEntity' 
            //structEntity.Name = "Struct Entity  NewName";

            i = 15;
            structEntity = new StructEntity();
            structEntity.Id = 10;
            structEntity.Name = "Struct Entity  NewName";
        }
        public void TryChangeReferenceTypes(Entity structEntity)
        {
            structEntity.Id = 100;
            structEntity.Name = "Class Entity Object NewName";
        }

        public void WorkWithValueTypes()
        {
            int intValue = 3;
            StructEntity structEntityValue = new StructEntity() { Id = 1, Name = "Struct Entity Name" };
            Console.WriteLine("before TryChangeValueTypes intValue={0}; structEntityValue=Id={1},Name={2}", intValue, structEntityValue.Id, structEntityValue.Name);
            TryChangeValueTypes(intValue, structEntityValue);
            Console.WriteLine("after TryChangeValueTypes intValue={0}; structEntityValue=Id={1},Name={2}", intValue, structEntityValue.Id, structEntityValue.Name);
        }
        public void WorkWithReferenceTypes()
        {
            Entity EntityObject = new Entity() { Id = 1, Name = "Class Entity Object Name" };
            Entity SameReferenceToEntityObject = null;
            SameReferenceToEntityObject = EntityObject;
            Console.WriteLine("before TryChangeReferenceTypes EntityObject=Id={0},Name={1}", EntityObject.Id, EntityObject.Name);
            TryChangeReferenceTypes(EntityObject);
            Console.WriteLine("after TryChangeReferenceTypes SameReferenceToEntityObject=Id={0},Name={1}", EntityObject.Id, EntityObject.Name);
        }
        public void WorkWithValueTypesSentByRef()
        {
            int intValue = 3;
            StructEntity structEntityValue = new StructEntity() { Id = 1, Name = "Struct Entity Name" };
            Console.WriteLine("before TryChangeValueTypesSentByRef intValue={0}; structEntityValue=Id={1},Name={2}", intValue, structEntityValue.Id, structEntityValue.Name);
            TryChangeValueTypesSentByRef(ref intValue, ref structEntityValue);
            Console.WriteLine("after TryChangeValueTypesSentByRef intValue={0}; structEntityValue=Id={1},Name={2}", intValue, structEntityValue.Id, structEntityValue.Name);
        }
        public void WorkWithValueTypesSentByOut()
        {
            int intValue = 3;
            StructEntity structEntityValue = new StructEntity() { Id = 1, Name = "Struct Entity Name" };
            Console.WriteLine("before TryChangeValueTypesSentByOut intValue={0}; structEntityValue=Id={1},Name={2}", intValue, structEntityValue.Id, structEntityValue.Name);
            TryChangeValueTypesSentByOut(out intValue, out structEntityValue);
            Console.WriteLine("after TryChangeValueTypesSentByOut intValue={0}; structEntityValue=Id={1},Name={2}", intValue, structEntityValue.Id, structEntityValue.Name);
        }
        private ArrayList SortArrayOfIntegersUsingBubleSorting(ArrayList arr)
        {
            bool wassorted = false;
            object tempvalue;
            do
            {
                wassorted = false;
                for (int i = 0; i < arr.Count - 1; i++)
                {
                    if ((int)arr[i] > (int)arr[i + 1])
                    {
                        tempvalue = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tempvalue;

                        wassorted = true;
                    }
                }
            } while (wassorted);
            return arr;
        }
        public void WorkingWithBoxingUnboxing()
        {
            int[] arrayOfInt = Enumerable.Aggregate<int, IEnumerable<int>>(Enumerable.Range(1, 10), Enumerable.Empty<int>(), (acumulator, entity) => entity % 2 == 0 ? acumulator.Concat(new List<int>() { entity, entity + 100 }) : acumulator.Concat(new List<int>() { entity })).ToArray();

            try
            {
                foreach (var i in arrayOfInt)
                {
                    Console.Write("{0} ~", i);
                }
            }
            catch (Exception ex)
            {
            }
            Console.WriteLine();
            ArrayList arrayListOfInt = new ArrayList(arrayOfInt);
            SortArrayOfIntegersUsingBubleSorting(arrayListOfInt);

            try
            {
                foreach (var i in arrayListOfInt)
                {
                    Console.Write("{0} ~", i);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestLinQEngine tlinq = new TestLinQEngine();
            //tlinq.FilterWithDelegate();
            //tlinq.FilterWithAnonymousFunction();
            //tlinq.FilterWithAnonymousFunction1();
            //tlinq.FilterWithLamdaExpression();
            //tlinq.FilterWithLamdaExpression1();
            //tlinq.FilterWithQuery();
            //tlinq.FilterWithExtention();

            //tlinq.Filter();
            //tlinq.Take();
            //tlinq.Skip();
            //tlinq.TakeWhile();
            //tlinq.SkipWhile();
            //tlinq.Distict();
            //tlinq.Join();
            //tlinq.GroupJoin ();
            //tlinq.Zip();
            // tlinq.OrderBy();
            //tlinq.ThenBy();
            //tlinq.OrderByDescending();
            //tlinq.ThenByDescending();
            //tlinq.Reverse();
            //tlinq.GroupBy();
            //tlinq.Concat();  

            //tlinq.Union ();
            //tlinq.Intersect();
            //tlinq.Except();
            //tlinq.OfType();
            //tlinq.Cast();
            //tlinq.ToArrayTolist();
            //tlinq.ToDictionary();
            //tlinq.ToLookUp();
            //tlinq.AsEnumerable();
            //tlinq.AsQueryable();
            //tlinq.FirstFirstOrDefault();
            // tlinq.LastLastOrDefault ();
            // tlinq.SigleSingleOrDefault();
            // tlinq.ElementAtElementAtOrDefault();
            //tlinq.DefaultIfEmpty();
            //tlinq.CountLongCount();
            //tlinq.MinMax();
            //tlinq.SumAverage();
            // tlinq.Agregate();
            //tlinq.Contains();
            //tlinq.Any();
            //tlinq.All();
            //tlinq.SequanceEqual();  
            // tlinq.Empty();
            //tlinq.Repeat();
            //tlinq.Range();
            //tlinq.Closure();
            //tlinq.Closure1();
            //----------------------------------------

            WorkWithTypes workWithTypes = new WorkWithTypes();
            // MyFunction();eroare (MyFunction nu este statica) cere sa fie creat un obiect ca apoi sa fie chemat din obiect 
            workWithTypes.WorkingWithBoxingUnboxing();
            Console.ReadLine();
        }
        private void MyFunction()
        { }
    }
}
