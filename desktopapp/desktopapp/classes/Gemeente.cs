using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Gemeente
    {
        private String postcode;
        private String gemeente;

        public Gemeente(String postcode, String gemeente)
        {
            this.postcode = postcode;
            this.gemeente = gemeente;

        }
        
        public String Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public String Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }
        
    }
}
