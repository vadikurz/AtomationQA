using System;

namespace FourthTask
{
    public class Point
    {
        private const string CoordinateValidationExceptionMessage = "Coordinates cannot be negative";

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public Point(int x, int y, int z)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x), CoordinateValidationExceptionMessage);
            }

            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y), CoordinateValidationExceptionMessage);
            }

            if (z < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(z), CoordinateValidationExceptionMessage);
            }

            X = x;
            Y = y;
            Z = z;
        }

        public double GetDistance(Point destination)
        {
            var power = 2;

            return Math.Sqrt(Math.Pow(destination.X - X, power) + Math.Pow(destination.Y - Y, power) + Math.Pow(destination.Z - Z, power));
        }

        public override string ToString() => $"X: {X}\nY: {Y}\nZ: {Z}\n";
    }
}
