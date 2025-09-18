using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkingSystem;

namespace SmartParkingSystem.Tests
{
    [TestClass] // Test class for Vehicle and ParkingSpot
    public class VehicleAndSpotTests
    {
        [TestMethod] // Verify that car license plate is stored correctly
        public void CreateCar_ShouldHaveCorrectLicensePlate()
        {
            var car = new Car("111-11-111");
            Assert.AreEqual("111-11-111", car.GetLicensePlate(), "License plate should be stored correctly.");
        }

        [TestMethod] // Verify that vehicle parking status can be updated
        public void Vehicle_ShouldUpdateIsParked()
        {
            var car = new Car("222-22-222");
            Assert.IsFalse(car.GetIsParked(), "Default status should be not parked.");

            car.SetIsParked(true);
            Assert.IsTrue(car.GetIsParked(), "Vehicle status should update to parked.");
        }

        [TestMethod] // ParkingSpot should allow vehicle to park
        public void ParkingSpot_ShouldParkVehicle()
        {
            var spot = new ParkingSpot(1);
            var car = new Car("333-33-333");

            bool parked = spot.Park(car);

            Assert.IsTrue(parked, "Vehicle should park successfully in free spot.");
            Assert.IsTrue(spot.GetIsOccupied(), "Spot should be marked as occupied.");
        }

        [TestMethod] // ParkingSpot should allow vehicle to unpark and calculate fee
        public void ParkingSpot_ShouldUnparkVehicle_AndReturnFee()
        {
            var spot = new ParkingSpot(2);
            var car = new Car("444-44-444");

            spot.Park(car);

            // Act – unpark with hourly rate (for example 10.0)
            double fee = spot.Unpark(10.0);

            // Assert
            Assert.IsTrue(fee >= 0, "Fee should be returned when vehicle unparks.");
            Assert.IsFalse(spot.GetIsOccupied(), "Spot should be free after vehicle leaves.");
        }
    }
}
