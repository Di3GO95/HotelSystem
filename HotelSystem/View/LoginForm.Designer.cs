namespace HotelSystem {
    partial class LoginForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureUser = new System.Windows.Forms.PictureBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelLogin = new System.Windows.Forms.Label();
            this.groupBoxUserPass = new System.Windows.Forms.GroupBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.groupBoxUserPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureUser
            // 
            this.pictureUser.Image = global::HotelSystem.Properties.Resources.user;
            this.pictureUser.Location = new System.Drawing.Point(153, 12);
            this.pictureUser.Name = "pictureUser";
            this.pictureUser.Size = new System.Drawing.Size(170, 177);
            this.pictureUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureUser.TabIndex = 0;
            this.pictureUser.TabStop = false;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Gold;
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Location = new System.Drawing.Point(12, 208);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(474, 99);
            this.panelLogin.TabIndex = 1;
            // 
            // labelLogin
            // 
            this.labelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.Location = new System.Drawing.Point(0, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(474, 99);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Iniciar Sesión";
            this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxUserPass
            // 
            this.groupBoxUserPass.Controls.Add(this.buttonLogin);
            this.groupBoxUserPass.Controls.Add(this.labelPassword);
            this.groupBoxUserPass.Controls.Add(this.textBoxPassword);
            this.groupBoxUserPass.Controls.Add(this.textBoxUsername);
            this.groupBoxUserPass.Controls.Add(this.labelUsername);
            this.groupBoxUserPass.Location = new System.Drawing.Point(12, 313);
            this.groupBoxUserPass.Name = "groupBoxUserPass";
            this.groupBoxUserPass.Size = new System.Drawing.Size(474, 301);
            this.groupBoxUserPass.TabIndex = 2;
            this.groupBoxUserPass.TabStop = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(86)))), ((int)(((byte)(42)))));
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(11, 192);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(434, 78);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Iniciar Sesion";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.White;
            this.labelPassword.Location = new System.Drawing.Point(76, 121);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(129, 25);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Contraseña:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(211, 118);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(234, 31);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(212, 54);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(233, 31);
            this.textBoxUsername.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(6, 60);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(200, 25);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Nombre de usuario:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(498, 626);
            this.Controls.Add(this.groupBoxUserPass);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.pictureUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.groupBoxUserPass.ResumeLayout(false);
            this.groupBoxUserPass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureUser;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.GroupBox groupBoxUserPass;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
    }
}