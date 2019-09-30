using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Controllers {
    class Controller {
        private static Controller onlyInstance;

        private Controller() {

        }

        public static Controller GetOnlyInstance() {
            if (onlyInstance == null)
                onlyInstance = new Controller();
            return onlyInstance;
        }

        public bool Login(string username, string password) {
            Connect connection = new Connect();

            return connection.Login(username, password);
        }
    }
}
