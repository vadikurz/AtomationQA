using System.Runtime.Serialization;

namespace FifthTask
{
    [DataContract]
    public class Chassis
    {
        [DataMember]
        public ushort NumberOfWheels { get; private set; }

        [DataMember]
        public string SerialNumber { get; private set; }

        [DataMember]
        public ushort PermissibleLoad { get; private set; }

        public Chassis(ushort numberOfWheels, string serialNumber, ushort permissibleLoad)
        {
            NumberOfWheels = numberOfWheels;
            SerialNumber = serialNumber;
            PermissibleLoad = permissibleLoad;
        }

        public override string ToString() => $"{NumberOfWheels}\n{SerialNumber}\n{PermissibleLoad}\n";
    }
}
