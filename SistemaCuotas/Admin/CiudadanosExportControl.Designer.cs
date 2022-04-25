
namespace SistemaCuotas.Admin
{
    partial class CiudadanosExportControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportarCiudadano = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtManzanaSearch = new System.Windows.Forms.TextBox();
            this.dgvCiudadanos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudadanos)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnExportarCiudadano);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.txtManzanaSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCiudadanos);
            this.splitContainer1.Size = new System.Drawing.Size(1228, 650);
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "Exportación de datos";
            // 
            // btnExportarCiudadano
            // 
            this.btnExportarCiudadano.Location = new System.Drawing.Point(555, 85);
            this.btnExportarCiudadano.Name = "btnExportarCiudadano";
            this.btnExportarCiudadano.Size = new System.Drawing.Size(160, 29);
            this.btnExportarCiudadano.TabIndex = 9;
            this.btnExportarCiudadano.Text = "Exportar Ciudadano";
            this.btnExportarCiudadano.UseVisualStyleBackColor = true;
            this.btnExportarCiudadano.Click += new System.EventHandler(this.btnExportarCiudadano_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "Exportar Todos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtManzanaSearch
            // 
            this.txtManzanaSearch.Location = new System.Drawing.Point(22, 87);
            this.txtManzanaSearch.Name = "txtManzanaSearch";
            this.txtManzanaSearch.PlaceholderText = "Manzana";
            this.txtManzanaSearch.Size = new System.Drawing.Size(224, 27);
            this.txtManzanaSearch.TabIndex = 6;
            // 
            // dgvCiudadanos
            // 
            this.dgvCiudadanos.AllowUserToResizeColumns = false;
            this.dgvCiudadanos.AllowUserToResizeRows = false;
            this.dgvCiudadanos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCiudadanos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiudadanos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCiudadanos.Location = new System.Drawing.Point(0, 0);
            this.dgvCiudadanos.Name = "dgvCiudadanos";
            this.dgvCiudadanos.ReadOnly = true;
            this.dgvCiudadanos.RowHeadersWidth = 51;
            this.dgvCiudadanos.RowTemplate.Height = 29;
            this.dgvCiudadanos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCiudadanos.Size = new System.Drawing.Size(1228, 500);
            this.dgvCiudadanos.TabIndex = 1;
            // 
            // CiudadanosExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CiudadanosExportControl";
            this.Size = new System.Drawing.Size(1228, 650);
            this.Load += new System.EventHandler(this.CiudadanosExportControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudadanos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportarCiudadano;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtManzanaSearch;
        private System.Windows.Forms.DataGridView dgvCiudadanos;
    }
}
