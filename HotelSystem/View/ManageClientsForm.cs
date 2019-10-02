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
    public partial class ManageClientsForm : Form {
        private readonly string msgTitle;
        private readonly string msgNoData;
        private readonly string msgNoDataEdit;
        private readonly string msgCreated;
        private readonly string msgEdited;
        private readonly string msgRemoved;
        private readonly string msgErrorCreated;
        private readonly string msgErrorEdited;
        private readonly string msgErrorRemoved;

        private BindingList<Client> clients;

        public ManageClientsForm() {
            InitializeComponent();

            msgTitle = "Gestión de clientes";
            msgNoData = "Introduzca los datos del cliente";
            msgNoDataEdit = "Elija un cliente de la lista antes de editarlo";
            msgCreated = "Cliente creado correctamente";
            msgEdited = "Cliente editado correctamente";
            msgRemoved = "Cliente eliminado correctamente";
            msgErrorCreated = "Error a la hora de crear el cliente";
            msgErrorEdited = "Error a la hora de editar el cliente";
            msgErrorRemoved = "Error a la hora de eliminar el cliente";
        }

        private void ButtonClearFields_Click(object sender, EventArgs e) {
            SetDefault();
        }

        private void ManageClientsForm_Load(object sender, EventArgs e) {
            List<Client> clientsList = Controller.GetOnlyInstance().GetClients();
            clients = new BindingList<Client>(clientsList);

            dataGridViewClients.DataSource = clients;
            if (clients.Count > 0)
                dataGridViewClients.CurrentCell.Selected = false;

            foreach (var country in Countries.Names)
                comboBoxCountries.Items.Add(country);
            comboBoxCountries.SelectedItem = comboBoxCountries.Items[0];
        }

        private void DataGridViewClients_CellClick(object sender, DataGridViewCellEventArgs e) {
            textBoxID.Text = dataGridViewClients.CurrentRow.Cells["Id"].Value.ToString();
            textBoxName.Text = dataGridViewClients.CurrentRow.Cells["FirstName"].Value.ToString();
            textBoxLastName.Text = dataGridViewClients.CurrentRow.Cells["LastName"].Value.ToString();
            textBoxPhone.Text = dataGridViewClients.CurrentRow.Cells["Phone"].Value.ToString();
            comboBoxCountries.SelectedItem = dataGridViewClients.CurrentRow.Cells["Country"].Value.ToString();

            buttonEdit.Enabled = true;
            buttonRemove.Enabled = true;
        }

        private void ButtonNewClient_Click(object sender, EventArgs e) {
            string name = textBoxName.Text;
            string lastName = textBoxLastName.Text;
            string phone = textBoxPhone.Text;
            string country = comboBoxCountries.SelectedItem.ToString();

            if (name.Length == 0 || lastName.Length == 0 || phone.Length == 0 || country.Length == 0) {
                AuxMessages.ShowError(msgNoData, msgTitle);
            } else {
                Client client = Controller.GetOnlyInstance().CreateClient(name, lastName, phone, country);
                if (client != null) {
                    AuxMessages.ShowOK(msgCreated, msgTitle);

                    clients.Add(client);
                } else {
                    AuxMessages.ShowError(msgErrorCreated, msgTitle);
                }
            }
            SetDefault();
        }

        private void ButtonEdit_Click(object sender, EventArgs e) {
            string idString = textBoxID.Text;
            string name = textBoxName.Text;
            string lastName = textBoxLastName.Text;
            string phone = textBoxPhone.Text;
            string country = comboBoxCountries.SelectedItem.ToString();

            if (idString == "" || name == "" || lastName == "" || phone == "" || country == "") {
                AuxMessages.ShowError(msgNoDataEdit, msgTitle);
            } else {
                int id = Int32.Parse(idString);
                bool edited = Controller.GetOnlyInstance().UpdateClient(id, name, lastName, phone, country);

                if (edited) {
                    AuxMessages.ShowOK(msgEdited, msgTitle);

                    Client client = SearchClient(id);
                    if (client != null) {
                        UpdateClientInList(client, name, lastName, phone, country);
                    }
                } else {
                    AuxMessages.ShowError(msgErrorEdited, msgTitle);
                }
            }
            SetDefault();
        }

        private void ButtonRemove_Click(object sender, EventArgs e) {
            string idString = textBoxID.Text;
            int id = Int32.Parse(idString);

            bool removed = Controller.GetOnlyInstance().RemoveClient(id);
            if (removed) {
                AuxMessages.ShowOK(msgRemoved, msgTitle);

                Client client = SearchClient(id);
                RemoveClientInList(client);
            } else {
                AuxMessages.ShowError(msgErrorRemoved, msgTitle);
            }
            SetDefault();
        }

        /// <summary>
        /// Returns the view to its default state
        /// </summary>
        private void SetDefault() {
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxLastName.Text = "";
            textBoxPhone.Text = "";
            comboBoxCountries.SelectedItem = comboBoxCountries.Items[0];

            buttonEdit.Enabled = false;
            buttonRemove.Enabled = false;

            if (clients.Count > 0)
                dataGridViewClients.CurrentCell.Selected = false;
        }

        private Client SearchClient(int id) {
            Client client = null;
            int i = 0;
            while (client == null && i < clients.Count) {
                Client clientTmp = clients[i];

                if (clientTmp.Id.Equals(id)) {
                    client = clientTmp;
                }
                i++;
            }
            return client;
        }

        private void UpdateClientInList(Client client, string name, string lastName, string phone, string country) {
            client.FirstName = name;
            client.LastName = lastName;
            client.Phone = phone;
            client.Country = country;

            clients.Remove(client);
            clients.Add(client);
        }

        private void RemoveClientInList(Client client) {
            clients.Remove(client);
        }
    }
}
