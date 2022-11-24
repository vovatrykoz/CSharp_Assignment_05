using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A5_Volodymyr.ContactFiles;
using System.Windows.Forms;

namespace A5_Volodymyr
{
    public partial class ContactForm : Form
    {
        public Contact m_contact = new Contact();

        bool okButtonPressed = false;


        private bool m_closeForm = false;

        public ContactForm(string title)
        {
            
        }

        public ContactForm()//some initialization
        {
            InitializeComponent();

            InitializeGUI();
        }



        public Contact ContactData//sets a property corresponding to the Contact.cs
        {
            get { return m_contact; }
            set
            {
                if (value != null)
                    m_contact = value;

                okButtonPressed = false;
                UpdateGUI();
            }
        }


        private Email ReadEmail() //reads the email
        {
            if (!String.IsNullOrEmpty(txtWorkEmail.Text)) //checks that something is written in
            {
                ContactData.EmailData.Personal = txtWorkEmail.Text;
                ContactData.EmailData.Work = txtPersEmail.Text;
            }
            

            return ContactData.EmailData; //returns the new data with values
        }

        private Phone ReadPhones() //reads the phone input
        {
            //checks that something is written in
            if (!String.IsNullOrEmpty(txtHomePhone.Text) && !String.IsNullOrEmpty(txtCellPhone.Text))
            {
                ContactData.PhoneData.Personal = txtHomePhone.Text; 
                ContactData.PhoneData.Cell = txtCellPhone.Text;
            }

            return ContactData.PhoneData;//returns the new data with values
        }


        private Address ReadAddress()
        {


           if (!String.IsNullOrEmpty(txtStreet.Text) && !String.IsNullOrEmpty(txtCity.Text) && !String.IsNullOrEmpty(txtZip.Text))
            {
            ContactData.AddressData.Street = txtStreet.Text; 
            ContactData.AddressData.City = txtCity.Text;
            ContactData.AddressData.Zip = txtZip.Text;
            ContactData.AddressData.Countries = (Countries)cmbCountry.SelectedIndex;
            }

            return ContactData.AddressData;  //returns the new data with values
        }


        private void InitializeGUI() //initialization of th contact form
        {
            cmbCountry.DataSource = Enum.GetValues(typeof(Countries));
            cmbCountry.SelectedItem = Countries.Sweden;

            m_closeForm = true;
        }

        private void UpdateGUI() //used to fill the contact form if a listbox item is selected
        {

            if(!okButtonPressed)
            {
                txtFirstName.Text = m_contact.FirstName;
                txtLastName.Text = m_contact.LastName;
                txtHomePhone.Text = m_contact.PhoneData.Personal;
                txtCellPhone.Text = m_contact.PhoneData.Cell;
                txtWorkEmail.Text = m_contact.EmailData.Work;
                txtPersEmail.Text = m_contact.EmailData.Personal;
                txtStreet.Text = m_contact.AddressData.Street;
                txtCity.Text = m_contact.AddressData.City;
                txtZip.Text = m_contact.AddressData.Zip;
                cmbCountry.SelectedItem = m_contact.AddressData.Countries;
            }

        }

        private bool ReadInput() //reads the input
        {
            bool success = false;

            Contact contact = new Contact();

            contact.FirstName = txtFirstName.Text; //takes the input directly from textboxes
            contact.LastName = txtLastName.Text;
            
            Email email = new Email();
            Phone phone = new Phone();
            Address address = new Address();

            contact.EmailData = ReadEmail(); //uses earlier defined methods to take care of input
            contact.PhoneData =  ReadPhones();
            contact.AddressData = ReadAddress();

            success = contact.CheckInput(); //checks that input is ok

            
            if (success)
            {
                m_contact = contact; //saves the values
            }
            else 
            {
                string strMessage = "First name, last name and a city are required!\nPlease, try again!"; //returns an error message
                MessageBox.Show(strMessage);
                success = false;
            }

            return success;
        }

        private void ContactForm_FormClosing(object sender, FormClosingEventArgs e)//event handler for when the form closes
        {
            if (m_closeForm)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            okButtonPressed = true; //used to signal that the ok button was pressed

            if (ReadInput())
            {
                UpdateGUI();
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_closeForm = true;//closes the form
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {

        }
    }
}
