namespace StarCrewMVC
{
    partial class ucHistorial
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
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.dgvMisionActiva = new System.Windows.Forms.DataGridView();
            this.btnFinMision = new System.Windows.Forms.Button();
            this.lblTituloMisiones = new System.Windows.Forms.Label();
            this.lblTituloHistorial = new System.Windows.Forms.Label();
            this.lblInformacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisionActiva)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AllowUserToResizeColumns = false;
            this.dgvHistorial.AllowUserToResizeRows = false;
            this.dgvHistorial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(78, 258);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.Size = new System.Drawing.Size(658, 227);
            this.dgvHistorial.TabIndex = 0;
            // 
            // dgvMisionActiva
            // 
            this.dgvMisionActiva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisionActiva.Location = new System.Drawing.Point(40, 28);
            this.dgvMisionActiva.Name = "dgvMisionActiva";
            this.dgvMisionActiva.Size = new System.Drawing.Size(521, 207);
            this.dgvMisionActiva.TabIndex = 1;
            // 
            // btnFinMision
            // 
            this.btnFinMision.Location = new System.Drawing.Point(638, 127);
            this.btnFinMision.Name = "btnFinMision";
            this.btnFinMision.Size = new System.Drawing.Size(98, 42);
            this.btnFinMision.TabIndex = 2;
            this.btnFinMision.Text = "Finalizar Mision";
            this.btnFinMision.UseVisualStyleBackColor = true;
            this.btnFinMision.Click += new System.EventHandler(this.btnFinMision_Click);
            // 
            // lblTituloMisiones
            // 
            this.lblTituloMisiones.AutoSize = true;
            this.lblTituloMisiones.Location = new System.Drawing.Point(205, 12);
            this.lblTituloMisiones.Name = "lblTituloMisiones";
            this.lblTituloMisiones.Size = new System.Drawing.Size(107, 13);
            this.lblTituloMisiones.TabIndex = 3;
            this.lblTituloMisiones.Text = "MISIONES ACTIVAS";
            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.AutoSize = true;
            this.lblTituloHistorial.Location = new System.Drawing.Point(362, 242);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(119, 13);
            this.lblTituloHistorial.TabIndex = 4;
            this.lblTituloHistorial.Text = "HISTORIAL MISIONES";
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Location = new System.Drawing.Point(585, 96);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(16, 13);
            this.lblInformacion.TabIndex = 5;
            this.lblInformacion.Text = "...";
            this.lblInformacion.Visible = false;
            // 
            // ucHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInformacion);
            this.Controls.Add(this.lblTituloHistorial);
            this.Controls.Add(this.lblTituloMisiones);
            this.Controls.Add(this.btnFinMision);
            this.Controls.Add(this.dgvMisionActiva);
            this.Controls.Add(this.dgvHistorial);
            this.Name = "ucHistorial";
            this.Size = new System.Drawing.Size(849, 515);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisionActiva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridView dgvMisionActiva;
        private System.Windows.Forms.Button btnFinMision;
        private System.Windows.Forms.Label lblTituloMisiones;
        private System.Windows.Forms.Label lblTituloHistorial;
        private System.Windows.Forms.Label lblInformacion;
    }
}
