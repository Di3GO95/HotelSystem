using HotelSystem.Controllers;
using HotelSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSystem.View {
    public partial class ManageRoomsForm : Form {
        private BindingList<RoomCompleteInfo> rooms;
        private bool pageLoaded;
        private readonly string msgTitle;
        private readonly string msgNoData;
        private readonly string msgNoDataEdit;
        private readonly string msgCreated;
        private readonly string msgEdited;
        private readonly string msgRemoved;
        private readonly string msgErrorCreated;
        private readonly string msgErrorAlreadyCreated;
        private readonly string msgErrorEdited;
        private readonly string msgErrorRemoved;
        public ManageRoomsForm() {
            InitializeComponent();

            pageLoaded = false;
            msgTitle = "Gestión de habitaciones";
            msgNoData = "Introduzca los datos de la habitación";
            msgNoDataEdit = "Elija una habitación de la lista antes de editarla";
            msgCreated = "habitación creada correctamente";
            msgEdited = "habitación editada correctamente";
            msgRemoved = "habitación eliminada correctamente";
            msgErrorCreated = "Error a la hora de crear la habitación";
            msgErrorAlreadyCreated = "La habitación ya se había creado anteriormente";
            msgErrorEdited = "Error a la hora de editar la habitación";
            msgErrorRemoved = "Error a la hora de eliminar la habitación";
        }

        private void ManageRoomsForm_Load(object sender, EventArgs e) {
            List<RoomCompleteInfo> roomsList = Controller.GetOnlyInstance().GetRooms();
            rooms = new BindingList<RoomCompleteInfo>(roomsList);

            dataGridViewRooms.DataSource = rooms;
            if (rooms.Count > 0) {
                dataGridViewRooms.CurrentCell.Selected = false;
            }

            List<RoomType> roomTypes = Controller.GetOnlyInstance().GetRoomTypes();
            foreach (var roomType in roomTypes) {
                comboBoxTypes.Items.Add(roomType.Type);
            }
            comboBoxTypes.SelectedIndex = 0;

            int price = Controller.GetOnlyInstance().GetPriceFromRoomTypeText(comboBoxTypes.SelectedItem.ToString());
            textBoxPrice.Text = price.ToString();

            buttonEdit.Enabled = false;
            buttonRemove.Enabled = false;
            pageLoaded = true;
        }

        private void ButtonClearFields_Click(object sender, EventArgs e) {
            SetDefault();
        }

        private void SetDefault() {
            textBoxNumber.Text = "";
            textBoxPhone.Text = "";
            textBoxPrice.Text = "";
            comboBoxTypes.SelectedIndex = 0;

            int price = Controller.GetOnlyInstance().GetPriceFromRoomTypeText(comboBoxTypes.SelectedItem.ToString());
            textBoxPrice.Text = price.ToString();

            buttonEdit.Enabled = false;
            buttonRemove.Enabled = false;

            if (rooms.Count > 0) 
                dataGridViewRooms.CurrentCell.Selected = false;
        }

        private void DataGridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e) {
            textBoxNumber.Text = dataGridViewRooms.CurrentRow.Cells["Number"].Value.ToString();
            textBoxPhone.Text = dataGridViewRooms.CurrentRow.Cells["Phone"].Value.ToString();
            textBoxPrice.Text = dataGridViewRooms.CurrentRow.Cells["Price"].Value.ToString();

            string type = dataGridViewRooms.CurrentRow.Cells["Type"].Value.ToString();
            bool selected = false;
            int i = 0;
            while (!selected && i < comboBoxTypes.Items.Count) {
                if (comboBoxTypes.Items[i].ToString().Equals(type)) {
                    comboBoxTypes.SelectedIndex = i;
                    selected = true;
                }

                i++;
            }

            buttonEdit.Enabled = true;
            buttonRemove.Enabled = true;
        }

        private void ButtonNewRoom_Click(object sender, EventArgs e) {
            string numberString = textBoxNumber.Text;
            string phone = textBoxPhone.Text;

            if (numberString == "" || phone == "") {
                AuxMessages.ShowError(msgNoData, msgTitle);
                return;
            }

            int number = Int32.Parse(numberString);
            string typeText = comboBoxTypes.SelectedItem.ToString();
            int type = 0;
            bool typeFound = false;
            int i = 0;
            while (!typeFound && i < RoomType.RoomTypes.Count) {
                if (RoomType.RoomTypes[i].Type.Equals(typeText)) {
                    type = RoomType.RoomTypes[i].Id;
                    typeFound = true;
                }
                i++;
            }

            if (!typeFound) {
                AuxMessages.ShowError(msgErrorCreated, msgTitle);
                return;
            }

            bool isRoomAvailable = IsRoomAvailable(number);
            if (!isRoomAvailable) {
                AuxMessages.ShowError(msgErrorAlreadyCreated, msgTitle);
                return;
            }

            RoomCompleteInfo room = Controller.GetOnlyInstance().CreateRoom(number, phone, type);
            if (room != null) {
                AuxMessages.ShowOK(msgCreated, msgTitle);

                rooms.Add(room);
            } else {
                AuxMessages.ShowError(msgErrorCreated, msgTitle);
            }
            SetDefault();
        }

        private void ComboBoxTypes_SelectedIndexChanged(object sender, EventArgs e) {
            if (pageLoaded) {
                int price = Controller.GetOnlyInstance().GetPriceFromRoomTypeText(comboBoxTypes.SelectedItem.ToString());
                textBoxPrice.Text = price.ToString();
            }
        }

        private bool IsRoomAvailable(int number) {
            foreach (var room in rooms) {
                if (room.Number.Equals(number))
                    return false;
            }
            return true;
        }

        private void ButtonEdit_Click(object sender, EventArgs e) {
            string newNumberString = textBoxNumber.Text;
            string phone = textBoxPhone.Text;

            if (newNumberString == "" || phone == "") {
                AuxMessages.ShowError(msgNoDataEdit, msgTitle);
                return;
            }

            int newNumber = Int32.Parse(newNumberString);
            string oldNumberString = dataGridViewRooms.CurrentRow.Cells["Number"].Value.ToString();
            int oldNumber = Int32.Parse(oldNumberString);
            string typeString = comboBoxTypes.SelectedItem.ToString();

            bool edited = Controller.GetOnlyInstance().UpdateRoom(oldNumber, newNumber, phone, typeString);

            if (edited) {
                AuxMessages.ShowOK(msgEdited, msgTitle);

                RoomCompleteInfo rci = SearchRoomInList(oldNumber);
                if (rci != null)
                    UpdateRoomInList(rci, newNumber, phone, typeString);
            } else {
                AuxMessages.ShowError(msgErrorEdited, msgTitle);
            }

            SetDefault();
        }

        private void ButtonRemove_Click(object sender, EventArgs e) {
            string numberString = dataGridViewRooms.CurrentRow.Cells["Number"].Value.ToString();
            int number = Int32.Parse(numberString);

            bool removed = Controller.GetOnlyInstance().RemoveRoom(number);
            if (removed) {
                AuxMessages.ShowOK(msgRemoved, msgTitle);

                RoomCompleteInfo rci = SearchRoomInList(number);
                RemoveRoomInList(rci);
            } else {
                AuxMessages.ShowError(msgErrorRemoved, msgTitle);
            }
            SetDefault();
        }

        private RoomCompleteInfo SearchRoomInList(int number) {
            RoomCompleteInfo rci = null;
            int i = 0;
            while (rci == null && i < rooms.Count) {
                if (rooms[i].Number.Equals(number))
                    rci = rooms[i];
                i++;
            }

            return rci;
        }

        private void UpdateRoomInList(RoomCompleteInfo rci, int number, string phone, string type) {
            rooms.Remove(rci);

            rci.Number = number;
            rci.Phone = phone;
            rci.Type = type;

            int price = Controller.GetOnlyInstance().GetPriceFromRoomTypeText(comboBoxTypes.SelectedItem.ToString());
            rci.Price = price;

            rooms.Add(rci);
        }

        private void RemoveRoomInList(RoomCompleteInfo rci) {
            rooms.Remove(rci);
        }
    }
}
