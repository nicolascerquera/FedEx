using CS270.DataBases;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CS270_Ver_2._0.Modules;
using CS270.Modules;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS270
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Planes : Page
    {
        public Planes()
        {
            this.InitializeComponent();
        }

        private void DefaultPlanes()
        {
            Add_Plane.IsEnabled = true;
            Erase_Plane.IsEnabled = false;
            Edit_Plane.IsEnabled = false;
            Search_Plane.IsEnabled = true;
            Save_Plane.IsEnabled = false;
            Cancel_Plane.IsEnabled = false;
            DefaultPlaneIndex();
            PResults.Items.Clear();
            PrintPlanes();
            BlankPlaneFields();
        }

        private void DefaultPlaneIndex()
        {
            Hanger_Database.Plane_Index.Clear();
            for (var i = 0; i < Hanger_Database.Hanger.Count; i++)
            {
                Hanger_Database.Plane_Index.Add(i);
            }
        }

        private void PrintPlanes()
        {
            var boxes = Hanger_Database.PrintHanger(Hanger_Database.Plane_Index);
            foreach (TextBlock box in boxes)
            {
                PResults.Items.Add(box);
            }
        }

        private void PResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlaneSelected();
        }

        private void PlaneSelected()
        {
            Add_Plane.IsEnabled = false;
            Erase_Plane.IsEnabled = true;
            Edit_Plane.IsEnabled = true;
            Search_Plane.IsEnabled = false;
            Save_Plane.IsEnabled = false;
            Cancel_Plane.IsEnabled = false;
        }

        private void Add_Plane_Click(object sender, RoutedEventArgs e)
        {
            Plane plane = new Plane(AirplaneNumber.Text, Model.Text, Plane_Cargo_Width.Text, Plane_Cargo_Length.Text, Plane_Cargo_Height.Text,
                Cargo_Capacity.Text, Flight_Time.Text, Fuel_Capacity.Text, Runway_Length.Text, Date_Of_Starting_Service.Text,
                Date_Of_Ending_Service.Text);
            Hanger_Database.AddPlane(plane);
            DefaultPlanes();
        }

        private void Erase_Plane_Click(object sender, RoutedEventArgs e)
        {
            Hanger_Database.ErasePlane(Hanger_Database.Plane_Index[PResults.SelectedIndex]);
            DefaultPlanes();
        }

        private void Edit_Plane_Click(object sender, RoutedEventArgs e)
        {
            AirplaneNumber.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].AirplaneNumber;
            Model.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].Model;
            Plane_Cargo_Width.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].Plane_Cargo_Width;
            Plane_Cargo_Height.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].Plane_Cargo_Height;
            Plane_Cargo_Length.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].Plane_Cargo_Length;
            Cargo_Capacity.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].CargoCapacity;
            Flight_Time.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].FlightTime;
            Fuel_Capacity.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].FuelCapacity;
            Runway_Length.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].RunwayLength;
            Date_Of_Starting_Service.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].DateOfStartingService;
            Date_Of_Ending_Service.Text = Hanger_Database.Hanger[Hanger_Database.Plane_Index[PResults.SelectedIndex]].DateOfEndingService;
            EditPlaneSetUp();
        }

        private void BlankPlaneFields()
        {
            AirplaneNumber.Text = "";
            Model.Text = "";
            Plane_Cargo_Width.Text = "";
            Plane_Cargo_Height.Text = "";
            Plane_Cargo_Length.Text = "";
            Cargo_Capacity.Text = "";
            Flight_Time.Text = "";
            Fuel_Capacity.Text = "";
            Runway_Length.Text = "";
            Date_Of_Starting_Service.Text = "";
            Date_Of_Ending_Service.Text = "";
        }

        private void Save_Plane_Click(object sender, RoutedEventArgs e)
        {
            Plane plane = new Plane(AirplaneNumber.Text, Model.Text, Plane_Cargo_Width.Text, Plane_Cargo_Length.Text, Plane_Cargo_Height.Text,
                Cargo_Capacity.Text, Flight_Time.Text, Fuel_Capacity.Text, Runway_Length.Text, Date_Of_Starting_Service.Text,
                Date_Of_Ending_Service.Text);

            plane.EditPlane(Hanger_Database.Plane_Index[PResults.SelectedIndex], plane);
            DefaultPlanes();
        }

        private void Cancel_Plane_Click(object sender, RoutedEventArgs e)
        {
            DefaultPlanes();
        }

        private void EditPlaneSetUp()
        {
            Save_Plane.IsEnabled = true;
            Cancel_Plane.IsEnabled = true;
            Edit_Plane.IsEnabled = false;
            Erase_Plane.IsEnabled = false;
        }

        private void Search_Plane_Click(object sender, RoutedEventArgs e)
        {
            Plane plane = new Plane(AirplaneNumber.Text, Model.Text, Plane_Cargo_Width.Text, Plane_Cargo_Length.Text, Plane_Cargo_Height.Text,
                Cargo_Capacity.Text, Flight_Time.Text, Fuel_Capacity.Text, Runway_Length.Text, Date_Of_Starting_Service.Text,
                Date_Of_Ending_Service.Text);

            plane.SearchPlane(plane);
            PResults.Items.Clear();
            PrintPlanes();
        }
    }
}
