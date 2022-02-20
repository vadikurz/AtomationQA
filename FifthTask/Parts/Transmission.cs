using System.Runtime.Serialization;

namespace FifthTask
{
    [DataContract]
    public class Transmission
    {
        [DataMember]
        public TransmissionType Type { get; private set; }

        [DataMember]
        public ushort NumberOfGears { get; private set; }

        [DataMember]
        public string Manufacturer { get; private set; }

        public Transmission(TransmissionType type, ushort numberOfGears, string manufacturer)
        {
            Type = type;
            NumberOfGears = numberOfGears;
            Manufacturer = manufacturer;
        }

        public override string ToString() => $"{Type}\n{NumberOfGears}\n{Manufacturer}\n";
    }
}
