using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingSystem
{
    public class ParkingSession
    {
        private Vehicle vehicle;
        private ParkingSpot spot;
        private DateTime startTime;
        private DateTime? endTime;

        public ParkingSession(Vehicle vehicle, ParkingSpot spot)
        {
            this.vehicle = vehicle;
            this.spot = spot;
            this.startTime = DateTime.Now;
            this.endTime = null;
        }

        public Vehicle GetVehicle() { return this.vehicle; }
        public ParkingSpot GetSpot() { return this.spot; }
        public DateTime GetStartTime() { return this.startTime; }
        public DateTime? GetEndTime() { return this.endTime; }

        public void EndSession()
        {
            this.endTime = DateTime.Now;
        }

        public double GetTotalHours()
        {
            DateTime effectiveEnd = this.endTime ?? DateTime.Now;
            return (effectiveEnd - this.startTime).TotalHours;
        }

        public double CalculateFee(double hourlyRate)
        {
            return Math.Ceiling(GetTotalHours()) * hourlyRate;
        }
    }
}
