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
using PIS.UI.Components;

namespace PIS.UI.Plan
{
    public partial class PlanForm : Form
    {
        int primaryKey;
        public PlanForm(int primaryKey = -1)
        {
            InitializeComponent();
            this.primaryKey = primaryKey;
            var localities = LocalityController.GetLocalities();
            foreach (var locality in localities)
                comboBox1.Items.Add(new ComboBoxItem() { Value = locality.Id, Text = locality.Name });

            if (primaryKey == -1)
            {
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (primaryKey == -1)
                primaryKey = PlanController.SavePlan(
                    new {
                        id = -1,
                        year = int.Parse(numericUpDown1.Value.ToString()),
                        month = int.Parse(numericUpDown2.Value.ToString()),
                        published = checkBox1.Checked,
                        locality = (comboBox1.SelectedItem as ComboBoxItem).Value,
                        note = textBox1.Text,
                    });
            else
                PlanController.SavePlan( 
                    new
                    {
                        id = primaryKey,
                        year = int.Parse(numericUpDown1.Value.ToString()),
                        month = int.Parse(numericUpDown2.Value.ToString()),
                        published = checkBox1.Checked,
                        locality = (comboBox1.SelectedItem as ComboBoxItem).Value,
                        note = textBox1.Text,
                    }, false);

            MessageBox.Show(primaryKey.ToString());
        }
    }
}
