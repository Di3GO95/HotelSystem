using HotelSystem.Databases.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Databases {
    internal class MySQLUserDAO : MySQLDAOFactory, IUserDAO {

        public bool Login(string username, string password) {
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
