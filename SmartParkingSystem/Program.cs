using System;
using System.Threading;

namespace SmartParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating tow parking lots
            ParkingLot lotA = new ParkingLot("Lot A", 10.0, 2); // hourly price 10, capacity 2
            ParkingLot lotB = new ParkingLot("Lot B", 15.0, 3);

            // creating vehicles
            Vehicle car1 = new Car("111-11-111");
            Vehicle car2 = new Car("222-22-222");
            Vehicle car3 = new Car("333-33-333");
            Vehicle moto1 = new Motorcycle("MOTO-001");

            // parking vehicles
            Console.WriteLine("=== Park in Lot A ===");
            lotA.ParkVehicle(car1);
            lotA.ParkVehicle(car2);

            Console.WriteLine("\n=== Park in Lot B ===");
            lotB.ParkVehicle(car3);
            lotB.ParkVehicle(moto1);

            // print initial status
            Console.WriteLine("\n--- initial status ---");
            lotA.PrintStatus();
            lotB.PrintStatus();

            // wait 3 seconds
            Console.WriteLine("\n(wait for the cars to park...)");
            Thread.Sleep(3000);

            // release vehicle from lot A
            Console.WriteLine("\n--- Exiting Lot A ---");
            double fee1 = lotA.UnparkVehicle("111-11-111");
            Console.WriteLine("fee for car1: " + fee1 + "NIS");

            // wait again
            Console.WriteLine("\n(wait for the car to exit...)");
            Thread.Sleep(2000);

            // release car from Lot B
            Console.WriteLine("\n--- Exiting Lot B ---");
            double fee2 = lotB.UnparkVehicle("MOTO-001");
            Console.WriteLine("fee for moto1: " + fee2 + "NIS");

            // Final status
            Console.WriteLine("\n--- Final status ---");
            lotA.PrintStatus();
            lotB.PrintStatus();

            Console.WriteLine("\nEnd test.");
        }
    }
}
