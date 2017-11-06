using FedEx.Model.DataBases;
using System.Collections.Generic;

namespace FedEx.Model.Modules
{
    class Customer_Constructor
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public Billing_Address Billing = null;
        public List<Mailing_Address> Mailing = new List<Mailing_Address>();

        public void AddCustomer(Master_Address customer)
        {
            Aerial_Database.Aerial_Master.Add(customer);
        }

        public void SearchCustomer(Master_Address customer)
        {
            var index = 0;
            Aerial_Database.indexes.Clear();
            List<int> indexes = new List<int>();
            foreach(Master_Address find in Aerial_Database.Aerial_Master)
            {
                if(find.Billing.CompanyName == customer.Billing.CompanyName || find.Billing.ContactName == customer.Billing.ContactName ||
                    find.Billing.StreetAddress1 == customer.Billing.StreetAddress1 || find.Billing.StreetAddress2 == customer.Billing.StreetAddress2 ||
                    find.Billing.City == customer.Billing.City || find.Billing.StateOrProvince == customer.Billing.StateOrProvince ||
                    find.Billing.Country == customer.Billing.Country || find.Billing.Zipcode == customer.Billing.Zipcode)
                {
                    indexes.Add(index);
                    index++;
                } else {
                    index++;
                }                
            }
            Aerial_Database.indexes = indexes;
        }

        public void SearchMailing(int customerIndex, Mailing_Address mail)
        {
            var index = 0;
            List<int> indexes = new List<int>();
            foreach (Mailing_Address find in Aerial_Database.Aerial_Master[customerIndex].Mailing)
            {
                if (find.CompanyName == mail.CompanyName || find.ContactName == mail.ContactName ||
                    find.StreetAddress1 == mail.StreetAddress1 || find.StreetAddress2 == mail.StreetAddress2 ||
                    find.City == mail.City || find.StateOrProvince == mail.StateOrProvince ||
                    find.Country == mail.Country || find.Zipcode == mail.Zipcode)
                {
                    indexes.Add(index);
                    index++;
                }
                else
                {
                    index++;
                }
            }
            Aerial_Database.mailIndexes = indexes;
        }

        public void EditBillingAddress(int index, Billing_Address newBillAdd)
        {
            Aerial_Database.Aerial_Master[index].Billing.CompanyName = newBillAdd.CompanyName;
            Aerial_Database.Aerial_Master[index].Billing.ContactName = newBillAdd.ContactName;
            Aerial_Database.Aerial_Master[index].Billing.StreetAddress1 = newBillAdd.StreetAddress1;
            Aerial_Database.Aerial_Master[index].Billing.StreetAddress2 = newBillAdd.StreetAddress2;
            Aerial_Database.Aerial_Master[index].Billing.City = newBillAdd.City;
            Aerial_Database.Aerial_Master[index].Billing.StateOrProvince = newBillAdd.StateOrProvince;
            Aerial_Database.Aerial_Master[index].Billing.Country = newBillAdd.Country;
            Aerial_Database.Aerial_Master[index].Billing.Zipcode = newBillAdd.Zipcode;
        }

        public void EditMailingAddress(int comIndex, int index, Mailing_Address newMailAdd)
        {
            Aerial_Database.Aerial_Master[comIndex].Mailing[index].ContactName = newMailAdd.ContactName;
            Aerial_Database.Aerial_Master[comIndex].Mailing[index].StreetAddress1 = newMailAdd.StreetAddress1;
            Aerial_Database.Aerial_Master[comIndex].Mailing[index].StreetAddress2 = newMailAdd.StreetAddress2;
            Aerial_Database.Aerial_Master[comIndex].Mailing[index].City = newMailAdd.City;
            Aerial_Database.Aerial_Master[comIndex].Mailing[index].StateOrProvince = newMailAdd.StateOrProvince;
            Aerial_Database.Aerial_Master[comIndex].Mailing[index].Country = newMailAdd.Country;
            Aerial_Database.Aerial_Master[comIndex].Mailing[index].Zipcode = newMailAdd.Zipcode;
        }
    }

    class Master_Address : Customer_Constructor
    {
        public Master_Address(Billing_Address billing, List<Mailing_Address> mailing)
        {
            Billing = billing;
            Mailing = mailing;
        }
    }

    class Billing_Address : Customer_Constructor
    {
        public Billing_Address(string companyname, string contactname, string streetaddress1, string streetaddress2,
            string stateorprovince, string city, string country, string zipcode)
        {
            CompanyName = companyname;
            ContactName = contactname;
            StreetAddress1 = streetaddress1;
            StreetAddress2 = streetaddress2;
            City = city;
            StateOrProvince = stateorprovince;
            Country = country;
            Zipcode = zipcode;
        }       
    }

    class Mailing_Address : Customer_Constructor
    {
        public Mailing_Address(string companyname, string contactname, string streetaddress1, string streetaddress2,
            string stateorprovince, string city, string country, string zipcode)
        {
            CompanyName = companyname;
            ContactName = contactname;
            StreetAddress1 = streetaddress1;
            StreetAddress2 = streetaddress2;
            City = city;
            StateOrProvince = stateorprovince;
            Country = country;
            Zipcode = zipcode;
        }       

        public void AddMailingAddress(Mailing_Address mailing, int customerIndex)
        {
            Aerial_Database.Aerial_Master[customerIndex].Mailing.Add(mailing);
        }
    }
}