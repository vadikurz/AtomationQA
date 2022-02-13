using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondTask;

namespace SecondTaskTests
{
    [TestClass]
    public class NumberConverterTests
    {
        [TestMethod]
        [DataRow("-10011", -19, 2)]
        public void TestConvertPositive(string expected, int number, int toBase)
        {
            var converter = new NumberConverter();

            string convertedNumber = converter.Convert(number, toBase);

            Assert.AreEqual(expected, convertedNumber);
        }
    }
}
