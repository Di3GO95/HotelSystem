using HotelSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Databases {
    internal interface IRoomDAO {
        List<RoomType> GetRoomTypes();

        RoomType GetRoomTypeFromId(int id);

        List<Room> GetRooms();

        Room CreateRoom(int number, string phone, int type);

        bool UpdateRoom(int oldNumber, int newNumber, string phone, int typeId);

        bool RemoveRoom(int number);
    }
}
