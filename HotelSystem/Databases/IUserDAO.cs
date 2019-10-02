using HotelSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Databases {
    internal interface IUserDAO {
        bool Login(string username, string password);

        bool CreateClient(string firstName, string lastName, string phone, string country);

        List<Client> GetClients();
    }
}
