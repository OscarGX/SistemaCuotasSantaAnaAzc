using SistemaCuotas.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas.Lector
{
    public partial class MainLector : Form
    {
        public MainLector()
        {
            InitializeComponent();
        }

        private void ciudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadanosLectorControl c = new CiudadanosLectorControl();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(c);
        }

        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuotasControl c = new CuotasControl(false);
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(c);
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadanosExportControl c = new CiudadanosExportControl();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(c);
        }

        private void MainLector_Load(object sender, EventArgs e)
        {
            CiudadanosLectorControl c = new CiudadanosLectorControl();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(c);
        }
    }
}
