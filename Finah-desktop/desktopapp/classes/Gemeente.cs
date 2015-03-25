using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Gemeente
    {
        //Getters and Setters
        private String postcode{ set; get;}
        private String gemeente { set; get; }

        //Constructors
        public Gemeente(String postcode, String gemeente)
        {
            this.postcode = postcode;
            this.gemeente = gemeente;
        }
    }
}
