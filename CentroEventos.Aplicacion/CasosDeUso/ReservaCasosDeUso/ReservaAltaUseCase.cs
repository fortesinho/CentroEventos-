using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion autorizacion, ValidadorReserva validador, IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEventoDeportivo)
{

    public void Ejecutar(Reserva reserva)
    {
        if (!autorizacion.PoseeElPermiso(Permiso.ReservaAlta))
            throw new FalloAutorizacionException("El usuario no tiene permiso para dar de alta reservas.");

        if (!validador.ValidarReserva(reserva, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (repoPersona.ObtenerPorId(reserva.PersonaId) == null)
            throw new EntidadNotFoundException("No existe la persona");

        //verificamos si existe el evento deportivo por id
        if (!repoEventoDeportivo.ExisteResponsable(reserva.EventoDeportivoId))
        {
            throw new EntidadNotFoundException("Evento deportivo no encontrado.");
        }
        //Valida que PersonaID no tenga EventoDeportivoId dos veces.
        if (repoReserva.Listar().Any(repo => (repo.PersonaId == reserva.PersonaId) && (repo.EventoDeportivoId == reserva.EventoDeportivoId)))
        {
            throw new DuplicadoException("Persona duplicada en el evento.");
        }
        if (repoReserva.ObtenerPorEvento(reserva.EventoDeportivoId).Count() >= repoEventoDeportivo.ObtenerPorId(reserva.EventoDeportivoId)?.CupoMaximo)
            throw new CupoExcedidoException(" Alcanzo el cupo maximo ");
        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = Reserva.EstadoAsis.Pendiente;
        repoReserva.Agregar(reserva);

    }
}
