using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaBajaUseCase(IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva, IServicioAutorizacion autorizacion)
{
public void Ejecutar(int personaId){
 if (!autorizacion.PoseeElPermiso( Permiso.UsuarioBaja))
      throw new FalloAutorizacionException("El usuario no tiene permiso para eliminar personas.");

  if (repoPersona.ObtenerPorId(personaId) == null)
      throw new EntidadNotFoundException(" No existe la persona");

  if (repoReserva.ObtenerPorPersona(personaId).Any())
        throw new OperacionInvalidaException("La persona tiene reservas.");

   if (repoEvento.Listar().Any(e => e.ResponsableId == personaId))
            throw new OperacionInvalidaException("La persona es responsable de eventos.");
   
   repoPersona.Eliminar(personaId);
}
}
