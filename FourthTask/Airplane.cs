using System;

namespace FourthTask
{
    public class Airplane : IFlyable
    {
        private const string DistanceValidationExceptionMessage = "The Airplane cannot fly more than 6000 kilometers";
        public const int StartingSpeed = 200; 
        public const int MaxSpeed = 900; 
        public const int MaxDistance = 6000; 

        public Point CurrentPoint { get; private set; }

        public Airplane(Point currentPoint)
        {
            CurrentPoint = currentPoint;
        }

        public void FlyTo(Point destinationPoint)
        {
            double distance = CurrentPoint.GetDistance(destinationPoint);

            if (distance > MaxDistance)
            {
                throw new ArgumentOutOfRangeException(nameof(distance), DistanceValidationExceptionMessage);
            }

            CurrentPoint = destinationPoint;
        }

        /// <summary>
        /// The airplane increases speed by 10 km/h every 10 km of flight from the initial speed of 200 km/h.
        /// </summary>
        /// <param name="destinationPoint"></param>
        /// <returns></returns>
        public double GetFlyTime(Point destinationPoint)
        {
            double distance = CurrentPoint.GetDistance(destinationPoint);

            if (distance > MaxDistance)
            {
                throw new ArgumentOutOfRangeException(nameof(distance),DistanceValidationExceptionMessage);
            }

            int numberOfSpeedIncreases = (int)(distance / 10);
            int airplaneSpeed = StartingSpeed;
            double time = 0;

            while (airplaneSpeed < MaxSpeed && distance > 10 && numberOfSpeedIncreases > 0)
            {
                time += 10.0 / airplaneSpeed;
                airplaneSpeed += 10;
                distance -= 10;
                numberOfSpeedIncreases -= 1;
            }

            return time + distance / airplaneSpeed;
        }
    }
}
