using HotelSystem.Databases.MySQL;
using HotelSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public List<Client> GetClients() {
            List<Client> clients = null;
            if (OpenConnection() == DatabaseStatus.Connected) {
                String query = "SELECT * FROM `clients`";

                MySqlCommand command = new MySqlCommand{
                    Connection = this.connection,
                    CommandText = query
                };

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                adapter.Dispose();

                clients = new List<Client>();
                foreach (DataRow row in table.Rows) {
                    int id = Int32.Parse(row["id"].ToString());
                    string firstName = row["first_name"].ToString();
                    string lastName = row["last_name"].ToString();
                    string phone = row["phone"].ToString();
                    string country = row["country"].ToString();

                    Client client = new Client(id, firstName, lastName, phone, country);
                    clients.Add(client);
                }
            }
            return clients;
        }

    }
}
