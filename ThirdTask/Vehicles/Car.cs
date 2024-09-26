using System;
using ThirdTask.Parts;

namespace ThirdTask.Vehicles
{
    public class Car : Vehicle
    {
        public CarBody BodyType { get; }

        public Car(Engine engine, Transmission transmission, Chassis chassis, CarBody bodyType) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels < 4)
            {
                throw new ArgumentOutOfRangeException(nameof(chassis), "A car cannot have less than 4 wheels of chassis.");
            }

            BodyType = bodyType;
        }

        public override string ToString() => $"Car:\n{base.ToString()}Body type: {BodyType}\n";
    }
}