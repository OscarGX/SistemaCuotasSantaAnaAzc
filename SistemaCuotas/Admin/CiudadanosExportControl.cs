using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas.Admin
{
    public partial class CiudadanosExportControl : UserControl
    {
        private readonly CiudadanoBusiness _ciudadanoBusiness = new CiudadanoBusiness();
        public CiudadanosExportControl()
        {
            _ciudadanoBusiness = new CiudadanoBusiness();
            InitializeComponent();
        }

        private void CiudadanosExportControl_Load(object sender, EventArgs e)
        {
            var ciudadanos = GetCiudadanos();
            if (ciudadanos != null)
            {
                SetDgvData(ciudadanos);
                foreach (DataGridViewColumn column in dgvCiudadanos.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvCiudadanos.Rows.Count > 0)
            {
                var fileName = DateTime.Now.TimeOfDay;
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "CSV (*.csv)|*.csv",
                    FileName = "CiudadanoExport-" + fileName.Hours + "" + fileName.Minutes + "" + fileName.Seconds,
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int columnCount = dgvCiudadanos.Columns.Count;
                        string columnNames = "";
                        string[] outputCsv = new string[dgvCiudadanos.Rows.Count + 1];
                        for (int i = 0; i < columnCount; i++)
                        {
                            columnNames += dgvCiudadanos.Columns[i].HeaderText.ToString() + ",";
                        }
                        outputCsv[0] += columnNames;

                        for (int i = 1; i < dgvCiudadanos.Rows.Count; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                outputCsv[i] += dgvCiudadanos.Rows[i - 1].Cells[j].Value.ToString() + ",";
                            }
                        }
                        File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                        MessageBox.Show("Datos exportados correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay información que exportar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private long GetCiudadanoId()
        {
            if (dgvCiudadanos.CurrentRow != null)
            {
                var id = long.Parse(dgvCiudadanos.Rows[dgvCiudadanos.CurrentRow.Index].Cells[0].Value.ToString());
                return id;
            }
            return 0;
        }

        private List<CiudadanoDomainModel> GetCiudadanos(int? manzana = null)
        {
            try
            {
                return _ciudadanoBusiness.GetCiudadanosByManzanaWithCuotas(manzana);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtManzanaSearch.Text.Trim()))
            {
                var ciudadanos = GetCiudadanos();
                if (ciudadanos != null)
                {
                    SetDgvData(ciudadanos);
                }
            }
            else
            {
                var manzana = int.Parse(txtManzanaSearch.Text.Trim());
                var ciudadanos = GetCiudadanos(manzana);
                if (ciudadanos != null)
                {
                    SetDgvData(ciudadanos);
                }
            }
        }

        private void btnExportarCiudadano_Click(object sender, EventArgs e)
        {
            var id = GetCiudadanoId();
            if (id > 0)
            {
                var ciudadano = _ciudadanoBusiness.GetCiudadanoByIdWithCuotas(id);
                if (ciudadano.Cuotasciudadanos.Count > 0)
                {
                    ExportCiudadanoWithCuotas(ciudadano);
                }
                else
                {
                    MessageBox.Show("El ciudadano no tiene cuotas asignadas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("La fila seleccionada no contiene información válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportCiudadanoWithCuotas(CiudadanoDomainModel ciudadano)
        {
            var fileName = DateTime.Now.TimeOfDay;
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = "CiudadanoCuotasExport-" + fileName.Hours + "" + fileName.Minutes + "" + fileName.Seconds,
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string nombreColumnName = "Nombre: " + ciudadano.FullName;
                    string columNames = "Id,ClaveCiudadano,FolioDeCuota,Concepto,Monto,Saldo,Apoyo,Descuento,Status,Comentarios";
                    string[] outputCsv = new string[ciudadano.Cuotasciudadanos.Count + 2];
                    outputCsv[0] = nombreColumnName;
                    outputCsv[1] = columNames;
                    for (int i = 0; i < ciudadano.Cuotasciudadanos.Count; i++)
                    {
                        var cuota = ciudadano.Cuotasciudadanos[i];
                        var rowItem = cuota.Id + "," + cuota.Ciudadano + "," + cuota.Folio + "," + cuota.CuotaDomainModel.Concepto + "," + cuota.CuotaDomainModel.Monto + "," + cuota.Saldo + "," + cuota.ApoyoString + "," + cuota.Descuento + "," + cuota.StatusString + "," + cuota.Comentarios;
                        outputCsv[i + 2] = rowItem;
                    }
                    File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                    MessageBox.Show("Datos exportados correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }
        }
    }
}
