using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repoEvento, IServicioAutorizacion servicio, ValidadorEventoDeportivo validador)
{
public void Ejecutar(EventoDeportivo Evento, int idUsuario){
 if (!servicio.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
      throw new FalloAutorizacionException("El usuario no tiene permiso para modificar Eventos.");
  if (repoEvento.ObtenerPorId(Evento.Id) == null)
        throw new EntidadNotFoundException("Evento", Evento.Id);
    if (repoEvento.ObtenerPorId(Evento.Id)?.FechaHoraInicio < DateTime.Now)
        throw new OperacionInvalidaException("No se puede modificar un evento que ya ocurrió.");
 validador.Validar(Evento);
 repoEvento.Modificar(Evento);
  
}
}
