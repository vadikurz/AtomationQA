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
        private CarPark defaultCarPark;
        private Car defaultCar;
        private Bus defaultBus;
        private Truck defaultTruck;
        private Scooter defaultScooter;

        [TestInitialize]
        public void TestInitialize()
        {
            defaultCarPark = new CarPark();

            defaultCar = new Car
            (
                new Engine(300, 3, EngineType.Diesel, "1234567v"),
                new Transmission(TransmissionType.Automatic, 7, "Aisin"),
                new Chassis(4, "12345v2", 1000),
                bodyType: CarBody.StationWagon
            );

            defaultBus = new Bus
            (
                new Engine(155, 2, EngineType.Electric, "v21r332502"),
                new Transmission(TransmissionType.Manual, 8, "ZF"),
                new Chassis(4, "004522vr34", 2000),
                numberOfSeats: 20
            );

            defaultTruck = new Truck
            (
                new Engine(200, 3, EngineType.Electric, "dr3407tye"),
                new Transmission(TransmissionType.Automatic, 8, "ZF"),
                new Chassis(4, "456308ht95", 2500),
                liftingCapacity: 5
            );

            defaultScooter = new Scooter
            (
                new Engine(40, 0.5, EngineType.Electric, "87tr34wqe"),
                new Transmission(TransmissionType.Manual, 8, "Aisin"),
                new Chassis(2, "002245vr99", 200),
                maxSpeed: 70
            );
        }

        [TestMethod]
        [DataRow("123")]
        public void AddVehicleShouldThrowAddException(string id)
        {
            defaultCarPark.Add(defaultCar, id);

            Assert.ThrowsException<AddException>(() => defaultCarPark.Add(defaultCar, id));
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow("null", "null")]
        public void GetAutoByParameterShouldThrowNotFoundParameterException(string parameter, string value)
        {
            defaultCarPark.Add(defaultTruck, "123");

            Assert.ThrowsException<NotFoundParameterException>(() => defaultCarPark.GetAutoByParameter(parameter, value));
        }

        [TestMethod]
        [DataRow("BodyType", "null")]
        [DataRow("bodytype", "")]
        public void GetAutoByParameterShouldThrowNotFoundValueByParameterException(string parameter, string value)
        {
            defaultCarPark.Add(defaultCar, "123");

            Assert.ThrowsException<NotFoundValueByParameterException>(() => defaultCarPark.GetAutoByParameter(parameter, value));
        }

        [TestMethod]
        [DataRow("NumberOfSeats", "20")]
        public void GetAutoByParameterShouldThrowAmbiguousMatchException(string parameter, string value)
        {
            var firstBus = defaultBus;
            var secondBus = defaultBus;

            defaultCarPark.Add(firstBus, "123");
            defaultCarPark.Add(secondBus, "124");

            Assert.ThrowsException<AmbiguousMatchException>(() => defaultCarPark.GetAutoByParameter(parameter, value));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("25489")]
        public void RemoveAutoShouldThrowRemoveAutoException(string id)
        {
            defaultCarPark.Add(defaultCar, "123");

            Assert.ThrowsException<RemoveAutoException>(() => defaultCarPark.RemoveAuto(id));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("25489")]
        public void UpdateAutoShouldThrowUpdateAutoException(string id)
        {
            defaultCarPark.Add(defaultCar, "123");

            Assert.ThrowsException<UpdateAutoException>(() => defaultCarPark.UpdateAuto(id, defaultScooter));
        }
    }
}
