using System.Runtime.Serialization;
using FifthTask.Parts;

namespace FifthTask.Vehicles
{
    [DataContract]
    [KnownType(typeof(Bus))]
    [KnownType(typeof(Car))]
    [KnownType(typeof(Scooter))]
    [KnownType(typeof(Truck))]
    public abstract class Vehicle
    {
        [DataMember]
        public Engine Engine { get; private set; }

        [DataMember]
        public Transmission Transmission { get; private set; }

        [DataMember]
        public Chassis Chassis { get; private set; }

        protected Vehicle(Engine engine, Transmission transmission, Chassis chassis)
        {
            Engine = engine;
            Transmission = transmission;
            Chassis = chassis;
        }

        public override string ToString() => $"Engine:\n{Engine}\nTransmission:\n{Transmission}\nChassis:\n{Chassis}\n";
    }
}
