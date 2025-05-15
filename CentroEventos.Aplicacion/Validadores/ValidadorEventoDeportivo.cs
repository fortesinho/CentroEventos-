using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorEventoDeportivo
{
 private readonly IRepositorioPersona _repositorioPersona;
public ValidadorEventoDeportivo(IRepositorioPersona repositorioPersona){
  _repositorioPersona = repositorioPersona;
 }
 public void Validar(EventoDeportivo Evento){
 if(String.IsNullOrWhiteSpace(Evento.Nombre)){
   throw new ValidacionException("Nombre no puede estar vacio");
 }
  if(String.IsNullOrWhiteSpace(Evento.Descripcion)){
   throw new ValidacionException("Descripcion no puede estar vacio");
 }   
  if (Evento.FechaHoraInicio < DateTime.Now){
    throw new ValidacionException("La fecha y hora de inicio deben ser iguales o posteriores al momento actual.");
  }
  if (Evento.CupoMaximo <= 0){
    throw new ValidacionException("El cupo máximo debe ser mayor que cero.");
  }
   if (Evento.DuracionHoras <= 0){
    throw new ValidacionException("La duración del evento debe ser mayor que cero.");
   }
     
    
}
}
