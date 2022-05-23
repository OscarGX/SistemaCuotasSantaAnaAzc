
namespace SistemaCuotas.Admin
{
    partial class CuotaCiudadano
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtCuotaSearch = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblManzana = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblOcupacion = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblCiudadano = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.chkApoyoMujer = new System.Windows.Forms.CheckBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCuotasCiudadano = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotasCiudadano)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtCuotaSearch);
            this.splitContainer1.Panel1.Controls.Add(this.lblFechaNacimiento);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.lblManzana);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.lblDireccion);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.lblSexo);
            this.splitContainer1.Panel1.Controls.Add(this.lblOcupacion);
            this.splitContainer1.Panel1.Controls.Add(this.lblEdad);
            this.splitContainer1.Panel1.Controls.Add(this.lblCiudadano);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.btnGuardar);
            this.splitContainer1.Panel1.Controls.Add(this.chkApoyoMujer);
            this.splitContainer1.Panel1.Controls.Add(this.lblClave);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCuotasCiudadano);
            this.splitContainer1.Size = new System.Drawing.Size(942, 803);
            this.splitContainer1.SplitterDistance = 446;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtCuotaSearch
            // 
            this.txtCuotaSearch.Location = new System.Drawing.Point(12, 372);
            this.txtCuotaSearch.Name = "txtCuotaSearch";
            this.txtCuotaSearch.PlaceholderText = "Buscar por concepto";
            this.txtCuotaSearch.Size = new System.Drawing.Size(317, 27);
            this.txtCuotaSearch.TabIndex = 42;
            this.txtCuotaSearch.TextChanged += new System.EventHandler(this.txtCuotaSearch_TextChanged);
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(622, 162);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(0, 20);
            this.lblFechaNacimiento.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(446, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 20);
            this.label10.TabIndex = 40;
            this.label10.Text = "Fecha de Nacimiento:";
            // 
            // lblManzana
            // 
            this.lblManzana.AutoSize = true;
            this.lblManzana.Location = new System.Drawing.Point(622, 123);
            this.lblManzana.Name = "lblManzana";
            this.lblManzana.Size = new System.Drawing.Size(0, 20);
            this.lblManzana.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(526, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Manzana:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(139, 231);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(0, 20);
            this.lblDireccion.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(554, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Sexo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Ocupación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Edad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Clave:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Dirección:";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(622, 194);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(0, 20);
            this.lblSexo.TabIndex = 31;
            // 
            // lblOcupacion
            // 
            this.lblOcupacion.AutoSize = true;
            this.lblOcupacion.Location = new System.Drawing.Point(139, 194);
            this.lblOcupacion.Name = "lblOcupacion";
            this.lblOcupacion.Size = new System.Drawing.Size(0, 20);
            this.lblOcupacion.TabIndex = 30;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(139, 162);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(0, 20);
            this.lblEdad.TabIndex = 29;
            // 
            // lblCiudadano
            // 
            this.lblCiudadano.AutoSize = true;
            this.lblCiudadano.Location = new System.Drawing.Point(270, 52);
            this.lblCiudadano.Name = "lblCiudadano";
            this.lblCiudadano.Size = new System.Drawing.Size(0, 20);
            this.lblCiudadano.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(397, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 28);
            this.label9.TabIndex = 23;
            this.label9.Text = "Cuotas del ciudadano";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(836, 370);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 29);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // chkApoyoMujer
            // 
            this.chkApoyoMujer.AutoSize = true;
            this.chkApoyoMujer.Location = new System.Drawing.Point(44, 268);
            this.chkApoyoMujer.Name = "chkApoyoMujer";
            this.chkApoyoMujer.Size = new System.Drawing.Size(75, 24);
            this.chkApoyoMujer.TabIndex = 15;
            this.chkApoyoMujer.Text = "Apoyo";
            this.chkApoyoMujer.UseVisualStyleBackColor = true;
            this.chkApoyoMujer.CheckedChanged += new System.EventHandler(this.chkApoyoMujer_CheckedChanged);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(139, 123);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(0, 20);
            this.lblClave.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status Ciudadano";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvCuotasCiudadano
            // 
            this.dgvCuotasCiudadano.AllowUserToResizeColumns = false;
            this.dgvCuotasCiudadano.AllowUserToResizeRows = false;
            this.dgvCuotasCiudadano.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCuotasCiudadano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotasCiudadano.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvCuotasCiudadano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuotasCiudadano.Location = new System.Drawing.Point(0, 0);
            this.dgvCuotasCiudadano.MultiSelect = false;
            this.dgvCuotasCiudadano.Name = "dgvCuotasCiudadano";
            this.dgvCuotasCiudadano.ReadOnly = true;
            this.dgvCuotasCiudadano.RowHeadersWidth = 51;
            this.dgvCuotasCiudadano.RowTemplate.Height = 29;
            this.dgvCuotasCiudadano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuotasCiudadano.Size = new System.Drawing.Size(942, 353);
            this.dgvCuotasCiudadano.TabIndex = 0;
            this.dgvCuotasCiudadano.SelectionChanged += new System.EventHandler(this.DgvSelectionChanged);
            // 
            // CuotaCiudadano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 803);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CuotaCiudadano";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cuota Ciudadano";
            this.Load += new System.EventHandler(this.CuotaCiudadano_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotasCiudadano)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckBox chkApoyoMujer;
        private System.Windows.Forms.DataGridView dgvCuotasCiudadano;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCiudadano;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblOcupacion;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblManzana;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCuotaSearch;
    }
}