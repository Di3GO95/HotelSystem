using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Controllers {
    internal class Connect {
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

        internal bool Login(string username, string password) {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();

            String query = "SELECT * FROM `users` WHERE `username`=@user AND `password`=@pass";

            command.Connection = this.Connection;
            command.CommandText = query;
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return (table.Rows.Count > 0);
        }
    }
}
