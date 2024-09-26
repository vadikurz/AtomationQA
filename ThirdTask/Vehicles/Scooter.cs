using System;

namespace ThirdTask
{
    public class Scooter : Vehicle
    {
        public ushort MaxSpeed { get; }

        public Scooter(Engine engine, Transmission transmission, Chassis chassis, ushort maxSpeed) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels is < 2 or > 3)
            {
                throw new ArgumentOutOfRangeException(nameof(chassis),"The number of wheels of chassis on the scooter can be from 2 before 3");
            }

            MaxSpeed = maxSpeed;
        }

        public override string ToString() => $"Scooter:\n{base.ToString()}Max speed: {MaxSpeed}\n";
    }
}