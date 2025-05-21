using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorReserva(IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
{
   

public void Validar(Reserva reserva){
 if (repoPersona.ObtenerPorId(reserva.PersonaId) == null)
            throw new EntidadNotFoundException("reserva",reserva.PersonaId);

 if (repoEvento.ObtenerPorId(reserva.EventoDeportivoId) == null)
            throw new EntidadNotFoundException("Evento Deportivo", reserva.EventoDeportivoId);

 if (repoReserva.ObtenerPorEventoYPersona(reserva.EventoDeportivoId, reserva.PersonaId).Any())
            throw new DuplicadoException("La persona ya está inscripta en este evento");

 if (repoReserva.ObtenerPorEvento(reserva.EventoDeportivoId).Count()>= repoEvento.ObtenerPorId(reserva.EventoDeportivoId)?.CupoMaximo)
            throw new CupoExcedidoException();
}
}
