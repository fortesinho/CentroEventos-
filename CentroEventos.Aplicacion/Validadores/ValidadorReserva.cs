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