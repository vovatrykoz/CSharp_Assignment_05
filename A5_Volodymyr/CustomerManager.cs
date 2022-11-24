using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A5_Volodymyr.ContactFiles;
using System.Threading.Tasks;

namespace A5_Volodymyr
{
    public class CustomerManager
    {
        private List<Customer> l_customers; //creates a List<T> that can stor customers

        public CustomerManager()//a constructor
        {
            l_customers = new List<Customer>();
        }

        public int Count //read only property of the customer manager - the amount of items in the List<T>
        {
            get { return l_customers.Count; }
        }

        public int GetNewID //read only property of the customer manager - which item is being added
        {
            get { return GetNewID; }
        }

        public bool AddCustomer(Contact contactIn) //adds a customer
        {
            bool success;
            int id = Count;

            if (id != -1)
            {
                Customer customer = new Customer();
                customer.ContactData = contactIn; //puts data into the customer class
                customer.ID = (id + 100).ToString(); //adds the id 
                l_customers.Add(customer); //adds the customer data into the list

                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }

        public bool AddCustomer(Customer customerIn) //overloading the AddCustomer method with an instance of the Customer.cs
        {

            //works similarly to the line 29
            bool success;

            int id = Count;
            if (id != -1)
            {
                l_customers.Add(customerIn);

                success = true;
            }
            else
            {
                success = false;
            }

            return success;
        }

        public string[] GetCustomerInfoToString() //converts the List<T> into a string[] array
        {
            string[] strInfoStrings = new string[l_customers.Count];

            int i = 0;
            foreach (Customer customerObj in l_customers)
            {
                strInfoStrings[i++] = customerObj.ToString();
            }

            return strInfoStrings;
        }

        public Customer GetCustomerIndex(int index) //gets an item of List<T> at a certain index
        {
            if (index < 0 || index >= l_customers.Count)
            {
                return null;
            }

            return l_customers[index];
        }

        public bool DeleteContact(int index)
        {
            bool success = false;

            if (index != -1)
            {
                l_customers.RemoveAt(index); //removes a contact
                ShiftArray(index); //shifts the array
                success = true;
            }
            return success;
        }

        private void ShiftArray(int index) //this will shift the array, so that there are no empty spaces left
        {
            for (int arrayIndex = index + 1; arrayIndex < l_customers.Count; arrayIndex++)
            {
                l_customers[arrayIndex - 1] = l_customers[arrayIndex];
                l_customers.RemoveAt(index);
            }
        }

        /*The way that was easier for me to do in order to edit an entry was to remove one and then place a new 
         * one with edited parameter in its place. This is what this class does
         */

        public bool ChangeContact(int index, Contact contact) //surves the purpose of editing an entry
        {
            bool success;

            if(index != -1)
            {
                Customer customer = new Customer();
                customer.ContactData = contact; //puts data into the customer class
                customer.ID = (index + 100).ToString();
                l_customers.RemoveAt(index); //removes an entry
                l_customers.Insert(index, customer); //adds the entry instead of the old one
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }


        public string[] SortByName() //responcible for sorting by the first name
        {
            string[] tempArray = GetCustomerInfoToString(); //gets the existing array

            Array.Sort(tempArray); //sortss it by name

            return tempArray; //returns it
        }

    }
}
