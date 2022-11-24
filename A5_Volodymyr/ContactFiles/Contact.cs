using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_Volodymyr.ContactFiles
{
    public class Contact
    {
        private string strFirstName = string.Empty;
        private string strLastName = string.Empty;

        private Address m_address;
        private Email m_email;
        private Phone m_phone;

        //a series of constructors

        public Contact(Email email)
        {
            m_email = email;
        }



        public Contact()
        {
            m_address = new Address();
            m_phone = new Phone();
            m_email = new Email();
        }

        public Contact(string firstName, string LastName, Address adress, Phone phone, Email mail)
        {

        }
        
        public Contact(Contact theOther)
        {
            this.strFirstName = theOther.strFirstName;
            this.strFirstName = theOther.strLastName;
            this.m_address = theOther.m_address;
            this.m_email = theOther.m_email;
            this.m_phone = theOther.m_phone;
        } 

        //properties that can be used in conjunction with an instance of a contact class in other classes
        public Address AddressData //reads and writes address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        public Email EmailData//reads and writes email
        {
            get { return m_email; }
            set { m_email = value; }
        }

        public Phone PhoneData//reads and writes phones
        {
            get { return m_phone; }
            set { m_phone = value; }
        }

        public string FirstName //reads and writes the first name
        {
            get { return strFirstName; }
            set { strFirstName = value; }
        }

        public string LastName //reads and writes the last name
        {
            get { return strLastName; }
            set { strLastName = value; }
        }

        public string FullName //combines the two
        {
            get { return "\t" + FirstName + "   " + LastName; }
        }
        
        public bool CheckInput() //checks that the name is not empty
        {
            bool inputOk;

            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                inputOk = true;
            }
            else
            {
                inputOk = false;
            }

            return inputOk;
        }

        public override string ToString()
        {
            string strOut = string.Format("{0, -20} {1} {2} {3}", FullName, m_address.ToString(), m_phone.ToString(), m_email.ToString());
            return strOut;
        }
    }
}
