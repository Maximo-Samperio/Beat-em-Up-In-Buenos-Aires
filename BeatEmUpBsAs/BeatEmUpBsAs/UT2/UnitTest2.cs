using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Mime;

namespace UT2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            int positionX = 10;
            int positionY = 20;
      

            var vector = new Vector2(positionX, positionY);

            var expectedresult = $"Position - X : {positionX} / Y : {positionY}\n";

            var result = vector.ToString();

            Assert.AreEqual(expectedresult, vector);

           
        }
    }
}
