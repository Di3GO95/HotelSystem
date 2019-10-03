using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Model {
    internal class RoomType {
        public static List<RoomType> RoomTypes { get; private set; }
        public int Id { get; private set; }
        public string Type { get; private set; }
        public int Price { get; private set; }

        public RoomType(int id, string type, int price) {
            this.Id = id;
            this.Type = type;
            this.Price = price;
        }

        public static void AddRoomType(RoomType rt) {
            if (RoomTypes == null)
                RoomTypes = new List<RoomType>();
            RoomTypes.Add(rt);
        }

        public static bool RemoveRoomType(RoomType rt) {
            if (RoomTypes == null)
                return false;
            return RoomTypes.Remove(rt);
        }
    }
}
