using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IValidadorReserva
{
    bool ValidarReserva(Reserva reserva, out string mensajeError);
}