using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkwithArrays; 

namespace UnitTestProject1
{
    [TestClass]
    public class StringOperatorTest
    {
        class TestStringReader : IStringReader
        {
            public string Read()
            {
                return "test string";
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var stringReader = new TestStringReader();
            var stringOperator = new StringOperator();

            var operatorObj = new TestStringOperator(stringReader, stringOperator);
            operatorObj.CountDifferent();  
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void CountDifferent_ReturnsCorrectCountOfDifferentChars()
        {
            var stringOperator = new StringOperator();
            var count = stringOperator.CountDifferent("test string 1");
            Assert.AreEqual(9, count);
        }

    }
}