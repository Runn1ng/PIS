using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIS.Services;

namespace PIS.UI.AdminPanel
{
    public partial class AdminPanelForm : Form
    {
        public AdminPanelForm()
        {
            InitializeComponent();
            ButtonAddUser.Click += async (o,e) => await ButtonAddUserOnClick(o,e);
        }

        private async Task ButtonAddUserOnClick(object sender, EventArgs e)
        {
            await AuthService.CreateUser("archie", "1234567");
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            usersTableAdapter.Fill(pisdbDataSet.Users);
        }
    }
}