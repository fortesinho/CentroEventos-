using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaModificacionUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion servicio, ValidadorReserva validador, IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEventoDeportivo)
{
      public void Ejecutar(Reserva reserva){
            if (!servicio.PoseeElPermiso( Permiso.UsuarioModificacion))
                  throw new FalloAutorizacionException("No tiene permiso para modificar Reservas.");

            if (!validador.ValidarReserva(reserva, out string mensajeError))
                  throw new ValidacionException(mensajeError);

            if (repoPersona.ObtenerPorId(reserva.PersonaId) == null)
                  throw new EntidadNotFoundException("No existe la persona");

             if (!repoEventoDeportivo.ExisteResponsable(reserva.EventoDeportivoId))
                  throw new EntidadNotFoundException("Evento deportivo no encontrado.");
            
            if (repoReserva.Listar().Any(repo => (repo.PersonaId == reserva.PersonaId) && (repo.EventoDeportivoId == reserva.EventoDeportivoId)))
                  throw new DuplicadoException("Persona duplicada en el evento.");

            repoReserva.Modificar(reserva);
      }
}
