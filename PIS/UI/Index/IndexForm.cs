using System;
using System.Windows.Forms;
using PIS.UI.Login;
using PIS.Controllers;

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
                    plan.Year,
                    plan.Month,
                    plan.Locality.Name,
                    "Утверждён в ОМСУ",
                    plan.Date
                    );
            }
        }

        private void OnButtonShowLoginFormOnClick(object o, EventArgs e)
        {
            var form = new LoginForm();
            if (form.ShowDialog() != DialogResult.OK) return;
            RenderOnSuccessfullLogin(form.Username);
        }

        private void RenderOnSuccessfullLogin(string username)
        {
            ButtonShowLoginForm.Visible = false;
            labelUsername.Text = $"ЗДРАВСТВУЙТЕ, {username}";
            labelUsername.Visible = true;

            //if (use)
        }
    }
}