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
using Word = Microsoft.Office.Interop.Word;

namespace PIS.UI.Plan
{
    public partial class PlanForm : Form
    {
        int primaryKey;
        PIS.Models.Plan currentPlan;
        public PlanForm(int primaryKey = -1, bool is_public = false)
        {
            InitializeComponent();

            for (int i = 1; i <= 31; i++)
                dataGridView1.Columns.Add("column" + i.ToString(), i.ToString());

            this.primaryKey = primaryKey;

            var localities = LocalityController.GetLocalities();
            foreach (var locality in localities)
                comboBox1.Items.Add(new ComboBoxItem() { Value = locality.Id, Text = locality.Name });

            if (primaryKey != -1)
            {
                currentPlan = PlanController.GetPlanByPK(primaryKey);
                var districts = PlanDistrictController.GetDistrictsByPlan(currentPlan).GroupBy(x => x.Address);
                foreach(var district in districts)
                {
                    DataGridViewRow row = dataGridView1.Rows[dataGridView1.RowCount - 1].Clone() as DataGridViewRow;
                    row.Cells[0].Value = district.Key.ToString();
                    foreach (var day in district)
                        row.Cells[day.Day].Value = "+";

                    dataGridView1.Rows.Add(row);
                }
                comboBox1.SelectedIndex = currentPlan.Locality_id - 1;
                checkBox1.Checked = currentPlan.Published;

                DisableElements();

                if(currentPlan.File_id != null)
                {
                    button2.Enabled = false;
                    button4.Enabled = true;
                }
            }

            if (is_public || (Program.CurrentUser != null && Program.CurrentUser.Id == 3))
            {
                textBox1.Enabled = false;
                checkBox1.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<int>> districts = new Dictionary<string, List<int>>();

            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if(dataGridView1.Rows[i].Cells[0].Value != null)
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
                        published = checkBox1.Checked,
                        note = textBox1.Text,
                    }, currentPlan, false);

            DisableElements();
            LoggerController.Log(Program.CurrentUser, "Сохрание плана-графика номер " + currentPlan.Id.ToString());
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;
                oDoc.PageSetup.TopMargin = 4f;
                oDoc.PageSetup.BottomMargin = 4f;
                oDoc.PageSetup.LeftMargin = 4f;
                oDoc.PageSetup.RightMargin = 4f;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 7;
                oDoc.Application.Selection.Tables[1].Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                oDoc.Application.Selection.Tables[1].Borders.InsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                oDoc.Application.Selection.Tables[1].Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth025pt;
                oDoc.Application.Selection.Tables[1].Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth025pt;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style 
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                var plan = Program.Db.Plans.Find(primaryKey);
                var loc = plan.Locality.Name;

                var m = new []
                {
                    "Январь",
                    "Февраль",
                    "Март",
                    "Апрель",
                    "Май",
                    "Июнь",
                    "Июль",
                    "Август",
                    "Сентябрь",
                    "Октябрь",
                    "Ноябрь",
                    "Декабрь",
                };

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = $"План-график за '{m[plan.Month - 1]} {plan.Year}' на '{loc}'";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save the file
                oDoc.Application.Selection.Tables[1].Columns[1].Width = 200f;
                oDoc.Application.Selection.Tables[1].Columns.AutoFit();
                oDoc.SaveAs2(filename);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dataGridView1, sfd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Добавление файла
        {
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|jpg files (*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                (sender as Button).Enabled = false;
                button4.Enabled = true;
                PlanController.AttachFile(primaryKey, openFileDialog1.FileName);
                LoggerController.Log(Program.CurrentUser, "Загрузка файла у плана-графика номер " + currentPlan.Id.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e) // Удаление файла
        {
            PlanController.RemoveFile(primaryKey);
            (sender as Button).Enabled = false;
            button2.Enabled = true;
            LoggerController.Log(Program.CurrentUser, "Удаление файла у плана-графика номер " + currentPlan.Id.ToString());
        }

        private void DisableElements()
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            comboBox1.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            button2.Enabled = true;
        }
    }
}
