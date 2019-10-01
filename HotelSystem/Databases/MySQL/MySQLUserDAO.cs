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

                String query = "SELECT * FROM `users` WHERE `username`=@user AND `password`=@pass";

                MySqlCommand command = new MySqlCommand{
                    Connection = this.connection,
                    CommandText = query
                };
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
        public bool CreateClient(string firstName, string lastName, string phone, string country) {
            if (OpenConnection() == DatabaseStatus.Connected) {
                String query = "INSERT INTO `clients`(`first_name`, `last_name`, `phone`, `country`) VALUES (@firstName,@lastName,@phone,@country)";

                MySqlCommand command = new MySqlCommand{
                    Connection = this.connection,
                    CommandText = query
                };
                command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = firstName;
                command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = lastName;
                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@country", MySqlDbType.VarChar).Value = country;

                int nRows = command.ExecuteNonQuery();
                CloseConnection();
                command.Dispose();

                if (nRows == 1)
                    return true;
            }
            return false;
        }

    }
}
