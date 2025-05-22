using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase(IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, IServicioAutorizacion autorizacion){

    public void Ejecutar(Reserva datosReserva, int idUsuario){
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
            throw new FalloAutorizacionException("El usuario no tiene permiso para dar de alta reservas.");
        if (repoPersona.ObtenerPorId(datosReserva.PersonaId) == null)
            throw new EntidadNotFoundException("Persona", datosReserva.PersonaId);

        EventoDeportivo? evento = repoEvento.ObtenerPorId(datosReserva.EventoDeportivoId);
        if (evento == null)
            throw new EntidadNotFoundException("EventoDeportivo", datosReserva.EventoDeportivoId);

        List<Reserva> reservasDelEvento = repoReserva.ObtenerPorEvento(datosReserva.EventoDeportivoId);

        if (reservasDelEvento.Count >= evento.CupoMaximo)
            throw new CupoExcedidoException("No hay cupo disponible para este evento.");

        foreach (Reserva r in reservasDelEvento){
            if (r.PersonaId == datosReserva.PersonaId)
                throw new DuplicadoException("La persona ya tiene una reserva para este evento.");
        }

        datosReserva.FechaAltaReserva = DateTime.Now;
        datosReserva.EstadoAsistencia = Reserva.EstadoAsis.Ausente;
        repoReserva.Agregar(datosReserva);
    }

    
}
