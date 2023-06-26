using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x = 3;
            int y = 4;

            var vector = new Vector2(x, y);

            var ExpectedResult = $"X : {x} / Y : {y}";

            var Result = vector.ToString();

            Assert.AreEqual(ExpectedResult, Result);
        }
    }
}