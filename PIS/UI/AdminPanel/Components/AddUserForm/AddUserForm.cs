using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIS.UI.AdminPanel.Components.AddUserModal
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pisdbDataSet1.Roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.pisdbDataSet1.Roles);

        }
    }
}