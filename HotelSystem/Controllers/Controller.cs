using HotelSystem.Databases;
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
            IUserDAO uDAO = DAOFactory.GetOnlyInstance().GetUserDAO();
            return uDAO.Login(username, password);
        }
    }
}
