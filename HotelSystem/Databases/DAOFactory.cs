using HotelSystem.Databases.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Databases {
    /// <summary>
    /// Abstract factory that returns all DAO of the app
    /// </summary>
    internal abstract class DAOFactory {
        private static DAOFactory onlyInstance;

        public static DAOFactory GetOnlyInstance() {
            return onlyInstance;
        }

        public abstract IUserDAO GetUserDAO();

        public static void SetDAOFactory(DatabaseTypes type) {
            switch (type) {
                case DatabaseTypes.MySQL: {
                    onlyInstance = new MySQLDAOFactory();
                    break;
                }
            }
        }
    }
}
