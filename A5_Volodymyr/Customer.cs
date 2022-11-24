using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A5_Volodymyr.ContactFiles;
using System.Threading.Tasks;

namespace A5_Volodymyr
{
    public class Customer
    {
        public Contact m_contact = new Contact();//an instance of a contact class
        string m_id;

        //a series of constructors
        public Customer()
        {
            m_contact = new Contact();
        }

        public Customer(Contact contactGet, string id)
        {

        }

        public Contact ContactData //a property that reads and writes the contact data
        {
            get { return m_contact; }
            set { m_contact = value; }
        }

        public string ID //used to assign an ID to an entry
        {
            get { return m_id; }
            set { m_id = value; }
        }



        public override string ToString() //converts everything to string
        {            
            string strOut = m_id + " " + m_contact.ToString();
            return strOut;
        }
    }
}

