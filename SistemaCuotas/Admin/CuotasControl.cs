using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas.Admin
{
    public partial class CuotasControl : UserControl
    {
        private readonly CuotaBusiness _cuotaBusiness;
        private bool _isAdmin;
        public CuotasControl(bool isAdmin = true)
        {
            _cuotaBusiness = new CuotaBusiness();
            _isAdmin = isAdmin;
            InitializeComponent();
        }

        private void CuotasControl_Load(object sender, EventArgs e)
        {
            ddlFilterColumn.SelectedIndex = ddlFilterColumn.FindStringExact("Concepto");
            if (!_isAdmin)
            {
                btnActulizar.Hide();
                button1.Hide();
                button2.Hide();
            }
            var cuotas = _cuotaBusiness.GetAll();
            SetDgvData(cuotas);
            foreach (DataGridViewColumn column in dgvCuotas.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCuotas.CurrentRow != null)
                {
                    if (dgvCuotas.SelectedRows.Count > 0 && dgvCuotas.Rows[dgvCuotas.CurrentRow.Index].Cells[0].Value != null)
                    {
                        var id = GetCiudadanoId();
                        CuotaAddEdit c = new CuotaAddEdit(id);
                        c.ShowDialog();
                    } else
                    {
                        MessageBox.Show("Fila no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Fila no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fila no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CuotaAddEdit c = new CuotaAddEdit();
            c.ShowDialog();
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

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            var cuotas = _cuotaBusiness.GetAll();
            SetDgvData(cuotas);
        }

        private void SetDgvData(List<CuotaDomainModel> cuotas)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Folio");
            dataTable.Columns.Add("Concepto");
            dataTable.Columns.Add("Monto");
            dataTable.Columns.Add("Fecha");
            foreach (var cuota in cuotas)
            {
                dataTable.Rows.Add(cuota.Folio, cuota.Concepto, cuota.Monto, cuota.Fecha.ToString("dd/MM/yyyy"));
            }
            dgvCuotas.DataSource = dataTable;
        }
    }
}
