using FourthTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourthTaskTests
{
    [TestClass]
    public class BirdMethodsTests
    {
        public const double Delta = 1e-6;
        [TestMethod]
        [DataRow(6.1726997515, new[] { 15, 2, 3 }, new[] { 100, 20, 35 }, 15)]
        public void GetFlyTimePositiveTest(double expectedTime, int[] currentPoint, int[] destinationPoint, int speed)
        {
            var bird = new Bird(new Point(currentPoint[0], currentPoint[1], currentPoint[2]));
            bird.Speed = speed;

            double actualTime = bird.GetFlyTime(new Point(destinationPoint[0], destinationPoint[1], destinationPoint[2]));

            Assert.AreEqual(expectedTime, actualTime, Delta);
        }
    }
}