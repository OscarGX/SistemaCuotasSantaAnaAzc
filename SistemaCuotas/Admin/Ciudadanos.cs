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
    public partial class Ciudadanos : Form
    {
        private readonly CiudadanoBusiness _ciudadanoBusiness;
        public Ciudadanos()
        {
            _ciudadanoBusiness = new CiudadanoBusiness();
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            CiudadanoAddEdit c = new CiudadanoAddEdit();
            c.ShowDialog();
            this.Close();
        }

        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cuotas c = new Cuotas();
            c.ShowDialog();
            this.Close();
        }

        private void Ciudadanos_Load(object sender, EventArgs e)
        {
            // this.dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
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

        private void GetCiudadanos()
        {
            var ciudadanos = _ciudadanoBusiness.GetAll();
            foreach (var ciudadano in ciudadanos)
            {
                dgvCiudadanos.Rows.Add(ciudadano.Clave, ciudadano.Nombre, ciudadano.Status, ciudadano.Fechanac.ToString("dd/MM/yyyy"), ciudadano.Ocupacion, ciudadano.Direccion, ciudadano.Manzana);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("[{0}] LIKE '%{1}%'", ddlFieldFilter.SelectedItem.ToString(), txtSearch.Text.Trim());
            (dgvCiudadanos.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCiudadanos.SelectedRows.Count > 0 && dgvCiudadanos.Rows[dgvCiudadanos.CurrentRow.Index].Cells[0].Value != null)
                {
                    var msg = "Está apunto de eliminar un ciudadano, esto eliminará también sus cuotas asignadas \r\n¿Está seguro?";
                    var dialogResult = MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.btnEliminar.Enabled = false;
                        var rowSelectedIndex = dgvCiudadanos.SelectedRows[0].Index;
                        var clave = GetCiudadanoId();
                            // long.Parse(dgvCiudadanos.Rows[dgvCiudadanos.CurrentRow.Index].Cells[0].Value.ToString());
                        if (_ciudadanoBusiness.DeleteOne(clave))
                        {
                            dgvCiudadanos.Rows.RemoveAt(rowSelectedIndex);
                            this.btnEliminar.Enabled = true;
                            MessageBox.Show("El ciudadano se eliminó correctamente", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.btnEliminar.Enabled = true;
                            MessageBox.Show("Ocurrió un error al eliminar el ciudadano", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar el ciudadano", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnEliminar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCiudadanos.SelectedRows.Count > 0 && dgvCiudadanos.Rows[dgvCiudadanos.CurrentRow.Index].Cells[0].Value != null)
                {
                    var id = GetCiudadanoId();
                    this.Hide();
                    CiudadanoAddEdit c = new CiudadanoAddEdit(id);
                    c.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var ciudadanoId = GetCiudadanoId();
            if (ciudadanoId == 0)
            {
                MessageBox.Show("Debes seleccionar una fila que tenga datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Hide();
                CuotaCiudadano c = new CuotaCiudadano(GetCiudadanoId());
                c.ShowDialog();
                this.Close();
            }
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
