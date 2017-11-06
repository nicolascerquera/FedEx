using FedEx.Model.DataBases;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FedEx.Model.Modules;
using System;


namespace FedEx.View
{
    public sealed partial class Customers : Page
    {
        public Customers()
        {
            this.InitializeComponent();
            DefaultAerial();
            Results.Items.Clear();
            PrintCustomers(Aerial_Database.indexes);
            DefaultSetUp();
        }

        private void DefaultSetUp()
        {
            EditBillingAddress.IsEnabled = false;
            EraseBillingAddress.IsEnabled = false;
            SaveBillingAddress.IsEnabled = false;
            CancelBillingAddress.IsEnabled = false;
            AddBillingAddress.IsEnabled = true;
            SearchBillingAddress.IsEnabled = true;
            SearchMailingAddress.IsEnabled = false;
            EraseMailingAddress.IsEnabled = false;
            SaveMailingAddress.IsEnabled = false;
            CancelMailingAddress.IsEnabled = false;
            EditMailingAddress.IsEnabled = false;
            AddMailingAddress.IsEnabled = false;
            BlankBillingFields();
            Results.Items.Clear();
            DefaultAerial();
            PrintCustomers();
            ResetCustomers();
        }

        private void ResetCustomers()
        {
            Results.SelectedIndex = -1;
        }

        private void DefaultMailing(int customerIndex)
        {
            Aerial_Database.mailIndexes.Clear();
            for (var i = 0; i < Aerial_Database.Aerial_Master[customerIndex].Mailing.Count; i++)
            {
                Aerial_Database.mailIndexes.Add(i);
            }
        }

        private void Results_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MailingResults.Items.Clear();
            PrintMailing(Aerial_Database.mailIndexes);
            BillingSelected();
        }

        private void BillingSelected()
        {
            EditBillingAddress.IsEnabled = true;
            EraseBillingAddress.IsEnabled = true;
            SaveBillingAddress.IsEnabled = false;
            CancelBillingAddress.IsEnabled = false;
            AddMailingAddress.IsEnabled = true;
            SearchMailingAddress.IsEnabled = true;
            EraseMailingAddress.IsEnabled = false;
            SaveMailingAddress.IsEnabled = false;
            CancelMailingAddress.IsEnabled = false;
            AddBillingAddress.IsEnabled = false;
            SearchBillingAddress.IsEnabled = false;
            EditMailingAddress.IsEnabled = false;
            BlankBillingFields();
        }

        private void EraseMailingAddress_Click(object sender, RoutedEventArgs e)
        {
            DefaultMailing(Aerial_Database.indexes[Results.SelectedIndex]);
            Aerial_Database.DeleteMailingAddress(Aerial_Database.indexes[Results.SelectedIndex], Aerial_Database.mailIndexes[MailingResults.SelectedIndex]);
            MailingResults.Items.Clear();
            PrintMailing(Aerial_Database.mailIndexes);
        }

        private void Customer1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Planes_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PrintMailing()
        {
            var customerList = Aerial_Database.PrintAerial(Aerial_Database.indexes);
            if (customerList.ElementAtOrDefault(Results.SelectedIndex) != null)
            {
                var list = Aerial_Database.PrintMailing(Aerial_Database.indexes[Results.SelectedIndex]);
                foreach (TextBlock ibox in list)
                {
                    MailingResults.Items.Add(ibox);
                }
            }
        }

        private void DefaultAerial()
        {
            Aerial_Database.indexes.Clear();
            for (var i = 0; i < Aerial_Database.Aerial_Master.Count; i++)
            {
                Aerial_Database.indexes.Add(i);
            }
        }

        private void PrintCustomers(List<int> indexes)
        {
            var list = Aerial_Database.PrintAerial(indexes);
            foreach (TextBlock ibox in list)
            {
                Results.Items.Add(ibox);

            }
        }

        private void PrintCustomers()
        {
            DefaultAerial();
            var list = Aerial_Database.PrintAerial(Aerial_Database.indexes);
            foreach (TextBlock ibox in list)
            {
                Results.Items.Add(ibox);

            }
        }

        private void PrintMailing(List<int> indexes)
        {
            var customerList = Aerial_Database.PrintAerial(Aerial_Database.indexes);
            if (customerList.ElementAtOrDefault(Results.SelectedIndex) != null)
            {
                DefaultMailing(Aerial_Database.indexes[Results.SelectedIndex]);
                var list = Aerial_Database.PrintMailing(Aerial_Database.indexes[Results.SelectedIndex], indexes);
                foreach (TextBlock ibox in list)
                {
                    MailingResults.Items.Add(ibox);

                }
            }
        }

        private void DefaultPrintMailing(List<int> indexes)
        {
            var list = Aerial_Database.PrintMailing(Aerial_Database.indexes[Results.SelectedIndex], indexes);
            foreach (TextBlock ibox in list)
            {
                MailingResults.Items.Add(ibox);

            }
        }

