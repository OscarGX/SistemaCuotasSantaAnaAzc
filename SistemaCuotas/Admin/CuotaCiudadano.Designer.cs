
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
            this.lblCiudadano = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlCuotas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCargarDgv = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkApoyoMujer = new System.Windows.Forms.CheckBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCiudadanoClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFolioCuota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCargarCiudadanoDdl = new System.Windows.Forms.Button();
            this.ddlCiudadanoFiltered = new System.Windows.Forms.ComboBox();
            this.btnBuscarCiudadano = new System.Windows.Forms.Button();
            this.txtCiudadanoSearch = new System.Windows.Forms.TextBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblCiudadano);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.txtMonto);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.ddlCuotas);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.btnLimpiar);
            this.splitContainer1.Panel1.Controls.Add(this.btnCargarDgv);
            this.splitContainer1.Panel1.Controls.Add(this.btnGuardar);
            this.splitContainer1.Panel1.Controls.Add(this.txtComentarios);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.chkApoyoMujer);
            this.splitContainer1.Panel1.Controls.Add(this.txtSaldo);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtDescuento);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtStatus);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtCiudadanoClave);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtFolioCuota);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnCargarCiudadanoDdl);
            this.splitContainer1.Panel1.Controls.Add(this.ddlCiudadanoFiltered);
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscarCiudadano);
            this.splitContainer1.Panel1.Controls.Add(this.txtCiudadanoSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCuotasCiudadano);
            this.splitContainer1.Size = new System.Drawing.Size(942, 953);
            this.splitContainer1.SplitterDistance = 637;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblCiudadano
            // 
            this.lblCiudadano.AutoSize = true;
            this.lblCiudadano.Location = new System.Drawing.Point(305, 55);
            this.lblCiudadano.Name = "lblCiudadano";
            this.lblCiudadano.Size = new System.Drawing.Size(0, 20);
            this.lblCiudadano.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(826, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 27;
            this.button1.Text = "Detalle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(795, 254);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(125, 27);
            this.txtMonto.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(707, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Monto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(397, 586);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 28);
            this.label9.TabIndex = 23;
            this.label9.Text = "Cuotas del ciudadano";
            // 
            // ddlCuotas
            // 
            this.ddlCuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCuotas.FormattingEnabled = true;
            this.ddlCuotas.Location = new System.Drawing.Point(424, 255);
            this.ddlCuotas.Name = "ddlCuotas";
            this.ddlCuotas.Size = new System.Drawing.Size(187, 28);
            this.ddlCuotas.TabIndex = 22;
            this.ddlCuotas.SelectedIndexChanged += new System.EventHandler(this.ddlCuotas_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(312, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Cuota:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(713, 509);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 29);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCargarDgv
            // 
            this.btnCargarDgv.Location = new System.Drawing.Point(826, 589);
            this.btnCargarDgv.Name = "btnCargarDgv";
            this.btnCargarDgv.Size = new System.Drawing.Size(94, 29);
            this.btnCargarDgv.TabIndex = 19;
            this.btnCargarDgv.Text = "Cargar";
            this.btnCargarDgv.UseVisualStyleBackColor = true;
            this.btnCargarDgv.Click += new System.EventHandler(this.btnCargarDgv_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(826, 509);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 29);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(139, 388);
            this.txtComentarios.MaxLength = 255;
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(781, 92);
            this.txtComentarios.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Comentarios:";
            // 
            // chkApoyoMujer
            // 
            this.chkApoyoMujer.AutoSize = true;
            this.chkApoyoMujer.Location = new System.Drawing.Point(312, 318);
            this.chkApoyoMujer.Name = "chkApoyoMujer";
            this.chkApoyoMujer.Size = new System.Drawing.Size(75, 24);
            this.chkApoyoMujer.TabIndex = 15;
            this.chkApoyoMujer.Text = "Apoyo";
            this.chkApoyoMujer.UseVisualStyleBackColor = true;
            this.chkApoyoMujer.CheckedChanged += new System.EventHandler(this.chkApoyoMujer_CheckedChanged);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(139, 316);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(125, 27);
            this.txtSaldo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Saldo:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(795, 187);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(125, 27);
            this.txtDescuento.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(681, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Descuento:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(139, 254);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(125, 27);
            this.txtStatus.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status:";
            // 
            // txtCiudadanoClave
            // 
            this.txtCiudadanoClave.Location = new System.Drawing.Point(486, 187);
            this.txtCiudadanoClave.Name = "txtCiudadanoClave";
            this.txtCiudadanoClave.ReadOnly = true;
            this.txtCiudadanoClave.Size = new System.Drawing.Size(125, 27);
            this.txtCiudadanoClave.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Clave del ciudadano:";
            // 
            // txtFolioCuota
            // 
            this.txtFolioCuota.Location = new System.Drawing.Point(139, 187);
            this.txtFolioCuota.Name = "txtFolioCuota";
            this.txtFolioCuota.ReadOnly = true;
            this.txtFolioCuota.Size = new System.Drawing.Size(125, 27);
            this.txtFolioCuota.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Folio de cuota:";
            // 
            // btnCargarCiudadanoDdl
            // 
            this.btnCargarCiudadanoDdl.Location = new System.Drawing.Point(713, 110);
            this.btnCargarCiudadanoDdl.Name = "btnCargarCiudadanoDdl";
            this.btnCargarCiudadanoDdl.Size = new System.Drawing.Size(94, 29);
            this.btnCargarCiudadanoDdl.TabIndex = 4;
            this.btnCargarCiudadanoDdl.Text = "Cargar";
            this.btnCargarCiudadanoDdl.UseVisualStyleBackColor = true;
            this.btnCargarCiudadanoDdl.Click += new System.EventHandler(this.btnCargarCiudadanoDdl_Click);
            // 
            // ddlCiudadanoFiltered
            // 
            this.ddlCiudadanoFiltered.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCiudadanoFiltered.FormattingEnabled = true;
            this.ddlCiudadanoFiltered.Location = new System.Drawing.Point(413, 111);
            this.ddlCiudadanoFiltered.Name = "ddlCiudadanoFiltered";
            this.ddlCiudadanoFiltered.Size = new System.Drawing.Size(277, 28);
            this.ddlCiudadanoFiltered.TabIndex = 3;
            // 
            // btnBuscarCiudadano
            // 
            this.btnBuscarCiudadano.Location = new System.Drawing.Point(283, 112);
            this.btnBuscarCiudadano.Name = "btnBuscarCiudadano";
            this.btnBuscarCiudadano.Size = new System.Drawing.Size(94, 29);
            this.btnBuscarCiudadano.TabIndex = 2;
            this.btnBuscarCiudadano.Text = "Buscar";
            this.btnBuscarCiudadano.UseVisualStyleBackColor = true;
            this.btnBuscarCiudadano.Click += new System.EventHandler(this.btnBuscarCiudadano_Click);
            // 
            // txtCiudadanoSearch
            // 
            this.txtCiudadanoSearch.Location = new System.Drawing.Point(12, 113);
            this.txtCiudadanoSearch.MaxLength = 200;
            this.txtCiudadanoSearch.Name = "txtCiudadanoSearch";
            this.txtCiudadanoSearch.Size = new System.Drawing.Size(252, 27);
            this.txtCiudadanoSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asignación de Cuotas";
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
            this.dgvCuotasCiudadano.Size = new System.Drawing.Size(942, 312);
            this.dgvCuotasCiudadano.TabIndex = 0;
            // 
            // CuotaCiudadano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 953);
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
        private System.Windows.Forms.Button btnCargarCiudadanoDdl;
        private System.Windows.Forms.ComboBox ddlCiudadanoFiltered;
        private System.Windows.Forms.Button btnBuscarCiudadano;
        private System.Windows.Forms.TextBox txtCiudadanoSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCiudadanoClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFolioCuota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlCuotas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCargarDgv;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkApoyoMujer;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvCuotasCiudadano;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCiudadano;
    }
}