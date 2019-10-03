using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Model {
    internal class RoomCompleteInfo {
        public int Number { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public RoomCompleteInfo(Room room) {
            this.Number = room.Number;
            this.Phone = room.Phone;
            this.Type = room.Type.Type;
            this.Price = room.Type.Price;
        }
    }
}
