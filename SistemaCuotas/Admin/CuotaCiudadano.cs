using Business;
using Business.Enum;
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
    public partial class CuotaCiudadano : Form
    {
        private long? ciudadanoId;
        private readonly CiudadanoBusiness _ciudadanoBusiness;
        private readonly CuotaBusiness _cuotaBusiness;
        private readonly CuotaCiudadanoBusiness _cuotaCiudadanoBusiness;
        private bool isEditing = false;
        private CiudadanoDomainModel ciudadanoForm;
        private string conceptoCuota = "";
        public CuotaCiudadano(long? cdId = null)
        {
            InitializeComponent();
            ciudadanoId = cdId;
            _ciudadanoBusiness = new CiudadanoBusiness();
            _cuotaBusiness = new CuotaBusiness();
            _cuotaCiudadanoBusiness = new CuotaCiudadanoBusiness();
        }

        private void CuotaCiudadano_Load(object sender, EventArgs e)
        {
            if(ciudadanoId != null)
            {
                isEditing = false;
                var ciudadanoDM = GetCiudadanoById(ciudadanoId.Value);
                if (ciudadanoDM != null)
                {
                    var cuotasDisponibles = GetCuotasDisponiblesByCiudadanoIdAndFechaRegistro(ciudadanoDM.FechaRegistro.Value, ciudadanoId.Value);
                    SetValues(ciudadanoDM);
                    SetDdlCuotas(cuotasDisponibles);
                    SetDgvCuotas(ciudadanoDM.Cuotasciudadanos);
                }
            }
        }

        private CiudadanoDomainModel GetCiudadanoById(long id)
        {
            try
            {
                return _ciudadanoBusiness.GetCiudadanoByIdWithCuotas(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<CuotaDomainModel> GetCuotasDisponiblesByCiudadanoIdAndFechaRegistro(DateTime fechaRegistro, long id)
        {
            try
            {
                return _cuotaBusiness.GetCuotasDisponiblesByCiudadanoIdAndFechaRegistro(id, fechaRegistro);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void SetValues(CiudadanoDomainModel ciudadanoDM)
        {
            ciudadanoForm = ciudadanoDM;
            lblCiudadano.Text = "Nombre: " + ciudadanoForm.FullName;
            lblClave.Text = ciudadanoDM.Clave.ToString();
            lblEdad.Text = ciudadanoDM.Edad.ToString();
            lblOcupacion.Text = ciudadanoDM.OcupacionDomainModel.Nombre;
            lblSexo.Text = ciudadanoDM.Sexo;
            lblDireccion.Text = ciudadanoDM.Direccion;
            lblManzana.Text = ciudadanoDM.Manzana.ToString();
            lblFechaNacimiento.Text = ciudadanoDM.Fechanac.ToString("dd/MM/yyyy");
            //ddlCuotas.Enabled = true;
            //txtCiudadanoClave.Text = ciudadanoDM.Clave.ToString();
            //txtStatus.Text = "No pagado";
            if (ciudadanoDM.Sexo == "femenino")
            {
                chkApoyoMujer.Enabled = true;
            } else
            {
                chkApoyoMujer.Enabled = false;
            }
        }

        private void SetDdlCuotas(List<CuotaDomainModel> cuotas)
        {
            //ddlCuotas.DataSource = cuotas;
            //ddlCuotas.DisplayMember = "Concepto";
            //ddlCuotas.ValueMember = "Folio";
        }

        private void SetDgvCuotas(List<CuotaCiudadanoDomainModel> cuotasDM)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Folio");
            dataTable.Columns.Add("Concepto");
            dataTable.Columns.Add("Monto Cuota");
            dataTable.Columns.Add("Saldo");
            dataTable.Columns.Add("Comentarios");
            dataTable.Columns.Add("Status");
            dataTable.Columns.Add("Apoyo");
            dataTable.Columns.Add("Descuento");
            foreach (var cuota in cuotasDM)
            {
                dataTable.Rows.Add(cuota.Id, cuota.CuotaDomainModel.Concepto, cuota.CuotaDomainModel.Monto, cuota.Saldo, cuota.Comentarios, cuota.StatusString, cuota.ApoyoString, cuota.Descuento);
            }
            dgvCuotasCiudadano.DataSource = dataTable;
            var index = 0;
            dgvCuotasCiudadano.ReadOnly = false;
            foreach (DataGridViewColumn column in dgvCuotasCiudadano.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
                if (index == 3 || index == 4)
                {
                    column.ReadOnly = false;
                }
                index++;
            }
        }

        private void DgvSelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.CurrentRow != null)
            {
                if (ciudadanoForm.Sexo == "femenino")
                {
                    var apoyo = dgv.Rows[dgv.CurrentRow.Index].Cells[6].Value.ToString();
                    chkApoyoMujer.Checked = apoyo == "Si";
                }
                // txtComentarios.Text = dgv.Rows[dgv.CurrentRow.Index].Cells[4].Value.ToString();
            }

        }

        //private long SetCuotaData()
        //{
        //    if (dgvCuotasCiudadano.CurrentRow != null)
        //    {
        //        var id = long.Parse(dgvCiudadanos.Rows[dgvCiudadanos.CurrentRow.Index].Cells[0].Value.ToString());
        //        return id;
        //    }
        //    return 0;
        //}

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            isEditing = false;
            //ddlCuotas.Enabled = true;
            //txtDescuento.Text = "";
            //txtStatus.Text = "No pagado";
            //txtSaldo.Text = "";
            chkApoyoMujer.Checked = false;
            // txtComentarios.Text = "";
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ciudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ciudadanos c = new Ciudadanos();
            c.ShowDialog();
            this.Close();
        }

        private void ddlCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            var selectedItem = combo.SelectedItem as CuotaDomainModel;
            //txtMonto.Text = selectedItem.Monto.ToString();
            // txtFolioCuota.Text = selectedItem.Folio.ToString();
            conceptoCuota = selectedItem.Concepto;
        }

        private void chkApoyoMujer_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            //if (check.Checked)
            //{
            //    txtDescuento.Text = "50%";
            //} else
            //{
            //    txtDescuento.Text = "0%";
            //}
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            var result = MessageBox.Show("Se guardarán los cambios en la cuota", "¿Está seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (DialogResult.Yes == result)
                {
                    try
                    {
                        var selectedRow = dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index];
                        var cuota = new CuotaCiudadanoDomainModel
                        {
                            Saldo = double.Parse(selectedRow.Cells[3].Value.ToString().Trim()),
                            Descuento = (ciudadanoForm.Sexo == "femenino" && chkApoyoMujer.Checked) ? 0.5 : 0,
                            Comentarios = dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index].Cells[4].Value.ToString().Trim(),
                            Apoyo = (sbyte)((ciudadanoForm.Sexo == "femenino" && chkApoyoMujer.Checked) ? 1 : 0),
                            Status = IsCuotaPagada() ? (int)CuotaCiudadanoStatusEnum.PAGADO : (int)CuotaCiudadanoStatusEnum.NOPAGADO,
                        };
                        var updated = _cuotaCiudadanoBusiness.UpdateOne(GetSelectedRowId(), cuota);
                        if (updated)
                        {
                            MessageBox.Show("Se guardó correctamente la cuota", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateSelectedRowData(cuota);
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al actualizar la cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        btnGuardar.Enabled = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hubo un error al actualizar la cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnGuardar.Enabled = true;
                    }
                } else
                {
                    btnGuardar.Enabled = true;
                }
            } else
            {
                btnGuardar.Enabled = true;
            }
            //if (isEditing)
            //{
            //    btnGuardar.Enabled = false;
            //    var result = MessageBox.Show("Se guardarán los cambios en la cuota", "¿Está seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            var cuota = new CuotaCiudadanoDomainModel
            //            {
            //                Saldo = double.Parse(txtSaldo.Text.Trim()),
            //                Descuento = (ciudadanoForm.Sexo == "femenino" && chkApoyoMujer.Checked) ? 0.5 : 0,
            //                Comentarios = txtComentarios.Text.Trim(),
            //                Apoyo = (sbyte)((ciudadanoForm.Sexo == "femenino" && chkApoyoMujer.Checked) ? 1 : 0),
            //                Status = IsCuotaPagada() ? (int)CuotaCiudadanoStatusEnum.PAGADO : (int)CuotaCiudadanoStatusEnum.NOPAGADO,
            //            };
            //            var updated = _cuotaCiudadanoBusiness.UpdateOne(GetSelectedRowId(), cuota);
            //            if (updated)
            //            {
            //                MessageBox.Show("Se guardó correctamente la cuota", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                UpdateSelectedRowData(cuota);
            //            }
            //            else
            //            {
            //                MessageBox.Show("Hubo un error al actualizar la cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            btnGuardar.Enabled = true;
            //        }
            //        catch (Exception ex)
            //        {
            //            btnGuardar.Enabled = true;
            //            MessageBox.Show("Hubo un error al actualizar la cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        btnGuardar.Enabled = true;
            //    }
            //} else
            //{
            //    var cuota = new CuotaCiudadanoDomainModel
            //    {
            //        Folio = int.Parse(txtFolioCuota.Text.Trim()),
            //        Apoyo = (sbyte)((ciudadanoForm.Sexo == "femenino" && chkApoyoMujer.Checked) ? 1 : 0),
            //        Saldo = double.Parse(txtSaldo.Text.Trim()),
            //        Ciudadano = ciudadanoId.Value,
            //        Comentarios = txtComentarios.Text.Trim(),
            //        Descuento = (ciudadanoForm.Sexo == "femenino" && chkApoyoMujer.Checked) ? 0.5 : 0,
            //        Status = IsCuotaPagada() ? (int)CuotaCiudadanoStatusEnum.PAGADO : (int) CuotaCiudadanoStatusEnum.NOPAGADO,
            //    };
            //    btnGuardar.Enabled = false;
            //    var result = MessageBox.Show("Se registrará la cuota", "¿Está seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            var inserted = _cuotaCiudadanoBusiness.AddOne(cuota);
            //            if (inserted != null)
            //            {
            //                MessageBox.Show("Se registró correctamente la cuota", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                AddCuotaToDgv(inserted);
            //            } else
            //            {
            //                MessageBox.Show("Hubo un error al asignar la cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            btnGuardar.Enabled = true;
            //        }
            //        catch (Exception ex)
            //        {
            //            btnGuardar.Enabled = true;
            //            MessageBox.Show("Hubo un error al asignar la cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    } else
            //    {
            //        btnGuardar.Enabled = true;
            //    }
            //}
        }

        private bool IsCuotaPagada()
        {
            var selectedRow = dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index];
            var monto = double.Parse(selectedRow.Cells[2].Value.ToString());
            var saldo = double.Parse(selectedRow.Cells[3].Value.ToString().Trim());
            if (ciudadanoForm.Sexo == "femenino" && chkApoyoMujer.Checked)
            {
                var descuento = monto * 0.5;
                var total = descuento - saldo;
                return total == 0;
            }
            else
            {
                var total = monto - saldo;
                return total == 0;
            }
        }

        private void AddCuotaToDgv(CuotaCiudadanoDomainModel cuota)
        {
            var dataSource = dgvCuotasCiudadano.DataSource as DataTable;
            dataSource.Rows.Add(cuota.Id, conceptoCuota, cuota.Saldo, cuota.Comentarios, cuota.StatusString, cuota.ApoyoString, cuota.Descuento);
        }

        private void btnCargarDgv_Click(object sender, EventArgs e)
        {
            // btnCargarDgv.Enabled = false;
            isEditing = true;
            var cuotaSelected = _cuotaCiudadanoBusiness.GetCuotaCiudadanoById(GetSelectedRowId());
            if (cuotaSelected != null)
            {
                // txtFolioCuota.Text = cuotaSelected.Folio.ToString();
            //    txtDescuento.Text = ciudadanoForm.Sexo == "femenino" && cuotaSelected.Apoyo == 1 ? "50%" : "0%";
            //    chkApoyoMujer.Checked = ciudadanoForm.Sexo == "femenino" && cuotaSelected.Apoyo == 1;
            //    ddlCuotas.Enabled = false;
            //    ddlCuotas.SelectedIndex = ddlCuotas.FindStringExact(cuotaSelected.CuotaDomainModel.Concepto);
            //    txtMonto.Text = cuotaSelected.CuotaDomainModel.Monto.ToString();
            //    txtSaldo.Text = cuotaSelected.Saldo.ToString();
            //    txtComentarios.Text = cuotaSelected.Comentarios;
            //    txtStatus.Text = cuotaSelected.StatusString;
            }
            // btnCargarDgv.Enabled = true;
        }

        private int GetSelectedRowId()
        {
            if (dgvCuotasCiudadano.CurrentRow != null)
            {
                var id = int.Parse(dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index].Cells[0].Value.ToString());
                return id;
            }
            return 0;
        }

        private void UpdateSelectedRowData(CuotaCiudadanoDomainModel cuota)
        {
            if (dgvCuotasCiudadano.CurrentRow != null)
            {
                dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index].Cells[3].Value = cuota.Saldo;
                dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index].Cells[4].Value = cuota.Comentarios;
                dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index].Cells[5].Value = cuota.StatusString;
                dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index].Cells[6].Value = cuota.ApoyoString;
                dgvCuotasCiudadano.Rows[dgvCuotasCiudadano.CurrentRow.Index].Cells[7].Value = cuota.Descuento;
            }
        }

        //private void btnBuscarCiudadano_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtCiudadanoSearch.Text.Trim()))
        //    {
        //        try
        //        {
        //            var query = txtCiudadanoSearch.Text.Trim();
        //            var ciudadanos = _ciudadanoBusiness.GetCiudadanosByNameWithCuotas(query);
        //            if (ciudadanos == null || ciudadanos.Count == 0)
        //            {
        //                MessageBox.Show("No se encontraron coincidencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            } else
        //            {
        //                SetDdlCiudadanosSearch(ciudadanos);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("No se pudo buscar, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void SetDdlCiudadanosSearch(List<CiudadanoDomainModel> ciudadanos)
        {
            //ddlCiudadanoFiltered.DataSource = ciudadanos;
            //ddlCiudadanoFiltered.DisplayMember = "FullName";
            //ddlCiudadanoFiltered.ValueMember = "Clave";
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (ddlCiudadanoFiltered.Items.Count > 0)
        //    {
        //        var selected = ddlCiudadanoFiltered.SelectedItem as CiudadanoDomainModel;
        //        CuotaCiudadanoDetalle c = new CuotaCiudadanoDetalle(selected);
        //        c.ShowDialog();
        //    }
        //}

        private void btnCargarCiudadanoDdl_Click(object sender, EventArgs e)
        {
            //if (ddlCiudadanoFiltered.Items.Count > 0)
            //{
            //    var ciudadano = ddlCiudadanoFiltered.SelectedItem as CiudadanoDomainModel;
            //    var ciudadanoAll = _ciudadanoBusiness.GetCiudadanoByIdWithCuotas(ciudadano.Clave);
            //    if (ciudadanoAll != null)
            //    {
            //        ciudadanoForm = ciudadanoAll;
            //        lblCiudadano.Text = "Ciudadano: " + ciudadanoForm.FullName;
            //        ciudadanoId = ciudadanoAll.Clave;
            //        txtCiudadanoClave.Text = ciudadanoId.Value.ToString();
            //        txtSaldo.Text = "";
            //        txtComentarios.Text = "";
            //        if (ciudadanoAll.Sexo == "femenino")
            //        {
            //            chkApoyoMujer.Enabled = true;
            //        } else
            //        {
            //            chkApoyoMujer.Enabled = false;
            //        }
            //        var cuotas = _cuotaBusiness.GetCuotasDisponiblesByCiudadanoIdAndFechaRegistro(ciudadanoAll.Clave, ciudadanoAll.FechaRegistro.Value);
            //        SetDdlCuotas(cuotas);
            //        ddlCuotas.Enabled = true;
            //        SetDgvCuotas(ciudadanoAll.Cuotasciudadanos);
            //    }
            //}
        }

        private void txtCuotaSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("Concepto LIKE '%{0}%'", txtCuotaSearch.Text.Trim());
            (dgvCuotasCiudadano.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
    }
}
