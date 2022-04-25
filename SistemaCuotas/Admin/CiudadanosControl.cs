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
    public partial class CiudadanosControl : UserControl
    {
        private readonly CiudadanoBusiness _ciudadanoBusiness;
        public CiudadanosControl()
        {
            _ciudadanoBusiness = new CiudadanoBusiness();
            InitializeComponent();
        }

        private void CiudadanosControl_Load(object sender, EventArgs e)
        {
            this.dgvCiudadanos.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.dgvCiudadanos_RowPrePaint);
            ddlFieldFilter.SelectedIndex = ddlFieldFilter.FindStringExact("Nombre");
            var ciudadanos = _ciudadanoBusiness.GetAll();
            SetDgvData(ciudadanos);
            foreach (DataGridViewColumn column in dgvCiudadanos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dgvCiudadanos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var rowCell = dgvCiudadanos.Rows[e.RowIndex].Cells[2];
            var edad = dgvCiudadanos.Rows[e.RowIndex].Cells[3];
            if (edad.Value != null)
            {
                edad.Style.ForeColor = int.Parse(edad.Value.ToString()) >= 60 ? Color.Red : Color.Black;
            }
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
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var ciudadanos = _ciudadanoBusiness.GetAll();
            SetDgvData(ciudadanos);
        }

        private void SetDgvData(List<CiudadanoDomainModel> ciudadanos)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Clave");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Status");
            dataTable.Columns.Add("Edad");
            dataTable.Columns.Add("Ocupación");
            dataTable.Columns.Add("Dirección");
            dataTable.Columns.Add("Manzana");
            int index = 0;
            foreach (var ciudadano in ciudadanos)
            {
                dataTable.Rows.Add(ciudadano.Clave, ciudadano.FullName, ciudadano.CuotasStatus, ciudadano.Edad, ciudadano.OcupacionDomainModel.Nombre, ciudadano.Direccion, ciudadano.Manzana);
                index++;
            }
            dgvCiudadanos.DataSource = dataTable;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("[{0}] LIKE '%{1}%'", ddlFieldFilter.SelectedItem.ToString(), txtSearch.Text.Trim());
            (dgvCiudadanos.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
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
                CuotaCiudadano c = new CuotaCiudadano(GetCiudadanoId());
                c.ShowDialog();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CiudadanoAddEdit c = new CiudadanoAddEdit();
            c.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCiudadanos.CurrentRow != null)
                {
                    if (dgvCiudadanos.SelectedRows.Count > 0 && dgvCiudadanos.Rows[dgvCiudadanos.CurrentRow.Index].Cells[0].Value != null)
                    {
                        var id = GetCiudadanoId();
                        CiudadanoAddEdit c = new CiudadanoAddEdit(id);
                        c.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
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
    }
}
