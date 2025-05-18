using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorReserva
{
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioReserva _repoReserva;

    public ValidadorReserva(IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
    {
        _repoPersona = repoPersona;
        _repoEvento = repoEvento;
        _repoReserva = repoReserva;
    }
public void Validar(Reserva reserva){
 if (_repoPersona.ObtenerPorId(reserva.PersonaId) == null)
            throw new EntidadNotFoundException("reserva",reserva.PersonaId);

 if (_repoEvento.ObtenerPorId(reserva.EventoDeportivoId) == null)
            throw new EntidadNotFoundException("Evento Deportivo", reserva.EventoDeportivoId);

 if (_repoReserva.ObtenerPorEventoYPersona(reserva.EventoDeportivoId, reserva.PersonaId).Any())
            throw new DuplicadoException("La persona ya está inscripta en este evento");

 if (_repoReserva.ObtenerPorEvento(reserva.EventoDeportivoId).Count()>= _repoEvento.ObtenerPorId(reserva.EventoDeportivoId)?.CupoMaximo)
            throw new CupoExcedidoException();
}
}
