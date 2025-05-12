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

namespace StarCrewMVC
{
    public partial class Form1 : Form
    {
        // Controllers
        private TripulantesController tripControl;
        private AsignacionesController asignControl;
        private MisionesController misionControl;

        // Servicios auxiliares
        private RolesService rolesService;
        private MisionesService misionesService;

        public Form1()
        {
            InitializeComponent();

            tripControl = new TripulantesController();
            asignControl = new AsignacionesController();
            misionControl = new MisionesController();

            rolesService = new RolesService();
            misionesService = new MisionesService();

            // Cargar datos iniciales
            CargarRoles();
            CargarMisiones();
            RefrescarTripulantes();
            CargarMisionesActivas();
        }
        private void CargarMisionesActivas()
        {
            var activas = misionControl.ConsultarMisionesActivas();
            cmbMisionesActivas.DataSource = activas;
            cmbMisionesActivas.DisplayMember = "Titulo";
            cmbMisionesActivas.ValueMember = "Id";
        }

        private void CargarRoles()
        {
            cmbRoles.DataSource = rolesService.ObtenerRoles();
            cmbRoles.DisplayMember = "Nombre";
            cmbRoles.ValueMember = "Id";
        }

        private void CargarMisiones()
        {
            cmbMisiones.DataSource = misionesService.ObtenerMisiones();
            cmbMisiones.DisplayMember = "Titulo";
            cmbMisiones.ValueMember = "Id";
        }

        private void RefrescarTripulantes()
        {
            lstTripulantes.Items.Clear();
            var lista = tripControl.ObtenerTripulantes();
            foreach (var t in lista)
                lstTripulantes.Items.Add($"{t.Id} - {t.Nombre} (Rol {t.RolId}, Nivel {t.NivelHabilidad})");

            // Para asignaciones: solo disponibles
            lstDisponibles.Items.Clear();

            var asigns = asignControl.ObtenerAsignaciones()
                                     .Where(a => a.Estado == "Asignado")  // ← solo las activas
                                     .ToList();
            var ocupadosIds = asigns.Select(a => a.TripulanteId).Distinct();

            foreach (var t in lista.Where(t => !ocupadosIds.Contains(t.Id)))
            {
                lstDisponibles.Items.Add(new ListItem { Id = t.Id, Text = $"{t.Id} - {t.Nombre}" });
            }
        }


        private void btnCrearTrip_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa un nombre.");
                return;
            }
            int rolId = (int)cmbRoles.SelectedValue;
            tripControl.CrearTripulante(txtNombre.Text, rolId);
            txtNombre.Clear();
            RefrescarTripulantes();
            MessageBox.Show("Tripulante creado.");
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cmbMisiones.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una misión.");
                return;
            }
            if (lstDisponibles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un tripulante.");
                return;
            }

            int misionId = (int)cmbMisiones.SelectedValue;
            var ids = new List<int>();
            foreach (ListItem li in lstDisponibles.SelectedItems)
                ids.Add(li.Id);

            // Asignar uno por uno
            foreach (int tid in ids)
                asignControl.AsignarTripulanteAMision(tid, misionId);

            CargarMisionesActivas();
            RefrescarTripulantes();
            MessageBox.Show("Asignaciones realizadas.");
        }

        private void btnCargarHistorial_Click(object sender, EventArgs e)
        {
            var historial = misionControl.ConsultarHistorialMisiones();
            dgvHistorial.DataSource = historial
                .Select(h => new {
                    h.Id,
                    Mision = h.MisionId,
                    Fecha = h.FechaFinalizacion,
                    Resultado = h.Resultado,
                    Detalles = h.Detalles
                })
                .ToList();
        }

        private void btnFinalizarMision_Click(object sender, EventArgs e)
        {
            if (cmbMisionesActivas.SelectedItem == null)
            {
                MessageBox.Show("No hay misiones activas para finalizar.");
                return;
            }

            int misionId = (int)cmbMisionesActivas.SelectedValue;
            misionControl.FinalizarMision(misionId);

            // Refrescar todo
            RefrescarTripulantes();
            CargarMisionesActivas();
            btnCargarHistorial_Click(null, null);

            MessageBox.Show("Misión finalizada y registrada en el historial.");
        }


        // Clase auxiliar para ListBox con ID y texto
        private class ListItem
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public override string ToString() => Text;
        }
    }
}
