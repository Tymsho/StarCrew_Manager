using System;
using System.Collections.Generic;
using Modelo;
using System.Linq;

namespace Controlador
{
    public class TripulantesController
    {
        private readonly TripulantesService tripulantesService;
        private readonly RolesService rolesService;

        public TripulantesController()
        {
            tripulantesService = new TripulantesService();
            rolesService = new RolesService();
        }

        public void CrearTripulante(string nombre, int rolId)
        {
            Tripulante nuevoTripulante = new Tripulante
            {
                Nombre = nombre,
                RolId = rolId,
            };

            tripulantesService.AgregarTripulante(nuevoTripulante);
        }

        public void ActualizarTripulante(int id, string nombre, int rolId)
        {
            // Primero obtenemos el tripulante actual para no perder datos
            var tripulante = tripulantesService.ObtenerTripulantePorId(id);
            if (tripulante == null)
            {
                throw new Exception("No se encontró el tripulante con ID " + id);
            }

            // Actualizamos solo los campos que nos interesan
            tripulante.Nombre = nombre;
            tripulante.RolId = rolId;

            tripulantesService.ActualizarTripulante(tripulante);
        }

        public List<Tripulante> ObtenerTripulantes()
        {
            return tripulantesService.ObtenerTripulantes();
        }

        public Tripulante ObtenerTripulantePorId(int id)
        {
            return tripulantesService.ObtenerTripulantePorId(id);
        }

        public void EliminarTripulante(int tripulanteId)
        {
            tripulantesService.EliminarTripulante(tripulanteId);
        }

        public List<Rol> ObtenerRoles()
        {
            return rolesService.ObtenerRoles();
        }

    }

    public class RolesController
    {
        private RolesService rolesService;
        public RolesController()
        {
            rolesService = new RolesService();
        }
        public List<Rol> ObtenerRoles()
        {
            return rolesService.ObtenerRoles();
        }
    }

    public class AsignacionesController
    {
        private AsignacionesService asignacionesService;

        public AsignacionesController()
        {
            asignacionesService = new AsignacionesService();
        }

        public void AsignarTripulanteAMision(int tripulanteId, int misionId)
        {
            Asignacion asignacion = new Asignacion
            {
                TripulanteId = tripulanteId,
                MisionId = misionId,
                Estado = "Pendiente"
            };

            asignacionesService.AgregarAsignacion(asignacion);
        }

        public List<Asignacion> ObtenerAsignaciones()
        {
            return asignacionesService.ObtenerAsignaciones();
        }

        public void EliminarAsignacion(int asignacionId)
        {
            var asignacion = new Asignacion { Id = asignacionId };
            asignacionesService.EliminarAsignacion(asignacion);
        }
    }

    public class MisionesController
    {
        private TripulantesService tripulantesService;
        private AsignacionesService asignacionesService;
        private RequisitosMisionesService requisitosService;
        private HistorialMisionesService historialService;
        private MisionesService misionesService;
        private TiposMisionesService tiposMisionesService;

        public MisionesController()
        {
            tripulantesService = new TripulantesService();
            asignacionesService = new AsignacionesService();
            requisitosService = new RequisitosMisionesService();
            historialService = new HistorialMisionesService();
            misionesService = new MisionesService();           
            tiposMisionesService = new TiposMisionesService();
        }

        public List<TipoMision> ObtenerTipoMision()
        {
            return tiposMisionesService.ObtenerTiposDeMision();
        }

        public List<Mision> ObtenerMisiones()
        {
            return misionesService.ObtenerMisiones();
        }

        public List<RequisitoMision> ObtenerRequisitosMision(int misionId)
        {
            return requisitosService.ObtenerRequisitosMision(misionId);
        }


        public void FinalizarMision(int misionId)
        {
            // Obtener tripulantes asignados
            List<Asignacion> asignaciones = asignacionesService.ObtenerAsignaciones()
                                                                .Where(a => a.MisionId == misionId && a.Estado == "Pendiente")
                                                                .ToList();

            List<Tripulante> tripulantesAsignados = tripulantesService.ObtenerTripulantes()
                                                                      .Where(t => asignaciones.Any(a => a.TripulanteId == t.Id))
                                                                      .ToList();

            // Obtener requisitos de la misión
            List<RequisitoMision> requisitos = requisitosService.ObtenerRequisitosMision(misionId);



            // Validar si cumple
            bool cumple = ValidarCumplimientoRequisitos(requisitos, tripulantesAsignados);

            string resultado = cumple ? "Exitosa" : "Fallida";

            // Agregar al historial
            HistorialMision historial = new HistorialMision
            {
                MisionId = misionId,
                FechaFinalizacion = DateTime.Now,
                Resultado = resultado,
                Detalles = cumple ? "Misión completada exitosamente." : "No se cumplieron los requisitos de la misión."
            };

            historialService.AgregarHistorialMision(historial);

            // Actualizar estado de asignaciones
            foreach (var asignacion in asignaciones)
            {
                asignacion.Estado = "Exitosa";
                asignacionesService.ActualizarAsignacion(asignacion);
            }

            if (cumple)
            {
                foreach (Tripulante t in tripulantesAsignados)
                {
                    if (t.NivelHabilidad < 3)
                    {
                        t.NivelHabilidad += 1;
                    }
                    
                    tripulantesService.ActualizarTripulante(t); // Asegúrate de tener este método
                }
            }
        }

        public List<HistorialMision> ConsultarHistorialMisiones()
        {
            return historialService.ObtenerHistorialMisiones();
        }

        public bool ValidarCumplimientoRequisitos(List<RequisitoMision> requisitos, List<Tripulante> tripulantesAsignados)
        {
            foreach (var requisito in requisitos)
            {
                var tripulantesConRol = tripulantesAsignados.Where(t => t.RolId == requisito.RolId).ToList();

                bool cumpleCantidadMinima = tripulantesConRol.Count >= requisito.CantidadMinima;
                bool cumpleHabilidadMinima = tripulantesConRol.Any(t => t.NivelHabilidad >= requisito.HabilidadMinima);

                // Si algún requisito no se cumple, la función devuelve false
                if (!cumpleCantidadMinima || !cumpleHabilidadMinima)
                {
                    return false;
                }
            }

            // Si todos los requisitos se cumplieron, devuelve true
            return true;
        }

        public List<Mision> ConsultarMisionesActivas()
        {
            var asigns = asignacionesService.ObtenerAsignaciones()
                             .Where(a => a.Estado == "Pendiente")
                             .ToList();
            var idsAct = asigns.Select(a => a.MisionId).Distinct();
            var todas = misionesService.ObtenerMisiones();
            return todas.Where(m => idsAct.Contains(m.Id)).ToList();
        }
    }
}
