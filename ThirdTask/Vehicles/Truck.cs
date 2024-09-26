using System;

namespace ThirdTask
{
    public class Truck : Vehicle
    {
        public ushort LiftingCapacity { get; }

        public Truck(Engine engine, Transmission transmission, Chassis chassis, ushort liftingCapacity) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels < 4)
            {
                throw new ArgumentOutOfRangeException(nameof(chassis), "A truck cannot have less than 4 wheels of chassis.");
            }

            LiftingCapacity = liftingCapacity;
        }

        public override string ToString() => $"Truck:\n{base.ToString()}Lifting capacity: {LiftingCapacity}\n";
    }
}