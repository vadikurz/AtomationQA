using System.Runtime.Serialization;
using FifthTask.Exceptions;
using FifthTask.Parts;

namespace FifthTask.Vehicles
{
    [DataContract]
    public class Car : Vehicle
    {
        [DataMember]
        public CarBody BodyType { get; private set; }

        public Car(Engine engine, Transmission transmission, Chassis chassis, CarBody bodyType) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels < 4)
            {
                throw new IncorrectValueException("A car cannot have less than 4 wheels.");
            }

            BodyType = bodyType;
        }

        public override string ToString() => $"Car:\n{base.ToString()}Body type: {BodyType}\n";
    }
}
