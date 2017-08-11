using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using covariant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IPerson> _mockObjPerson = null;
        private void SetUp(string code, string name, int age)
        {
            _mockObjPerson = new Mock<IPerson>();//crearea moqului

            //setarile proprietatilor moqului 
            _mockObjPerson.SetupProperty(person => person.Code, code ?? "");
            _mockObjPerson.SetupProperty(person => person.Name, name ?? "");
            _mockObjPerson.SetupProperty(person => person.Age, age);

            //setarea returnului metodelor
            _mockObjPerson.Setup(person => person.ToString()).Returns(() => $"Code={_mockObjPerson.Object.Code}, Name={_mockObjPerson.Object.Name}, Age={_mockObjPerson.Object.Age}");

            _mockObjPerson.Setup(person => person.ToString1(It.IsAny<string>())).Returns((string str) =>
                $"{(str ?? "")}, Code={_mockObjPerson.Object.Code}, Name={_mockObjPerson.Object.Name}, Age={_mockObjPerson.Object.Age}");
        }
        public UnitTest1()
        {
            //--------------initializarea
            SetUp("11", "RRT", 20);
        }

        [TestMethod]
        public void TestMethod1()
        {
            IFactory<Food> pizaf = new PizzaFactory();
            Food food = pizaf.Create();
            Assert.AreEqual(food.GetType().ToString(), typeof(Pizza).ToString());
            Assert.IsInstanceOfType(food, typeof(Pizza));
        }

        [TestMethod]
        public void TestMethod2()
        {
            //--------------initializarea----
            //se scoate obiectul creat de moq
            IPerson personObj = _mockObjPerson.Object;

            var orderWithOutPerson = new Order();
            var orderWithPerson = new Order(personObj);

            //--------------Act----------------
            string str1 = orderWithOutPerson.ToString();
            string str2 = orderWithPerson.ToString();


            //--------------Assertul------------
            //verificare a executiei(sa fie o singura data) cu moqul
            _mockObjPerson.Verify(person => person.ToString(), Times.Exactly(1));

            //verificarea raspunsului ToString1 cu Assertul
            Assert.AreEqual("Order of ", str1);
            Assert.AreEqual("Order of Code=11, Name=RRT, Age=20", str2);
        }
    }
}
