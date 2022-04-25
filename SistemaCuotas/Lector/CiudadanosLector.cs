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
    public partial class CiudadanosLector : Form
    {
        private readonly CiudadanoBusiness _ciudadanoBusiness;
        public CiudadanosLector()
        {
            InitializeComponent();
            _ciudadanoBusiness = new CiudadanoBusiness();
        }

        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CuotasLector c = new CuotasLector();
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

        private void CiudadanosLector_Load(object sender, EventArgs e)
        {
            ddlFieldFilter.SelectedIndex = ddlFieldFilter.FindStringExact("Nombre");
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Clave");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Status");
            dataTable.Columns.Add("Edad");
            dataTable.Columns.Add("Ocupación");
            dataTable.Columns.Add("Dirección");
            dataTable.Columns.Add("Manzana");
            var ciudadanos = _ciudadanoBusiness.GetAll();
            int index = 0;
            foreach (var ciudadano in ciudadanos)
            {
                dataTable.Rows.Add(ciudadano.Clave, ciudadano.FullName, ciudadano.CuotasStatus, ciudadano.Edad, ciudadano.OcupacionDomainModel.Nombre, ciudadano.Direccion, ciudadano.Manzana);
                index++;
            }
            dgvCiudadanos.DataSource = dataTable;
            foreach (DataGridViewColumn column in dgvCiudadanos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow row in dgvCiudadanos.Rows)
            {
                var rowCell = row.Cells[2];
                if (rowCell.Value != null)
                {
                    var statusRowValue = rowCell.Value.ToString();
                    if (statusRowValue == "Con adeudos")
                    {
                        rowCell.Style.ForeColor = Color.Red;
                    }
                    else if (statusRowValue == "Sin adeudos")
                    {
                        rowCell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        rowCell.Style.ForeColor = Color.Black;
                    }
                }
                //row.Cells[2].Style.ForeColor = statusRowValue == "Con adeudos" ? Color.Red : Color.Green;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("[{0}] LIKE '%{1}%'", ddlFieldFilter.SelectedItem.ToString(), txtSearch.Text.Trim());
            (dgvCiudadanos.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            var id = GetCiudadanoId();
            if (id > 0)
            {
                var ciudadano = _ciudadanoBusiness.GetCiudadanoByIdAll(id);
                if (ciudadano != null)
                {
                    CuotasCiudadanoLector c = new CuotasCiudadanoLector(ciudadano);
                    c.ShowDialog();
                }
            } else
            {
                MessageBox.Show("La columna seleccionada no contiene información", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private long GetCiudadanoId()
        {
            if (dgvCiudadanos.CurrentRow != null)
            {
                var id = long.Parse(dgvCiudadanos.Rows[dgvCiudadanos.CurrentRow.Index].Cells[0].Value.ToString());
                return id;
            }
            return 0;
        }
    }
}
