using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PIS.Models;
using PIS.Services;
using PIS.UI.AdminPanel.Components.AddUserForm;

namespace PIS.UI.AdminPanel
{
    public partial class AdminPanelForm : Form
    {
        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private async void FillTable()
        {
            var users = await Program.Db.Users.ToListAsync();
            dataGridView1.Rows.Clear();
            foreach (var user in users)
            {
                dataGridView1.Rows.Add(
                    user.Id,
                    user.Username,
                    user.Role?.Name,
                    user.Locality?.Name
                );
            }
        }

        private async void ButtonAddUser_Click(object sender, EventArgs e)
        {
            var addForm = new AddUserForm();

            if (addForm.ShowDialog() != DialogResult.OK) return;

            var newUser = new User
            {
                Username = addForm.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(addForm.Password,
                    BCrypt.Net.BCrypt.GenerateSalt(12)),
                Role_id = (int) addForm.RoleId,
                Locality_id = (int) addForm.LocalityId,
            };

            await AuthService.CreateUser(newUser);
            FillTable();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var pk = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            if (pk == Program.CurrentUser.Id)
            {
                Utils.ShowError("себя нельзя удалить. извините");
                return;
            }

            var userToDelete = await Program.Db.Users.FindAsync(pk);
            await AuthService.DeleteUser(userToDelete);
            FillTable();
        }
    }
}