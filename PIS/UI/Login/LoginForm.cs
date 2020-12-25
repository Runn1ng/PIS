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
            AcceptButton = ButtonLogin;
            ButtonLogin.Click += HandleSignButtonClick;
        }

        public string Username => InputUsername.Text.Trim();
        public string Password => InputPassword.Text;

        private void HandleSignButtonClick(object sender, EventArgs e)
        {
            var notEmpty = !string.IsNullOrEmpty(Username) &&
                           !string.IsNullOrEmpty(Password);

            if (notEmpty)
            {
                var user = AuthService.Login(Username, Password);
                if (user != null)
                {
                    DialogResult = DialogResult.OK;
                    Program.CurrentUser = user;
                }
                else Utils.ShowError("Wrong username or password");
            }
            else Utils.ShowError("Fill fields please!");
        }
    }
}