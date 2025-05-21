using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaBajaUseCase(IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva, IServicioAutorizacion autorizacion)
{
public void Ejecutar(int personaId, int idUsuario){
 if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
      throw new FalloAutorizacionException("El usuario no tiene permiso para eliminar personas.");

  if (repoPersona.ObtenerPorId(personaId) == null)
      throw new EntidadNotFoundException("Persona", personaId);

}
}
