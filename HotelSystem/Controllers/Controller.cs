using HotelSystem.Databases;
using HotelSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Controllers {
    class Controller {
        private static Controller onlyInstance;

        private Controller() {
            DAOFactory.SetDAOFactory(DatabaseTypes.MySQL);
        }

        public static Controller GetOnlyInstance() {
            if (onlyInstance == null)
                onlyInstance = new Controller();
            return onlyInstance;
        }

        /*
         * USER METHODS
         * */

        public bool Login(string username, string password) {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.Login(username, password);
        }

        /*
         * CLIENT METHODS
         * */

        public Client CreateClient(string name, string lastName, string phone, string country) {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.CreateClient(name, lastName, phone, country);
        }

        public bool UpdateClient(int id, string name, string lastName, string phone, string country) {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.UpdateClient(id, name, lastName, phone, country);
        }

        public bool RemoveClient(int id) {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.RemoveClient(id);
        }

        public List<Client> GetClients() {
            IUserDAO uDAO = DAOFactory.OnlyInstance.GetUserDAO();
            return uDAO.GetClients();
        }

        /**
         * ROOM METHODS
         * */

        public List<RoomType> GetRoomTypes() {
            if (RoomType.RoomTypes == null) {
                IRoomDAO rDAO = DAOFactory.OnlyInstance.GetRoomDAO();
                List<RoomType> roomTypes = rDAO.GetRoomTypes();

                foreach (var room in roomTypes)
                    RoomType.AddRoomType(room);
            }
            return RoomType.RoomTypes;
        }

        public List<RoomCompleteInfo> GetRooms() {
            IRoomDAO rDAO = DAOFactory.OnlyInstance.GetRoomDAO();
            List<Room> rooms = rDAO.GetRooms();
            List<RoomCompleteInfo> roomsCompleteInfo = new List<RoomCompleteInfo>();

            foreach (Room room in rooms) {
                int typeId = room.TypeId;
                RoomType type = rDAO.GetRoomTypeFromId(typeId);
                room.UpdateType(type);

                RoomCompleteInfo rci = new RoomCompleteInfo(room);
                roomsCompleteInfo.Add(rci);
            }

            return roomsCompleteInfo;
        }

        public RoomCompleteInfo CreateRoom(int number, string phone, int typeId) {
            IRoomDAO rDAO = DAOFactory.OnlyInstance.GetRoomDAO();
            Room room = rDAO.CreateRoom(number, phone, typeId);

            if (room == null)
                return null;

            RoomType type = rDAO.GetRoomTypeFromId(typeId);
            room.UpdateType(type);

            RoomCompleteInfo rci = new RoomCompleteInfo(room);
            return rci;
        }

        public int GetPriceFromRoomTypeText(string typeText) {
            int i = 0;
            while (i < RoomType.RoomTypes.Count) {
                if (RoomType.RoomTypes[i].Type.Equals(typeText)) {
                    return RoomType.RoomTypes[i].Price;
                }

                i++;
            }
            return 0;
        }

        public bool UpdateRoom(int oldNumber, int newNumber, string phone, string typeString) {
            int typeId = 0;
            foreach (var type in RoomType.RoomTypes) {
                if (type.Type.Equals(typeString)) {
                    typeId = type.Id;
                }
            }

            IRoomDAO rDAO = DAOFactory.OnlyInstance.GetRoomDAO();
            return rDAO.UpdateRoom(oldNumber, newNumber, phone, typeId);
        }

        public bool RemoveRoom(int number) {
            IRoomDAO rDAO = DAOFactory.OnlyInstance.GetRoomDAO();
            return rDAO.RemoveRoom(number);
        }
    }
}
