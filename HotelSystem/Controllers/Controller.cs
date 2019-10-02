using HotelSystem.Databases;
using HotelSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Controllers {
    class Controller {
        private static Controller onlyInstance;

        private Controller() {
            DAOFactory.SetDAOFactory(DatabaseTypes.MySQL);
        }

        public static Controller GetOnlyInstance() {
            if (onlyInstance == null)
                onlyInstance = new Controller();
            return onlyInstance;
        }

        public bool Login(string username, string password) {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.Login(username, password);
        }

        public Client CreateClient(string name, string lastName, string phone, string country) {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.CreateClient(name, lastName, phone, country);
        }

        public bool UpdateClient(int id, string name, string lastName, string phone, string country) {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.UpdateClient(id, name, lastName, phone, country);
        }

        public bool RemoveClient(int id) {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.RemoveClient(id);
        }

        public List<Client> GetClients() {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.GetClients();
        }
    }
}
