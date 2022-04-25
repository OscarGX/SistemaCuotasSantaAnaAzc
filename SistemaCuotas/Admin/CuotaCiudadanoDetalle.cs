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
    public partial class CuotaCiudadanoDetalle : Form
    {
        public CiudadanoDomainModel ciudadanoDM;
        public CuotaCiudadanoDetalle(CiudadanoDomainModel ciudadano)
        {
            ciudadanoDM = ciudadano;
            InitializeComponent();
        }

        private void CuotaCiudadanoDetalle_Load(object sender, EventArgs e)
        {
            lblDireccion.Text = ciudadanoDM.Direccion;
            lblEdad.Text = ciudadanoDM.Edad + " años";
            lblFechaNacimiento.Text = ciudadanoDM.Fechanac.ToString("dd/MM/yyyy");
            lblManzana.Text = ciudadanoDM.Manzana.ToString();
            lblNombre.Text = ciudadanoDM.FullName;
            lblOcupacion.Text = ciudadanoDM.OcupacionDomainModel.Nombre;
            lblSexo.Text = ciudadanoDM.Sexo;
        }
    }
}
