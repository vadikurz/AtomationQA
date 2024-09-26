using FourthTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourthTaskTests
{
    [TestClass]
    public class PointMethodsTests
    {
        public const double Delta = 1e-6;
        [TestMethod]
        [DataRow(792.13950791, new[] { 17, 3, 5 }, new[] { 143, 256, 745 })]
        public void GetDistancePositiveTest(double expectedDistance, int[] startingPoint, int[] destination)
        {
            var startPoint = new Point(startingPoint[0], startingPoint[1], startingPoint[2]);
            var destinationPoint = new Point(destination[0], destination[1], destination[2]);

            double actualDistance = startPoint.GetDistance(destinationPoint);

            Assert.AreEqual(expectedDistance, actualDistance, Delta);
        }

    }
}