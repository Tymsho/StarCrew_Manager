using System.Windows.Forms;

namespace StarCrewMVC
{
    partial class ucMisiones
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
            this.dgvMisiones = new System.Windows.Forms.DataGridView();
            this.dgvTripulanteDisponible = new System.Windows.Forms.DataGridView();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblTituloMisiones = new System.Windows.Forms.Label();
            this.lblTituloTripulantes = new System.Windows.Forms.Label();
            this.lblMisionAsignada = new System.Windows.Forms.Label();
            this.lblTripulanteAsignado = new System.Windows.Forms.Label();
            this.lblConfirmacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripulanteDisponible)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMisiones
            // 
            this.dgvMisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisiones.Location = new System.Drawing.Point(15, 21);
            this.dgvMisiones.Name = "dgvMisiones";
            this.dgvMisiones.Size = new System.Drawing.Size(953, 215);
            this.dgvMisiones.TabIndex = 0;
            // 
            // dgvTripulanteDisponible
            // 
            this.dgvTripulanteDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTripulanteDisponible.Location = new System.Drawing.Point(15, 263);
            this.dgvTripulanteDisponible.Name = "dgvTripulanteDisponible";
            this.dgvTripulanteDisponible.Size = new System.Drawing.Size(341, 219);
            this.dgvTripulanteDisponible.TabIndex = 1;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(523, 360);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(130, 23);
            this.btnAsignar.TabIndex = 2;
            this.btnAsignar.Text = "Asignar Mision";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(685, 360);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(134, 23);
            this.btnBorrar.TabIndex = 3;
            this.btnBorrar.Text = "Borrar Asignaciones";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // lblTituloMisiones
            // 
            this.lblTituloMisiones.AutoSize = true;
            this.lblTituloMisiones.Location = new System.Drawing.Point(465, 5);
            this.lblTituloMisiones.Name = "lblTituloMisiones";
            this.lblTituloMisiones.Size = new System.Drawing.Size(59, 13);
            this.lblTituloMisiones.TabIndex = 4;
            this.lblTituloMisiones.Text = "MISIONES";
            // 
            // lblTituloTripulantes
            // 
            this.lblTituloTripulantes.AutoSize = true;
            this.lblTituloTripulantes.Location = new System.Drawing.Point(86, 247);
            this.lblTituloTripulantes.Name = "lblTituloTripulantes";
            this.lblTituloTripulantes.Size = new System.Drawing.Size(156, 13);
            this.lblTituloTripulantes.TabIndex = 5;
            this.lblTituloTripulantes.Text = "TRIPULANTES DISPONIBLES";
            // 
            // lblMisionAsignada
            // 
            this.lblMisionAsignada.AutoSize = true;
            this.lblMisionAsignada.Location = new System.Drawing.Point(653, 247);
            this.lblMisionAsignada.Name = "lblMisionAsignada";
            this.lblMisionAsignada.Size = new System.Drawing.Size(142, 13);
            this.lblMisionAsignada.TabIndex = 6;
            this.lblMisionAsignada.Text = "No hay Mision Seleccionada";
            // 
            // lblTripulanteAsignado
            // 
            this.lblTripulanteAsignado.AutoSize = true;
            this.lblTripulanteAsignado.Location = new System.Drawing.Point(362, 281);
            this.lblTripulanteAsignado.Name = "lblTripulanteAsignado";
            this.lblTripulanteAsignado.Size = new System.Drawing.Size(119, 13);
            this.lblTripulanteAsignado.TabIndex = 7;
            this.lblTripulanteAsignado.Text = "Sin Tripulante Asignado";
            // 
            // lblConfirmacion
            // 
            this.lblConfirmacion.AutoSize = true;
            this.lblConfirmacion.Location = new System.Drawing.Point(621, 410);
            this.lblConfirmacion.Name = "lblConfirmacion";
            this.lblConfirmacion.Size = new System.Drawing.Size(93, 13);
            this.lblConfirmacion.TabIndex = 8;
            this.lblConfirmacion.Text = "Manager Misiones";
            // 
            // ucMisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblConfirmacion);
            this.Controls.Add(this.lblTripulanteAsignado);
            this.Controls.Add(this.lblMisionAsignada);
            this.Controls.Add(this.lblTituloTripulantes);
            this.Controls.Add(this.lblTituloMisiones);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.dgvTripulanteDisponible);
            this.Controls.Add(this.dgvMisiones);
            this.Name = "ucMisiones";
            this.Size = new System.Drawing.Size(983, 530);
            this.Load += new System.EventHandler(this.ucMisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripulanteDisponible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMisiones;
        private DataGridView dgvTripulanteDisponible;
        private Button btnAsignar;
        private Button btnBorrar;
        private Label lblTituloMisiones;
        private Label lblTituloTripulantes;
        private Label lblMisionAsignada;
        private Label lblTripulanteAsignado;
        private Label lblConfirmacion;
    }
}
