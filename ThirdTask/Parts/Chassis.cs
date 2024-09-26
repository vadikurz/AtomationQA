namespace ThirdTask
{
    public class Chassis
    {
        public ushort NumberOfWheels { get; }

        public string SerialNumber { get; }

        public ushort PermissibleLoad { get; }

        public Chassis(ushort numberOfWheels, string serialNumber, ushort permissibleLoad)
        {
            NumberOfWheels = numberOfWheels;
            SerialNumber = serialNumber;
            PermissibleLoad = permissibleLoad;
        }

        public override string ToString() => $"Number of wheels: {NumberOfWheels}\nSerial number: {SerialNumber}\nPermissible load: {PermissibleLoad}";

    }
}