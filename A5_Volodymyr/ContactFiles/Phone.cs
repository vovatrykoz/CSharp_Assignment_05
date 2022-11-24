using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_Volodymyr.ContactFiles
{
    public class Phone
    {
        private string strHome;
        private string strWork;

        //chain calling constructors
        public Phone():this(string.Empty, string.Empty)
        {

        }

        public Phone(string homePhone, string workPhone)
        {

            strHome = homePhone;
            strWork = workPhone;
        }

        //read and write for Phone properties
        public string Personal
        {
            //private mail
            get { return strHome; }

            set { strHome = value; }
        }

        public string Cell
        {
            //private mail
            get { return strWork; }

            set { strWork = value; }
        }
        //converts everything to a single string
        public override string ToString()
        {
            string strOut = string.Format("\t{0,-20} {1, -20}", strWork, strHome);
            return strOut;
        }
    }
}
