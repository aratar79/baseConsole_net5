using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var _mainService = new MainService(null, null, null);
            var result = _mainService.RunTest();
            Assert.IsTrue(result);
        }
    }
}
