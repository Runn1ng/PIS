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
using PIS.UI.Plan;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace PIS.UI.Main
{
    public partial class MainForm : Form
    {
        private Application xl;

        public MainForm()
        {
            InitializeComponent();

            var localities = LocalityController.GetLocalities();
            foreach (var locality in localities)
                comboBox1.Items.Add(new ComboBoxItem() { Value = locality.Id, Text = locality.Name });

            button1_Click(null, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xl = new Application();
            xl.Visible = true;
            xlWorkBook = xl.Workbooks.Add(misValue);
            xlWorkSheet =
                (Microsoft.Office.Interop.Excel.Worksheet) xlWorkBook.Worksheets
                    .get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR =
                (Microsoft.Office.Interop.Excel.Range) xlWorkSheet.Cells[3, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, true);
            xlWorkSheet.Cells[1, 1] = "Заявки по месяцам --- ";
            xlWorkSheet.Cells[2, 2] = "Год";
            xlWorkSheet.Cells[2, 3] = "Месяц";
            xlWorkSheet.Cells[2, 4] = "Населенный пункт";
            xlWorkSheet.Cells[2, 5] = "Статус";
            xlWorkSheet.Cells[2, 6] = "Дата установки статуса";
        }

        private void dataGridView1_CellMouseDoubleClick(object sender,
            DataGridViewCellMouseEventArgs e)
        {
            (new PlanForm((int) dataGridView1.Rows[e.RowIndex].Cells[0].Value))
                .ShowDialog();
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
                    (comboBox1.Items[plan.Locality_id - 1] as ComboBoxItem).Text,
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
                filter.locality_id =
                    (int) (comboBox1.SelectedItem as ComboBoxItem).Value;

            dataGridView1.Rows.Clear();
            var plans = PlanController.GetPlans(false, filter);
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
                if (textbox.Tag == "year" && (value < 1900 || value > 2100))
                {
                    MessageBox.Show("Год должен быть в диапазоне 1900-2100");
                    textbox.Text = "";
                }
                else if (textbox.Tag == "month" && (value < 1 || value > 12))
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
    }
}