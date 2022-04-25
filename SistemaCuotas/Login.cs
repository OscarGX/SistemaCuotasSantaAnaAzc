using Business.Enum;
using Business.Infrastructure;
using SistemaCuotas.Admin;
using SistemaCuotas.Lector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCuotas
{
    public partial class Login : Form
    {
        private readonly IAccountBusiness _accountBusiness;

        //public Login(IAccountBusiness accountBusiness)
        //{
        //    _accountBusiness = accountBusiness;
        //}
        public Login(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
            InitializeComponent();
            lblError.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            lblError.Hide();
            var nombre = txtNombre.Text.Trim();
            var password = txtPassword.Text.Trim();
            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(password))
            {
                lblError.Text = "Debes completar los campos";
                lblError.Show();
                button1.Enabled = true;
                return;
            }
            var user = _accountBusiness.Login(nombre, password);
            if (user == null)
            {
                lblError.Text = "Nombre o contraseña incorrectos";
                lblError.Show();
                button1.Enabled = true;
            } else if (user.Tipo == (int)NivelEnum.ADMIN)
            {
                this.Hide();
                MainForm c = new MainForm();
                c.ShowDialog();
                this.Close();
            } else
            {
                this.Hide();
                MainLector c = new MainLector();
                c.ShowDialog();
                this.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
