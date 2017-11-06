using FedEx.Model.Modules;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace FedEx.Model.DataBases
{
    class JhonFKennedy_Database
    {
        public static List<FlightOrder_Constructor> JFK = new List<FlightOrder_Constructor>();

        public static List<TextBlock> PrintOrders()
        {
            var boxes = new List<TextBlock>();
            foreach(FlightOrder_Constructor order in JFK)
            {
                var box = new TextBlock();
                box.Text = "CompanyName: " + order.Company + "\n" +
                    "Cargo Weight: " + order.Weight + "\n" +
                    "Picking Address: " + order.PickingAddress.StreetAddress1 + "\n" +
                    "Picking City: " + order.PickingAddress.City + "\n" +
                    "Picking Country: " + order.PickingAddress.Country + "\n" +
                    "Delivery Address: " + order.SendingAddress.StreetAddress1 + "\n" +
                    "Delivery City: " + order.SendingAddress.City + "\n" +
                    "Delivery Country: " + order.SendingAddress.Country + "\n" +
                    "Requested Date: " + order.DateOfOrderRequested + "\n" +
                    "PickUp Date: " + order.PickUpDate + "\n" +
                    "Delivery Date: " + order.DeliverDate + "\n";

                boxes.Add(box);
            }

            return boxes;
        }
    }
}
