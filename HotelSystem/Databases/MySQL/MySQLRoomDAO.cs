using HotelSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSystem.Databases.MySQL {
    internal class MySQLRoomDAO : MySQLDAOFactory, IRoomDAO {
        public List<RoomType> GetRoomTypes() {
            List<RoomType> roomTypes = new List<RoomType>();

            if (OpenConnection() == DatabaseStatus.Connected) {
                String query = "SELECT * FROM `room_types`";

                MySqlCommand command = new MySqlCommand{
                    Connection = this.connection,
                    CommandText = query
                };

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                CloseConnection();
                adapter.Dispose();

                foreach (DataRow row in table.Rows) {
                    int id = Int32.Parse(row["id"].ToString());
                    string type = row["type"].ToString();
                    int price = Int32.Parse(row["price"].ToString());

                    RoomType roomType = new RoomType(id, type, price);
                    roomTypes.Add(roomType);
                }
            }
            return roomTypes;
        }

        public RoomType GetRoomTypeFromId(int id) {
            RoomType roomType = null;

            if (OpenConnection() == DatabaseStatus.Connected) {
                String query = "SELECT * FROM `room_types` WHERE `id`=@id";

                MySqlCommand command = new MySqlCommand {
                    Connection = this.connection,
                    CommandText = query
                };
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                CloseConnection();
                adapter.Dispose();

                if (table.Rows.Count == 1) {
                    string type = table.Rows[0]["type"].ToString();
                    int price = Int32.Parse(table.Rows[0]["price"].ToString());

                    roomType = new RoomType(id, type, price);
                }
            }

            return roomType;
        }

        public List<Room> GetRooms() {
            List<Room> rooms = new List<Room>();

            if (OpenConnection() == DatabaseStatus.Connected) {
                String query = "SELECT * FROM `rooms`";

                MySqlCommand command = new MySqlCommand {
                    Connection = this.connection,
                    CommandText = query
                };

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                CloseConnection();
                adapter.Dispose();

                foreach (DataRow row in table.Rows) {
                    int id = Int32.Parse(row["id"].ToString());
                    int number = Int32.Parse(row["number"].ToString());
                    string phone = row["phone"].ToString();
                    int typeInt = Int32.Parse(row["type"].ToString());

                    Room room = new Room(id, number, phone, typeInt);
                    rooms.Add(room);
                }
            }

            return rooms;
        }

        public Room CreateRoom(int number, string phone, int type) {
            Room room = null;

            if (OpenConnection() == DatabaseStatus.Connected) {
                String query = "INSERT INTO `rooms`(`number`, `phone`, `type`) VALUES (@number,@phone,@type)";
            

                MySqlCommand command = new MySqlCommand {
                    Connection = this.connection,
                    CommandText = query
                };
                command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;
                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;

                int nRows = command.ExecuteNonQuery();

                if (nRows == 1) {
                    int id = (int)command.LastInsertedId;
                    room = new Room(id, number, phone, type);
                }

                CloseConnection();
                command.Dispose();

            }

            return room;
        }

        public bool UpdateRoom(int oldNumber, int newNumber, string phone, int typeId) {
            bool updated = false;
            if (OpenConnection() == DatabaseStatus.Connected) {
                String query = "UPDATE `rooms` SET `number`=@newNumber,`phone`=@phone,`type`=@typeId WHERE `number`=@oldNumber";

                MySqlCommand command = new MySqlCommand {
                    Connection = this.connection,
                    CommandText = query
                };
                command.Parameters.Add("@newNumber", MySqlDbType.Int32).Value = newNumber;
                command.Parameters.Add("@oldNumber", MySqlDbType.Int32).Value = oldNumber;
                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@typeId", MySqlDbType.Int32).Value = typeId;

                int nRows = command.ExecuteNonQuery();
                CloseConnection();
                command.Dispose();

                if (nRows == 1)
                    updated = true;
            }
            return updated;
        }

        public bool RemoveRoom(int number) {
            if (OpenConnection() == DatabaseStatus.Connected) {
                String query = "DELETE FROM `rooms` WHERE `number`=@number";

                MySqlCommand command = new MySqlCommand {
                    Connection = this.connection,
                    CommandText = query
                };
                command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;

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
