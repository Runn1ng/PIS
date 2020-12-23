using System;
using System.Windows.Forms;
using PIS.Services;
using PIS.UI.AdminPanel;

namespace PIS.UI.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = ButtonLogin;
            ButtonLogin.Click += HandleSignButtonClick;
            new AdminPanelForm().ShowDialog();
        }

        public string Username => InputUsername.Text.Trim();
        public string Password => InputPassword.Text;

        private void HandleSignButtonClick(object sender, EventArgs e)
        {
            var notEmpty = !string.IsNullOrEmpty(Username) &&
                           !string.IsNullOrEmpty(Password);

            if (notEmpty)
            {
                if (AuthService.Login(Username, Password))
                    DialogResult = DialogResult.OK;
                else Utils.ShowError("Wrong username or password");
            }
            else Utils.ShowError("Fill fields please!");
        }
    }
}