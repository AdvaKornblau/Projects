using System;


namespace SmartParkingSystem
{
    public class ParkingSpot
    {
        private int id;
        private bool isOccupied;
        private Vehicle? currentVehicle;
        private ParkingSession? session;

        public ParkingSpot(int id)
        {
            this.id = id;
            this.isOccupied = false;
            this.currentVehicle = null;
            this.session = null;
        }

        public int GetId() 
        {
            return this.id;
        }
        public bool GetIsOccupied() 
        {
            return this.isOccupied;
        }
        public Vehicle GetCurrentVehicle() 
        {
            return this.currentVehicle;
        }
        public ParkingSession GetSession() 
        {
            return this.session;
        }

        public bool Park(Vehicle vehicle)
        {
            if (this.isOccupied) 
                return false;

            this.currentVehicle = vehicle;
            this.isOccupied = true;
            vehicle.SetIsParked(true);

            this.session = new ParkingSession(vehicle, this);
            return true;
        }

        public double Unpark(double hourlyRate)
        {
            if (!this.isOccupied) 
                return 0;

            this.session.EndSession();
            double fee = this.session.CalculateFee(hourlyRate);

            this.currentVehicle.SetIsParked(false);
            this.currentVehicle = null;
            this.isOccupied = false;
            this.session = null;

            return fee;
        }
    }

}
