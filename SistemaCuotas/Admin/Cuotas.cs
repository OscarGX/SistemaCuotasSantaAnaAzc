using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas.Admin
{
    public partial class Cuotas : Form
    {
        private readonly CuotaBusiness _cuotaBusiness;
        public Cuotas()
        {
            _cuotaBusiness = new CuotaBusiness();
            InitializeComponent();
        }

        private void ciudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // navegar hacia ciudadanos
            this.Hide();
            Ciudadanos c = new Ciudadanos();
            c.ShowDialog();
            this.Close();
        }

        private void Cuotas_Load(object sender, EventArgs e)
        {
            ddlFilterColumn.SelectedIndex = ddlFilterColumn.FindStringExact("Concepto");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CuotaAddEdit c = new CuotaAddEdit();
            c.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCuotas.SelectedRows.Count > 0 && dgvCuotas.Rows[dgvCuotas.CurrentRow.Index].Cells[0].Value != null)
                {
                    var id = GetCiudadanoId();
                    this.Hide();
                    CuotaAddEdit c = new CuotaAddEdit(id);
                    c.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        private int GetCiudadanoId()
        {
            var id = int.Parse(dgvCuotas.Rows[dgvCuotas.CurrentRow.Index].Cells[0].Value.ToString());
            return id;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("[{0}] LIKE '%{1}%'", ddlFilterColumn.SelectedItem.ToString(), textBox1.Text.Trim());
            (dgvCuotas.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void exportarCiudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CiudadanosExport c = new CiudadanosExport();
            c.ShowDialog();
            this.Close();
        }
    }
}
