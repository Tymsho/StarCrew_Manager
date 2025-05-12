using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Modelo
{
    //Estas clases representan las entidades del sistema: roles, tipos de misión, misiones, asignaciones, historial de misiones, requisitos y tripulantes.
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class TipoMision
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Mision
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int TipoMisionId { get; set; }
        public int Dificultad { get; set; }
        public string Requisitos { get; set; }
    }

    public class Asignacion
    {
        public int Id { get; set; }
        public int TripulanteId { get; set; }
        public int MisionId { get; set; }
        public string Estado { get; set; }
    }

    public class HistorialMision
    {
        public int Id { get; set; }
        public int MisionId { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string Resultado { get; set; }
        public string Detalles { get; set; }
    }

    public class RequisitoMision
    {
        public int Id { get; set; }
        public int MisionId { get; set; }
        public int RolId { get; set; }
        public int CantidadMinima { get; set; }
        public int HabilidadMinima { get; set; }
    }
    public class Tripulante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RolId { get; set; }
        public int NivelHabilidad { get; set; }
    }

    //Contiene la cadena de conexión para todas las operaciones con la base de datos.
    public class Conexion
    {
        public static string Local = "Server=DESKTOP-NKI4B61\\SQLEXPRESS;Database=StarCrew;TrustServerCertificate=True;Trusted_Connection=True;";

    }

    //Clase que maneja las consultas a la tabla Tripulantes
    public class TripulantesService
    {
        private string connectionString = Conexion.Local;

        //Inserta un nuevo tripulantes
        public void AgregarTripulante(Tripulante tripulante)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tripulantes (Nombre, RolId) VALUES (@Nombre, @RolId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", tripulante.Nombre);
                command.Parameters.AddWithValue("@RolId", tripulante.RolId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Modifica un tripulante por ID
        public void ActualizarTripulante(Tripulante tripulante)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Tripulantes SET Nombre = @Nombre, RolId = @RolId, NivelHabilidad = @NivelHabilidad WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", tripulante.Id);
                command.Parameters.AddWithValue("@Nombre", tripulante.Nombre);
                command.Parameters.AddWithValue("@RolId", tripulante.RolId);
                command.Parameters.AddWithValue("@NivelHabilidad", tripulante.NivelHabilidad);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Elimina un tripulante por ID
        public void EliminarTripulante(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tripulantes WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Obtiene una lista de todos los tripulantes cargados
        public List<Tripulante> ObtenerTripulantes()
        {
            List<Tripulante> tripulantes = new List<Tripulante>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nombre, RolId, NivelHabilidad FROM Tripulantes";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tripulantes.Add(new Tripulante
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            RolId = reader.GetInt32(2),
                            NivelHabilidad = reader.GetInt32(3)
                        });
                    }
                }
                connection.Close();
            }

            return tripulantes;
        }

        //Obtiene un tripulante segun el ID
        public Tripulante ObtenerTripulantePorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, RolId, NivelHabilidad FROM Tripulantes WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Tripulante
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            RolId = reader.GetInt32(2),
                            NivelHabilidad = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                        };
                    }
                }
                connection.Close();
            }
            return null; // Tripulante no encontrado
        }
    }

    //Clase que maneja las consultas a la tabla Asignaciones
    public class AsignacionesService
    {
        private string connectionString = Conexion.Local;

        //Inserta una asignacion a la tabla
        public void AgregarAsignacion(Asignacion asignacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Asignaciones (TripulanteId, MisionId, Estado) VALUES (@TripulanteId, @MisionId, @Estado)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TripulanteId", asignacion.TripulanteId);
                command.Parameters.AddWithValue("@MisionId", asignacion.MisionId);
                command.Parameters.AddWithValue("@Estado", asignacion.Estado);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Modifica una asignacion por ID
        public void ActualizarAsignacion(Asignacion asignacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Asignaciones SET Estado = @Estado WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", asignacion.Id);
                command.Parameters.AddWithValue("@Estado", asignacion.Estado);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Elimina una asignacion por ID
        public void EliminarAsignacion(Asignacion asignacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Asignaciones WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", asignacion.Id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Obtiene una lista de las asignaciones existentes
        public List<Asignacion> ObtenerAsignaciones()
        {
            List<Asignacion> asignaciones = new List<Asignacion>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, TripulanteId, MisionId, Estado FROM Asignaciones";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        asignaciones.Add(new Asignacion
                        {
                            Id = reader.GetInt32(0),
                            TripulanteId = reader.GetInt32(1),
                            MisionId = reader.GetInt32(2),
                            Estado = reader.GetString(3)
                        });
                    }
                }
                connection.Close();
            }

            return asignaciones;
        }
    }

    //Clase que maneja las consultas a la tabla HistorialDeMisiones
    public class HistorialMisionesService
    {
        private string connectionString = Conexion.Local;

        //Agrega una entrada al historial de misiones
        public void AgregarHistorialMision(HistorialMision historial)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO HistorialMisiones (MisionId, FechaFinalizacion, Resultado, Detalles) VALUES (@MisionId, @FechaFinalizacion, @Resultado, @Detalles)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MisionId", historial.MisionId);
                command.Parameters.AddWithValue("@FechaFinalizacion", historial.FechaFinalizacion);
                command.Parameters.AddWithValue("@Resultado", historial.Resultado);
                command.Parameters.AddWithValue("@Detalles", historial.Detalles ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Obtiene una lista con todas las entradas del historial de misiones
        public List<HistorialMision> ObtenerHistorialMisiones()
        {
            List<HistorialMision> historialMisiones = new List<HistorialMision>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, MisionId, FechaFinalizacion, Resultado, Detalles FROM HistorialMisiones";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        historialMisiones.Add(new HistorialMision
                        {
                            Id = reader.GetInt32(0),
                            MisionId = reader.GetInt32(1),
                            FechaFinalizacion = reader.GetDateTime(2),
                            Resultado = reader.GetString(3),
                            Detalles = reader.IsDBNull(4) ? null : reader.GetString(4)
                        });
                    }
                }
                connection.Close();
            }

            return historialMisiones;
        }
    }

    //Clase que maneja las consultas a la tabla Roles
    public class RolesService
    {
        private string connectionString = Conexion.Local;

        public List<Rol> ObtenerRoles()
        {
            List<Rol> roles = new List<Rol>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nombre FROM Roles";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Rol { Id = reader.GetInt32(0), Nombre = reader.GetString(1) });
                    }
                }
                connection.Close();
            }

            return roles;
        }
    }

    //Clase que maneja las consultas a la tabla TiposDeMisiones
    public class TiposMisionesService
    {
        private string connectionString = Conexion.Local;
        public List<TipoMision> ObtenerTiposDeMision()
        {
            List<TipoMision> tipos = new List<TipoMision>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nombre FROM TiposDeMision";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipos.Add(new TipoMision { Id = reader.GetInt32(0), Nombre = reader.GetString(1) });
                    }
                }
                connection.Close();
            }

            return tipos;
        }
    }

    //Clase que maneja las consultas a la tabla Misiones
    public class MisionesService
    {
        private string connectionString = Conexion.Local;
        public List<Mision> ObtenerMisiones()
        {
            List<Mision> misiones = new List<Mision>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Titulo, TipoMisionId, Dificultad, Requisitos FROM Misiones";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        misiones.Add(new Mision
                        {
                            Id = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            TipoMisionId = reader.GetInt32(2),
                            Dificultad = reader.GetInt32(3),
                            Requisitos = reader.GetString(4)
                        });
                    }
                }
                connection.Close();
            }
            return misiones;

        }

    }

    //Clase que maneja las consultas a la tabla RequisitosMisiones
    public class RequisitosMisionesService
    {
        private string connectionString = Conexion.Local;

        public List<RequisitoMision> ObtenerRequisitosMision()
        {
            List<RequisitoMision> requisitosMision = new List<RequisitoMision>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, MisionId, RolId, CantidadMinima FROM RequisitosMision";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requisitosMision.Add(new RequisitoMision
                        {
                            Id = reader.GetInt32(0),
                            MisionId = reader.GetInt32(1),
                            RolId = reader.GetInt32(2),
                            CantidadMinima = reader.GetInt32(3)
                        });
                    }
                }
                connection.Close();
            }

            return requisitosMision;
        }

        public List<RequisitoMision> ObtenerRequisitosMision(int misionId)
        {
            var todosLosRequisitos = ObtenerRequisitosMision();
            return todosLosRequisitos.Where(r => r.MisionId == misionId).ToList();
        }
    }
}
