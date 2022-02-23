using System.Runtime.Serialization;
using FifthTask.Exceptions;
using FifthTask.Parts;

namespace FifthTask.Vehicles
{
    [DataContract]
    public class Scooter : Vehicle
    {
        public const ushort MaximumSpeed = 90; 

        [DataMember]
        public ushort MaxSpeed { get; private set; }

        public Scooter(Engine engine, Transmission transmission, Chassis chassis, ushort maxSpeed) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels < 2 || chassis.NumberOfWheels > 3)
            {
                throw new IncorrectValueException("The number of wheels on the scooter can be from 2 before 3");
            }

            if (maxSpeed > MaximumSpeed)
            {
                throw new IncorrectValueException("The speed of the scooter cannot be more than 90 km/h");
            }

            MaxSpeed = maxSpeed;
        }

        public override string ToString() => $"Scooter:\n{base.ToString()}Max speed: {MaxSpeed}\n";
    }
}
