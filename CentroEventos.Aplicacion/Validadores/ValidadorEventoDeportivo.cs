using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorEventoDeportivo()
{
  public bool ValidadorEvento(EventoDeportivo Evento, out string mensajeError) {
    
      mensajeError = "";
      if (String.IsNullOrWhiteSpace(Evento.Nombre)){
        mensajeError += "Nombre no puede estar vacio.";
      }
      if (String.IsNullOrWhiteSpace(Evento.Descripcion)){
        mensajeError += "Descripcion no puede estar vacio.";
      }
      if (Evento.FechaHoraInicio < DateTime.Now) {
        mensajeError+= "La fecha y hora de inicio deben ser iguales o posteriores al momento actual."; 
      }
      if (Evento.CupoMaximo <= 0) {
        mensajeError += "El cupo máximo debe ser mayor que cero."; 
      }
      if (Evento.DuracionHoras <= 0) {
         mensajeError += "El cupo máximo debe ser mayor que cero.";
      }
      /*if (repositorioPersona.ObtenerPorId(Evento.ResponsableId) == null)
        throw new EntidadNotFoundException("Persona (Responsable)", Evento.ResponsableId);*/

    return mensajeError == "";
}
}