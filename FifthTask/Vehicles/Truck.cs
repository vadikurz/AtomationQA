using System;
using System.Runtime.Serialization;
using FifthTask.Parts;

namespace FifthTask.Vehicles
{
    [DataContract]
    public class Truck : Vehicle
    {
        [DataMember]
        public ushort LiftingCapacity { get; private set; }

        public Truck(Engine engine, Transmission transmission, Chassis chassis, ushort liftingCapacity) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels < 4)
            {
                throw new ArgumentOutOfRangeException("A truck cannot have less than 4 wheels.");
            }

            LiftingCapacity = liftingCapacity;
        }

        public override string ToString() => $"Truck:\n{base.ToString()}Lifting capacity: {LiftingCapacity}\n";
    }
}
