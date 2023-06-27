using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x = 3;
            int y = 4;

            var vector = new Vector2(x, y);

            var expectedresult = $"X : {x} / Y : {y}";

            var result = vector.ToString();
            Assert.AreEqual(expectedresult, result);

        }
    }
}
