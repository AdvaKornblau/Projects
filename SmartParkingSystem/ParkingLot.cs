using System;
using System.Threading;


namespace SmartParkingSystem
{
    public class ParkingLot
    {
        private string name;
        private double hourlyRate;
        private int capacity;
        private ParkingSpot[] spots;
        private object locker;

        public ParkingLot(string name, double hourlyRate, int capacity)
        {
            this.name = name;
            this.hourlyRate = hourlyRate;
            this.capacity = capacity;
            this.spots = new ParkingSpot[capacity];
            this.locker = new object();

            for (int i = 0; i < capacity; ++i) {
                this.spots[i] = new ParkingSpot(i + 1); // ID of a parkingSpot will begin from 1.
            }
        }

        public string GetName() 
        {
            return this.name;
        }
        public double GetHourlyRate() 
        {
            return this.hourlyRate;
        }
        public int GetCapacity() 
        {
            return this.capacity;
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            lock (this.locker)
            {
                if (vehicle.GetIsParked()) {
                    Console.WriteLine("Vehicle " + vehicle.GetLicensePlate() + " is already parked elsewhere.");
                    return false;
                }

                foreach (ParkingSpot spot in this.spots) {
                    if (!spot.GetIsOccupied()) {
                        spot.Park(vehicle);
                        Console.WriteLine(vehicle.ToString() + " parked at spot " + spot.GetId());
                        return true;
                    }
                }

                // case there are no avilable parking spots
                Console.WriteLine("No available spots for " + vehicle.ToString());
                return false;
            }
        }

        public double UnparkVehicle(string licensePlate)
        {
            lock (this.locker)
            {
                foreach (ParkingSpot spot in this.spots) {
                    if (spot.GetCurrentVehicle() != null &&
                        spot.GetCurrentVehicle().GetLicensePlate() == licensePlate) {
                        double fee = spot.Unpark(this.hourlyRate);
                        Console.WriteLine("Vehicle " + licensePlate + " unparked. Fee: " + fee + "NIS");
                        return fee;
                    }
                }
                Console.WriteLine("Vehicle " + licensePlate + " not found.");
                return 0;
            }
        }

        public override string ToString()
        {
            int free = 0, occupied = 0;
            foreach (ParkingSpot spot in this.spots) {
                if (spot.GetIsOccupied())
                    ++occupied;
                else
                    ++free;
            }

            return "Parking Lot '" + this.name + "' (Capacity: " + this.capacity +
                   ") - Free: " + free + ", Occupied: " + occupied;
        }

        public void PrintStatus()
        {
            Console.WriteLine(this.ToString());
        }

    }
}
