using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repoEvento, IServicioAutorizacion servicio, ValidadorEventoDeportivo validador, IRepositorioPersona repoPersona)
{
public void Ejecutar(EventoDeportivo evento){
  if (!servicio.PoseeElPermiso(Permiso.EventoAlta))
    throw new FalloAutorizacionException("El usuario no tiene permiso para dar de alta eventos.");
  if (!validador.ValidadorEvento(evento, out string mensajeError))
    throw new ValidacionException(mensajeError); 
  
   if (repoPersona.ObtenerPorId(evento.ResponsableId) == null)
      throw new EntidadNotFoundException("No existe la persona responsable");

   repoEvento.Agregar(evento);
}
}
