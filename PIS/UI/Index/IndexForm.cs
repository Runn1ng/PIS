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
            ButtonShowLoginForm.Click += (o, e) => new LoginForm().ShowDialog();

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
    }
}