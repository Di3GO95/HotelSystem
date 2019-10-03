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
        public static DAOFactory OnlyInstance { get; private set; }

        public abstract IUserDAO GetUserDAO();

        public abstract IRoomDAO GetRoomDAO();

        public static void SetDAOFactory(DatabaseTypes type) {
            switch (type) {
                case DatabaseTypes.MySQL: {
                    OnlyInstance = new MySQLDAOFactory();
                    break;
                }
            }
        }
    }
}
