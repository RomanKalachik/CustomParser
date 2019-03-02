using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("2.0", Evaluator.Evaluate("1 1 +"));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(Evaluator.Evaluate("2 -3 *"), "-6.0");
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(Evaluator.Evaluate("1 1 + 2 3 * -"), "-4.0");
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual(Evaluator.Evaluate("1 3 / 2 *"), "0.666666666666667");
        }
        [Test]
        public void Test5()
        {
            Assert.AreEqual("20.0", Evaluator.Evaluate("10 1 2 + 2 + 5 + +"));
        }
    }
}
