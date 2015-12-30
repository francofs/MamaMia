using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace InputUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGFTSample()
        {
            MenuService ms = MenuService.GetInstance();

            Assert.AreEqual("eggs, toast, coffee", ms.GetOrderSummary("morning, 1, 2, 3"));
            Assert.AreEqual("eggs, toast, coffee", ms.GetOrderSummary("morning, 2, 1, 3"));
            Assert.AreEqual("eggs, toast, coffee(x3)", ms.GetOrderSummary("morning, 1, 2, 3, 3, 3"));
            Assert.AreEqual("steak, potato, wine, cake", ms.GetOrderSummary("night, 1, 2, 3, 4"));
            Assert.AreEqual("steak, potato(x2), cake", ms.GetOrderSummary("night, 1, 2, 2, 4"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidInputTests()
        {
            MenuService ms = MenuService.GetInstance();

            Assert.AreEqual("error", ms.GetOrderSummary("mornng, 1, 2, 3"));
            Assert.AreEqual("error", ms.GetOrderSummary(""));
            Assert.AreEqual("error", ms.GetOrderSummary("night"));
        }

        [TestMethod]
        public void MySample()
        {
            MenuService ms = MenuService.GetInstance();

            Assert.AreEqual("eggs, error, toast, coffee(x2)", ms.GetOrderSummary("morning, 1, 1, 2, 3, 3"));
            Assert.AreEqual("steak, error, potato(x3), wine, error, cake", ms.GetOrderSummary("night, 1, 1, 2, 2, 2, 3, 3, 4"));
            Assert.AreEqual("eggs, toast, coffee(x2), error", ms.GetOrderSummary("morning, 1, 2, 3, 3, 4"));
        }

    }
}
