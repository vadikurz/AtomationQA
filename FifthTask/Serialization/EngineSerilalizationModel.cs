using System.Runtime.Serialization;

namespace FifthTask.Serialization
{
    [DataContract]
    public class EngineSerializationModel
    {
        [DataMember]
        public int Power { get; private set; }

        [DataMember]
        public EngineType Type { get; private set; }

        [DataMember]
        public string SerialNumber { get; private set; }

        private EngineSerializationModel() { }

        public EngineSerializationModel(int power, EngineType type, string serialNumber)
        {
            Power = power;
            Type = type;
            SerialNumber = serialNumber;
        }
    }
}
