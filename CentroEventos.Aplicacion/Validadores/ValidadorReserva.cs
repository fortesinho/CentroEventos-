using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorReserva()
{
    public bool ValidarReserva(Reserva reserva, out string mensajeError)
    {
        mensajeError = "";

        if (reserva.PersonaId <= 0)
            mensajeError += "Id de la persona inválido.";

        if (reserva.EventoDeportivoId <= 0)
            mensajeError += "Id del evento deportivo inválido.";

        if (reserva.FechaAltaReserva == default(DateTime))
            mensajeError += "FechaAlta de la reserva inválida.";

        if (string.IsNullOrWhiteSpace(reserva.EstadoAsistencia + ""))
        {
            mensajeError += "Estado de la reserva invalido.";
        }
        return mensajeError == "";
    }
        
    }

    /*public class ValidadorReserva(IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
    {
            public void Validar(Reserva reserva){
            if (repoPersona.ObtenerPorId(reserva.PersonaId) == null)
                        throw new EntidadNotFoundException("reserva",reserva.PersonaId);

            if (repoEvento.ObtenerPorId(reserva.EventoDeportivoId) == null)
                        throw new EntidadNotFoundException("Evento Deportivo", reserva.EventoDeportivoId);

            if (repoReserva.Listar().Any(r => r.PersonaId == reserva.PersonaId &&  r.EventoDeportivoId == reserva.EventoDeportivoId))
                        throw new DuplicadoException("La persona ya está inscripta en este evento");

            if (repoReserva.ObtenerPorEvento(reserva.EventoDeportivoId).Count()>= repoEvento.ObtenerPorId(reserva.EventoDeportivoId)?.CupoMaximo)
                        throw new CupoExcedidoException();
            }
            }
    */