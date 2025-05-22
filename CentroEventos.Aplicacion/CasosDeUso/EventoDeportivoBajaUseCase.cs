using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva, IServicioAutorizacion servicio)
{
public void Ejecutar (int idEvento, int idUsuario){
if (!servicio.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
     throw new FalloAutorizacionException("No tiene permiso para eliminar eventos.");
 if (repoEvento.ObtenerPorId(idEvento) == null)
      throw new EntidadNotFoundException("Evento", idEvento);
var reservas = repoReserva.Listar();
  if (reservas.Any(r => r.EventoDeportivoId == idEvento))
     throw new OperacionInvalidaException("No se puede eliminar porque el evento tiene reservas asociadas.");
  repoEvento.Eliminar(idEvento);
}
}
