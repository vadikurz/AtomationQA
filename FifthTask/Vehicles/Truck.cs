using System.Runtime.Serialization;
using FifthTask.Exceptions;
using FifthTask.Parts;

namespace FifthTask.Vehicles
{
    [DataContract]
    public class Truck : Vehicle
    {
        public const ushort MaximumLiftingCapacity = 450;
        
        [DataMember]
        public ushort LiftingCapacity { get; private set; }

        public Truck(Engine engine, Transmission transmission, Chassis chassis, ushort liftingCapacity) : base(engine, transmission, chassis)
        {
            if (chassis.NumberOfWheels < 4)
            {
                throw new IncorrectValueException("A truck cannot have less than 4 wheels");
            }

            if (liftingCapacity > MaximumLiftingCapacity)
            {
                throw new IncorrectValueException("The lifting capacity of the truck cannot be more than 450 tons");
            }

            LiftingCapacity = liftingCapacity;
        }

        public override string ToString() => $"Truck:\n{base.ToString()}Lifting capacity: {LiftingCapacity}\n";
    }
}
