using System.Windows.Forms;

namespace PIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btn__showLoginForm.Click += (o, e) => new LoginForm().ShowDialog();
        }
    }
}