using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Modelo;
using static StarCrewMVC.FormMain;

namespace StarCrewMVC
{
    public partial class ucHistorial : UserControl
    {
        // Variable para almacenar el ID de la misión activa seleccionada
        private int misionActivaSeleccionadaId = 0;

        private MisionesController misionesController;
        public ucHistorial()
        {
            InitializeComponent();
            // Establecer el estilo predeterminado
            CustomUI.LoadDefaultStyle(this);

            //  Inicializar el controlador
            misionesController = new MisionesController();

            // Inicializar los DataGridView
            CargarHistorial();
            CargarMisionesActivas();

            // Evento para el botón de finalizar misión
            dgvMisionActiva.CellClick += dgvMisionActiva_CellClick;
        }

        // Método para configurar el DataGridView del historial
        private void ConfigurarDataGridView()
        {
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHistorial.AllowUserToResizeRows = false;
            dgvHistorial.Columns["MisionId"].Visible = false;
        }

        // Método para configurar el DataGridView de misiones activas
        private void ConfigurarDataGridViewActivas()
        {
            // Configuraciones basicas
            dgvMisionActiva.RowHeadersVisible = false;
            dgvMisionActiva.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvMisionActiva.MultiSelect = false;
            dgvMisionActiva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMisionActiva.AllowUserToResizeColumns = false;
            // Ocultar columnas innecesarias a la vista
            dgvMisionActiva.Columns["Id"].Visible = false;
            dgvMisionActiva.Columns["TipoMisionId"].Visible = false;
            dgvMisionActiva.Columns["Dificultad"].Visible = false;
            dgvMisionActiva.Columns["Requisitos"].Visible = false;

        }

        // Método para cargar las misiones activas en el DataGridView
        private void CargarMisionesActivas()
        {
            dgvMisionActiva.Columns.Clear(); // Limpia columnas anteriores
            var activas = misionesController.ConsultarMisionesActivas();
            dgvMisionActiva.DataSource = activas;
            

            // Agregar botón "Seleccionar" si no está
            if (!dgvMisionActiva.Columns.Contains("btnSeleccionar"))
            {
                var btnSeleccionar = new DataGridViewButtonColumn
                {
                    Name = "btnSeleccionar",
                    HeaderText = "Acción",
                    Text = "Seleccionar",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                dgvMisionActiva.Columns.Add(btnSeleccionar);
            }
            ConfigurarDataGridViewActivas(); // Configura el DataGridView después de cargar los datos
        }

        // Método para cargar el historial de misiones en el DataGridView
        private void CargarHistorial()
        {
            var historial = misionesController.ConsultarHistorialMisiones();

            var datos = historial.Select(h => new
            {
                h.FechaFinalizacion,
                h.Resultado,
                h.MisionId,
                h.Detalles
            }).ToList();

            dgvHistorial.DataSource = datos;

            ConfigurarDataGridView();
        }

        // Evento para manejar el clic en el botón "Seleccionar" de la misión activa
        private void dgvMisionActiva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMisionActiva.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                if (misionActivaSeleccionadaId != 0)
                {
                    AlienMessageBox.Show("Ya seleccionaste una misión activa. Finalizala antes de seleccionar otra.", "Misión Activa", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                misionActivaSeleccionadaId = Convert.ToInt32(dgvMisionActiva.Rows[e.RowIndex].Cells["Id"].Value);
                lblInformacion.Visible = true;
                lblInformacion.Text = $"Misión seleccionada.";
            }
        }

        // Evento para manejar el clic en el botón "Finalizar Misión"
        private void btnFinMision_Click(object sender, EventArgs e)
        {
            // Verificar si hay una misión activa seleccionada
            if (misionActivaSeleccionadaId == 0)
            {
                lblInformacion.Text = "Seleccioná una misión activa para finalizar.";
                return;
            }

            misionesController.FinalizarMision(misionActivaSeleccionadaId);

            // Refrescar
            CargarMisionesActivas();
            CargarHistorial();
            misionActivaSeleccionadaId = 0;

            AlienMessageBox.Show("Misión finalizada", "Finalización de Misión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblInformacion.Visible = false;
        }

    }
}
