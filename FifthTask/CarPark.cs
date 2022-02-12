using System.Collections.Generic;
using System.Linq;
using FifthTask.Vehicles;

namespace FifthTask
{
    public class CarPark
    {
        public Dictionary<string, Vehicle> Vehicles { get; set; }

        public CarPark()
        {
            Vehicles = new Dictionary<string, Vehicle>();
        }

        public void Add(Vehicle vehicle, string id)
        {
            Vehicles.Add(id, vehicle);
        }

        public Vehicle GetAutoByParameter(string parameter, string value)
        {
            foreach (var vehicle in Vehicles.Values)
            {
                var properties = vehicle.GetType().GetProperties();

                if (properties.Any(property =>
                    property.Name == parameter && property.GetValue(vehicle)?.ToString() == value))
                {
                    return vehicle;
                }
            }

            return null;
        }

        public void UpdateAuto(string id, Vehicle vehicle)
        {
            if (!Vehicles.ContainsKey(id))
            {

            }

            Vehicles[id] = vehicle;
        }

        public void RemoveAuto(string id)
        {
            if (!Vehicles.ContainsKey(id))
            {

            }

            Vehicles.Remove(id);
        }
    }
}
