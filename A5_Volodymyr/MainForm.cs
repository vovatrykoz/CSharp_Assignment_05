using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace A5_Volodymyr
{
    public partial class MainForm : Form
    {
        //creating an instance the CustomerManager.cs
        CustomerManager customerMngr = new CustomerManager();

        bool sortByName = false; //var that will help determine when to sort the array by name

        public MainForm()
        {
            InitializeComponent();//Init by the VS

            //InitializeGUI();
        }


        private void UpdateCustomerList()
        {

            //determines how exactly GUI should be updated. In this case, it will be sorted by name
            if (sortByName)
            {
                string[] strContacts = customerMngr.SortByName();

                lstCustomers.Items.Clear(); //clearing the listbox, so that entries do not repeat
                lstCustomers.Items.AddRange(strContacts); //Adding the array in string format to the list box
                sortByName = false;
            }
            else
            {
                //Gets the list with all the contact information in a form of a string array
                string[] strContacts = customerMngr.GetCustomerInfoToString();

                if (strContacts != null) //checks so that the array has values in it
                {
                    lstCustomers.Items.Clear(); //clearing the listbox, so that entries do not repeat
                    lstCustomers.Items.AddRange(strContacts); //Adding the array in string format to the list box
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                } 
                else
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            ContactForm contactForm = new ContactForm();//creates an instance of a contact form

            int index = lstCustomers.SelectedIndex; //gets the listbox item which is currently selected

            if (index != -1)//if a listbox item is selected, the data will be loaded into contact form
                contactForm.ContactData = customerMngr.GetCustomerIndex(index).ContactData;

            if (contactForm.ShowDialog() == DialogResult.OK)//waits for the user to press OK
            {
                customerMngr.AddCustomer(contactForm.ContactData);//sends the info to be added to the List<T> to the customer manager
                UpdateCustomerList();//updates the GUI
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstCustomers.SelectedIndex; //gets the listbox item which is currently selected

            if (index != -1) //checks that something is actually seleccted
            {
                customerMngr.DeleteContact(index); //deletes an entry
                UpdateCustomerList();//updates the GUI
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();//creates an instance of a contact form

            int index = lstCustomers.SelectedIndex; //gets the listbox item which is currently selected
            
            if (index != -1)//if a listbox item is selected, the data will be loaded into contact form
                contactForm.ContactData = customerMngr.GetCustomerIndex(index).ContactData;

            if (contactForm.ShowDialog() == DialogResult.OK)
            {
                customerMngr.ChangeContact(index, contactForm.ContactData);//edits an entry


            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            sortByName = true; //when the name label is clicked, the program will sort everything by the first name
            UpdateCustomerList();
        }
    }
}
