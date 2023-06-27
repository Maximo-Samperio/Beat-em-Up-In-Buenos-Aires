using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom;
using System.Collections.Specialized;
using System.Net.Mime;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int positionX = 10;
            int positionY = 20;
            int angle = 50;
            int scaleX = 20;
            int scaleY = 20;

            var vector = new Vector2(positionX, positionY);

            var expectedresult = $"Position - X : {positionX} / Y : {positionY}\n" +
                                 $"Rotation - Angle : {angle}\n" +
                                 $"Scale - X : {scaleX} / Y : {scaleY}";

            var result = vector.ToString();
            Assert.AreEqual(expectedresult, result);





        }
    }
}
