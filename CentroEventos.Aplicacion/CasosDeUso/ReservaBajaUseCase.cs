using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaBajaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion servicio)
{
public void Ejecutar(int reservaId, int idUsuario){
 if(!servicio.PoseeElPermiso(idUsuario, Permiso.ReservaBaja))
   throw new FalloAutorizacionException("El usuario no tiene permiso para dar de baja reservas.");

  repoReserva.Eliminar(reservaId);
}
}
