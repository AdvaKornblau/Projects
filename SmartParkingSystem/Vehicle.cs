using System;


namespace SmartParkingSystem
{
    public abstract class Vehicle
    {
        private string licensePlate;
        private string vehicleType;
        private bool isParked;
        public Vehicle(string licensePlate, string vehicleType)
        {
            this.licensePlate = licensePlate;
            this.vehicleType = vehicleType;
            this.isParked = false;
        }

        public string GetLicensePlate() 
        {
            return this.licensePlate; 
        }
        public void SetLicensePlate(string licensePlate) 
        { 
            this.licensePlate = licensePlate; 
        }

        public string GetVehicleType() 
        { 
            return this.vehicleType; 
        }
        public void SetVehicleType(string vehicleType) 
        {
            this.vehicleType = vehicleType;
        }

        public bool GetIsParked() 
        {
            return this.isParked;
        }
        public void SetIsParked(bool value)
        {
            this.isParked = value;
        }

        public override string ToString()
        {
            return this.vehicleType + " - Plate: " + this.licensePlate;
        }

    }
}