        private void EraseBillingAddress_Click(object sender, RoutedEventArgs e)
        {
            Aerial_Database.DeleteCustomer(Aerial_Database.indexes[Results.SelectedIndex]);
            Aerial_Database.indexes.RemoveAt(Results.SelectedIndex);
            DefaultAerial();
            Results.Items.Clear();
            PrintCustomers();
            DefaultSetUp();
        }

        private void EditBillingAddress_Click(object sender, RoutedEventArgs e)
        {
            var index = Aerial_Database.indexes[Results.SelectedIndex];
            CompanyName_Billing.Text = Aerial_Database.Aerial_Master[index].Billing.CompanyName;
            ContactName_Billing.Text = Aerial_Database.Aerial_Master[index].Billing.ContactName;
            StreetAddress1_Billing.Text = Aerial_Database.Aerial_Master[index].Billing.StreetAddress1;
            StreetAddress2_Billing.Text = Aerial_Database.Aerial_Master[index].Billing.StreetAddress2;
            City_Billing.Text = Aerial_Database.Aerial_Master[index].Billing.City;
            StateOrProvince_Billing.Text = Aerial_Database.Aerial_Master[index].Billing.StateOrProvince;
            Country_Billing.Text = Aerial_Database.Aerial_Master[index].Billing.Country;
            Zipcode_Billing.Text = Aerial_Database.Aerial_Master[index].Billing.Zipcode;
            EditSetUp();
        }
        private void EditSetUp()
        {
            EraseBillingAddress.IsEnabled = false;
            SaveBillingAddress.IsEnabled = true;
            CancelBillingAddress.IsEnabled = true;
            EditBillingAddress.IsEnabled = false;
        }

        private void SaveBillingAddress_Click(object sender, RoutedEventArgs e)
        {
            Billing_Address billing = new Billing_Address(CompanyName_Billing.Text, ContactName_Billing.Text, StreetAddress1_Billing.Text,
                StreetAddress2_Billing.Text, StateOrProvince_Billing.Text, City_Billing.Text, Country_Billing.Text, Zipcode_Billing.Text);
            var index = Aerial_Database.indexes[Results.SelectedIndex];
            billing.EditBillingAddress(index, billing);
            Results.Items.Clear();
            DefaultAerial();
            PrintCustomers(Aerial_Database.indexes);
            DefaultSetUp();
        }

        private void CancelBillingAddress_Click(object sender, RoutedEventArgs e)
        {
            BillingSelected();
        }

        private void BlankBillingFields()
        {
            CompanyName_Billing.Text = "";
            ContactName_Billing.Text = "";
            StreetAddress1_Billing.Text = "";
            StreetAddress2_Billing.Text = "";
            City_Billing.Text = "";
            StateOrProvince_Billing.Text = "";
            Country_Billing.Text = "";
            Zipcode_Billing.Text = "";
        }

        private void AddBillingAddress_Click(object sender, RoutedEventArgs e)
        {
            Master_Address customer = new Master_Address(new Billing_Address(CompanyName_Billing.Text, ContactName_Billing.Text, StreetAddress1_Billing.Text,
                StreetAddress2_Billing.Text, StateOrProvince_Billing.Text, City_Billing.Text, Country_Billing.Text, Zipcode_Billing.Text), new List<Mailing_Address>());
            customer.AddCustomer(customer);
            Results.Items.Clear();
            DefaultAerial();
            PrintCustomers(Aerial_Database.indexes);
            DefaultSetUp();

        }

        private void SearchBillingAddress_Click(object sender, RoutedEventArgs e)
        {
            Master_Address customer = new Master_Address(new Billing_Address(CompanyName_Billing.Text, ContactName_Billing.Text, StreetAddress1_Billing.Text,
               StreetAddress2_Billing.Text, StateOrProvince_Billing.Text, City_Billing.Text, Country_Billing.Text, Zipcode_Billing.Text), new List<Mailing_Address>());
            Results.Items.Clear();
            customer.SearchCustomer(customer);
            PrintCustomers(Aerial_Database.indexes);
        }

