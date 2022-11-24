using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_Volodymyr.ContactFiles
{
    public class Address
    {

        private string strStreet;
        private string strZip;
        private string strCity;
        private Countries enmCountry;

        //chain calling the constructors
        public Address(): this (string.Empty, string.Empty,  "Västerås") 
        {
        }

        public Address(string street, string zip, string city, Countries country)
        {

        }

        public Address(string street, string zip, string city):
            this (street, zip, city, Countries.Sweden)
        {

        }


        //methods for writing and reading address properties
        public string Street
        {
            get { return strStreet; }
            set { strStreet = value; }
        }

        public string Zip
        {
            get { return strZip; }
            set { strZip = value; }
        }

        public string City
        {
            get { return strCity; }
            set { strCity = value; }
        }

        public Countries Countries
        {
            get { return enmCountry; }
            set { enmCountry = value; }
        }

        public bool CheckInput() //checks the input later
        {
            bool inputOk;

            if(!string.IsNullOrEmpty(GetCountryString()) && !string.IsNullOrEmpty(strCity))
            {
                inputOk = true;
            }
            else
            {
                inputOk = false;
            }

            return inputOk;
        }

        public string GetCountryString() //converts an enum item to string
        {
            string strCountry = enmCountry.ToString();
            strCountry = strCountry.Replace("_", " ");
            return strCountry;
        }

        public override string ToString() //converts the output to a single string
        {
            string strOut = string.Format("\t\t{0, -8} {1, -8} {2, -10} {3}", strStreet, strZip, strCity, GetCountryString());
            return strOut;
        }
    }
}
