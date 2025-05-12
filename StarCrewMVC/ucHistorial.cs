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
        private int misionActivaSeleccionadaId = 0;

        private MisionesController misionesController;
        public ucHistorial()
        {
            InitializeComponent();
            CustomUI.LoadDefaultStyle(this);

            misionesController = new MisionesController();

            CargarHistorial();
            CargarMisionesActivas();

            dgvMisionActiva.CellClick += dgvMisionActiva_CellClick;
        }

        private void ConfigurarDataGridView()
        {
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // no modificar altura filas
            dgvHistorial.AllowUserToResizeRows = false;
            // ocultar columna id
            dgvHistorial.Columns["MisionId"].Visible = false;
        }

        private void ConfigurarDataGridViewActivas()
        {
            dgvMisionActiva.RowHeadersVisible = false;
            dgvMisionActiva.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvMisionActiva.MultiSelect = false;
            dgvMisionActiva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMisionActiva.AllowUserToResizeColumns = false;
            // ocultar columna id
            dgvMisionActiva.Columns["Id"].Visible = false;
            // ocultar columna titulo
            dgvMisionActiva.Columns["Titulo"].Visible = false;
        }
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

        private void btnFinMision_Click(object sender, EventArgs e)
        {
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
