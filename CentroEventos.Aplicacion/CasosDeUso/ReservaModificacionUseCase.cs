using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaModificacionUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion servicio, ValidadorReserva validador)
{
public void Ejecutar(Reserva reserva, int idUsuario){
if (!servicio.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
      throw new FalloAutorizacionException("No tiene permiso para modificar Reservas.");
if (repoReserva.ObtenerPorId(reserva.Id) == null)
      throw new EntidadNotFoundException("Reserva", reserva.Id);
validador.Validar(reserva);
repoReserva.Modificar(reserva);
}
}
