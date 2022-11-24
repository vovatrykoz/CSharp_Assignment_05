using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Email
    {
        private string strPersonal;

        private string strWork;

       

        //chain calling email constructors
        public Email ( )
        {
        }


        public Email (string workMail) : this ( workMail, string.Empty )
        {
        }

        public Email (string workMail, string personalMail)
        {
            strWork = workMail;
            strPersonal = personalMail;
        }

        //read and write properties for email.

        public string Personal
        {
            //private mail
            get { return strPersonal; }

            set { strPersonal = value; }
        }

        public string Work
        {
            get { return strWork; }

            set { strWork = value; }
        }

        //returns the input as a single string

        public override string ToString()
        {
            string strOut = string.Format ( "{0,-20} {1, -20}", strWork, strPersonal );
            return strOut;
        }


    }







