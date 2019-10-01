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
        public ManageClientsForm() {
            InitializeComponent();
        }

        private void ButtonClearFields_Click(object sender, EventArgs e) {
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxLastName.Text = "";
            textBoxPhone.Text = "";
            textBoxCountry.Text = "";
        }
    }
}
