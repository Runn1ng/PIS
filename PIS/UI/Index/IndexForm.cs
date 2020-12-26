using System;
using System.Windows.Forms;
using PIS.UI.Login;
using PIS.Controllers;
using PIS.UI.AdminPanel;
using PIS.UI.Components;
using PIS.UI.Main;
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


            var localities = LocalityController.GetLocalities();
            foreach (var locality in localities)
                comboBox1.Items.Add(new ComboBoxItem()
                { Value = locality.Id, Text = locality.Name });

            foreach (var plan in plans)
            {
                dataGridView1.Rows.Add(
                    plan.Id,
                    plan.Year,
                    plan.Month,
                    (comboBox1.Items[plan.Locality_id - 1] as ComboBoxItem).Text,
                    "Утверждён в ОМСУ",
                    plan.Date
                );
            }

        }

        private void DigitsOnly(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            int value;

            if (textbox.Text == "")
                return;

            if (int.TryParse(textbox.Text, out value))
            {
                if (textbox.Tag.ToString() == "year" &&
                    (value < 1900 || value > 2100))
                {
                    MessageBox.Show("Год должен быть в диапазоне 1900-2100");
                    textbox.Text = "";
                }
                else if (textbox.Tag.ToString() == "month" &&
                         (value < 1 || value > 12))
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
            Filter filter = new Filter();

            if (textBox1.Text != "")
                filter.year_from = int.Parse(textBox1.Text);
            if (textBox2.Text != "")
                filter.year_to = int.Parse(textBox2.Text);
            if (textBox3.Text != "")
                filter.month_from = int.Parse(textBox3.Text);
            if (textBox4.Text != "")
                filter.month_to = int.Parse(textBox4.Text);
            if (comboBox1.SelectedIndex > -1)
                filter.locality_id = (int)(comboBox1.SelectedItem as ComboBoxItem).Value;

            dataGridView1.Rows.Clear();
            var plans = PlanController.GetPlans(true, filter);
            foreach (var plan in plans)
            {
                dataGridView1.Rows.Add(
                    plan.Id,
                    plan.Year,
                    plan.Month,
                    (comboBox1.Items[plan.Locality_id - 1] as ComboBoxItem).Text,
                    "Утверждён в ОМСУ",
                    plan.Date
                    );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellMouseDoubleClick(object sender,
            DataGridViewCellMouseEventArgs e)
        {
            (new PlanForm((int) dataGridView1.Rows[e.RowIndex].Cells[0].Value, true))
                .ShowDialog();
            button1_Click(null, null);
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
            button3.Visible = true;

            if (user.Role.Id == 1)
            {
                buttonAdminPanel.Visible = true;
            }
        }

        private void buttonAdminPanel_Click(object sender, EventArgs e)
        {
            new AdminPanelForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
        }
    }
}