
namespace SistemaCuotas.Lector
{
    partial class CuotasLector
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
            this.ddlFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ciudadanosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarCiudadanosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.ddlFilter);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCuotas);
            this.splitContainer1.Size = new System.Drawing.Size(1063, 471);
            this.splitContainer1.SplitterDistance = 109;
            this.splitContainer1.TabIndex = 0;
            // 
            // ddlFilter
            // 
            this.ddlFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFilter.FormattingEnabled = true;
            this.ddlFilter.Items.AddRange(new object[] {
            "Folio",
            "Concepto"});
            this.ddlFilter.Location = new System.Drawing.Point(397, 57);
            this.ddlFilter.Name = "ddlFilter";
            this.ddlFilter.Size = new System.Drawing.Size(151, 28);
            this.ddlFilter.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Buscar por concepto o folio";
            this.txtSearch.Size = new System.Drawing.Size(360, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ciudadanosToolStripMenuItem,
            this.exportarCiudadanosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ciudadanosToolStripMenuItem
            // 
            this.ciudadanosToolStripMenuItem.Name = "ciudadanosToolStripMenuItem";
            this.ciudadanosToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.ciudadanosToolStripMenuItem.Text = "Ciudadanos";
            this.ciudadanosToolStripMenuItem.Click += new System.EventHandler(this.ciudadanosToolStripMenuItem_Click);
            // 
            // exportarCiudadanosToolStripMenuItem
            // 
            this.exportarCiudadanosToolStripMenuItem.Name = "exportarCiudadanosToolStripMenuItem";
            this.exportarCiudadanosToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.exportarCiudadanosToolStripMenuItem.Text = "Exportar Ciudadanos";
            this.exportarCiudadanosToolStripMenuItem.Click += new System.EventHandler(this.exportarCiudadanosToolStripMenuItem_Click);
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.AllowUserToResizeColumns = false;
            this.dgvCuotas.AllowUserToResizeRows = false;
            this.dgvCuotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuotas.Location = new System.Drawing.Point(0, 0);
            this.dgvCuotas.MultiSelect = false;
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.ReadOnly = true;
            this.dgvCuotas.RowHeadersWidth = 51;
            this.dgvCuotas.RowTemplate.Height = 29;
            this.dgvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuotas.Size = new System.Drawing.Size(1063, 358);
            this.dgvCuotas.TabIndex = 0;
            // 
            // CuotasLector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 471);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CuotasLector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuotas Lector";
            this.Load += new System.EventHandler(this.CuotasLector_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ciudadanosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarCiudadanosToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox ddlFilter;
        private System.Windows.Forms.DataGridView dgvCuotas;
    }
}