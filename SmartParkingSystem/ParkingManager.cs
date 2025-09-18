/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingSystem
{
    public class ParkingManager
    {
        private List<ParkingLot>? parkingLots;

        public ParkingManager()
        {
            this.parkingLots = new List<ParkingLot>();
        }

        public void AddParkingLot(ParkingLot lot)
        {
            this.parkingLots.Add(lot);
            Console.WriteLine("Added parking lot: " + lot.GetName());
        }

        public bool RemoveParkingLot(string name)
        {
            ParkingLot lot = this.parkingLots.FirstOrDefault(l => l.GetName() == name);
            if (lot != null)
            {
                this.parkingLots.Remove(lot);
                Console.WriteLine("Removed parking lot: " + name);
                return true;
            }
            Console.WriteLine("Parking lot " + name + " not found.");
            return false;
        }

        public ParkingLot FindParkingLot(string name)
        {
            return this.parkingLots.FirstOrDefault(l => l.GetName() == name);
        }

        public void PrintAllStatus()
        {
            Console.WriteLine("=== Parking Manager Status ===");
            foreach (ParkingLot lot in this.parkingLots)
            {
                Console.WriteLine(lot.ToString());
            }
        }

        public int GetCount()
        {
            return this.parkingLots.Count;
        }
    }
}

*/