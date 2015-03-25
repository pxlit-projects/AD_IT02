using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finah
{
    public class Users
    {
        private int userID;
        private int age;
        private string name;
        private string email;
        private string phone;
        private int institution;
        private string username;
        private string password;
        private int role;

        //null constructor
        public Users() { }

        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        public int Institution
        {
            get
            {
                return institution;
            }
            set
            {
                institution = value;
            }
        }
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public int Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }
    }
}
