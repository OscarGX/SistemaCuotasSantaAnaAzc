using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas.Lector
{
    public partial class CuotasCiudadanoLector : Form
    {
        private CiudadanoDomainModel _ciudadano;
        public CuotasCiudadanoLector(CiudadanoDomainModel ciudadano)
        {
            InitializeComponent();
            _ciudadano = ciudadano;
        }

        private void CuotasCiudadanosLector_Load(object sender, EventArgs e)
        {
            lblClave.Text = _ciudadano.Clave.ToString();
            lblNombre.Text = _ciudadano.FullName;
            lblCurp.Text = _ciudadano.Curp;
            lblDireccion.Text = _ciudadano.Direccion;
            lblManzana.Text = _ciudadano.Manzana.ToString();
            lblFechaNacimiento.Text = _ciudadano.Fechanac.ToString("dd/MM/yyyy");
            lblEdad.Text = _ciudadano.Edad.ToString();
            lblSexo.Text = _ciudadano.Sexo;
            lblFechaRegistro.Text = _ciudadano.FechaRegistro.Value.ToString("dd/MM/yyyy");
            lblOcupacion.Text = _ciudadano.OcupacionDomainModel.Nombre;
            lblCutoasAsignadas.Text = _ciudadano.Cuotasciudadanos.Count.ToString();
            lblStatusCuotas.Text = _ciudadano.CuotasStatus;
            lblStatusCuotas.ForeColor = lblStatusCuotas.Text == "Con adeudos" ? Color.Red : Color.Black;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Folio");
            dataTable.Columns.Add("Concepto");
            dataTable.Columns.Add("Monto");
            dataTable.Columns.Add("Saldo");
            dataTable.Columns.Add("Comentarios");
            dataTable.Columns.Add("Status");
            dataTable.Columns.Add("Apoyo");
            dataTable.Columns.Add("Descuento");
            foreach (var cuota in _ciudadano.Cuotasciudadanos)
            {
                dataTable.Rows.Add(cuota.Id, cuota.CuotaDomainModel.Concepto, cuota.CuotaDomainModel.Monto ,cuota.Saldo, cuota.Comentarios, cuota.StatusString, cuota.ApoyoString, cuota.Descuento);
            }
            dgvCuotasCiudadano.DataSource = dataTable;
            foreach (DataGridViewColumn column in dgvCuotasCiudadano.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtCuotaSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("Concepto LIKE '%{0}%'", txtCuotaSearch.Text.Trim());
            (dgvCuotasCiudadano.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
    }
}