        private void MailingResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MailingSelected();
        }

        private void AddMailingAddress_Click(object sender, RoutedEventArgs e)
        {
            Mailing_Address mailing = new Mailing_Address(CompanyName_Mailing.Text, ContactName_Mailing.Text, StreetAddress1_Mailing.Text,
               StreetAddress2_Mailing.Text, StateOrProvince_Mailing.Text, City_Mailing.Text, Country_Mailing.Text, Zipcode_Mailing.Text);
            mailing.AddMailingAddress(mailing, Aerial_Database.indexes[Results.SelectedIndex]);
            MailingResults.Items.Clear();
            PrintMailing(Aerial_Database.mailIndexes);
            ClearMailingFields();
        }

        private void ClearMailingFields()
        {
            CompanyName_Mailing.Text = "";
            ContactName_Mailing.Text = "";
            StreetAddress1_Mailing.Text = "";
            StreetAddress2_Mailing.Text = "";
            StateOrProvince_Mailing.Text = "";
            City_Mailing.Text = "";
            Country_Mailing.Text = "";
            Zipcode_Mailing.Text = "";
        }

        private void MailingSelected()
        {
            AddMailingAddress.IsEnabled = false;
            SearchMailingAddress.IsEnabled = false;
            EditMailingAddress.IsEnabled = true;
            EraseMailingAddress.IsEnabled = true;
            SaveMailingAddress.IsEnabled = false;
            CancelMailingAddress.IsEnabled = false;
        }

        private void EditMailingAddress_Click(object sender, RoutedEventArgs e)
        {
            var customerIndex = Aerial_Database.indexes[Results.SelectedIndex];
            DefaultMailing(customerIndex);
            CompanyName_Mailing.Text = Aerial_Database.Aerial_Master[customerIndex].Mailing[Aerial_Database.mailIndexes[MailingResults.SelectedIndex]].CompanyName;
            ContactName_Mailing.Text = Aerial_Database.Aerial_Master[customerIndex].Mailing[Aerial_Database.mailIndexes[MailingResults.SelectedIndex]].ContactName;
            StreetAddress1_Mailing.Text = Aerial_Database.Aerial_Master[customerIndex].Mailing[Aerial_Database.mailIndexes[MailingResults.SelectedIndex]].StreetAddress1;
            StreetAddress2_Mailing.Text = Aerial_Database.Aerial_Master[customerIndex].Mailing[Aerial_Database.mailIndexes[MailingResults.SelectedIndex]].StreetAddress2;
            City_Mailing.Text = Aerial_Database.Aerial_Master[customerIndex].Mailing[Aerial_Database.mailIndexes[MailingResults.SelectedIndex]].City;
            StateOrProvince_Mailing.Text = Aerial_Database.Aerial_Master[customerIndex].Mailing[Aerial_Database.mailIndexes[MailingResults.SelectedIndex]].StateOrProvince;
            Country_Mailing.Text = Aerial_Database.Aerial_Master[customerIndex].Mailing[Aerial_Database.mailIndexes[MailingResults.SelectedIndex]].Country;
            Zipcode_Mailing.Text = Aerial_Database.Aerial_Master[customerIndex].Mailing[Aerial_Database.mailIndexes[MailingResults.SelectedIndex]].Zipcode;
            EditMailingSetUp();
        }

        private void EditMailingSetUp()
        {
            EditMailingAddress.IsEnabled = false;
            EraseMailingAddress.IsEnabled = false;
            SaveMailingAddress.IsEnabled = true;
            CancelMailingAddress.IsEnabled = true;
        }

        private void SaveMailingAddress_Click(object sender, RoutedEventArgs e)
        {
            Mailing_Address mailing = new Mailing_Address(CompanyName_Mailing.Text, ContactName_Mailing.Text, StreetAddress1_Mailing.Text,
              StreetAddress2_Mailing.Text, StateOrProvince_Mailing.Text, City_Mailing.Text, Country_Mailing.Text, Zipcode_Mailing.Text);
            mailing.EditMailingAddress(Aerial_Database.indexes[Results.SelectedIndex], MailingResults.SelectedIndex, mailing);
            MailingSelected();
            ClearMailingFields();
            MailingResults.Items.Clear();
            DefaultMailing(Aerial_Database.indexes[Results.SelectedIndex]);
            PrintMailing(Aerial_Database.mailIndexes);
        }

        private void CancelMailingAddress_Click(object sender, RoutedEventArgs e)
        {
            ClearMailingFields();
            MailingSelected();
        }

        private void SearchMailingAddress_Click(object sender, RoutedEventArgs e)
        {
            Mailing_Address mailing = new Mailing_Address(CompanyName_Mailing.Text, ContactName_Mailing.Text, StreetAddress1_Mailing.Text,
             StreetAddress2_Mailing.Text, StateOrProvince_Mailing.Text, City_Mailing.Text, Country_Mailing.Text, Zipcode_Mailing.Text);
            mailing.SearchMailing(Aerial_Database.indexes[Results.SelectedIndex], mailing);
            MailingResults.Items.Clear();
            DefaultPrintMailing(Aerial_Database.mailIndexes);
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            Orders form = new Orders();
            Window.Current.Content.Visibility = Visibility.Collapsed;
            Window.Current.Content = form;
            form.Visibility = Visibility.Visible;
        }

        private void PlanesButton_Click(object sender, RoutedEventArgs e)
        {
            Planes form = new Planes();
            Window.Current.Content.Visibility = Visibility.Collapsed;
            Window.Current.Content = form;
            form.Visibility = Visibility.Visible;
        }
    }
}
