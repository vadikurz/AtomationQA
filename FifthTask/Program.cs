using System;
using System.Collections.Generic;
using System.Linq;
using FifthTask.Extensions;
using FifthTask.Parts;
using FifthTask.Serialization;
using FifthTask.Vehicles;

namespace FifthTask
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

        public static IEnumerable<ViewSerializer<ICollection<Vehicle>>> CreateViewSerializers()
            => new ViewSerializer<ICollection<Vehicle>>[]
            {
                new()
                {
                    Path = "vehicle_volume_more_than1,5.xml",
                    View = vs => vs
                        .Where(v => v.Engine.Capacity > 1.5)
                        .ToList()
                },

                new()
                {
                    Path = "only_bus_and_truck_engine_information.xml",
                    View = vs => vs.Where(v => v is Truck or Bus)
                        .Select(vehicle => vehicle.Engine)
                        .Select(engine => new EngineSerializationModel(engine.Power, engine.Type, engine.SerialNumber))
                        .ToList()
                },

                new()
                {
                    Path = "all_information_grouped_by_transmissiontype.xml",
                    View = vs => vs.GroupBy(v => v.Transmission.Type)
                        .Select(group => group.ToSerializationModel()).ToList()

                }
            };

        static void Main(string[] args)
        {
            try
            {
                var carPark = new CarPark();
               
                var car = new Car
                (
                    new Engine(300, 3, EngineType.Diesel, "1234567v"),
                    new Transmission(TransmissionType.Automatic, 7, "Aisin"),
                    new Chassis(4, "12345v2", 1000),
                    bodyType: CarBody.StationWagon
                );

                var bus = new Bus
                (
                    new Engine(155, 2, EngineType.Electric, "v21r332502"),
                    new Transmission(TransmissionType.Manual, 8, "ZF"),
                    new Chassis(4, "004522vr34", 2000),
                    numberOfSeats: 20
                );

                carPark.Add(car, "123");
                carPark.Add(bus, "124");

                var foundVehicle = carPark.GetAutoByParameter("NumberOfSeats", "20");

                carPark.UpdateAuto("123", bus);

                carPark.RemoveAuto("124");

                var vehicles = CreateVehicles();

                var viewSerializers = CreateViewSerializers();

                foreach (var serializer in viewSerializers)
                {
                    serializer.Execute(vehicles);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
