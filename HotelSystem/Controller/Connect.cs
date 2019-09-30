using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Controller {
    class Connect {
        public MySqlConnection Connection { get; private set; }

        public Connect() {
            Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=hotel_db;");
        }

        public void OpenConnection() {
            if (Connection.State == ConnectionState.Closed) {
                Connection.Open();
            }
        }

        public void CloseConnection() {
            if (Connection.State == ConnectionState.Open) {
                Connection.Close();
            }
        }
    }
}
