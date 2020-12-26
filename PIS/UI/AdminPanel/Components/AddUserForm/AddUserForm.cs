using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PIS.Models;

namespace PIS.UI.AdminPanel.Components.AddUserForm
{
    public partial class AddUserForm : Form
    {
        private readonly User userToUpdate;

        public AddUserForm(User userToUpdate = null)
        {
            InitializeComponent();
            AcceptButton = button1;
            if (userToUpdate != null)
            {
                this.userToUpdate = userToUpdate;
                this.button1.Enabled = true;
            }
        }

        public string Username => textBox1.Text;
        public string Password => textBox2.Text;
        public object RoleId => comboBox1.SelectedValue;
        public object LocalityId => comboBox2.SelectedValue;

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            localitiesTableAdapter.Fill(pisdbDataSet2.Localities);
            rolesTableAdapter.Fill(pisdbDataSet1.Roles);
            if (userToUpdate != null)
            {
                this.textBox1.Text = userToUpdate.Username;
                this.comboBox1.SelectedValue = userToUpdate.Role_id;
                this.comboBox2.SelectedValue = userToUpdate.Locality_id;
                button1.Text = "Изменить";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox1.Text != "" &&
                              (textBox2.Text != "" || userToUpdate != null);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var alreadyExists =
                await Program.Db.Users.FirstOrDefaultAsync(u =>
                    u.Username == Username) != null;
            if (!alreadyExists)
                DialogResult = DialogResult.OK;
            else Utils.ShowError("пользователь с таким именем существует");
        }
    }
}