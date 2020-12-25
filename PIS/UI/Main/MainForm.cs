using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIS.Controllers;
using PIS.UI.Plan;

namespace PIS.UI.Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ShowPlans();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            (new PlanForm((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value)).ShowDialog();
        }

        private void ShowPlans()
        {
            var plans = PlanController.GetPlans();
            dataGridView1.Rows.Clear();
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new PlanForm()).ShowDialog();
            ShowPlans();
        }
    }
}
