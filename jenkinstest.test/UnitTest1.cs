using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace jenkinstest.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Thread.Sleep(10000);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Thread.Sleep(2000);
        }
    }
}
