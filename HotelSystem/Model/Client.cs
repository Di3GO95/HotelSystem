using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Model {
    internal class Client {
        public int Id { get; private set; }
        [System.ComponentModel.DisplayName("First Name")]
        public string FirstName { get; set; }
        [System.ComponentModel.DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

        public Client(int id, string firstName, string lastName, string phone, string country) {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.Country = country;
        }
    }
}
