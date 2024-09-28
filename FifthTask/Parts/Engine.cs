using System.Runtime.Serialization;

namespace FifthTask.Parts
{
    [DataContract]
    public class Engine
    {
        [DataMember]
        public int Power { get; private set; }

        [DataMember]
        public double Capacity { get; private set; }

        [DataMember]
        public EngineType Type { get; private set; }

        [DataMember]
        public string SerialNumber { get; private set; }

        public Engine(int power, double capacity, EngineType type, string serialNumber)
        {
            Power = power;
            Capacity = capacity;
            Type = type;
            SerialNumber = serialNumber;
        }

        public override string ToString() => $"Power: {Power}\nSerial number: {SerialNumber}\nCapacity: {Capacity}\nType: {Type}";
    }
}
