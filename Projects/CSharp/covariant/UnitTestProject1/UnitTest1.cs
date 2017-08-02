using System.Collections.Generic;
using System.Linq;
using covariant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IFactory<Food> pizaf = new PizzaFactory();
            Food pizza = pizaf.Create();
            Assert.AreNotEqual(pizza.GetType(), typeof(Pizza).ToString());
        }

        [TestMethod]
        public void TestMethod2()
        {
            var MockObjPerson = new Moq.Mock<IPerson>();
            MockObjPerson.SetupProperty(person => person.Code, "11");
            MockObjPerson.SetupProperty(person => person.Name, "RRT");
            MockObjPerson.SetupProperty(person => person.Age, 20);
            MockObjPerson.Setup(person => person.ToString1(It.IsAny<string>())).Returns((string str)=>(str??"") + ", Code=" + "11"+ ", Name=" + "RRT" + ", Age=" + 20.ToString());
            IPerson personObj = MockObjPerson.Object;
           string str1= personObj.ToString1("yyy");
            MockObjPerson.Verify(person => person.ToString1(It.IsAny<string>()), Times.Once);
            Assert.AreEqual("yyy, Code=11, Name=RRT, Age=20", str1);
            List<Person> persons = new List<Person>
            {
                new Person {Code = "!C", Name = "AAA", Age = 20},
                new Person {Code = "!Q", Name = "BBB", Age = 30}
            };
            var q=persons.FirstOrDefault(x => x.Code.Equals("!W"));
            Assert.AreEqual(q,null);

        }
    }
}
