using System.Collections.Generic;
using System.Linq;
using FifthTask.Exceptions;
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
            if (Vehicles.ContainsKey(id))
            {
                throw new AddException("Vehicle with this ID already exists");
            } 
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
                throw new UpdateAutoException("No such identifier exists");
            }

            Vehicles[id] = vehicle;
        }

        public void RemoveAuto(string id)
        {
            if (!Vehicles.ContainsKey(id))
            {
                throw new RemoveAutoException("No such identifier exists");
            }

            Vehicles.Remove(id);
        }
    }
}
