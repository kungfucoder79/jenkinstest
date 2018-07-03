using NUnit.Framework;
using System.Threading;

namespace jenkinstest.test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Thread.Sleep(10000);
        }

        [Test]
        public void TestMethod2()
        {
            Thread.Sleep(2000);
        }
    }
}
