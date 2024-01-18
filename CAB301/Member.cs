using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301
{
    class Member
    {
        private string firstName;
        private string lastName;
        private string address;
        private string number;

        private string username;
        private string password;

        public List<string> borrowedMovies = new List<string>();

        public Member(string firstName, string lastName, string address, string number, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.number = number;
            this.password = password;

            username = this.lastName + this.firstName;


        }

        public string userName()
        {
            return username;
        }

        public string firstname()
        {
            return firstName;
        }

        public string lastname()
        {
            return lastName;
        }

        public string returnNumber()
        {
            return number;
        }

        public string returnPassword()
        {
            return password;
        }
    }
}
