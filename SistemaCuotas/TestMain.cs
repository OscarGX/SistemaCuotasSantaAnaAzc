using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas
{
    public partial class TestMain : Form
    {
        public TestMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1 u = new UserControl1();
            panel1.Controls.Add(u);
        }
    }
}
