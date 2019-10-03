using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Databases.MySQL {
    internal class MySQLDAOFactory : DAOFactory {
        protected readonly MySqlConnection connection;

        public MySQLDAOFactory() {
            connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=hotel_db;");
        }

        public DatabaseStatus OpenConnection() {
            try {
                connection.Open();
                return DatabaseStatus.Connected;
            } catch (MySqlException ex) {
                switch (ex.Number) {
                    case 0:
                        //Cannot connect to server
                        return DatabaseStatus.CannotConnect;
                    case 1045:
                        //Invalid username/password
                        return DatabaseStatus.InvalidUserPass;
                    default:
                        return DatabaseStatus.CannotConnect;
                }
            }
        }

        public DatabaseStatus CloseConnection() {
            connection.Close();
            return DatabaseStatus.Ok;
        }

        public override IUserDAO GetUserDAO() {
            return new MySQLUserDAO();
        }

        public override IRoomDAO GetRoomDAO() {
            return new MySQLRoomDAO();
        }
    }
}
