using System;
using System.Collections.Generic;
using ThirdTask.Parts;
using ThirdTask.Vehicles;

namespace ThirdTask
{
    public class Program
    {
        public static List<Vehicle> CreateVehicles()
            => new()
            {
                new Car
                (
                    new Engine(300, 3, EngineType.Diesel, "1234567v"),
                    new Transmission(TransmissionType.Automatic, 7, "Aisin"),
                    new Chassis(4, "12345v2", 1000),
                    bodyType: CarBody.StationWagon
                ),

                new Bus
                (
                    new Engine(155, 2, EngineType.Electric, "v21r332502"),
                    new Transmission(TransmissionType.Manual, 8, "ZF"),
                    new Chassis(4, "004522vr34", 2000),
                    numberOfSeats: 20
                ),

                new Scooter
                (
                    new Engine(40, 0.5, EngineType.Electric, "87tr34wqe"),
                    new Transmission(TransmissionType.Manual, 8, "Aisin"),
                    new Chassis(2, "002245vr99", 200),
                    maxSpeed: 70
                ),

                new Truck
                (
                    new Engine(200, 3, EngineType.Electric, "dr3407tye"),
                    new Transmission(TransmissionType.Automatic, 8, "ZF"),
                    new Chassis(4, "456308ht95", 2500),
                    liftingCapacity: 5
                )
            };

        public static void Main(string[] args)
        {
            try
            {
                var vehicles = CreateVehicles();

                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine(vehicle.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}