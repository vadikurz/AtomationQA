using System;

namespace FourthTask
{
    public class Bird : IFlyable
    {
        private const string SpeedValidationExceptionMessage = "The Bird Speed is 0 km/h";
        private const string DistanceValidationExceptionMessage = "The Bird cannot fly more than 100 kilometers";
        public const int MaxDistance = 100;
        public const int MinSpeed = 0; 
        public const int MaxSpeed = 20; 

        public Point CurrentPoint { get; private set; }

        private int speed;

        public int Speed
        {
            get => speed;
            set
            {
                if (value is <= MinSpeed or > MaxSpeed)
                {
                    throw new ArgumentOutOfRangeException(null,"The bird speed must be between 0 and 20 km/h");
                }
                speed = value;
            }
        }

        public Bird(Point currentPoint)
        {
            CurrentPoint = currentPoint;
            Speed = RandomSpeed(); // Random speed in range from 0 to 20 km/h
        }

        private int RandomSpeed()
        { 
            Random random = new Random();

            return random.Next(MinSpeed, MaxSpeed);
        }

        public void FlyTo(Point destinationPoint)
        {
            double distance = CurrentPoint.GetDistance(destinationPoint);

            if (distance > MaxDistance)
            {
                throw new ArgumentOutOfRangeException(nameof(distance), DistanceValidationExceptionMessage);
            }

            if (!IsPossibleToFly())
            {
                throw new InvalidOperationException(SpeedValidationExceptionMessage);
            }

            CurrentPoint = destinationPoint;
        }

        public double GetFlyTime(Point destinationPoint)
        {
            if (!IsPossibleToFly())
            {
                throw new InvalidOperationException(SpeedValidationExceptionMessage);
            }

            double distance = CurrentPoint.GetDistance(destinationPoint);

            if (distance > MaxDistance)
            {
                throw new ArgumentOutOfRangeException(nameof(distance), DistanceValidationExceptionMessage);
            }

            return CurrentPoint.GetDistance(destinationPoint) / Speed;
        }

        private bool IsPossibleToFly() => Speed != 0;
    }
}
