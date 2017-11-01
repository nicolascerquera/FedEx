using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS270_Ver_2._0.Modules;
using Windows.UI.Xaml.Controls;

namespace CS270.DataBases
{
    class Aerial_Database
    {
        public static List<Customer_Constructor> Aerial_Master = new List<Customer_Constructor>();
        public static List<int> indexes = new List<int>();
        public static List<int> mailIndexes = new List<int>();

        public static void IntitializeMasterAerial()
        {
            Aerial_Master.Add(new Master_Address(new Billing_Address("B", "D", "A", "C", "A", "A", "B", "D"), new List<Mailing_Address>()));
            Aerial_Master[0].Mailing.Add(new Mailing_Address("B", "0", "1", "2", "3", "4", "5", "2"));
            Aerial_Master[0].Mailing.Add(new Mailing_Address("B", "3", "2", "3", "2", "3", "2", "3"));
            Aerial_Master[0].Mailing.Add(new Mailing_Address("B", "2", "3", "2", "3", "2", "3", "6"));
            Aerial_Master.Add(new Master_Address(new Billing_Address("D", "P", "D", "A", "C", "B", "D", "B"), new List<Mailing_Address>()));
            Aerial_Master[1].Mailing.Add(new Mailing_Address("D", "0", "1", "2", "3", "4", "5", "2"));
            Aerial_Master[1].Mailing.Add(new Mailing_Address("D", "3", "2", "3", "2", "3", "2", "3"));
            Aerial_Master[1].Mailing.Add(new Mailing_Address("D", "2", "3", "2", "3", "2", "3", "6"));
            Aerial_Master.Add(new Master_Address(new Billing_Address("A", "Q", "B", "D", "B", "D", "A", "C"), new List<Mailing_Address>()));
            Aerial_Master[2].Mailing.Add(new Mailing_Address("A", "0", "1", "2", "3", "4", "5", "2"));
            Aerial_Master[2].Mailing.Add(new Mailing_Address("A", "3", "2", "3", "2", "3", "2", "3"));
            Aerial_Master[2].Mailing.Add(new Mailing_Address("A", "2", "3", "2", "3", "2", "3", "6"));
            Aerial_Master.Add(new Master_Address(new Billing_Address("C", "M", "A", "B", "D", "A", "C", "A"), new List<Mailing_Address>()));
            Aerial_Master[3].Mailing.Add(new Mailing_Address("C", "0", "1", "2", "3", "4", "5", "2"));
            Aerial_Master[3].Mailing.Add(new Mailing_Address("C", "3", "2", "3", "2", "3", "2", "3"));
            Aerial_Master[3].Mailing.Add(new Mailing_Address("C", "2", "3", "2", "3", "2", "3", "6"));
            Aerial_Master.Add(new Master_Address(new Billing_Address("E", "N", "A", "B", "D", "A", "C", "A"), new List<Mailing_Address>()));
            Aerial_Master[4].Mailing.Add(new Mailing_Address("E", "0", "1", "2", "3", "4", "5", "2"));
            Aerial_Master[4].Mailing.Add(new Mailing_Address("E", "3", "2", "3", "2", "3", "2", "3"));
            Aerial_Master[4].Mailing.Add(new Mailing_Address("E", "2", "3", "2", "3", "2", "3", "6"));
        }

        public static void DeleteCustomer(int index)
        {
            Aerial_Master.RemoveAt(index);
        }      

        public static void DeleteMailingAddress(int comIndex, int index)
        {
            Aerial_Master[comIndex].Mailing.RemoveAt(index);
        }

        public static List<TextBlock> PrintAerial(List<int> indexes)
        {
            List<TextBlock> boxes = new List<TextBlock>();
            for (var i = 0; i < indexes.Count; i++)
            {
                  TextBlock box = new TextBlock();
                    box.Text = "Company Name: " + Aerial_Master[indexes[i]].Billing.CompanyName + "\n" +
                        "Contact Name: " + Aerial_Master[indexes[i]].Billing.ContactName + "\n" +
                        "Street Address 1: " + Aerial_Master[indexes[i]].Billing.StreetAddress1 + "\n" +
                        "Street Address 2: " + Aerial_Master[indexes[i]].Billing.StreetAddress2 + "\n" +
                        "City: " + Aerial_Master[indexes[i]].Billing.City + "\n" +
                        "State Or Province: " + Aerial_Master[indexes[i]].Billing.StateOrProvince + "\n" +
                        "Country: " + Aerial_Master[indexes[i]].Billing.Country + "\n" +
                        "Zipcode: " + Aerial_Master[indexes[i]].Billing.Zipcode;
                    boxes.Add(box);                          
            }
            return boxes;
        }

        public static List<TextBlock> PrintMailing(int index)
        {
            List<TextBlock> boxes = new List<TextBlock>();
            foreach (Mailing_Address mailing in Aerial_Master[index].Mailing)
            {
                TextBlock box = new TextBlock();
                box.Text = "Company Name: " + mailing.CompanyName + "\n" +
                    "Contact Name: " + mailing.ContactName + "\n" +
                    "Street Address 1: " + mailing.StreetAddress1 + "\n" +
                    "Street Address 2: " + mailing.StreetAddress2 + "\n" +
                    "City: " + mailing.City + "\n" +
                    "State Or Province: " + mailing.StateOrProvince + "\n" +
                    "Country: " + mailing.Country + "\n" +
                    "Zipcode: " + mailing.Zipcode;
                boxes.Add(box);
            }
            return boxes;
        }

        public static List<TextBlock> PrintMailing(int index, List<int> indexes)
        {
            List<TextBlock> boxes = new List<TextBlock>();
            for (var i = 0; i < indexes.Count; i++)
            {
                TextBlock box = new TextBlock();
                box.Text = "Company Name: " + Aerial_Master[index].Mailing[indexes[i]].CompanyName + "\n" +
                    "Contact Name: " + Aerial_Master[index].Mailing[indexes[i]].ContactName + "\n" +
                    "Street Address 1: " + Aerial_Master[index].Mailing[indexes[i]].StreetAddress1 + "\n" +
                    "Street Address 2: " + Aerial_Master[index].Mailing[indexes[i]].StreetAddress2 + "\n" +
                    "City: " + Aerial_Master[index].Mailing[indexes[i]].City + "\n" +
                    "State Or Province: " + Aerial_Master[index].Mailing[indexes[i]].StateOrProvince + "\n" +
                    "Country: " + Aerial_Master[index].Mailing[indexes[i]].Country + "\n" +
                    "Zipcode: " + Aerial_Master[index].Mailing[indexes[i]].Zipcode;
                boxes.Add(box);
            }
            return boxes;
        }
    }
}