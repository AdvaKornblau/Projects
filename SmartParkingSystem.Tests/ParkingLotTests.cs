using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkingSystem;
using System.Threading;

namespace SmartParkingSystem.Tests
{
    [TestClass]
    public class ParkingLotTests
    {
        // 1. Create a ParkingLot and check capacity
        [TestMethod]
        public void CreateParkingLot_ShouldHaveCorrectCapacity()
        {
            // Arrange
            var lot = new ParkingLot("Lot A", 10.0, 3);

            // Act
            int capacity = lot.GetCapacity();

            // Assert
            Assert.AreEqual(3, capacity, "Capacity should match initialized value.");
        }

        // 2. succees parking when there is an available parking spot
        [TestMethod]
        public void ParkVehicle_ShouldReturnTrue_WhenSpotAvailable()
        {
            // Arrange
            var lot = new ParkingLot("Lot B", 15.0, 2);
            var car = new Car("111-11-111");

            // Act
            bool parked = lot.ParkVehicle(car);

            // Assert
            Assert.IsTrue(parked, "Car should park successfully when spot available.");
        }

        // 3. avoid parking the same car twice
        [TestMethod]
        public void ParkVehicle_ShouldFail_WhenSameCarTriesToParkTwice()
        {
            // Arrange
            var lot = new ParkingLot("Lot C", 12.0, 2);
            var car = new Car("222-22-222");

            // Act
            bool firstAttempt = lot.ParkVehicle(car);
            bool secondAttempt = lot.ParkVehicle(car);

            // Assert
            Assert.IsTrue(firstAttempt, "First attempt should succeed.");
            Assert.IsFalse(secondAttempt, "Second attempt should fail.");
        }

        // 4. fail to park when the parking lot is at full capacity
        [TestMethod]
        public void ParkVehicle_ShouldFail_WhenLotIsFull()
        {
            // Arrange
            var lot = new ParkingLot("Lot D", 10.0, 1);
            var car1 = new Car("333-33-333");
            var car2 = new Car("444-44-444");

            // Act
            bool firstAttempt = lot.ParkVehicle(car1);
            bool secondAttempt = lot.ParkVehicle(car2);

            // Assert
            Assert.IsTrue(firstAttempt, "First attempt should succeed.");
            Assert.IsFalse(secondAttempt, "Second attempt should fail when lot is full.");
        }

        // 5. Exiting and calculating fee
        [TestMethod]
        public void UnparkVehicle_ShouldReturnFee_WhenCarLeaves()
        {
            // Arrange
            var lot = new ParkingLot("Lot E", 20.0, 1);
            var car = new Car("555-55-555");
            lot.ParkVehicle(car);

            // Act
            Thread.Sleep(1000); // simulate ~1 sec parking
            double fee = lot.UnparkVehicle("555-55-555");

            // Assert
            Assert.IsTrue(fee >= 0, "Fee should be calculated when car leaves.");
        }

        // 6. Try to exit a car that did not enter
        [TestMethod]
        public void UnparkVehicle_ShouldReturnZero_WhenCarNotFound()
        {
            // Arrange
            var lot = new ParkingLot("Lot F", 15.0, 1);

            // Act
            double fee = lot.UnparkVehicle("NON-EXISTENT");

            // Assert
            Assert.AreEqual(0, fee, "Unparking non-existent vehicle should return zero fee.");
        }

        // 7. Change parking lot status after parking and exit
        [TestMethod]
        public void ToString_ShouldReflectParkingAndUnparking()
        {
            // Arrange
            var lot = new ParkingLot("Lot G", 10.0, 2);
            var car = new Car("666-66-666");

            // Act
            lot.ParkVehicle(car);
            string statusAfterParking = lot.ToString();
            lot.UnparkVehicle("666-66-666");
            string statusAfterUnparking = lot.ToString();

            // Assert
            Assert.IsTrue(statusAfterParking.Contains("Occupied: 1"), "Should show 1 occupied spot.");
            Assert.IsTrue(statusAfterUnparking.Contains("Occupied: 0"), "Should show 0 occupied spots after unpark.");
        }
    }
}
