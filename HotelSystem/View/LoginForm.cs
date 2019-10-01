using HotelSystem.Controllers;
using HotelSystem.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSystem {
    public partial class LoginForm : Form {
        private readonly string msgTitle;
        private readonly string msgNoData;
        private readonly string msgWrongData;
        public LoginForm() {
            InitializeComponent();

            msgTitle = "Iniciar sesión";
            msgNoData = "Escribe tu nombre y tu contraseña para iniciar sesión";
            msgWrongData = "Nombre de usuario o contraseña incorrecta";
        }

        private void ButtonLogin_Click(object sender, EventArgs e) {
            if (textBoxUsername.TextLength == 0 || textBoxPassword.TextLength == 0) {
                MessageBox.Show(msgNoData, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                string user = textBoxUsername.Text;
                string password = textBoxPassword.Text;
                bool login = Controller.GetOnlyInstance().Login(user, password);

                if (login) {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();

                } else {
                    MessageBox.Show(msgWrongData, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Text = "";
                }
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }
    }
}
