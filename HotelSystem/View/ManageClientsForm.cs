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
        private readonly string msgCreated;
        private readonly string msgError;
        public ManageClientsForm() {
            InitializeComponent();

            msgTitle = "Gestión de clientes";
            msgNoData = "Introduzca los datos del cliente";
            msgCreated = "Cliente creado correctamente";
            msgError = "Error a la hora de crear el cliente";
        }

        private void ButtonClearFields_Click(object sender, EventArgs e) {
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxLastName.Text = "";
            textBoxPhone.Text = "";
            textBoxCountry.Text = "";
        }

        private void ButtonNewClient_Click(object sender, EventArgs e) {
            string name = textBoxName.Text;
            string lastName = textBoxLastName.Text;
            string phone = textBoxPhone.Text;
            string country = textBoxCountry.Text;

            if (name.Length == 0 || lastName.Length == 0 || phone.Length == 0 || country.Length == 0) {
                AuxMessages.ShowError(msgNoData, msgTitle);
            } else {
                bool created = Controller.GetOnlyInstance().CreateClient(name, lastName, phone, country);
                if (created) {
                    AuxMessages.ShowOK(msgCreated, msgTitle);
                } else {
                    AuxMessages.ShowError(msgError, msgTitle);
                }
            }
            ButtonClearFields_Click(sender, e);
        }

        private void ManageClientsForm_Load(object sender, EventArgs e) {
            List<Client> clients = Controller.GetOnlyInstance().GetClients();

            dataGridViewClients.DataSource = clients;
        }
    }
}
