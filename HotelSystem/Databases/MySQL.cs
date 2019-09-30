using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Databases {
    internal class MySQL {
        private readonly MySqlConnection connection;

        public MySQL() {
            connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=hotel_db;");
        }

        private DatabaseStatus OpenConnection() {
            Debug.WriteLine("abc");
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

        private DatabaseStatus CloseConnection() {
            connection.Close();
            return DatabaseStatus.Ok;
        }

        internal bool Login(string username, string password) {
            if (OpenConnection() == DatabaseStatus.Connected) {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand();

                String query = "SELECT * FROM `users` WHERE `username`=@user AND `password`=@pass";

                command.Connection = this.connection;
                command.CommandText = query;
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                adapter.Dispose();

                CloseConnection();

                return (table.Rows.Count > 0);
            }

            return false;
        }
    }
}
