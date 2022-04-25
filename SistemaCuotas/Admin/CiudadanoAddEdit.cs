using Business;
using Business.Enum;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas.Admin
{
    public partial class CiudadanoAddEdit : Form
    {
        long? id;
        private readonly OcupacionBusiness _ocupacionBusiness;
        private readonly CiudadanoBusiness _ciudadanoBusiness;
        public CiudadanoAddEdit(long? id = null)
        {
            this.id = id;
            _ocupacionBusiness = new OcupacionBusiness();
            _ciudadanoBusiness = new CiudadanoBusiness();
            InitializeComponent();
            GetOcupaciones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var msg = (id == null) ? "Se guardará el registro" : "Se modificará el registro";
            msg += "\r\n¿Está seguro?";
            var dialogResult = MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (id == null)
                {
                    this.btnGuardar.Enabled = false;
                    var manzana = int.Parse(txtManzana.Text.Trim());
                    var fechaNacimiento = DateTime.ParseExact(txtFechaNacimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var ocupacion = (int)ddlOcupacion.SelectedValue;
                    var ciudadano = new CiudadanoDomainModel
                    {
                        Clave = GetClaveCiudadano(),
                        Nombre = txtNombre.Text.Trim(),
                        ApellidoPaterno = txtApa.Text.Trim(),
                        ApellidoMaterno = txtAma.Text.Trim(),
                        FechaRegistro = DateTime.Now,
                        Sexo = ddlSexo.SelectedItem.ToString().ToLower(),
                        Curp = string.IsNullOrEmpty(txtCurp.Text.Trim()) ? null : txtCurp.Text.Trim().ToUpper(),
                        Direccion = txtDireccion.Text.Trim(),
                        Manzana = manzana,
                        Fechanac = fechaNacimiento,
                        Ocupacion = ocupacion,
                        Comentarios = txtComentarios.Text.Trim(),
                        Status = (int)StatusEnum.ACTIVO
                    };
                    try
                    {
                        var inserted = _ciudadanoBusiness.Add(ciudadano);
                        if (inserted)
                        {
                            this.btnGuardar.Enabled = true;
                            MessageBox.Show("El ciudadano se guardó correctamente", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else
                        {
                            this.btnGuardar.Enabled = true;
                            MessageBox.Show("Ocurrió un error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.btnGuardar.Enabled = true;
                        MessageBox.Show("Ocurrió un error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.btnGuardar.Enabled = false;
                    var clave = id.Value;
                    var manzana = int.Parse(txtManzana.Text.Trim());
                    var fechaNacimiento = DateTime.ParseExact(txtFechaNacimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var ocupacion = (int)ddlOcupacion.SelectedValue;
                    var ciudadano = new CiudadanoDomainModel
                    {
                        Clave = clave,
                        Nombre = txtNombre.Text.Trim(),
                        ApellidoPaterno = txtApa.Text.Trim(),
                        ApellidoMaterno = txtAma.Text.Trim(),
                        Sexo = ddlSexo.SelectedItem.ToString().ToLower(),
                        Curp = string.IsNullOrEmpty(txtCurp.Text.Trim()) ? null : txtCurp.Text.Trim().ToUpper(),
                        Direccion = txtDireccion.Text.Trim(),
                        Manzana = manzana,
                        Fechanac = fechaNacimiento,
                        Ocupacion = ocupacion,
                        Comentarios = txtComentarios.Text.Trim(),
                    };
                    try
                    {
                        var updated = _ciudadanoBusiness.UpdateOne(ciudadano);
                        if (updated)
                        {
                            this.btnGuardar.Enabled = true;
                            MessageBox.Show("El ciudadano se guardó correctamente", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.btnGuardar.Enabled = true;
                            MessageBox.Show("Ocurrió un error al editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.btnGuardar.Enabled = true;
                        MessageBox.Show("Ocurrió un error al editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GetOcupaciones()
        {
            var ocupaciones = _ocupacionBusiness.GetOcupaciones();
            ddlOcupacion.DataSource = ocupaciones;
            ddlOcupacion.DisplayMember = "Nombre";
            ddlOcupacion.ValueMember = "Idocup";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ciudadanos c = new Ciudadanos();
            c.ShowDialog();
            this.Close();
        }

        private void ciudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ciudadanos c = new Ciudadanos();
            c.ShowDialog();
            this.Close();
        }

        private long GetClaveCiudadano()
        {
            var currentYear = DateTime.Now.Year.ToString();
            var lastCurrentYearNumbers = currentYear[2..];
            var lastId = _ciudadanoBusiness.GetLastCiudadanoId();
            var id = "";
            long idNumber = 0;
            if (lastId == 0)
            {
                id = lastCurrentYearNumbers + "0001";
                idNumber = long.Parse(id);
                return idNumber;
            }
            var lastIdString = lastId.ToString();
            var lastIdTwoFirstNumbers = lastIdString.Substring(0, 2);
            if (lastCurrentYearNumbers == lastIdTwoFirstNumbers)
            {
                idNumber = lastId;
                idNumber++;
                return idNumber;
            }
            else
            {
                id = lastCurrentYearNumbers + "0001";
                idNumber = long.Parse(id);
                return idNumber;
            }
        }

        private void CiudadanoAddEdit_Load(object sender, EventArgs e)
        {
            lblAddEdit.Text = id == null ? "Nuevo Ciudadano" : "Editar Ciudadano";
            ddlSexo.SelectedIndex = ddlSexo.FindStringExact("Masculino");
            if (id != null && id is long)
            {
                try
                {
                    var idCd = id.Value;
                    var ciudadano = _ciudadanoBusiness.GetCiudadanoById(idCd);
                    SetValues(ciudadano);
                }
                catch (Exception)
                {
                }
            }
        }

        private void SetValues(CiudadanoDomainModel cd)
        {
            txtNombre.Text = cd.Nombre;
            txtApa.Text = cd.ApellidoPaterno;
            txtAma.Text = cd.ApellidoMaterno;
            ddlSexo.SelectedIndex = ddlSexo.FindStringExact(cd.Sexo);
            txtCurp.Text = cd.Curp;
            txtDireccion.Text = cd.Direccion;
            //ddlManzana.SelectedIndex = ddlManzana.FindStringExact(cd.Manzana.ToString());
            txtManzana.Text = cd.Manzana.ToString();
            txtFechaNacimiento.Text = cd.Fechanac.ToString("dd/MM/yyyy");
            ddlOcupacion.SelectedIndex = ddlOcupacion.FindStringExact(cd.OcupacionDomainModel.Nombre);
            txtComentarios.Text = cd.Comentarios;
        }
    }
}
