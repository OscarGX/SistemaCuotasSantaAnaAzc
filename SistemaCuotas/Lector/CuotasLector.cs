using Business;
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
    public partial class CuotasLector : Form
    {
        private readonly CuotaBusiness _cuotaBusiness;
        public CuotasLector()
        {
            InitializeComponent();
            _cuotaBusiness = new CuotaBusiness();
        }

        private void CuotasLector_Load(object sender, EventArgs e)
        {
            ddlFilter.SelectedIndex = ddlFilter.FindStringExact("Concepto");
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Folio");
            dataTable.Columns.Add("Concepto");
            dataTable.Columns.Add("Monto");
            dataTable.Columns.Add("Fecha");
            var cuotas = _cuotaBusiness.GetAll();
            foreach (var cuota in cuotas)
            {
                dataTable.Rows.Add(cuota.Folio, cuota.Concepto, cuota.Monto, cuota.Fecha.ToString("dd/MM/yyyy"));
            }
            dgvCuotas.DataSource = dataTable;
            foreach (DataGridViewColumn column in dgvCuotas.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ciudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CiudadanosLector c = new CiudadanosLector();
            c.ShowDialog();
            this.Close();
        }

        private void exportarCiudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CiudadanosExport c = new CiudadanosExport(false);
            c.ShowDialog();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("[{0}] LIKE '%{1}%'", ddlFilter.SelectedItem.ToString(), txtSearch.Text.Trim());
            (dgvCuotas.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
    }
}
