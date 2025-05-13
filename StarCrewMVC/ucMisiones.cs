using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Modelo;
using static StarCrewMVC.FormMain;

namespace StarCrewMVC
{
    public partial class ucMisiones : UserControl
    {
        // Variables para almacenar los controladores y datos
        private MisionesController misionesController;
        private AsignacionesController asignacionesController;
        private TripulantesController tripController;
        private List<Rol> listaRoles;
        private List<TipoMision> tipoMisiones;
        private List<Tripulante> tripulanteAsignado;
        private int idMision;
        public ucMisiones()
        {
            InitializeComponent();
            CustomUI.LoadDefaultStyle(this);

            // Inicializar los controladores
            misionesController = new MisionesController();
            asignacionesController = new AsignacionesController();
            tripController = new TripulantesController();
            tripulanteAsignado = new List<Tripulante>();
            listaRoles = new List<Rol>();
            tipoMisiones = new List<TipoMision>();
            // Inicializar el id de la misión por defecto 
            idMision = 0;

            // Inicializar los DataGridView
            CargarMisiones();
            cargarTripulantesDisponibles();

        }

        // Método para configurar el DataGridView de misiones
        private void configurarDataGridViewMisiones()
        {
            dgvMisiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajusta al contenido
            dgvMisiones.AllowUserToAddRows = false; // No permitir agregar filas
            dgvMisiones.MultiSelect = false; // No permitir selección múltiple
            dgvMisiones.ReadOnly = true; // Solo lectura
            dgvMisiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
            dgvMisiones.RowHeadersVisible = false; // Ocultar encabezados de fila
            dgvMisiones.AllowUserToResizeRows = false; // No permitir redimensionar filas
            dgvMisiones.AllowUserToResizeColumns = false; // No permitir redimensionar columnas
        }

        // Método para configurar el DataGridView de tripulantes
        private void configurarDataGridViewTripulante()
        {
            dgvTripulanteDisponible.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTripulanteDisponible.AllowUserToAddRows = false;
            dgvTripulanteDisponible.MultiSelect = false;
            dgvTripulanteDisponible.AllowUserToResizeRows = false;
            dgvTripulanteDisponible.AllowUserToResizeColumns = false;
            dgvTripulanteDisponible.RowHeadersVisible = false;
            dgvTripulanteDisponible.ReadOnly = true;
            dgvTripulanteDisponible.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Método para cargar las misiones en el DataGridView
        private void CargarMisiones()
        {
            dgvMisiones.Columns.Clear(); // Limpiar
            configurarDataGridViewMisiones();    // Solo aplica estilo

            // Obtener la lista de misiones y tipos de misión
            var lista = misionesController.ObtenerMisiones();
            tipoMisiones = misionesController.ObtenerTipoMision();

            // Crear la lista de datos para el DataGridView
            var datos = lista.Select(m => new
            {
                m.Id,
                m.Titulo,
                Tipo = tipoMisiones.FirstOrDefault(r => r.Id == m.TipoMisionId)?.Nombre,
                m.Dificultad,
                m.Requisitos
            }).ToList();

            dgvMisiones.DataSource = datos;

            dgvMisiones.Columns["Id"].Visible = false; // Ocultar la columna Id

            // Agregar la columna de botón solo si no está
            if (!dgvMisiones.Columns.Contains("btnSeleccionar"))
            {
                var btnSeleccionar = new DataGridViewButtonColumn
                {
                    Name = "btnSeleccionar",
                    HeaderText = "Seleccionar Mision",
                    Text = "Seleccionar",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                dgvMisiones.Columns.Add(btnSeleccionar);
            }
        }
        // Método para cargar los tripulantes disponibles en el DataGridView
        private void cargarTripulantesDisponibles()
        {
            listaRoles = tripController.ObtenerRoles();
            var lista = tripController.ObtenerTripulantes();

            // Filtrar los tripulantes ocupados
            var asigns = asignacionesController.ObtenerAsignaciones()
                                               .Where(a => a.Estado == "Pendiente")
                                               .ToList();
            var ocupadosIds = asigns.Select(a => a.TripulanteId).Distinct();

            // Filtrar los tripulantes disponibles
            var disponibles = lista.Where(t => !ocupadosIds.Contains(t.Id)).Select(t => new
            {
                t.Id,
                t.Nombre,
                Rol = listaRoles.FirstOrDefault(r => r.Id == t.RolId)?.Nombre,
                Nivel = t.NivelHabilidad
            }).ToList();

            dgvTripulanteDisponible.DataSource = disponibles;
            // Aplicar el estilo al DataGridView
            configurarDataGridViewTripulante();
            dgvTripulanteDisponible.Columns["Id"].Visible = false; // Ocultar la columna Id

            // Agregar columna de botón solo si no está
            if (!dgvTripulanteDisponible.Columns.Contains("btnDgvAsignar"))
            {
                DataGridViewButtonColumn btnAsignar = new DataGridViewButtonColumn
                {
                    HeaderText = "Asignar a Mision",
                    Text = "Asignar",
                    Name = "btnDgvAsignar",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                dgvTripulanteDisponible.Columns.Add(btnAsignar);
            }
        }

        // Método para manejar el evento de clic en la celda del DataGridView de tripulantes
        private void DgvTripulanteDisponible_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvTripulanteDisponible.Columns[e.ColumnIndex].Name;
                // Verificar que la columna es la correcta
                if (columnName == "btnDgvAsignar")
                {
                    
                    int idTripulante = Convert.ToInt32(dgvTripulanteDisponible.Rows[e.RowIndex].Cells["Id"].Value);
                    // Verificar si ya fue asignado
                    if (tripulanteAsignado.Any(t => t.Id == idTripulante))
                    {
                        lblTripulanteAsignado.Text = "Este Tripulante ya fue Asignado. \n\nAsigne Otro";
                        lblConfirmacion.ForeColor = Color.YellowGreen;
                        return;
                    }
                    // Usamos el metodo del controlador para obtener el tripulante por id
                    var tripulante = tripController.ObtenerTripulantePorId(idTripulante);
                    // Verificar si el tripulante existe
                    if (tripulante != null)
                    {
                        // Agregar el tripulante a la lista de asignados
                        tripulanteAsignado.Add(tripulante);
                        lblTripulanteAsignado.Text = $"{tripulante.Nombre} Asignado a la Misión.";
                    }
                }
            }
        }

        // Método para manejar el evento de clic en la celda del DataGridView de misiones
        private void dgvMisiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se hizo clic en una fila válida (no en encabezados)
            if (e.RowIndex >= 0)
            {
                // Verificar si tenemos suficientes columnas y están en el orden esperado
                if (dgvMisiones.Columns.Count > e.ColumnIndex)
                {
                    string columnName = dgvMisiones.Columns[e.ColumnIndex].Name;

                    if (columnName == "btnSeleccionar")
                    {
                       // Si ya hay una misión seleccionada, no dejar seleccionar otra
                        if (idMision != 0)
                        {
                            lblMisionAsignada.Text = "Mision Seleccionada.\n\nBorre Asignaciones para seleccionar otra";
                            return;
                        }

                        idMision = Convert.ToInt32(dgvMisiones.Rows[e.RowIndex].Cells["Id"].Value);

                        lblMisionAsignada.Text = "Mision Seleccionada";
                    }
                }
            }
        }

