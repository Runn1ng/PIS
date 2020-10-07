using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btn__showLoginForm.Click += (o, e) => new LoginForm().ShowDialog();
        }
    }
}