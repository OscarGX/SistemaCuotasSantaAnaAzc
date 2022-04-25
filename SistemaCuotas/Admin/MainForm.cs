using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas.Admin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CiudadanosControl c = new CiudadanosControl();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(c);
        }

        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuotasControl c = new CuotasControl();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(c);
        }

        private void ciudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadanosControl c = new CiudadanosControl();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(c);
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadanosExportControl c = new CiudadanosExportControl();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(c);
        }
    }
}
