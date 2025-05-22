using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEvento,IRepositorioReserva repoReserva,IRepositorioPersona repoPersona,IServicioAutorizacion autorizacion){
    public List<Persona> Ejecutar(int idEvento, int idUsuario){ 
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaListado))//si usuario tiene permiso para listar reservas
            throw new FalloAutorizacionException("El usuario no tiene permiso para listar la asistencia.");

        EventoDeportivo? evento = repoEvento.ObtenerPorId(idEvento);//guarda el evento deportivo por su id
        if (evento == null)
            throw new EntidadNotFoundException("EventoDeportivo", idEvento);

        if (evento.FechaHoraInicio > DateTime.Now)
            throw new OperacionInvalidaException("El evento aún no se ha realizado.");

        List<Reserva> reservas = repoReserva.ObtenerPorEvento(idEvento); // guarda todas las reservas que tengan ese id del evento
        List<Persona> personasAsistieron = new List<Persona>();

        foreach (Reserva reserva in reservas){  
            if (reserva.EstadoAsistencia == Reserva.EstadoAsis.Presente){ //si asistio 
                Persona? persona = repoPersona.ObtenerPorId(reserva.PersonaId); // guarda a la persona
                if (persona != null){
                    personasAsistieron.Add(persona);//la agrega a la lista
                }
            }
        }
        return personasAsistieron; // devuelve la lista de personas que asistieron al evento
    }
}
