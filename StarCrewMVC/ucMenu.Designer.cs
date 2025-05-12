namespace StarCrewMVC
{
    partial class ucMenu
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
            this.btnTripulantes = new System.Windows.Forms.Button();
            this.btnMisiones = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTripulantes
            // 
            this.btnTripulantes.Location = new System.Drawing.Point(48, 121);
            this.btnTripulantes.Name = "btnTripulantes";
            this.btnTripulantes.Size = new System.Drawing.Size(110, 40);
            this.btnTripulantes.TabIndex = 0;
            this.btnTripulantes.Text = "Tripulantes";
            this.btnTripulantes.UseVisualStyleBackColor = true;
            this.btnTripulantes.Click += new System.EventHandler(this.btnTripulantes_Click);
            // 
            // btnMisiones
            // 
            this.btnMisiones.Location = new System.Drawing.Point(48, 204);
            this.btnMisiones.Name = "btnMisiones";
            this.btnMisiones.Size = new System.Drawing.Size(110, 40);
            this.btnMisiones.TabIndex = 1;
            this.btnMisiones.Text = "Misiones";
            this.btnMisiones.UseVisualStyleBackColor = true;
            this.btnMisiones.Click += new System.EventHandler(this.btnMisiones_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(48, 288);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(110, 40);
            this.btnHistorial.TabIndex = 2;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(48, 369);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(110, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(35, 60);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(98, 13);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Star Crew Manager";
            this.lblTitulo.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnMisiones);
            this.Controls.Add(this.btnTripulantes);
            this.Name = "ucMenu";
            this.Size = new System.Drawing.Size(198, 502);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTripulantes;
        private System.Windows.Forms.Button btnMisiones;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitulo;
    }
}
