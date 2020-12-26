using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIS.Controllers;
using PIS.Models;
using PIS.Services;
using PIS.UI.AdminPanel.Components.AddLocalityForm;
using PIS.UI.AdminPanel.Components.AddUserForm;

namespace PIS.UI.AdminPanel
{
    public partial class AdminPanelForm : Form
    {
        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private async void AdminPanelForm_Load(object sender, EventArgs e)
        {
            await FillUsersTable();
            await FillLocalitesTable();
        }

        private async Task FillUsersTable()
        {
            var users = await Program.Db.Users.ToListAsync();
            dataGridView1.Rows.Clear();
            foreach (var user in users)
                dataGridView1.Rows.Add(
                    user.Id,
                    user.Username,
                    user.Role?.Name,
                    user.Locality?.Name
                );
        }

        private async Task FillLocalitesTable()
        {
            var users = await Program.Db.Localities.ToListAsync();
            dataGridView2.Rows.Clear();
            foreach (var locality in users)
                dataGridView2.Rows.Add(
                    locality.Id,
                    locality.Name
                );
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
                Locality_id = (int) addForm.LocalityId
            };

            await AuthService.CreateUser(newUser);
            await FillUsersTable();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var pk = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value
                .ToString());

            if (pk == Program.CurrentUser.Id)
            {
                Utils.ShowError("себя нельзя удалить. извините");
                return;
            }

            var userToDelete = await Program.Db.Users.FindAsync(pk);
            await AuthService.DeleteUser(userToDelete);
            await FillUsersTable();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var pk = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value
                .ToString());
            var userToUpdate = await Program.Db.Users.FindAsync(pk);
            var addForm = new AddUserForm(userToUpdate);

            if (addForm.ShowDialog() != DialogResult.OK) return;

            if (userToUpdate == null) return;

            userToUpdate.Username = addForm.Username;
            userToUpdate.Locality_id = (int) addForm.LocalityId;
            userToUpdate.Role_id = (int) addForm.RoleId;
            if (addForm.Password != "")
                userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(
                    addForm.Password,
                    BCrypt.Net.BCrypt.GenerateSalt(12));

            await Program.Db.SaveChangesAsync();
            await FillUsersTable();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var addForm = new AddLocalityForm();

            if (addForm.ShowDialog() != DialogResult.OK) return;

            var locality = new Locality() {Name = addForm.LocalityName};

            await LocalityController.AddLocality(locality);
           await FillLocalitesTable();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var pk = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value
                .ToString());
            var userToUpdate = await Program.Db.Localities.FindAsync(pk);
            var addForm = new AddLocalityForm(userToUpdate);

            if (addForm.ShowDialog() != DialogResult.OK) return;

            if (userToUpdate == null) return;

            userToUpdate.Name = addForm.LocalityName;

            await Program.Db.SaveChangesAsync();
            await FillLocalitesTable();
        }
    }
}