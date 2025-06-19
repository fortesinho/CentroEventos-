using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repoEvento, IServicioAutorizacion servicio, IValidadorEventoDeportivo validador)
{
public void Ejecutar(EventoDeportivo Evento){
    
  if (!servicio.PoseeElPermiso(Permiso.UsuarioModificacion))
            throw new FalloAutorizacionException("El usuario no tiene permiso para modificar Eventos.");
    
  if (repoEvento.ObtenerPorId(Evento.Id) == null)
            throw new EntidadNotFoundException("Evento no existe");
            
  if (repoEvento.ObtenerPorId(Evento.Id)?.FechaHoraInicio < DateTime.Now)
            throw new OperacionInvalidaException("No se puede modificar un evento que ya ocurrio.");
            
  if (!validador.ValidadorEvento(Evento, out string mensajeError))
            throw new ValidacionException(mensajeError); 

  

 repoEvento.Modificar(Evento);
  
}
}
