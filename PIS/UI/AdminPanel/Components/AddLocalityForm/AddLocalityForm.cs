using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIS.Models;

namespace PIS.UI.AdminPanel.Components.AddLocalityForm
{
    public partial class AddLocalityForm : Form
    {
        private readonly Locality locality;

        public AddLocalityForm(Locality locality = null)
        {
            InitializeComponent();
            if (locality != null)
            {
                this.locality = locality;
                button1.Enabled = true;
            }
        }

        public string LocalityName => textBox1.Text;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox1.Text != "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void AddLocalityForm_Load(object sender, EventArgs e)
        {
            if (locality != null)
            {
                textBox1.Text = locality.Name;
                button1.Text = "Изменить";
            }
        }
    }
}
