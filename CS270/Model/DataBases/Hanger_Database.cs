using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS270.Modules;
using Windows.UI.Xaml.Controls;

namespace CS270.DataBases
{
    class Hanger_Database
    {
        public static List<Flight_Constructor> Hanger = new List<Flight_Constructor>();

        public static List<int> Plane_Index = new List<int>();

        public static void IntializeHanger()
        {
            Hanger.Add(new Plane("N35LX", "Boeing 737-330", "K", "I", "J", "M", "R", "M", "P", "O", "R"));
            Hanger.Add(new Plane("N644AA", "Boeing 757-223", "K", "I", "J", "R", "M", "P", "O", "P", "O"));
            Hanger.Add(new Plane("N96PB", "Embraer 110", "K", "I", "J", "N", "P", "O", "R", "N", "P"));
            Hanger.Add(new Plane("N736PA", "Boeing 747-121", "K", "I", "J", "P", "O", "R", "N", "M", "M"));
            Hanger.Add(new Plane("N778LP", "Cessna 172", "K", "I", "J", "O", "M", "N", "M", "R", "M"));
        }

        public static void AddPlane(Flight_Constructor Plane)
        {
            Hanger.Add(Plane);
        }

        public static List<TextBlock> PrintHanger(List<int> indexes)
        {
            List<TextBlock> boxes = new List<TextBlock>(); 
            foreach(int i in indexes)
            {
                TextBlock box = new TextBlock();
                box.Text = "Airplane Number: " + Hanger[i].AirplaneNumber + "\n" +
                    "Model: " + Hanger[i].Model + "\n" +
                    "Cargo Height: " + Hanger[i].Plane_Cargo_Height + "\n" +
                    "Cargo Length: " + Hanger[i].Plane_Cargo_Length + "\n" +
                    "Cargo Width: " + Hanger[i].Plane_Cargo_Width + "\n" +
                    "Cargo Capacity: " + Hanger[i].CargoCapacity + "\n" +
                    "Flight Time: " + Hanger[i].FlightTime + "\n" +
                    "Fuel Capacity: " + Hanger[i].FuelCapacity + "\n" +
                    "Runway Length: " + Hanger[i].RunwayLength + "\n" +
                    "Date Of Starting Service: " + Hanger[i].DateOfStartingService + "\n" +
                    "Date of Ending Service: " + Hanger[i].DateOfEndingService + "\n";
                boxes.Add(box);
            }
            return boxes;
        }

        public static void ErasePlane(int index)
        {
            Hanger.RemoveAt(index);
        }
    }
}
