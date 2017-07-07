using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkwithArrays; 

namespace UnitTestProject1
{
    [TestClass]
    public class StringProcessorTest
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
            var stringProcessor = new StringProcessor();

            var processor = new TestStringProcessor(stringReader, stringProcessor);
            processor.CountDifferent();  
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void CountDifferent_ReturnsCorrectCountOfDifferentChars()
        {
            var stringProcessor = new StringProcessor();
            var count = stringProcessor.CountDifferent("test string 1");
            Assert.AreEqual(9, count);
        }

    }
}