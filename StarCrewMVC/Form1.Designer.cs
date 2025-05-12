namespace StarCrewMVC
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnCrearTrip;
        private System.Windows.Forms.ListBox lstTripulantes;
        private System.Windows.Forms.ComboBox cmbMisiones;
        private System.Windows.Forms.ListBox lstDisponibles;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnCargarHistorial;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTripulantes;
        private System.Windows.Forms.Label lblMisiones;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.Label lblMisionesActivas;
        private System.Windows.Forms.ComboBox cmbMisionesActivas;
        private System.Windows.Forms.Button btnFinalizarMision;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMisionesActivas = new System.Windows.Forms.Label();
            this.cmbMisionesActivas = new System.Windows.Forms.ComboBox();
            this.btnFinalizarMision = new System.Windows.Forms.Button();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCrearTrip = new System.Windows.Forms.Button();
            this.lstTripulantes = new System.Windows.Forms.ListBox();
            this.cmbMisiones = new System.Windows.Forms.ComboBox();
            this.lstDisponibles = new System.Windows.Forms.ListBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnCargarHistorial = new System.Windows.Forms.Button();
            this.lblRoles = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTripulantes = new System.Windows.Forms.Label();
            this.lblMisiones = new System.Windows.Forms.Label();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.lblHistorial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMisionesActivas
            // 
            this.lblMisionesActivas.AutoSize = true;
            this.lblMisionesActivas.Location = new System.Drawing.Point(695, 10);
            this.lblMisionesActivas.Name = "lblMisionesActivas";
            this.lblMisionesActivas.Size = new System.Drawing.Size(89, 13);
            this.lblMisionesActivas.TabIndex = 0;
            this.lblMisionesActivas.Text = "Misiones Activas:";
            // 
            // cmbMisionesActivas
            // 
            this.cmbMisionesActivas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMisionesActivas.Location = new System.Drawing.Point(790, 7);
            this.cmbMisionesActivas.Name = "cmbMisionesActivas";
            this.cmbMisionesActivas.Size = new System.Drawing.Size(200, 21);
            this.cmbMisionesActivas.TabIndex = 1;
            // 
            // btnFinalizarMision
            // 
            this.btnFinalizarMision.Location = new System.Drawing.Point(774, 34);
            this.btnFinalizarMision.Name = "btnFinalizarMision";
            this.btnFinalizarMision.Size = new System.Drawing.Size(120, 23);
            this.btnFinalizarMision.TabIndex = 2;
            this.btnFinalizarMision.Text = "Finalizar Misión";
            this.btnFinalizarMision.UseVisualStyleBackColor = true;
            this.btnFinalizarMision.Click += new System.EventHandler(this.btnFinalizarMision_Click);
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(60, 12);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(150, 21);
            this.cmbRoles.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(283, 12);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // btnCrearTrip
            // 
            this.btnCrearTrip.Location = new System.Drawing.Point(450, 10);
            this.btnCrearTrip.Name = "btnCrearTrip";
            this.btnCrearTrip.Size = new System.Drawing.Size(100, 23);
            this.btnCrearTrip.TabIndex = 7;
            this.btnCrearTrip.Text = "Crear Tripulante";
            this.btnCrearTrip.UseVisualStyleBackColor = true;
            this.btnCrearTrip.Click += new System.EventHandler(this.btnCrearTrip_Click);
            // 
            // lstTripulantes
            // 
            this.lstTripulantes.FormattingEnabled = true;
            this.lstTripulantes.Location = new System.Drawing.Point(15, 70);
            this.lstTripulantes.Name = "lstTripulantes";
            this.lstTripulantes.Size = new System.Drawing.Size(535, 95);
            this.lstTripulantes.TabIndex = 9;
            // 
            // cmbMisiones
            // 
            this.cmbMisiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMisiones.FormattingEnabled = true;
            this.cmbMisiones.Location = new System.Drawing.Point(75, 177);
            this.cmbMisiones.Name = "cmbMisiones";
            this.cmbMisiones.Size = new System.Drawing.Size(200, 21);
            this.cmbMisiones.TabIndex = 11;
            // 
            // lstDisponibles
            // 
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.Location = new System.Drawing.Point(300, 200);
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstDisponibles.Size = new System.Drawing.Size(250, 95);
            this.lstDisponibles.TabIndex = 13;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(15, 205);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(250, 23);
            this.btnAsignar.TabIndex = 14;
            this.btnAsignar.Text = "Asignar a Misión";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(15, 330);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(535, 150);
            this.dgvHistorial.TabIndex = 16;
            // 
            // btnCargarHistorial
            // 
            this.btnCargarHistorial.Location = new System.Drawing.Point(15, 490);
            this.btnCargarHistorial.Name = "btnCargarHistorial";
            this.btnCargarHistorial.Size = new System.Drawing.Size(120, 23);
            this.btnCargarHistorial.TabIndex = 17;
            this.btnCargarHistorial.Text = "Refrescar Historial";
            this.btnCargarHistorial.UseVisualStyleBackColor = true;
            this.btnCargarHistorial.Click += new System.EventHandler(this.btnCargarHistorial_Click);
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(12, 15);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(26, 13);
            this.lblRoles.TabIndex = 3;
            this.lblRoles.Text = "Rol:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(230, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTripulantes
            // 
            this.lblTripulantes.AutoSize = true;
            this.lblTripulantes.Location = new System.Drawing.Point(12, 50);
            this.lblTripulantes.Name = "lblTripulantes";
            this.lblTripulantes.Size = new System.Drawing.Size(62, 13);
            this.lblTripulantes.TabIndex = 8;
            this.lblTripulantes.Text = "Tripulantes:";
            // 
            // lblMisiones
            // 
            this.lblMisiones.AutoSize = true;
            this.lblMisiones.Location = new System.Drawing.Point(12, 180);
            this.lblMisiones.Name = "lblMisiones";
            this.lblMisiones.Size = new System.Drawing.Size(51, 13);
            this.lblMisiones.TabIndex = 10;
            this.lblMisiones.Text = "Misiones:";
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Location = new System.Drawing.Point(300, 180);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(64, 13);
            this.lblDisponibles.TabIndex = 12;
            this.lblDisponibles.Text = "Disponibles:";
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Location = new System.Drawing.Point(12, 310);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(106, 13);
            this.lblHistorial.TabIndex = 15;
            this.lblHistorial.Text = "Historial de Misiones:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1002, 530);
            this.Controls.Add(this.lblMisionesActivas);
            this.Controls.Add(this.cmbMisionesActivas);
            this.Controls.Add(this.btnFinalizarMision);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCrearTrip);
            this.Controls.Add(this.lblTripulantes);
            this.Controls.Add(this.lstTripulantes);
            this.Controls.Add(this.lblMisiones);
            this.Controls.Add(this.cmbMisiones);
            this.Controls.Add(this.lblDisponibles);
            this.Controls.Add(this.lstDisponibles);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnCargarHistorial);
            this.Name = "Form1";
            this.Text = "StarCrew Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

