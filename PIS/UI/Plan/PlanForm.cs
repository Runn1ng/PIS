﻿using System;
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

            primaryKey = 6;

            for (int i = 1; i <= 31; i++)
                dataGridView1.Columns.Add("column" + i.ToString(), i.ToString());

            this.primaryKey = primaryKey;
            var localities = LocalityController.GetLocalities();
            foreach (var locality in localities)
                comboBox1.Items.Add(new ComboBoxItem() { Value = locality.Id, Text = locality.Name });

            if (primaryKey != -1)
            {
                var plan = PlanController.GetPlanByPK(primaryKey);
                var districts = plan.PlanDistrict.GroupBy(x => x.Address);
                foreach(var district in districts)
                {
                    DataGridViewRow row = dataGridView1.Rows[dataGridView1.RowCount - 1].Clone() as DataGridViewRow;
                    row.Cells[0].Value = district.Key.ToString();
                    foreach (var day in district)
                        row.Cells[day.Day].Value = "+";

                    dataGridView1.Rows.Add(row);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<int>> districts = new Dictionary<string, List<int>>();

            for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if(dataGridView1.Rows[i].Cells[0].Value.ToString() != "")
                {
                    string district = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    districts[district] = new List<int>();
                    for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            districts[district].Add(j);
                    }
                }
            }

            if (primaryKey == -1)
                primaryKey = PlanController.SavePlan(
                    new {
                        id = -1,
                        year = int.Parse(numericUpDown1.Value.ToString()),
                        month = int.Parse(numericUpDown2.Value.ToString()),
                        published = checkBox1.Checked,
                        districts,
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
                        districts,
                        locality = (comboBox1.SelectedItem as ComboBoxItem).Value,
                        note = textBox1.Text,
                    }, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Добавление файла
        {

        }

        private void button4_Click(object sender, EventArgs e) // Удаление файла
        {

        }
    }
}
