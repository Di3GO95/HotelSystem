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
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        private void ManageClientsToolStripMenuItem_Click(object sender, EventArgs e) {
            ManageClientsForm mClientsForm = new ManageClientsForm();
            mClientsForm.ShowDialog();
        }

        private void ManageRoomsToolStripMenuItem_Click(object sender, EventArgs e) {
            ManageRoomsForm mRoomsForm = new ManageRoomsForm();
            mRoomsForm.ShowDialog();
        }

        private void ManageReservationsToolStripMenuItem_Click(object sender, EventArgs e) {
            ManageReservationsForm mReservationsForm = new ManageReservationsForm();
            mReservationsForm.ShowDialog();
        }
    }
}
