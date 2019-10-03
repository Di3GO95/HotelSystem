using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Model {
    internal class Room {
        public int Id { get; private set; }
        public int Number { get; set; }
        public string Phone { get; set; }
        public RoomType Type { get; private set; }
        public int TypeId { get; private set; }

        public Room(int id, int number, string phone, RoomType type) {
            this.Id = id;
            this.Number = number;
            this.Phone = phone;
            this.Type = type;
            this.TypeId = type.Id;
        }

        public Room(int id, int number, string phone, int typeId) {
            this.Id = id;
            this.Number = number;
            this.Phone = phone;
            this.Type = null;
            this.TypeId = typeId;
        }

        public void UpdateType(RoomType type) {
            this.Type = type;
            this.TypeId = type.Id;
        }
    }
}
