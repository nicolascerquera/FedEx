using CS270_Ver_2._0.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS270.Modules
{
    class FlightOrder_Constructor
    {
        public string Company { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double Cargo_Height { get; set; }
        public double Cargo_Width { get; set; }
        public double Cargo_Length { get; set; }
        public Mailing_Address PickingAddress { get; set; }
        public Mailing_Address SendingAddress { get; set; }
        public DateTime DateOfOrderRequested { get; set; }
        public DateTimeOffset PickUpDate { get; set; }
        public Plane PlaneRequested { get; set; }
        public DateTimeOffset DeliverDate { get; set; }        
    }

    class Order : FlightOrder_Constructor
    {
        public Order(string company, double weight, double volume, double cargoheight, double cargowidth, double cargolength, 
            Mailing_Address pickingAddress, Mailing_Address sendingAddress, DateTime requested, DateTimeOffset pickup, 
            Plane plane, DateTimeOffset deliver)
        {
            Company = company;
            Weight = weight;
            Volume = volume;
            Cargo_Height = cargoheight;
            Cargo_Length = cargolength;
            Cargo_Width = cargowidth;
            PickingAddress = pickingAddress;
            SendingAddress = sendingAddress;
            DateOfOrderRequested = requested;
            PickUpDate = pickup;
            PlaneRequested = plane;
            DeliverDate = deliver;
        }
    }
}
