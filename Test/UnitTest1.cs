using Jenkins_build;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {   
            Add calculator = new Add();
            int a = 5;
            int b = 3;
            int expectedSum = 8;
            
            int actualSum = calculator.Addition(a, b);

            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}