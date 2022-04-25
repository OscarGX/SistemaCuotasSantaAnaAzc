using Business;
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
    public partial class CuotaAddEdit : Form
    {
        int? id;
        private readonly CuotaBusiness _cuotaBusiness;
        public CuotaAddEdit(int? id = null)
        {
            this.id = id;
            _cuotaBusiness = new CuotaBusiness();
            InitializeComponent();
        }

        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cuotas c = new Cuotas();
            c.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cuotas c = new Cuotas();
            c.ShowDialog();
            this.Close();
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
                    var fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var monto = double.Parse(txtMonto.Text);
                    var cuota = new CuotaDomainModel
                    {
                        Concepto = txtConcepto.Text.Trim(),
                        Fecha = fecha,
                        Hora = DateTime.Now.TimeOfDay,
                        Status = "completa",
                        Monto = monto
                    };
                    try
                    {
                        var inserted = _cuotaBusiness.Add(cuota);
                        if (inserted)
                        {
                            this.btnGuardar.Enabled = true;
                            MessageBox.Show("La cuota se guardó correctamente", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
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
                    var idCuota = id.Value;
                    var fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var monto = double.Parse(txtMonto.Text);
                    var cuota = new CuotaDomainModel
                    {
                        Concepto = txtConcepto.Text.Trim(),
                        Fecha = fecha,
                        Monto = monto
                    };
                    try
                    {
                        var updated = _cuotaBusiness.UpdateOne(idCuota, cuota);
                        if (updated)
                        {
                            this.btnGuardar.Enabled = true;
                            MessageBox.Show("La cuota se guardó correctamente", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CuotaAddEdit_Load(object sender, EventArgs e)
        {
            lblAddEdit.Text = id == null ? "Nueva Cuota" : "Editar Cuota";
            if (id != null && id is int)
            {
                try
                {
                    var idC = id.Value;
                    var cuota = _cuotaBusiness.GetCuotaById(idC);
                    SetValues(cuota);
                }
                catch (Exception)
                {
                }
            }
        }

        private void SetValues(CuotaDomainModel cd)
        {
            txtConcepto.Text = cd.Concepto;
            txtFecha.Text = cd.Fecha.ToString("dd/MM/yyyy");
            txtMonto.Text = cd.Monto.ToString();
        }
    }
}
