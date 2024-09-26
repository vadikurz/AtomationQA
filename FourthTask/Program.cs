using System;
using System.Collections.Generic;

namespace FourthTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var point = new Point(15, 2, 3);

                var flyables = new List<IFlyable>
                {
                    new Bird(point),
                    new Airplane(point),
                    new Drone(point, 50)
                };

                foreach (var flyable in flyables)
                {
                    flyable.FlyTo(new Point(75, 68, 45));
                    flyable.GetFlyTime(new Point(123, 150, 75));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
