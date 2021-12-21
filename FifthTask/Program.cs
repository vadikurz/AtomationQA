﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace FifthTask
{


    public class Program
    {
        public static IEnumerable<ViewSerializer<ICollection<Vehicle>>> CreateViewSerializer() 
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
                        .Select(engine => (EngineType: engine.Type, SerialNumber: engine.SerialNumber,
                            Power: engine.Power))
                        .ToList()
                },

                new()
                {
                    Path = "all_information_grouped_by_transmissiontype.xml",
                    View = vs => vs.OrderBy(v => v.Transmission.Type).ToList()
                }
            };

        static void Main(string[] args)
        {
            try
            {

                var car = new Car(new Engine(300, 3, EngineType.Diesel, "1234567v"),
                    new Transmission(TransmissionType.Automatic, 7, "Aisin"),
                    new Chassis(4, "12345v2", 1000), CarBody.StationWagon);

                var bus = new Bus(new Engine(155, 2, EngineType.Electric, "v21r332502"),
                    new Transmission(TransmissionType.Manual, 8, "ZF"),
                    new Chassis(4, "004522vr34", 2000), 20);

                var scooter = new Scooter(new Engine(40, 0.5, EngineType.Electric, "87tr34wqe"),
                    new Transmission(TransmissionType.Manual, 8, "Aisin"),
                    new Chassis(2, "002245vr99", 200), 70);

                var truck = new Truck(new Engine(200, 3, EngineType.Electric, "dr3407tye"),
                    new Transmission(TransmissionType.Automatic, 8, "ZF"),
                    new Chassis(4, "456308ht95", 2500), 5);

                List<Vehicle> vehicles = new List<Vehicle>() { car, bus, scooter, truck };

                var viewSerializers = CreateViewSerializer();
                foreach (var decorator in viewSerializers)
                {
                    decorator.Execute(vehicles);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