        // Método para limpiar la asignación de tripulantes
        private void limpiarAsignacion()
        {
            tripulanteAsignado.Clear();
            idMision = 0;
            lblTituloMisiones.Text = "MISIONES";
            lblTituloTripulantes.Text = "TRIPULANTES DISPONIBLES";
            lblMisionAsignada.Text = "No hay Mision Seleccionada";
            lblTripulanteAsignado.Text = "Sin Tripulante Asignado";
            lblConfirmacion.Text = "Manager Misiones";
            lblConfirmacion.ForeColor = Color.LimeGreen;
            lblConfirmacion.Location = new System.Drawing.Point(621, 410);
        }

        // Método para manejar el evento de clic en el botón "Asignar"
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una misión seleccionada y al menos un tripulante asignado
            if (idMision <= 0 && tripulanteAsignado.Count == 0)
            {
                lblConfirmacion.Text = "Seleccione una misión y al menos un tripulante.";
                lblConfirmacion.ForeColor = Color.Red;
                lblConfirmacion.Location = new System.Drawing.Point(500, 410);
                return;
            }
            // Verificar si hay una misión seleccionada
            if (idMision <= 0)
            {
                lblConfirmacion.Text = "Seleccione una misión primero.";
                lblConfirmacion.ForeColor = Color.YellowGreen;
                return;
            }
            // Verificar si hay tripulantes asignados
            if (tripulanteAsignado.Count == 0)
            {
                lblConfirmacion.Text = "Seleccione al menos un tripulante.";
                lblConfirmacion.ForeColor = Color.YellowGreen;
                return;
            }
            // Asignar los tripulantes a la misión
            foreach (var t in tripulanteAsignado)
            {
                asignacionesController.AsignarTripulanteAMision(t.Id, idMision);
            }
            AlienMessageBox.Show("Asignación exitosa", "Asignación de Tripulantes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar la asignación y recargar los datos
            limpiarAsignacion();
            CargarMisiones();
            cargarTripulantesDisponibles();
        }

        // Método para manejar el evento de carga del UserControl y asignar los eventos de los dataGridView
        private void ucMisiones_Load(object sender, EventArgs e)
        {
            dgvMisiones.CellClick += dgvMisiones_CellClick;
            dgvTripulanteDisponible.CellClick += DgvTripulanteDisponible_CellClick;
        }

        // Método para manejar el evento de clic en el botón "Borrar"
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            limpiarAsignacion();
        }
    }
}
