using System;
using System.Runtime.Serialization;
using FifthTask.Parts;

namespace FifthTask.Vehicles
{
    [DataContract]
    public class Bus : Vehicle
    {
        [DataMember]
        public ushort NumberOfSeats { get; private set; }

        public Bus(Engine engine, Transmission transmission, Chassis chassis, ushort numberOfSeats) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels < 4)
            {
                throw new ArgumentOutOfRangeException("A bus cannot have less than 4 wheels.");
            }

            NumberOfSeats = numberOfSeats;
        }

        public override string ToString() => $"Bus:\n{base.ToString()}Number of seats: {NumberOfSeats}\n";
    }
}
