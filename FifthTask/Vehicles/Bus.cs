using System.Runtime.Serialization;
using FifthTask.Exceptions;
using FifthTask.Parts;

namespace FifthTask.Vehicles
{
    [DataContract]
    public class Bus : Vehicle
    {
        public const ushort MaximumNumberOfSeats = 60;

        [DataMember]
        public ushort NumberOfSeats { get; private set; }

        public Bus(Engine engine, Transmission transmission, Chassis chassis, ushort numberOfSeats) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels < 4)
            {
                throw new IncorrectValueException("A bus cannot have less than 4 wheels.");
            }

            if (numberOfSeats > MaximumNumberOfSeats)
            {
                throw new IncorrectValueException("A bus cannot have more than 60 seats.");
            }

            NumberOfSeats = numberOfSeats;
        }

        public override string ToString() => $"Bus:\n{base.ToString()}Number of seats: {NumberOfSeats}\n";
    }
}
