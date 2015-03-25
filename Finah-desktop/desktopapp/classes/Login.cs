using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Login
    {
        private String gebruiker;

        public Login(string gebruiker)
        {
            this.gebruiker = gebruiker;
        }

        public string Gebruiker
        {
            get { return gebruiker; }
            set { gebruiker = value; }
        }
    }
}
