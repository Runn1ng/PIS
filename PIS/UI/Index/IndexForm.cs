using System.Windows.Forms;
using PIS.UI.Login;

namespace PIS.UI.Index
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
            ButtonShowLoginForm.Click += (o, e) => new LoginForm().ShowDialog();
        }
    }
}