using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repoEvento, IServicioAutorizacion servicio, ValidadorEventoDeportivo validador)
{
public void Ejecutar(EventoDeportivo evento){
  if (!servicio.PoseeElPermiso(Permiso.EventoAlta))
        throw new FalloAutorizacionException("El usuario no tiene permiso para dar de alta eventos.");
   
   validador.Validar(evento);
   repoEvento.Agregar(evento);
}
}
