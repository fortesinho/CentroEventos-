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
                mensajeError += "Id de la persona inválido.\n";

            if (reserva.EventoDeportivoId <= 0)
                mensajeError += "Id del evento deportivo inválido.\n";

            if (reserva.FechaAltaReserva == default(DateTime))
                mensajeError += "FechaAlta de la reserva inválida.\n";

            if (string.IsNullOrWhiteSpace(reserva.EstadoAsistencia + ""))
            {
                mensajeError += "Estado de la reserva invalido.\n";
            }

            return mensajeError == "";
        }
    }