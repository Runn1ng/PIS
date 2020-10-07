using System;
using System.Windows.Forms;
using PIS.Services;

namespace PIS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            btn__login.Click += Btn__login_Click;
        }

        public string Username => input__username.Text;

        public string Password => input__password.Text;

        private void Btn__login_Click(object sender, EventArgs e)
        {
            Auth.SignIn();
            MessageBox.Show(Username + Password);
        }
    }
}