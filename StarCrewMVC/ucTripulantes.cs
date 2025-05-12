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
    public partial class ucTripulantes : UserControl
    {
        private TripulantesController tripController;
        private RolesController rolesController;
        private List<Rol> listaRoles;
        private int? tripulanteIdEnEdicion = null; // Para rastrear si estamos editando

        public ucTripulantes()
        {
            InitializeComponent();
            CustomUI.LoadDefaultStyle(this);

            tripController = new TripulantesController();
            rolesController = new RolesController();
            listaRoles = new List<Rol>();

            CargarRoles();
            CargarTripulantes();

            dgvTripulantes.CellClick += DgvTripulantes_CellClick;
        }

        private void ConfigurarDataGridView()
        {

            // Eliminar la columna de selección 
            dgvTripulantes.RowHeadersVisible = false;
            // Desactivar la selección de filas completas
            dgvTripulantes.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // Impedir que el usuario pueda seleccionar múltiples celdas
            dgvTripulantes.MultiSelect = false;

            // Configurar las columnas de botones solo una vez
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.UseColumnTextForButtonValue = true;

            // Asegurarse de que no se añaden las columnas más de una vez
            if (!dgvTripulantes.Columns.Contains("btnEditar"))
            {
                dgvTripulantes.Columns.Add(btnEditar);
            }
            if (!dgvTripulantes.Columns.Contains("btnEliminar"))
            {
                dgvTripulantes.Columns.Add(btnEliminar);
            }
        }

        private void CargarRoles()
        {
            cmbRoles.DataSource = rolesController.ObtenerRoles();
            cmbRoles.DisplayMember = "Nombre";
            cmbRoles.ValueMember = "Id";
        }

        private void CargarTripulantes()
        {
            listaRoles = tripController.ObtenerRoles();

            var lista = tripController.ObtenerTripulantes();

            // Convertimos a una lista anónima para mostrar solo lo que queremos
            dgvTripulantes.DataSource = lista.Select(t => new
            {
                t.Id,
                t.Nombre,
                Rol = listaRoles.FirstOrDefault(r => r.Id == t.RolId)?.Nombre,
                Nivel = t.NivelHabilidad
            }).ToList();

            ConfigurarDataGridView();
        }

        private void DgvTripulantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se hizo clic en una fila válida (no en encabezados)
            if (e.RowIndex >= 0)
            {
                // Verificar si tenemos suficientes columnas y están en el orden esperado
                if (dgvTripulantes.Columns.Count > e.ColumnIndex)
                {
                    // Obtener el ID del tripulante seleccionado
                    int idTripulante = Convert.ToInt32(dgvTripulantes.Rows[e.RowIndex].Cells["Id"].Value);

                    // Verificar en qué columna se hizo clic
                    string columnName = dgvTripulantes.Columns[e.ColumnIndex].Name;

                    // Ejecutar la acción correspondiente según la columna
                    if (columnName == "btnEditar")
                    {
                        EditarTripulante(idTripulante);
                    }
                    else if (columnName == "btnEliminar")
                    {
                        EliminarTripulante(idTripulante);
                    }
                }
            }
        }



        private void EditarTripulante(int idTripulante)
        {
            // Obtener el tripulante por ID
            var tripulante = tripController.ObtenerTripulantePorId(idTripulante);
            if (tripulante != null)
            {
                // Cargar los datos en los controles
                txtNombre.Text = tripulante.Nombre;
                cmbRoles.SelectedValue = tripulante.RolId;

                // Cambiar el texto del botón para indicar que estamos editando
                btnAgregar.Text = "Actualizar";

                // Guardar el ID del tripulante que estamos editando
                tripulanteIdEnEdicion = idTripulante;
            }
        }

        private void EliminarTripulante(int idTripulante)
        {
            // Pedir confirmación antes de eliminar
            if (AlienMessageBox.Show("¿Está seguro de eliminar este tripulante?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Eliminar el tripulante usando el controlador
                    tripController.EliminarTripulante(idTripulante);

                    // Recargar la lista de tripulantes
                    CargarTripulantes();

                    AlienMessageBox.Show("Tripulante eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    lblAgregar.Text = $"Error al eliminar el tripulante: " +  ex.Message + " Error";
                        
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validación del nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == "Nombre...")
            {
                lblAgregar.Text = "Por favor, ingresá un nombre valido.";
                lblAgregar.ForeColor = Color.YellowGreen;
                return;
            }

            // Obtener el rol seleccionado
            int rolId = (int)cmbRoles.SelectedValue;

            // Verificar si estamos editando o creando un tripulante
            if (tripulanteIdEnEdicion.HasValue)
            {
                // Estamos editando - Actualizando el tripulante
                tripController.ActualizarTripulante(tripulanteIdEnEdicion.Value, txtNombre.Text.Trim(), rolId);

                // Cambiar de vuelta al modo de agregar
                btnAgregar.Text = "Agregar";
                tripulanteIdEnEdicion = null;

                AlienMessageBox.Show("Tripulante actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Estamos creando un nuevo tripulante
                tripController.CrearTripulante(txtNombre.Text.Trim(), rolId);
                AlienMessageBox.Show("Tripulante creado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblAgregar.Visible = false;
            }
            // Limpiar campo de texto
            txtNombre.Clear();
            // Volver a mostrar el placeholder
            txtNombre.Text = "Nombre...";
            // Refrescar la tabla
            CargarTripulantes();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre...")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = "Nombre...";
            }
        }
    }
}

