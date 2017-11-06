using FedEx.Model.DataBases;
using System.Collections.Generic;

namespace FedEx.Model.Modules
{
    class Flight_Constructor
    {
        public string AirplaneNumber { get; set; }
        public string Model { get; set; }
        public string Plane_Cargo_Width { get; set; }
        public string Plane_Cargo_Length { get; set; }
        public string Plane_Cargo_Height { get; set; }
        public string CargoCapacity { get; set; }
        public string FlightTime { get; set; }
        public string FuelCapacity { get; set; }
        public string RunwayLength { get; set; }
        public string DateOfStartingService { get; set; }
        public string DateOfEndingService { get; set; }

        public void EditPlane(int index, Flight_Constructor flight)
        {
            Hanger_Database.Hanger[index].AirplaneNumber = flight.AirplaneNumber;
            Hanger_Database.Hanger[index].Model = flight.Model;
            Hanger_Database.Hanger[index].Plane_Cargo_Width = flight.Plane_Cargo_Width;
            Hanger_Database.Hanger[index].Plane_Cargo_Length = flight.Plane_Cargo_Length;
            Hanger_Database.Hanger[index].Plane_Cargo_Height = flight.Plane_Cargo_Height;
            Hanger_Database.Hanger[index].CargoCapacity = flight.CargoCapacity;
            Hanger_Database.Hanger[index].FlightTime = flight.FlightTime;
            Hanger_Database.Hanger[index].FuelCapacity = flight.FuelCapacity;
            Hanger_Database.Hanger[index].RunwayLength = flight.RunwayLength;
            Hanger_Database.Hanger[index].DateOfStartingService = flight.DateOfStartingService;
            Hanger_Database.Hanger[index].DateOfEndingService = flight.DateOfEndingService;
        }

        public void SearchPlane(Flight_Constructor plane)
        {
            var index = 0;
            var indexes = new List<int>();
            foreach(Plane flight in Hanger_Database.Hanger)
            {
                if(plane.AirplaneNumber == flight.AirplaneNumber || plane.Model == flight.Model || plane.Plane_Cargo_Width == flight.Plane_Cargo_Width
                    || plane.Plane_Cargo_Length == flight.Plane_Cargo_Length || plane.Plane_Cargo_Height == flight.Plane_Cargo_Height ||
                    plane.CargoCapacity == flight.CargoCapacity || plane.FlightTime == flight.FlightTime || plane.FuelCapacity == flight.FuelCapacity ||
                    plane.RunwayLength == flight.RunwayLength || plane.DateOfStartingService == flight.DateOfStartingService || plane.DateOfEndingService == flight.DateOfEndingService)
                {
                    indexes.Add(index);
                    index++;
                } else
                {
                    index++;
                }
            }

            Hanger_Database.Plane_Index = indexes;
        }
    }

    class Plane : Flight_Constructor
    {
        public Plane(string airplaneNumber, string model, string planeCargoWidth, string planeCargoLength,
            string planeCargoHeight, string cargoCapacity, string flighTime, string fuelCapacity, 
            string runwayLength, string dateOfStartingService, string dateOfEdinngService)
        {
            AirplaneNumber = airplaneNumber;
            Model = model;
            Plane_Cargo_Width = planeCargoWidth;
            Plane_Cargo_Length = planeCargoLength;
            Plane_Cargo_Height = planeCargoHeight;
            CargoCapacity = cargoCapacity;
            FlightTime = flighTime;
            FuelCapacity = fuelCapacity;
            RunwayLength = runwayLength;
            DateOfStartingService = dateOfStartingService;
            DateOfEndingService = dateOfEdinngService;
        }
    }
}