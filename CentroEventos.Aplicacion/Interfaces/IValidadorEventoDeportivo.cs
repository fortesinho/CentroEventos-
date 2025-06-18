using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IValidadorEventoDeportivo
{
 public bool ValidadorEvento(EventoDeportivo Evento, out string mensajeError);
}