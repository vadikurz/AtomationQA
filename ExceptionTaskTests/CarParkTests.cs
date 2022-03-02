using FifthTask;
using FifthTask.Exceptions;
using FifthTask.Parts;
using FifthTask.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionTaskTests
{
    [TestClass]
    public class CarParkTests
    {
        [TestMethod]
        [DataRow("123")]
        public void AddVehicleShouldThrowAddException(string id)
        {
            var carPark = new CarPark();
            var car = new Car
            (
                new Engine(300, 3, EngineType.Diesel, "1234567v"),
                new Transmission(TransmissionType.Automatic, 7, "Aisin"),
                new Chassis(4, "12345v2", 1000),
                bodyType: CarBody.StationWagon
            );

            carPark.Add(car, id);

            Assert.ThrowsException<AddException>(() => carPark.Add(car, id));
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow("null", "null")]
        public void GetAutoByParameterShouldThrowNotFoundParameterException(string parameter, string value)
        {
            var carPark = new CarPark();
            var truck = new Truck
            (
                new Engine(200, 3, EngineType.Electric, "dr3407tye"),
                new Transmission(TransmissionType.Automatic, 8, "ZF"),
                new Chassis(4, "456308ht95", 2500),
                liftingCapacity: 5
            );
            carPark.Add(truck, "123");

            Assert.ThrowsException<NotFoundParameterException>(() => carPark.GetAutoByParameter(parameter, value));
        }

        [TestMethod]
        [DataRow("BodyType", "null")]
        public void GetAutoByParameterShouldThrowNotFoundValueByParameterException(string parameter, string value)
        {
            var carPark = new CarPark();
            var car = new Car
            (
                new Engine(300, 3, EngineType.Diesel, "1234567v"),
                new Transmission(TransmissionType.Automatic, 7, "Aisin"),
                new Chassis(4, "12345v2", 1000),
                bodyType: CarBody.StationWagon
            );
            carPark.Add(car, "123");

            Assert.ThrowsException<NotFoundValueByParameterException>(() => carPark.GetAutoByParameter(parameter, value));
        }

        [TestMethod]
        [DataRow("NumberOfSeats", "20")]
        public void GetAutoByParameterShouldThrowAmbiguousMatchException(string parameter, string value)
        {
            var carPark = new CarPark();
            var firstBus = new Bus
            (
                new Engine(155, 2, EngineType.Electric, "v21r332502"),
                new Transmission(TransmissionType.Manual, 8, "ZF"),
                new Chassis(4, "004522vr34", 2000),
                numberOfSeats: 20
            );
            var secondBus = new Bus
            (
                new Engine(155, 2, EngineType.Electric, "v21r332502"),
                new Transmission(TransmissionType.Manual, 8, "ZF"),
                new Chassis(4, "004522vr34", 2000),
                numberOfSeats: 20
            );
            carPark.Add(firstBus, "123");
            carPark.Add(secondBus, "124");

            Assert.ThrowsException<AmbiguousMatchException>(() => carPark.GetAutoByParameter(parameter, value));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("25489")]
        public void RemoveAutoShouldThrowRemoveAutoException(string id)
        {
            var carPark = new CarPark();
            var car = new Car
            (
                new Engine(300, 3, EngineType.Diesel, "1234567v"),
                new Transmission(TransmissionType.Automatic, 7, "Aisin"),
                new Chassis(4, "12345v2", 1000),
                bodyType: CarBody.StationWagon
            );
            carPark.Add(car, "123");

            Assert.ThrowsException<RemoveAutoException>(() => carPark.RemoveAuto(id));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("25489")]
        public void UpdateAutoShouldThrowUpdateAutoException(string id)
        {
            var carPark = new CarPark();
            var car = new Car
            (
                new Engine(300, 3, EngineType.Diesel, "1234567v"),
                new Transmission(TransmissionType.Automatic, 7, "Aisin"),
                new Chassis(4, "12345v2", 1000),
                bodyType: CarBody.StationWagon
            );
            carPark.Add(car, "123");

            var scooter = new Scooter
            (
                new Engine(40, 0.5, EngineType.Electric, "87tr34wqe"),
                new Transmission(TransmissionType.Manual, 8, "Aisin"),
                new Chassis(2, "002245vr99", 200),
                maxSpeed: 70
            );

            Assert.ThrowsException<UpdateAutoException>(() => carPark.UpdateAuto(id, scooter));
        }
    }
}
