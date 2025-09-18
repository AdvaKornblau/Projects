using System;
using System.Threading;

namespace SmartParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====== SIMULATION OF SMART PARKING SYSTEM ======\n");

            // creating two parking lots
            ParkingLot lotA = new ("Lot A", 10.0, 2); // hourly price 10, capacity 2
            ParkingLot lotB = new ("Lot B", 15.0, 3);

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
            if (fee1 == 0) {
                Console.WriteLine("Vehicle 111-11-111 not found.");
            } else {
                Console.WriteLine("fee for car1: " + fee1 + "NIS");
            }

            // wait again
            Console.WriteLine("\n(wait for the car to exit...)");
            Thread.Sleep(2000);

            // release car from Lot B
            Console.WriteLine("\n--- Exiting Lot B ---");
            double fee2 = lotB.UnparkVehicle("MOTO-001");
            if (fee2 == 0) {
                Console.WriteLine("Vehicle 111-11-111 not found.");
            } else {
                Console.WriteLine("fee for moto1: " + fee2 + "NIS");
            }

            // Final status
            Console.WriteLine("\n--- Final status ---");
            lotA.PrintStatus();
            lotB.PrintStatus();

            
            // Thread-safety test: concurrent park/unpark operations
            
            ParkingLot lotC = new ("Lot C", 15.0, 2);

            Vehicle car4 = new Car("aa1-11-111");
            Vehicle car5 = new Car("bb2-22-222");
            Vehicle moto2 = new Motorcycle("MOTO-002");

            // Three threads attempt to park simultaneously 
            Thread t1 = new (() => lotC.ParkVehicle(car4));
            Thread t2 = new (() => lotC.ParkVehicle(car5));
            Thread t3 = new (() => lotC.ParkVehicle(moto2));

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            lotC.PrintStatus();

            // release a parking spot
            Thread t4 = new (() => lotC.UnparkVehicle("aa1-11-111"));
            t4.Start();
            t4.Join();

            lotC.PrintStatus();


            Console.WriteLine("\n======== END SIMULATION =========");
        }
    }
}
