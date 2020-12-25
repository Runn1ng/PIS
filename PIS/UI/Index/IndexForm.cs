using System;
using System.Windows.Forms;
using PIS.UI.Login;
using PIS.Controllers;
using PIS.UI.AdminPanel;
using PIS.UI.Components;
using PIS.UI.Plan;

namespace PIS.UI.Index
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
            ButtonShowLoginForm.Click += OnButtonShowLoginFormOnClick;

            var plans = PlanController.GetPlans(true);

            foreach (var plan in plans)
            {
                dataGridView1.Rows.Add(
                    plan.Id,
                    plan.Year,
                    plan.Month,
                    plan.Locality.Name,
                    "Утверждён в ОМСУ",
                    plan.Date
                    );
            }

            var localities = LocalityController.GetLocalities();
            foreach (var locality in localities)
                comboBox1.Items.Add(new ComboBoxItem() { Value = locality.Id, Text = locality.Name });
        }

        private void DigitsOnly(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            int value;

            if (textbox.Text == "")
                return;

            if (int.TryParse(textbox.Text, out value))
            {
                if(textbox.Tag.ToString() == "year" && (value < 1900 || value > 2100))
                {
                    MessageBox.Show("Год должен быть в диапазоне 1900-2100");
                    textbox.Text = "";
                } else if (textbox.Tag.ToString() == "month" && (value < 1 || value > 12))
                {
                    MessageBox.Show("Месяц должен быть в диапазоне 1-12");
                    textbox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста вводите числа");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            (new PlanForm((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value)).ShowDialog();
        }

        private void OnButtonShowLoginFormOnClick(object o, EventArgs e)
        {
            var form = new LoginForm();
            if (form.ShowDialog() != DialogResult.OK) return;
            RenderOnSuccessfullLogin();
        }

        private void RenderOnSuccessfullLogin()
        {
            var user = Program.CurrentUser;
            ButtonShowLoginForm.Visible = false;
            labelUsername.Text = $"ЗДРАВСТВУЙТЕ, {user.Username}";
            labelUsername.Visible = true;

            if (user.Role.Id == 1)
            {
                buttonAdminPanel.Visible = true;
            }
        }

        private void buttonAdminPanel_Click(object sender, EventArgs e)
        {
            new AdminPanelForm().ShowDialog();
        }
    }
}