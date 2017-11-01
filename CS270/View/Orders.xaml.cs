using CS270.DataBases;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CS270_Ver_2._0.Modules;
using CS270.Modules;
using System;

namespace CS270
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Aerial_Database.IntitializeMasterAerial();
            Hanger_Database.IntializeHanger();
        }

        private void DefaultSqueduling()
        {
            DefaultAerial();
            DefaultPlaneIndex();
            PrintCustomersSchedule(Aerial_Database.indexes);            
            PrintPlanesSchedule(Hanger_Database.Plane_Index);
            ClearMailingSchedule();
        }

        private void PrintCustomersSchedule(List<int> indexes)
        {
            CustomerSchedule.Items.Clear();
            var list = Aerial_Database.PrintAerial(indexes);
            foreach (TextBlock ibox in list)
            {
                CustomerSchedule.Items.Add(ibox);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrintMailingSchedule();
            ClearCustomerSchedule();
            var customerList = Aerial_Database.PrintAerial(Aerial_Database.indexes);
            if (customerList.ElementAtOrDefault(CustomerSchedule.SelectedIndex) != null)
            {
                CompanyName_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Billing.CompanyName;
                ContactName_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Billing.ContactName;
                StreetAddress1_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Billing.StreetAddress1;
                StreetAddress2_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Billing.StreetAddress2;
                City_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Billing.City;
                StateOrProvince_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Billing.StateOrProvince;
                Country_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Billing.Country;
                Zipcode_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Billing.Zipcode;
            }
        }

        private void ClearCustomerSchedule()
        {
            CompanyName_Schedule.Text = "";
            ContactName_Schedule.Text = "";
            StreetAddress1_Schedule.Text = "";
            StreetAddress2_Schedule.Text = "";
            City_Schedule.Text = "";
            StateOrProvince_Schedule.Text = "";
            Country_Schedule.Text = "";
            Zipcode_Schedule.Text = "";
        }

        private void PrintMailingSchedule()
        {
            MailingSchedule.Items.Clear();
            var customerList = Aerial_Database.PrintAerial(Aerial_Database.indexes);
            if (customerList.ElementAtOrDefault(CustomerSchedule.SelectedIndex) != null)
            {
                var list = Aerial_Database.PrintMailing(Aerial_Database.indexes[CustomerSchedule.SelectedIndex]);
                foreach (TextBlock ibox in list)
                {
                    MailingSchedule.Items.Add(ibox);
                }
            }
        }

        private void PrintMailingSchedule(List<int> mailing)
        {
            MailingSchedule.Items.Clear();
            var customerList = Aerial_Database.PrintAerial(Aerial_Database.indexes);
            if (customerList.ElementAtOrDefault(CustomerSchedule.SelectedIndex) != null)
            {
                var list = Aerial_Database.PrintMailing(Aerial_Database.indexes[CustomerSchedule.SelectedIndex], Aerial_Database.mailIndexes);
                foreach (TextBlock ibox in list)
                {
                    MailingSchedule.Items.Add(ibox);
                }
            }
        }

        private void PrintPlanesSchedule(List<int> indexes)
        {
            PlanesSchedule.Items.Clear();
            var boxes = Hanger_Database.PrintHanger(indexes);
            foreach (TextBlock box in boxes)
            {
                PlanesSchedule.Items.Add(box);
            }
        }

        private void CancelSearch_Customer_Click(object sender, RoutedEventArgs e)
        {
            CustomerSchedule.SelectedIndex = -1;
            ClearCustomerSchedule();
            DefaultAerial();
            PrintCustomersSchedule(Aerial_Database.indexes);
        }

        private void SearchCustomer_Schedule_Click(object sender, RoutedEventArgs e)
        {
            Master_Address customer = new Master_Address(new Billing_Address(CompanyName_Schedule.Text,ContactName_Schedule.Text,
            StreetAddress1_Schedule.Text, StreetAddress2_Schedule.Text, City_Schedule.Text, StateOrProvince_Schedule.Text,
            Country_Schedule.Text, Zipcode_Schedule.Text),new List<Mailing_Address>());

            customer.SearchCustomer(customer);
            PrintCustomersSchedule(Aerial_Database.indexes);
        }

        private void MailingSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var customerList = Aerial_Database.PrintAerial(Aerial_Database.indexes);
            if (customerList.ElementAtOrDefault(CustomerSchedule.SelectedIndex) != null)
            {
                DefaultMailing(Aerial_Database.indexes[CustomerSchedule.SelectedIndex]);
                var MailingList = Aerial_Database.PrintMailing(Aerial_Database.indexes[CustomerSchedule.SelectedIndex], Aerial_Database.mailIndexes);
                if (MailingList.ElementAtOrDefault(MailingSchedule.SelectedIndex) != null)
                {
                    CompanyName_Mailing_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Mailing[Aerial_Database.mailIndexes[MailingSchedule.SelectedIndex]].CompanyName;
                    ContactName_Mailing_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Mailing[Aerial_Database.mailIndexes[MailingSchedule.SelectedIndex]].ContactName;
                    StreetAddress1_Mailing_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Mailing[Aerial_Database.mailIndexes[MailingSchedule.SelectedIndex]].StreetAddress1;
                    StreetAddress2_Mailing_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Mailing[Aerial_Database.mailIndexes[MailingSchedule.SelectedIndex]].StreetAddress2;
                    City_Mailing_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Mailing[Aerial_Database.mailIndexes[MailingSchedule.SelectedIndex]].City;
                    StateOrProvince_Mailing_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Mailing[Aerial_Database.mailIndexes[MailingSchedule.SelectedIndex]].StateOrProvince;
                    Country_Mailing_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Mailing[Aerial_Database.mailIndexes[MailingSchedule.SelectedIndex]].Country;
                    Zipcode_Mailing_Schedule.Text = Aerial_Database.Aerial_Master[Aerial_Database.indexes[CustomerSchedule.SelectedIndex]].Mailing[Aerial_Database.mailIndexes[MailingSchedule.SelectedIndex]].Zipcode;
                }
            }
        }

        private void ClearMailingSchedule()
        {
            CompanyName_Mailing_Schedule.Text = "";
            ContactName_Mailing_Schedule.Text = "";
            StreetAddress1_Mailing_Schedule.Text = "";
            StreetAddress2_Mailing_Schedule.Text = "";
            City_Mailing_Schedule.Text = "";
            StateOrProvince_Mailing_Schedule.Text = "";
            Country_Mailing_Schedule.Text = "";
            Zipcode_Mailing_Schedule.Text = "";
        }

        private void CancelSearch_Mailing_Click(object sender, RoutedEventArgs e)
        {
            MailingSchedule.SelectedIndex = -1;
            ClearMailingSchedule();
            DefaultMailing(Aerial_Database.indexes[CustomerSchedule.SelectedIndex]);
            MailingSchedule.Items.Clear();
            PrintMailingSchedule();
        }

        private void SearchMailing_Schedule_Click(object sender, RoutedEventArgs e)
        {
            Mailing_Address mailing = new Mailing_Address(CompanyName_Mailing_Schedule.Text, ContactName_Mailing_Schedule.Text,
            StreetAddress1_Mailing_Schedule.Text, StreetAddress2_Mailing_Schedule.Text, StateOrProvince_Mailing_Schedule.Text, 
            City_Mailing_Schedule.Text, Country_Mailing_Schedule.Text, Zipcode_Mailing_Schedule.Text);

            mailing.SearchMailing(Aerial_Database.indexes[CustomerSchedule.SelectedIndex], mailing);
            PrintMailingSchedule(Aerial_Database.mailIndexes);
        }

        private void PlanesSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var customerList = Hanger_Database.PrintHanger(Hanger_Database.Plane_Index);
            if (customerList.ElementAtOrDefault(PlanesSchedule.SelectedIndex) != null)
            {
                AirplaneNumber_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].AirplaneNumber;
                Model_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].Model;
                PlaneCargoHeight_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].Plane_Cargo_Height;
                PlaneCargoLength_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].Plane_Cargo_Length;
                PlaneCargoWidth_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].Plane_Cargo_Width;
                CargoCapacity_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].CargoCapacity;
                FlightTime_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].FlightTime;
                FuelCapacity_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].FuelCapacity;
                RunwayLength_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].RunwayLength;
                DateOfStartingService_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].DateOfStartingService;
                DateOfEndingService_Schedule.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PlanesSchedule.SelectedIndex]].DateOfEndingService;
            }
        }

        private void SearchPlane_Schedule_Click(object sender, RoutedEventArgs e)
        {
            Plane plane = new Plane(AirplaneNumber_Schedule.Text, Model_Schedule.Text, PlaneCargoHeight_Schedule.Text,
            PlaneCargoLength_Schedule.Text, PlaneCargoWidth_Schedule.Text, CargoCapacity_Schedule.Text, FlightTime_Schedule.Text,
            FuelCapacity_Schedule.Text, RunwayLength_Schedule.Text, DateOfStartingService_Schedule.Text,
            DateOfEndingService_Schedule.Text);

            plane.SearchPlane(plane);
            PlanesSchedule.Items.Clear();
            PrintPlanesSchedule(Hanger_Database.Plane_Index);
        }

        private void CancelSearch_Plane_Click(object sender, RoutedEventArgs e)
        {
            ClearPlaneSchedule();
            DefaultPlaneIndex();
            PlanesSchedule.SelectedIndex = -1;
        }

        private void ClearPlaneSchedule()
        {
            AirplaneNumber_Schedule.Text = "";
            Model_Schedule.Text = "";
            PlaneCargoHeight_Schedule.Text = "";
            PlaneCargoLength_Schedule.Text = "";
            PlaneCargoWidth_Schedule.Text = "";
            CargoCapacity_Schedule.Text = "";
            FlightTime_Schedule.Text = "";
            FuelCapacity_Schedule.Text = "";
            RunwayLength_Schedule.Text = "";
            DateOfStartingService_Schedule.Text = "";
            DateOfEndingService_Schedule.Text = "";
        }

        private void ClearOrderSchedule()
        {
            PackageWeight.Text = "";
            PackageVolume.Text = "";
            CargoHeight.Text = "";
            CargoLength.Text = "";
            CargoWidth.Text = "";
        }

        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            ClearMailingSchedule();
            ClearPlaneSchedule();
            ClearOrderSchedule();
            ClearCustomerSchedule();
            CustomerSchedule.SelectedIndex = -1;
            MailingSchedule.SelectedIndex = -1;
            PlanesSchedule.SelectedIndex = -1;
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            Mailing_Address picking = new Mailing_Address(CompanyName_Schedule.Text, ContactName_Schedule.Text,
                StreetAddress1_Schedule.Text, StreetAddress2_Schedule.Text, City_Schedule.Text, StateOrProvince_Schedule.Text,
                Country_Schedule.Text, Zipcode_Schedule.Text);
            Mailing_Address delivery = new Mailing_Address(CompanyName_Mailing_Schedule.Text, ContactName_Mailing_Schedule.Text,
                StreetAddress1_Mailing_Schedule.Text, StreetAddress2_Mailing_Schedule.Text, City_Mailing_Schedule.Text,
                StateOrProvince_Mailing_Schedule.Text, Country_Mailing_Schedule.Text, Zipcode_Mailing_Schedule.Text);
            Plane planeUsed = new Plane(AirplaneNumber_Schedule.Text, Model_Schedule.Text, PlaneCargoHeight_Schedule.Text,
            PlaneCargoLength_Schedule.Text, PlaneCargoWidth_Schedule.Text, CargoCapacity_Schedule.Text, FlightTime_Schedule.Text,
            FuelCapacity_Schedule.Text, RunwayLength_Schedule.Text, DateOfStartingService_Schedule.Text,
            DateOfEndingService_Schedule.Text);
            Order newOrder = new Order(picking.CompanyName,Double.Parse(PackageWeight.Text), Double.Parse(PackageVolume.Text), 
                Double.Parse(CargoHeight.Text), Double.Parse(CargoWidth.Text), Double.Parse(CargoLength.Text), picking, delivery, 
                DateTime.Now, PickingDate.Date, planeUsed, DeliveryDate.Date);
            JhonFKennedy_Database.JFK.Add(newOrder);
            ClearMailingSchedule();
            ClearPlaneSchedule();
            ClearOrderSchedule();
            ClearCustomerSchedule();
            CustomerSchedule.SelectedIndex = -1;
            MailingSchedule.SelectedIndex = -1;
            PlanesSchedule.SelectedIndex = -1;
            PrintOrders();
        }

        private void PrintOrders()
        {
            Schedules.Items.Clear();
            var list = JhonFKennedy_Database.PrintOrders();
            foreach(TextBlock box in list)
            {
                Schedules.Items.Add(box);
            }
        }
    }
}