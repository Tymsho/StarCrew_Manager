using System.Drawing;
using System.Windows.Forms;



namespace StarCrewMVC
{
    partial class ucTripulantes
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
            this.dgvTripulantes = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTituloLista = new System.Windows.Forms.Label();
            this.lblTituloAgregar = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblAgregar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripulantes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTripulantes
            // 
            this.dgvTripulantes.AllowUserToAddRows = false;
            this.dgvTripulantes.AllowUserToDeleteRows = false;
            this.dgvTripulantes.AllowUserToResizeColumns = false;
            this.dgvTripulantes.AllowUserToResizeRows = false;
            this.dgvTripulantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTripulantes.Location = new System.Drawing.Point(210, 64);
            this.dgvTripulantes.MultiSelect = false;
            this.dgvTripulantes.Name = "dgvTripulantes";
            this.dgvTripulantes.ReadOnly = true;
            this.dgvTripulantes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTripulantes.Size = new System.Drawing.Size(585, 228);
            this.dgvTripulantes.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(410, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(113, 13);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Gestion de Tripulantes";
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.AutoSize = true;
            this.lblTituloLista.Location = new System.Drawing.Point(420, 48);
            this.lblTituloLista.Name = "lblTituloLista";
            this.lblTituloLista.Size = new System.Drawing.Size(99, 13);
            this.lblTituloLista.TabIndex = 2;
            this.lblTituloLista.Text = "Lista de Tripulantes";
            // 
            // lblTituloAgregar
            // 
            this.lblTituloAgregar.AutoSize = true;
            this.lblTituloAgregar.Location = new System.Drawing.Point(420, 304);
            this.lblTituloAgregar.Name = "lblTituloAgregar";
            this.lblTituloAgregar.Size = new System.Drawing.Size(143, 13);
            this.lblTituloAgregar.TabIndex = 3;
            this.lblTituloAgregar.Text = "Agregar Tripulante a la Nave";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.LimeGreen;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(260, 351);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(122, 19);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.Text = "Nombre...";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // cmbRoles
            // 
            this.cmbRoles.BackColor = System.Drawing.Color.LimeGreen;
            this.cmbRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbRoles.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(460, 351);
            this.cmbRoles.Margin = new System.Windows.Forms.Padding(0);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(121, 20);
            this.cmbRoles.TabIndex = 5;
            this.cmbRoles.Text = "Rol...";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(660, 350);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblAgregar
            // 
            this.lblAgregar.AutoSize = true;
            this.lblAgregar.Location = new System.Drawing.Point(244, 387);
            this.lblAgregar.Name = "lblAgregar";
            this.lblAgregar.Size = new System.Drawing.Size(0, 13);
            this.lblAgregar.TabIndex = 7;
            // 
            // ucTripulantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lblAgregar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTituloAgregar);
            this.Controls.Add(this.lblTituloLista);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvTripulantes);
            this.Name = "ucTripulantes";
            this.Size = new System.Drawing.Size(1302, 557);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripulantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTripulantes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTituloLista;
        private System.Windows.Forms.Label lblTituloAgregar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnAgregar;
        private Label lblAgregar;
    }
}
