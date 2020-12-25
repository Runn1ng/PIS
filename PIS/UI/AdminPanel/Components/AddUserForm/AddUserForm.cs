using System;
using System.Windows.Forms;

namespace PIS.UI.AdminPanel.Components.AddUserForm
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            AcceptButton = button1;
        }

        public string Username => textBox1.Text;
        public string Password => textBox2.Text;
        public object RoleId => comboBox1.SelectedValue; 
        public object LocalityId => comboBox2.SelectedValue;

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            localitiesTableAdapter.Fill(pisdbDataSet2.Localities);
            rolesTableAdapter.Fill(pisdbDataSet1.Roles);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox1.Text != "" && textBox2.Text != "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}