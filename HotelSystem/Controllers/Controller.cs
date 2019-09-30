using HotelSystem.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Controllers {
    class Controller {
        private static Controller onlyInstance;
        private readonly MySQL connection;

        private Controller() {
            connection = new MySQL();
        }

        public static Controller GetOnlyInstance() {
            if (onlyInstance == null)
                onlyInstance = new Controller();
            return onlyInstance;
        }

        public bool Login(string username, string password) {
            return connection.Login(username, password);
        }
    }
}
