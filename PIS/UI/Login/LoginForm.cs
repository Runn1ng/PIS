using System;
using System.Windows.Forms;
using PIS.Services;

namespace PIS.UI.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = BtnLogin;
            BtnLogin.Click += HandleSignButtonClick;
        }

        public string Username => InputUsername.Text.Trim();
        public string Password => InputPassword.Text;

        private void HandleSignButtonClick(object sender, EventArgs e)
        {
            var notEmpty = !string.IsNullOrEmpty(Username) &&
                           !string.IsNullOrEmpty(Password);

            if (notEmpty)
            {
                if (AuthService.Login(Username, Password)) DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Wrong username or password", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Fill fields please!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}