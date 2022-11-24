using Lab10Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab10Test
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void NameOnlyConstructor()
        {
            Person actual = new Person("1");
            Person expected = new Person("1", 1, 1);
            Assert.AreEqual(actual, expected);
        }        
    }
}