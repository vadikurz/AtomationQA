namespace ThirdTask
{
    public class Transmission
    {
        public TransmissionType Type { get; }

        public ushort NumberOfGears { get; }

        public string Manufacturer { get; }

        public Transmission(TransmissionType type, ushort numberOfGears, string manufacturer)
        {
            Type = type;
            NumberOfGears = numberOfGears;
            Manufacturer = manufacturer;
        }

        public override string ToString() => $"Type: {Type}\nNumber of gears: {NumberOfGears}\nManufacturer {Manufacturer}";
    }
}