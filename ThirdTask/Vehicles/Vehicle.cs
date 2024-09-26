namespace ThirdTask
{
    public abstract class Vehicle
    {
        public Engine Engine { get; }

        public Transmission Transmission { get; }

        public Chassis Chassis { get; }

        protected Vehicle(Engine engine, Transmission transmission, Chassis chassis)
        {
            Engine = engine;
            Transmission = transmission;
            Chassis = chassis;
        }

        public override string ToString() => $"Engine:\n{Engine}\nTransmission:\n{Transmission}\nChassis:\n{Chassis}\n";
    }
}