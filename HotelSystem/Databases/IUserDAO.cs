using HotelSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Databases {
    internal interface IUserDAO {
        bool Login(string username, string password);

        Client CreateClient(string firstName, string lastName, string phone, string country);

        bool UpdateClient(int id, string firstName, string lastName, string phone, string country);

        bool RemoveClient(int id);

        List<Client> GetClients();
    }
}
