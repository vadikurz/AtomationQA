using FourthTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourthTaskTests
{
    [TestClass]
    public class DroneMethodsTests
    {
        public const double Delta = 1e-6;
        [TestMethod]
        [DataRow(9.1366076855, new[] { 15, 2, 3 }, new[] { 400, 232, 90 }, 50)]
        public void GetFlyTimePositiveTest(double expectedTime, int[] currentPoint, int[] destinationPoint, int speed)
        {
            var drone = new Drone(new Point(currentPoint[0], currentPoint[1], currentPoint[2]), speed);

            double actualTime = drone.GetFlyTime(new Point(destinationPoint[0], destinationPoint[1], destinationPoint[2]));

            Assert.AreEqual(expectedTime, actualTime, Delta);
        }
    }
}